#pragma checksum "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\AddressType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d83376bdcb42b3636cc5cdeff71928ee2d02742b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AddressType_Index), @"mvc.1.0.view", @"/Views/AddressType/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d83376bdcb42b3636cc5cdeff71928ee2d02742b", @"/Views/AddressType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c48d50ad73516f394a10f2f079a3c35b7fcbb59f", @"/Views/_ViewImports.cshtml")]
    public class Views_AddressType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/addresstype.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\AddressType\Index.cshtml"
  
    ViewData["Title"] = "Address Type";
    ViewData["SubTitle"] = "Address Type";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row mb-4\">\r\n    <div class=\"col-10\">\r\n        <h1 class=\"f-26\">");
#nullable restore
#line 9 "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\AddressType\Index.cshtml"
                    Write(ViewData["SubTitle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n    <div class=\"col-2 text-right\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 302, "\"", 361, 1);
#nullable restore
#line 12 "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\AddressType\Index.cshtml"
WriteAttributeValue("", 309, Url.Action("Add", "AddressType", new { Area = "" }), 309, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"Add\" class=\"btn btn-primary\">Add New</a>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\rasel\Documents\GitHub\lab-sample\AeonicTech.TestApp\AeonicTech.TestApp\Views\AddressType\Index.cshtml"
Write(Html.RenderAlert("AddressTypeMessage"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-body"">
                <table id=""dataTablesAddressType"" class=""table table-hover"" style=""width:100%""></table>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d83376bdcb42b3636cc5cdeff71928ee2d02742b5864", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(document).ready(function () {\r\n            AddressType.LoadDataTables(\'dataTablesAddressType\', App.DisplayLength(), (\"/AddressType/GetDataAsync\"));\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
