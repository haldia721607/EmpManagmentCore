using EmpManagmentBOL.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpManagmentBOL.ViewModels.UserArea.ViewModels
{
    public class ComplainantListViewModel
    {
        public IEnumerable<ComplainantAndDetailsViewModel> complainantAndDetailsViewModels { get; set; }
        public IEnumerable<BikeCategory> BikeCategory { get; set; }
    }
}
