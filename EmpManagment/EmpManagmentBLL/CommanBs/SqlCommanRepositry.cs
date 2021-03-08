using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpManagmentBOL.Tables;
using EmpManagmentBOL.ViewModels.CommanArea.ViewModels;
using EmpManagmentBOL.ViewModels.CommanAreaViewModels;
using EmpManagmentDAL.DbContextClass;
using EmpManagmentIBLL.ICommanRepositry;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpManagmentBLL.CommanBs
{
    public class SqlCommanRepositry : IAccountRepository
    {
        private readonly EmployeeDbContext DbContext;

        public SqlCommanRepositry(EmployeeDbContext employeeDbContext)
        {
            this.DbContext = employeeDbContext;
        }
        public IEnumerable<Country> CounteryList()
        {
            var allCountries = DbContext.Countries.Where(x => x.Status == true).ToList();
            if (allCountries.Count > 0)
            {
                return allCountries;
            }
            return null;
        }
        public IEnumerable<State> StateList(int countryId)
        {
            var getStateByCountry = DbContext.States.Where(x => x.CountryId == countryId && x.Status == true).ToList();
            if (getStateByCountry.Count > 0)
            {
                return getStateByCountry;
            }
            return null;
        }
        public IEnumerable<City> CityList(int stateId)
        {
            var getCityByState = DbContext.Cities.Where(x => x.StateId == stateId && x.Status == true).ToList();
            if (getCityByState.Count > 0)
            {
                return getCityByState;
            }
            return null;
        }
    }
}
