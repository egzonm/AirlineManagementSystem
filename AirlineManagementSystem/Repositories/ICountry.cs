using AirlineManagementSystem.Models;
using System.Collections.Generic;

namespace AirlineManagementSystem.Repositories
{
    public interface ICountry
    {
        IEnumerable<Country> GetCountry();
        Country GetCountryById(int countryId);
        void InsertCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(int countryId);
        void Dispose();
        void Save();
    }                   
}