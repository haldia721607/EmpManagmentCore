using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpManagmentBOL.ViewModels.UserArea.ViewModels
{
    public class ComplaientCategoryViewModel
    {
        public int ComplaientCategoryId { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage = "Complaient category description required")]
        [MaxLength(500,ErrorMessage ="Max length 100")]
        public string Description { get; set; }
        [Required (ErrorMessage = "Complaient category status required")]
        public bool Status { get; set; }
        public string UserStatus { get; set; }
    }
}
