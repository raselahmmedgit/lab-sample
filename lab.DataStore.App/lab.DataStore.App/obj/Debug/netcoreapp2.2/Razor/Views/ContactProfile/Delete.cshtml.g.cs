#pragma checksum "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4082cbd78de5664ed58a8e6a95ba009b7aebd6fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContactProfile_Delete), @"mvc.1.0.view", @"/Views/ContactProfile/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ContactProfile/Delete.cshtml", typeof(AspNetCore.Views_ContactProfile_Delete))]
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
#line 1 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\_ViewImports.cshtml"
using lab.DataStore.App;

#line default
#line hidden
#line 2 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\_ViewImports.cshtml"
using lab.DataStore.App.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4082cbd78de5664ed58a8e6a95ba009b7aebd6fa", @"/Views/ContactProfile/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf41cf225a788442bf760a550b28b93ca1d96873", @"/Views/_ViewImports.cshtml")]
    public class Views_ContactProfile_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<lab.DataStore.App.EntityModels.ContactProfile>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(98, 184, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>ContactProfile</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(283, 45, false);
#line 15 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(328, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(392, 41, false);
#line 18 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(433, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(496, 44, false);
#line 21 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(540, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(604, 40, false);
#line 24 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(644, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(707, 49, false);
#line 27 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PreferredName));

#line default
#line hidden
            EndContext();
            BeginContext(756, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(820, 45, false);
#line 30 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PreferredName));

#line default
#line hidden
            EndContext();
            BeginContext(865, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(928, 45, false);
#line 33 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AddressId));

#line default
#line hidden
            EndContext();
            BeginContext(973, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1037, 41, false);
#line 36 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AddressId));

#line default
#line hidden
            EndContext();
            BeginContext(1078, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1141, 51, false);
#line 39 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PrimaryPassword));

#line default
#line hidden
            EndContext();
            BeginContext(1192, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1256, 47, false);
#line 42 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PrimaryPassword));

#line default
#line hidden
            EndContext();
            BeginContext(1303, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1366, 49, false);
#line 45 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDeactivated));

#line default
#line hidden
            EndContext();
            BeginContext(1415, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1479, 45, false);
#line 48 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsDeactivated));

#line default
#line hidden
            EndContext();
            BeginContext(1524, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1587, 52, false);
#line 51 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ProfilePictureId));

#line default
#line hidden
            EndContext();
            BeginContext(1639, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1703, 48, false);
#line 54 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ProfilePictureId));

#line default
#line hidden
            EndContext();
            BeginContext(1751, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1814, 48, false);
#line 57 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EmailAllowed));

#line default
#line hidden
            EndContext();
            BeginContext(1862, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1926, 44, false);
#line 60 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EmailAllowed));

#line default
#line hidden
            EndContext();
            BeginContext(1970, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2033, 46, false);
#line 63 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SmsAllowed));

#line default
#line hidden
            EndContext();
            BeginContext(2079, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2143, 42, false);
#line 66 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SmsAllowed));

#line default
#line hidden
            EndContext();
            BeginContext(2185, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2248, 52, false);
#line 69 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RegistrationDate));

#line default
#line hidden
            EndContext();
            BeginContext(2300, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2364, 48, false);
#line 72 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.RegistrationDate));

#line default
#line hidden
            EndContext();
            BeginContext(2412, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2475, 47, false);
#line 75 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DateOfBirth));

#line default
#line hidden
            EndContext();
            BeginContext(2522, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2586, 43, false);
#line 78 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DateOfBirth));

#line default
#line hidden
            EndContext();
            BeginContext(2629, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2692, 48, false);
#line 81 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GenderTypeId));

#line default
#line hidden
            EndContext();
            BeginContext(2740, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2804, 44, false);
#line 84 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.GenderTypeId));

#line default
#line hidden
            EndContext();
            BeginContext(2848, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2911, 46, false);
#line 87 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsArchived));

#line default
#line hidden
            EndContext();
            BeginContext(2957, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3021, 42, false);
#line 90 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsArchived));

#line default
#line hidden
            EndContext();
            BeginContext(3063, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3126, 47, false);
#line 93 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3173, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3237, 43, false);
#line 96 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CreatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3280, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3343, 45, false);
#line 99 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3388, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3452, 41, false);
#line 102 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3493, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3556, 47, false);
#line 105 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3603, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3667, 43, false);
#line 108 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3710, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3773, 45, false);
#line 111 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3818, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3882, 41, false);
#line 114 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3923, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3986, 45, false);
#line 117 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(4031, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4095, 41, false);
#line 120 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(4136, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4199, 45, false);
#line 123 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(4244, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4308, 41, false);
#line 126 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(4349, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4412, 47, false);
#line 129 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedDate));

#line default
#line hidden
            EndContext();
            BeginContext(4459, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4523, 43, false);
#line 132 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DeletedDate));

#line default
#line hidden
            EndContext();
            BeginContext(4566, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(4604, 206, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4082cbd78de5664ed58a8e6a95ba009b7aebd6fa23625", async() => {
                BeginContext(4630, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(4640, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4082cbd78de5664ed58a8e6a95ba009b7aebd6fa24018", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 137 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4676, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(4759, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4082cbd78de5664ed58a8e6a95ba009b7aebd6fa25959", async() => {
                    BeginContext(4781, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4797, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4810, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<lab.DataStore.App.EntityModels.ContactProfile> Html { get; private set; }
    }
}
#pragma warning restore 1591