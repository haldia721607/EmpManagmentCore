#pragma checksum "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\Complaient\ListCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c14319c10f82f0216b4bb5c0f3962bed484c555"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Complaient_ListCategory), @"mvc.1.0.view", @"/Areas/User/Views/Complaient/ListCategory.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Razor.TagHelpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\_ViewImports.cshtml"
using EmpManagmentBOL.ViewModels.UserArea.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\_ViewImports.cshtml"
using EmpManagmentBOL.ViewModels.UserArea.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\_ViewImports.cshtml"
using EmpManagmentBOL.Tables;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\_ViewImports.cshtml"
using EmpManagment;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c14319c10f82f0216b4bb5c0f3962bed484c555", @"/Areas/User/Views/Complaient/ListCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"294e41710238c1401e7b121627c2f842a45ed4a9", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_Complaient_ListCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ComplaientCategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Complaient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/dataTables/datatables.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("names", "Development,Staging,Production", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/dataTables/datatables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/dataTables/dataTables.bootstrap4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\Complaient\ListCategory.cshtml"
  
    ViewBag.Title = "Complaient Category";
    var projectName = Startup.StaticConfig["SolutionProjectName"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row wrapper border-bottom white-bg page-heading\">\r\n    <div class=\"col-lg-10\">\r\n        <h2>Complaient Category Lists</h2>\r\n        <ol class=\"breadcrumb\">\r\n            <li class=\"breadcrumb-item\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c14319c10f82f0216b4bb5c0f3962bed484c5559003", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </li>
            <li class=""breadcrumb-item"">
                <a>Complaient Category</a>
            </li>
            <li class=""active breadcrumb-item"">
                <strong>Category Lists</strong>
            </li>
        </ol>
    </div>
    <div class=""col-lg-2"">

    </div>
</div>

<div class=""wrapper wrapper-content animated fadeInRight"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""ibox "">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c14319c10f82f0216b4bb5c0f3962bed484c55511060", async() => {
                WriteLiteral("<i class=\"fa fa-plus\"></i> Add New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <button type=""submit"" id=""btnDeleteMultipaleCategory"" class=""btn btn-danger"">Delete Multipale Category</button>
                <div class=""ibox-title"">
                    <h5>Complaient Category Lists</h5>
                </div>
                <div class=""ibox-content"">
                    <table id=""tblCategoryList"" class=""table table-striped table-bordered table-hover dataTables-example"">
                        <thead>
                            <tr>
                                <th>Select</th>
                                <th>Description</th>
                                <th>userStatus</th>
                                <th></th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c14319c10f82f0216b4bb5c0f3962bed484c55513711", async() => {
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1c14319c10f82f0216b4bb5c0f3962bed484c55513993", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Names = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c14319c10f82f0216b4bb5c0f3962bed484c55516365", async() => {
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c14319c10f82f0216b4bb5c0f3962bed484c55516647", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c14319c10f82f0216b4bb5c0f3962bed484c55517807", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Names = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script type=""text/javascript"">
        var datatable = $(""#tblCategoryList"").DataTable();
        $(document).ready(function () {
            bindCategoryList();
            chkFun();
            deleteMultipleCategory();
        });

        //Checkbox cheked and unchecked function
        function chkFun() {
            $('#tblCategoryList').on('click', '#chkAll', function () {
                $('input:checkbox').not(this).prop('checked', this.checked);
            });
            $('#tblCategoryList').on('click', '#chk', function () {
                var len = $(""#tblCategoryList input[name='chk']"").length;
                var chkLen = $(""#tblCategoryList input[name='chk']:checked"").length;
                if (len == chkLen) {
                    $(""#tblCategoryList #chkAll"").not(this).prop('checked',""checked"");
                } else {
                    $(""#tblCategoryList #chkAll"").prop(""checked"",false)
                }
            });
        }

        //Bind all cat");
                WriteLiteral("egory\r\n        function bindCategoryList() {\r\n                $.ajax({\r\n                type: \'GET\',\r\n                url: \'/");
#nullable restore
#line 93 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\Complaient\ListCategory.cshtml"
                  Write(projectName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/User/Complaient/GetAllCategoryList',
                dataType: ""json"",
                    success: function (DBdata) {
                        datatable.destroy();
                        datatable= $(""#tblCategoryList"").DataTable({
                        destroy:true,
                        data: DBdata,
                        searching: true,
                        ordering: true,
                        pagingType: ""full_numbers"",
                            ""columns"": [
                                {
                                    title: "" <input type='checkbox' name='chkAll' class='chkAllClass' id='chkAll' value=''/>"", ""data"": ""complaientCategoryId"", ""render"": function (data) {
                                        return "" <input type='checkbox' name='chk' class='chkClass' id='chk' value="" + data+"" />"";
                                    },
                                     ""orderable"": false,
                                    ""searchable"": false,
                 ");
                WriteLiteral(@"                   ""width"": ""150px""
                                },
                            { ""data"": ""description"" },
                            { title:""Status"", ""data"": ""userStatus"" },
                            {
                                ""data"": ""complaientCategoryId"", ""render"": function (data) {
                                    return ""<a class='btn btn-default btn-sm' href='");
#nullable restore
#line 116 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\Complaient\ListCategory.cshtml"
                                                                               Write(Url.Action("EditCategory", "Complaient",new { area="User"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id="" + data + ""')><i class='fa fa-pencil'></i> Edit</a> <a class='btn btn-danger btn-sm' style='margin-left:5px' onclick=Delete(""+data+"")><i class='fa fa-trash'></i> Delete</a>"";
                                },
                                ""orderable"": false,
                                ""searchable"": false,
                                ""width"": ""150px""
                            }

                        ],
                        ""language"": {

                            ""emptyTable"": ""No data found, Please click on <b>Add New</b> Button""
                        }
                    });
                    },
                    error: function (xmlHttpRequest, errorText, thrownError) {
                        alert(xmlHttpRequest, errorText, thrownError);
                    }
            });
        }

        //Delete Category function
        function Delete(complaientCategoryId) {
            if(confirm('Are You Sure to Delete this Employee Record ?'))
          ");
                WriteLiteral("  {\r\n                $.ajax({\r\n                    type: \"POST\",\r\n                    url: \'");
#nullable restore
#line 142 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\Complaient\ListCategory.cshtml"
                     Write(Url.Action("Delete", "Complaient",new { area="User"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/' + complaientCategoryId,
                    success: function (data) {
                        if (data.success)
                        {
                            bindCategoryList();
                            toastr.success(message = data.message, title = 'Deleted')
                        }
                    },
                    error: function (xmlHttpRequest, errorText, thrownError) {
                        alert(xmlHttpRequest, errorText, thrownError);
                    }
                });
            }
        }

        function deleteMultipleCategory(){
            $(""#btnDeleteMultipaleCategory"").click(function(){
                var checkedCheckboxValue = new Array();
                var count = $(""#tblCategoryList input[name='chk']:checked"").length;
                if (count == 0) {
                    alert(""No rows selected to delete"");
                    return false;
                }
                else {
                     $(""#tblCategoryList input");
                WriteLiteral(@"[name='chk']:checked"").each(function () {
                         checkedCheckboxValue.push($(this).attr('value'));
                     });
                }

                if (confirm('Are You Sure to Delete ' + count+' selected categorys ?')){
                        $.ajax({
                            type: 'POST',
                            url: '");
#nullable restore
#line 174 "D:\DotNetCoreProjects\EmpManagment\EmpManagment\Areas\User\Views\Complaient\ListCategory.cshtml"
                             Write(Url.Action("MultipleCategoryDelete", "Complaient",new { area="User"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                            data: { ids: checkedCheckboxValue },
                            success: function (data) {
                                if (data.success)
                                {
                                    bindCategoryList();
                                    toastr.success(message = data.message, title = 'Deleted')
                                }
                                else {
                                    toastr.warning(message = data.message, title = 'Not Deleted')
                                }
                            },
                            error: function (xmlHttpRequest, errorText, thrownError) {
                                alert(xmlHttpRequest, errorText, thrownError);
                            }
                    });
                }
            });
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ComplaientCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
