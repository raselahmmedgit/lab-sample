#pragma checksum "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\Account\ForgotPasswordConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58c4f75e00fb2ec4815c9fc1e39525a5c7cdb801"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ForgotPasswordConfirmation), @"mvc.1.0.view", @"/Views/Account/ForgotPasswordConfirmation.cshtml")]
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
#line 1 "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\_ViewImports.cshtml"
using AeonicTech.TestApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\_ViewImports.cshtml"
using AeonicTech.TestApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58c4f75e00fb2ec4815c9fc1e39525a5c7cdb801", @"/Views/Account/ForgotPasswordConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c48d50ad73516f394a10f2f079a3c35b7fcbb59f", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ForgotPasswordConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\Account\ForgotPasswordConfirmation.cshtml"
  
    ViewData["Title"] = "Forgot Password Confirmation";
    Layout = "~/Views/Shared/_LayoutLogin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12 mt-6"">
        <div class=""form-signin text-center"">
            <h1 class=""mb-3 font-weight-normal"">Forgot password confirmation</h1>
            <div class=""form-group mb-3"">
                <p>Please check your email to reset your password.</p>
            </div>
            <div class=""form-group mb-3"">
                <div class=""row"">
                    <div class=""col-12 text-left"">
                        <a");
            BeginWriteAttribute("href", " href=\"", 589, "\"", 646, 1);
#nullable restore
#line 16 "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\Account\ForgotPasswordConfirmation.cshtml"
WriteAttributeValue("", 596, Url.Action("Login", "Account", new { Area = "" }), 596, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"txt3\">\r\n                            Back to log in\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
