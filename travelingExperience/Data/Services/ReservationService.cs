using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using travelingExperience.Data;
using travelingExperience.DbConnetion;
using travelingExperience.Entity;
using travelingExperience.Models;

public class ReservationService
{
    private readonly AppDbContext _db;

    public ReservationService(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    public List<Reserve> GetReservationsForUser(string userId)
    {
        // Replace with your actual logic to retrieve reservations for a user
        return _db.Reserves
            .Where(r => r.UserID == userId)
            .Include(r => r.Travel) // Include related Travel data if needed
            .ToList();
    }

    public void AddReservation(Reserve reservation)
    {
        // Add your validation or additional logic as needed before adding a reservation

        _db.Reserves.Add(reservation);
        _db.SaveChanges();
    }

    // Add other methods as needed, such as UpdateReservation, DeleteReservation, etc.
}
