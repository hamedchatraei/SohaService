#pragma checksum "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c60bcd1f1db6d9051705b671de1c25522ed350d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Unit_InformationUnit), @"mvc.1.0.view", @"/Views/Unit/InformationUnit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c60bcd1f1db6d9051705b671de1c25522ed350d", @"/Views/Unit/InformationUnit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Unit_InformationUnit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SohaService.DataLayer.Entities.Unit.Unit>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("disabled", new global::Microsoft.AspNetCore.Html.HtmlString("disabled"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml"
  
    ViewData["Title"] = "مشخصات قطعه";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main>\r\n    <div class=\"container\">\r\n        <div class=\"user-account\">\r\n            <button class=\"header\">صفحه ی ");
#nullable restore
#line 10 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml"
                                     Write(Model.UnitName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button>
            <div class=""row"">
                <div class=""col-md-3 col-sm-4 col-xs-12"">
                    <aside>
                        <section>
                            <div class=""inner"">
                                <ul>
                                    <li><button class=""button-a button-a-Active""><a");
            BeginWriteAttribute("href", " href=\"", 565, "\"", 602, 2);
            WriteAttributeValue("", 572, "/InformationUnit/", 572, 17, true);
#nullable restore
#line 17 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml"
WriteAttributeValue("", 589, Model.UnitId, 589, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> مشخصات </a></button></li>\r\n");
#nullable restore
#line 18 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml"
                                     if (Model.IsDelete == false)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><button class=\"button-a\"><a");
            BeginWriteAttribute("href", " href=\"", 809, "\"", 839, 2);
            WriteAttributeValue("", 816, "/EditUnit/", 816, 10, true);
#nullable restore
#line 20 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml"
WriteAttributeValue("", 826, Model.UnitId, 826, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ویرایش </a></button></li>\r\n                                        <li><button class=\"button-a\"><a");
            BeginWriteAttribute("href", " href=\"", 940, "\"", 972, 2);
            WriteAttributeValue("", 947, "/DeleteUnit/", 947, 12, true);
#nullable restore
#line 21 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml"
WriteAttributeValue("", 959, Model.UnitId, 959, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> حذف </a></button></li>\r\n");
#nullable restore
#line 22 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <li><button class=""button-a""> گزارش </button></li>
                                </ul>
                            </div>
                        </section>
                    </aside>
                </div>
                <div class=""col-md-9 col-sm-8 col-xs-12"">
                    <section class=""user-account-content"">
                        <header>
                            <h1> اطلاعات کامل </h1>
                        </header>
                        <div class=""inner form-layer"">
                            <div class=""row"">
                                <div class=""col-md-3 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">نام قطعه</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                    <div ");
            WriteLiteral("class=\"input-group\">\r\n                                        <span class=\"input-group-addon\"><i class=\"zmdi zmdi-account\"></i></span>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3c60bcd1f1db6d9051705b671de1c25522ed350d8330", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 44 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Unit\InformationUnit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UnitName);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</main>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SohaService.DataLayer.Entities.Unit.Unit> Html { get; private set; }
    }
}
#pragma warning restore 1591