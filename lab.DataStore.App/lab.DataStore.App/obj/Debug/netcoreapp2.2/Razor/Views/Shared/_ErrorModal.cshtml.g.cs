#pragma checksum "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\Shared\_ErrorModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb31117766706124b06c2f9ba16f3e6dc9a8426a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ErrorModal), @"mvc.1.0.view", @"/Views/Shared/_ErrorModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ErrorModal.cshtml", typeof(AspNetCore.Views_Shared__ErrorModal))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb31117766706124b06c2f9ba16f3e6dc9a8426a", @"/Views/Shared/_ErrorModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf41cf225a788442bf760a550b28b93ca1d96873", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ErrorModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<lab.DataStore.App.ViewModels.ErrorPageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 245, true);
            WriteLiteral("<div id=\"errorPage\">\r\n    <div class=\"error-page\">\r\n        <div class=\"error-content\">\r\n            <h3>\r\n                <i class=\"fa fa-warning text-yellow\"></i>Oops! Something went wrong.\r\n            </h3>\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(302, 18, false);
#line 9 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\Shared\_ErrorModal.cshtml"
           Write(Model.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(320, 81, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n    </div>\r\n    <!-- /.error-page -->\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<lab.DataStore.App.ViewModels.ErrorPageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
