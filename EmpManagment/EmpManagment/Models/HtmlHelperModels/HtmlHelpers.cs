using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagment.HtmlHelperModels
{
    public static class HtmlHelpers
    {
        //public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string cssClass = null)
        //{
        //    if (String.IsNullOrEmpty(cssClass))
        //        cssClass = "active";

        //    string currentAction = (string)html.ViewContext.RouteData.Values["action"];
        //    string currentController = (string)html.ViewContext.RouteData.Values["controller"];

        //    if (String.IsNullOrEmpty(controller))
        //        controller = currentController;

        //    if (String.IsNullOrEmpty(action))
        //        action = currentAction;

        //    return controller == currentController && action == currentAction ?
        //        cssClass : String.Empty;
        //}
        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
    //[HtmlTargetElement("Custom-TagHelper")]
    //public class HtmlHelpers : TagHelper
    //{
    //    public string Name { get; set; }
    //    public string ActionName(IActionContextAccessor actionContext)
    //    {
    //        var rd = actionContext.ActionContext.RouteData;
    //        //string currentController = rd.Values["controller"].ToString();
    //        string currentAction = rd.Values["action"].ToString();
    //        return Name = currentAction; 
    //    }
    //}
}
