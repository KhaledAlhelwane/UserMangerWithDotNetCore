#pragma checksum "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\IdentityRoles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b68dd3d04456c400402201ac85cdd33667d30ef5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IdentityRoles_Index), @"mvc.1.0.view", @"/Views/IdentityRoles/Index.cshtml")]
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
#line 1 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\_ViewImports.cshtml"
using IdentityLearning;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\_ViewImports.cshtml"
using IdentityLearning.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\_ViewImports.cshtml"
using IdentityLearning.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b68dd3d04456c400402201ac85cdd33667d30ef5", @"/Views/IdentityRoles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"971940ad75004ffe2dd5a98e213ed303825110df", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_IdentityRoles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_AddingRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\IdentityRoles\Index.cshtml"
  
	ViewData["Title"] = "Roles";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Roles</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b68dd3d04456c400402201ac85cdd33667d30ef54684", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 9 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\IdentityRoles\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new  RolesFormViewModel();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<table class=\"tabel table-striped mt-4\">\r\n\t<thead >\r\n\t\t<tr class=\"bg-primary text-white\">\r\n\t\t<th>Id</th>\r\n\t\t<th>Name</th>\r\n\t</tr>\r\n\t\r\n\t</thead>\r\n\t<tbody>\r\n");
#nullable restore
#line 19 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\IdentityRoles\Index.cshtml"
             foreach(var x in Model)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t<td>");
#nullable restore
#line 22 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\IdentityRoles\Index.cshtml"
               Write(x.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t");
#nullable restore
#line 24 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\IdentityRoles\Index.cshtml"
           Write(x.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 26 "C:\Users\khale\Desktop\usermanger\UserMangerWithDotNetCore\IdentityLearning\IdentityLearning\Views\IdentityRoles\Index.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\r\n\t</tbody>\r\n</table>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b68dd3d04456c400402201ac85cdd33667d30ef57779", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591