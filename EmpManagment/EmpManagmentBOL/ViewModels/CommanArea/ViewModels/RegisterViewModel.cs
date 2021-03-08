using EmpManagment.Areas.Comman.CustomValidation;
using EmpManagmentBOL.Tables;
using EmpManagmentBOL.ViewModels.CommanArea.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace EmpManagmentBOL.ViewModels.CommanAreaViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            this.Countries = new List<SelectListItem>();
            this.States = new List<SelectListItem>();
            this.Cities = new List<SelectListItem>();
            //this.countryViewModels = new List<Country>();
            //this.stateViewModels = new List<State>();
            //this.cityViewModels = new List<City>();
        }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please fill name")]
        [MaxLength(50,ErrorMessage ="Max length 50 char.")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please fill name")]
        [MaxLength(50, ErrorMessage = "Max length 50 char.")]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account",areaName:"Comman")]
        [ValidEmailDomain(allowedDomain: "gmail.com", ErrorMessage = "Email domain must be gmail.com")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please fill password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please fill confirm password.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passord and confirm password does not match.")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please select country.")]
        public int countryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select state.")]
        public int stateId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select city.")]
        public int cityId { get; set; }


        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Cities { get; set; }

        //[Required(AllowEmptyStrings =false,ErrorMessage ="Please select country")]
        //public IEnumerable<Country> countryViewModels { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please select state")]
        //public IEnumerable<State> stateViewModels { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please select city")]
        //public IEnumerable<City> cityViewModels { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please check terms and policy")]
        public bool TermsAndPolicy { get; set; }

    }
}
