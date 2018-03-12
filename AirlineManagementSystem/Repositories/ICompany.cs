using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineManagementSystem.Models;

namespace AirlineManagementSystem.Repositories
{
    public interface ICompany
    {
        IEnumerable<Companies> GetCompany();
        Companies GetCompaniesById(int companyId);
        void InsertCompany(Companies comp);
        void UpdateCompany(Companies comp);
        void DeleteCompany(int companyId);
        void Dispose();
        void Save();
    }
}
