#pragma checksum "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e520e7c70be03c1a8400c96b44309c5022a86a91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\_ViewImports.cshtml"
using WebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\_ViewImports.cshtml"
using WebClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e520e7c70be03c1a8400c96b44309c5022a86a91", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74eabcf7e030352eff2473b217adffa5ad5752fa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebClient.Models.CustomerRepository.Customer>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    int rowcount = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e520e7c70be03c1a8400c96b44309c5022a86a914092", async() => {
                WriteLiteral("Create New Customer");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</h2>\r\n\r\n\r\n\r\n<table class=\"table table-bordered\">\r\n    <tr>\r\n        <th>#</th>\r\n        <th>Name</th>\r\n        <th>Family</th>\r\n        <th>Email</th>\r\n        <th>Phone</th>\r\n    </tr>\r\n");
#nullable restore
#line 21 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
           Write(rowcount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
           Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
           Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
           Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td></td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 688, "\"", 722, 2);
            WriteAttributeValue("", 695, "/Home/Edit/", 695, 11, true);
#nullable restore
#line 31 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
WriteAttributeValue("", 706, item.CustomerId, 706, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Edit</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 776, "\"", 812, 2);
            WriteAttributeValue("", 783, "/Home/Delete/", 783, 13, true);
#nullable restore
#line 32 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
WriteAttributeValue("", 796, item.CustomerId, 796, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a>\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 36 "C:\Users\pc\Source\Repos\Projects  RelatdTo Working\EshopAPI\WebClient\Views\Home\Index.cshtml"
        rowcount++;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebClient.Models.CustomerRepository.Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591