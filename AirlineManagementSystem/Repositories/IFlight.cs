using AirlineManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem.Repositories
{
    public interface IFlight
    {
        IEnumerable<Flights> GetFlights();
        Flights GetFlightById(int flightId);
        void InsertFlight(Flights flight);
        void UpdateFlight(Flights flight);
        void DeleteFlight(int flightId);
        void Dispose();
        void Save();
    }
}
