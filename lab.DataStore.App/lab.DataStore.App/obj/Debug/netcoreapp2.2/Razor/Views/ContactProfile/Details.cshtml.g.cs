#pragma checksum "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdc78030856784c1d8cda07a8dc3f3fce6695588"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContactProfile_Details), @"mvc.1.0.view", @"/Views/ContactProfile/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ContactProfile/Details.cshtml", typeof(AspNetCore.Views_ContactProfile_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdc78030856784c1d8cda07a8dc3f3fce6695588", @"/Views/ContactProfile/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf41cf225a788442bf760a550b28b93ca1d96873", @"/Views/_ViewImports.cshtml")]
    public class Views_ContactProfile_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<lab.DataStore.App.EntityModels.ContactProfile>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(99, 137, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>ContactProfile</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(237, 45, false);
#line 14 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(282, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(346, 41, false);
#line 17 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(387, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(450, 44, false);
#line 20 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(494, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(558, 40, false);
#line 23 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(598, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(661, 49, false);
#line 26 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PreferredName));

#line default
#line hidden
            EndContext();
            BeginContext(710, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(774, 45, false);
#line 29 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.PreferredName));

#line default
#line hidden
            EndContext();
            BeginContext(819, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(882, 45, false);
#line 32 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AddressId));

#line default
#line hidden
            EndContext();
            BeginContext(927, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(991, 41, false);
#line 35 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.AddressId));

#line default
#line hidden
            EndContext();
            BeginContext(1032, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1095, 51, false);
#line 38 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PrimaryPassword));

#line default
#line hidden
            EndContext();
            BeginContext(1146, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1210, 47, false);
#line 41 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.PrimaryPassword));

#line default
#line hidden
            EndContext();
            BeginContext(1257, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1320, 49, false);
#line 44 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDeactivated));

#line default
#line hidden
            EndContext();
            BeginContext(1369, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1433, 45, false);
#line 47 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsDeactivated));

#line default
#line hidden
            EndContext();
            BeginContext(1478, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1541, 52, false);
#line 50 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProfilePictureId));

#line default
#line hidden
            EndContext();
            BeginContext(1593, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1657, 48, false);
#line 53 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProfilePictureId));

#line default
#line hidden
            EndContext();
            BeginContext(1705, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1768, 48, false);
#line 56 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EmailAllowed));

#line default
#line hidden
            EndContext();
            BeginContext(1816, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1880, 44, false);
#line 59 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.EmailAllowed));

#line default
#line hidden
            EndContext();
            BeginContext(1924, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1987, 46, false);
#line 62 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SmsAllowed));

#line default
#line hidden
            EndContext();
            BeginContext(2033, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2097, 42, false);
#line 65 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.SmsAllowed));

#line default
#line hidden
            EndContext();
            BeginContext(2139, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2202, 52, false);
#line 68 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RegistrationDate));

#line default
#line hidden
            EndContext();
            BeginContext(2254, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2318, 48, false);
#line 71 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.RegistrationDate));

#line default
#line hidden
            EndContext();
            BeginContext(2366, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2429, 47, false);
#line 74 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateOfBirth));

#line default
#line hidden
            EndContext();
            BeginContext(2476, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2540, 43, false);
#line 77 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateOfBirth));

#line default
#line hidden
            EndContext();
            BeginContext(2583, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2646, 48, false);
#line 80 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GenderTypeId));

#line default
#line hidden
            EndContext();
            BeginContext(2694, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2758, 44, false);
#line 83 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.GenderTypeId));

#line default
#line hidden
            EndContext();
            BeginContext(2802, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2865, 46, false);
#line 86 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsArchived));

#line default
#line hidden
            EndContext();
            BeginContext(2911, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2975, 42, false);
#line 89 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsArchived));

#line default
#line hidden
            EndContext();
            BeginContext(3017, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3080, 47, false);
#line 92 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3127, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3191, 43, false);
#line 95 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3234, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3297, 45, false);
#line 98 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3342, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3406, 41, false);
#line 101 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3447, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3510, 47, false);
#line 104 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3557, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3621, 43, false);
#line 107 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3664, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3727, 45, false);
#line 110 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3772, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3836, 41, false);
#line 113 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3877, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3940, 45, false);
#line 116 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(3985, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4049, 41, false);
#line 119 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(4090, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4153, 45, false);
#line 122 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(4198, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4262, 41, false);
#line 125 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(4303, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(4366, 47, false);
#line 128 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedDate));

#line default
#line hidden
            EndContext();
            BeginContext(4413, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(4477, 43, false);
#line 131 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
       Write(Html.DisplayFor(model => model.DeletedDate));

#line default
#line hidden
            EndContext();
            BeginContext(4520, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(4567, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdc78030856784c1d8cda07a8dc3f3fce669558822925", async() => {
                BeginContext(4613, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 136 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\ContactProfile\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4621, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(4629, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdc78030856784c1d8cda07a8dc3f3fce669558825283", async() => {
                BeginContext(4651, 12, true);
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
            BeginContext(4667, 10, true);
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