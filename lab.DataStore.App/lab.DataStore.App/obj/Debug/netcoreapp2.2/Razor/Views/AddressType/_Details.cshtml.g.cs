#pragma checksum "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\AddressType\_Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a59547cb78c567abad17b8835b5cf4bb2aaf49b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AddressType__Details), @"mvc.1.0.view", @"/Views/AddressType/_Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AddressType/_Details.cshtml", typeof(AspNetCore.Views_AddressType__Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a59547cb78c567abad17b8835b5cf4bb2aaf49b", @"/Views/AddressType/_Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf41cf225a788442bf760a550b28b93ca1d96873", @"/Views/_ViewImports.cshtml")]
    public class Views_AddressType__Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<lab.DataStore.App.PageViewModels.AddressTypePageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(66, 758, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a59547cb78c567abad17b8835b5cf4bb2aaf49b4141", async() => {
                BeginContext(123, 83, true);
                WriteLiteral("\r\n\r\n    <div class=\"form-body\">\r\n        <div class=\"form-group row\">\r\n            ");
                EndContext();
                BeginContext(207, 90, false);
#line 6 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\AddressType\_Details.cshtml"
       Write(Html.LabelFor(model => model.TypeName, new { @class = "col-md-4 col-sm-4 control-label" }));

#line default
#line hidden
                EndContext();
                BeginContext(297, 141, true);
                WriteLiteral("\r\n            <div class=\"col-md-8 col-sm-8\">\r\n                <input type=\"text\" id=\"TypeName\" class=\"form-control\" name=\"TypeName\" readonly");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 438, "\"", 461, 1);
#line 8 "C:\Users\rasel\Documents\GitHub\lab-sample\lab.DataStore.App\lab.DataStore.App\Views\AddressType\_Details.cshtml"
WriteAttributeValue("", 446, Model.TypeName, 446, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(462, 355, true);
                WriteLiteral(@">
            </div>
        </div>

        <div class=""form-actions"">
            <div class=""row"">
                <div class=""col-md-12 col-sm-12"">
                    <input type=""button"" class=""btn btn-danger"" value=""Cancel"" onclick=""AppModal.CloseCommonModal();"" />
                </div>
            </div>
        </div>
    </div>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(824, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<lab.DataStore.App.PageViewModels.AddressTypePageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591