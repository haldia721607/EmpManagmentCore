using EmpManagmentBOL.Tables;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmpManagmentBOL.ViewModels.UserArea.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
            this.Countries = new List<SelectListItem>();
            this.States = new List<SelectListItem>();
            this.Cities = new List<SelectListItem>();
        }

        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [Required]
        public virtual Country Country { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        [Required]
        public virtual State State { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        [Required]
        public virtual City City { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}
