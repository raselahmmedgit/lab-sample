#pragma checksum "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a436b88822ac1d0e52eff0d15c258a9ad8aa283"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error.cshtml", typeof(AspNetCore.Views_Shared_Error))]
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
using lab.DataStore.App.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a436b88822ac1d0e52eff0d15c258a9ad8aa283", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca3a9db8caf0bd9c4caf825b7922bf20bd387449", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<lab.DataStore.App.Models.ErrorPageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Oops! Error";
    Layout = "~/Views/Shared/_LayoutError.cshtml";

#line default
#line hidden
            BeginContext(151, 486, true);
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card"">
            <div class=""card-body"">
                <div id=""errorPage"">
                    <div class=""error-page"">
                        <div class=""error-content"">
                            <h3>
                                <i class=""fa fa-warning text-yellow""></i>Oops! Something went wrong.
                            </h3>
                            <p>
                                ");
            EndContext();
            BeginContext(638, 18, false);
#line 17 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\Shared\Error.cshtml"
                           Write(Model.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(656, 219, true);
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /.error-page -->\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<lab.DataStore.App.Models.ErrorPageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
