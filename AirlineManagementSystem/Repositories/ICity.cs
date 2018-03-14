using AirlineManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem.Repositories
{
    public interface ICity
    {
        IEnumerable<Cities> GetCity();
        Cities GetCityById(int cityId);
        void InsertCity(Cities city);
        void UpdateCity(Cities city);
        void DeleteCity(int cityId);
        void Dispose();
        void Save();
    }
}
