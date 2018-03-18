using AirlineManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem.Repositories
{
    public interface IReservation
    {
        IEnumerable<Reservation> GetReservation();
        Reservation GetReservationById(int reservationId);
        void InsertReservation(Reservation res);
        void UpdateReservation(Reservation res);
        void DeleteReservation(int reservationId);
        void Dispose();
        void Save();
    }
}
