using EmpManagmentBOL.Tables;
using EmpManagmentBOL.ViewModels.CommanArea.ViewModels;
using EmpManagmentBOL.ViewModels.CommanAreaViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagmentIBLL.ICommanRepositry
{
    public interface IAccountRepository
    {
        IEnumerable<Country> CounteryList();
        IEnumerable<State> StateList(int counteryId);
        IEnumerable<City> CityList(int stateId);
    }
}
