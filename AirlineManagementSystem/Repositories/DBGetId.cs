using AirlineManagementSystem.Models;

namespace AirlineManagementSystem.Repositories
{
    public abstract class DBGetId
    {
        public abstract Companies GetCompaniesById(int companyId);
         
    }
}