﻿using System.ComponentModel;
using AutoMapper;
using Domain.Entities;
using Persistance;
using Persistance.Repositories;
using Persistance.Repositories.Booking;

namespace Application.Servicies;

public class BookingService
{
    private readonly IMedcToPharmRepo _medcToPharmRepo;
    private readonly IBookingRepo _bookingRepo;
    private readonly AppDbContext _context;
    private static List<MedcToPharm> medcToPharmList = new List<MedcToPharm>();

    private static MapperConfiguration bookingConfig = new MapperConfiguration(cfg => cfg.CreateMap<CartDto, Booking>()
        .ForMember(booking => booking.UserId, act => act.MapFrom(cart => cart.UserId))
        .ForMember(booking => booking.BookingDate, act => act.MapFrom(cart => DateTime.Now))
        .ForMember(booking => booking.Status, act => act.MapFrom(cart => "Processing"))
        .ForMember(booking => booking.TotalPrice, act => act.MapFrom(cart => cart.Price))
        .ForMember(booking => booking.Orders, act => act.MapFrom(cart =>
        cart.MedcList.Select(medc => new Order()
            {
                MedcToPharmId = medcToPharmList
                    .FirstOrDefault(m => m.MedcId == medc.MedcId
                                         && m.DoseId == medc.DoseId
                                         && m.PharmId == cart.PharmId)!.Id,
                Amount = medc.Amount
            }
        ).ToList())
    ));

    private static MapperConfiguration historyConfig = new MapperConfiguration(cfg => cfg
        .CreateMap<Booking, HistoryDto>()
        .ForMember(history => history.OrderId, act => act.MapFrom(booking => booking.Id))
        .ForMember(history => history.UserId, act => act.MapFrom(booking => booking.UserId))
        .ForMember(history => history.OrderDate, act => act.MapFrom(booking => booking.BookingDate))
        .ForMember(history => history.PharmacyTitle, act => act.MapFrom(booking => 
            booking.Orders.FirstOrDefault().MedcToPharm.Pharmacy.Name))
        .ForMember(history => history.MedcList, act => act.MapFrom(booking =>
            booking.Orders.Select(order => new MedInCartDto()
            {
                medcTitle = order.MedcToPharm.Medicine.Name,
                package = order.MedcToPharm.Doses.Package,
                amount = order.Amount,
                price = order.MedcToPharm.Price
            })
            ))
        .ForMember(history => history.Status, act => act.MapFrom(booking => booking.Status))
        .ForMember(history => history.TotalPrice, act => act.MapFrom(booking => booking.TotalPrice)));
            
    
    private Mapper bookingMapper = new Mapper(bookingConfig);
    private Mapper historyMapper = new Mapper(historyConfig);

    public BookingService(IMedcToPharmRepo medcToPharmRepo, IBookingRepo bookingRepo, AppDbContext context)
    {
        _medcToPharmRepo = medcToPharmRepo;
        _bookingRepo = bookingRepo;
        _context = context;
        medcToPharmList = _medcToPharmRepo.GetAllMedsToPharm();
    }
    
    public async Task bookOrder(CartDto order)
    {
        Booking booking = bookingMapper.Map<CartDto, Booking>(order);
        await _bookingRepo.saveOrder(booking);
    }

    public async Task<List<HistoryDto>> showHistory(int userId)
    {
        return (await _bookingRepo.getBookingByUser(userId))
            .Select(booking => historyMapper.Map<Booking,HistoryDto>(booking))
            .ToList();
    }

    public async Task<List<HistoryDto>> showOrders()
    {
        return (await _bookingRepo.getAllUsersBooking())
            .Select(booking => historyMapper.Map<Booking,HistoryDto>(booking))
            .ToList();
    }
    
    public async Task changeStatusAsync(int bookingId)
    {
        var booking = (await _bookingRepo
            .getOrderDataAsync(bookingId));

        if (booking.Status == "Processing")
        {
            try
            {
                foreach (var order in booking.Orders)
                {
                    var orderAmount = order.Amount;
                    var inStock = order.MedcToPharm.Amount;
                    if (orderAmount <= inStock)
                    {
                        _context.MedcToPharms.Attach(order.MedcToPharm);
                        order.MedcToPharm.Amount = inStock - orderAmount;
                    }
                    else
                    {
                        throw new OrderAmountException();
                    }
                }

                _context.Bookings.Attach(booking);
                booking.Status = "Approved";
            }
            catch (OrderAmountException ex)
            {
                foreach (var order in booking.Orders)
                {
                    await _context.Entry(order.MedcToPharm).ReloadAsync();
                }

                _context.Bookings.Attach(booking);
                booking.Status = "Cancelled";
            }
            finally
            {
                await _context.SaveChangesAsync();
            }
            
            
        }

    }
}