#pragma checksum "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7ee6ac93da8f15cb6baa5d776c66615b5829938"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_EditCompany), @"mvc.1.0.view", @"/Views/Company/EditCompany.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7ee6ac93da8f15cb6baa5d776c66615b5829938", @"/Views/Company/EditCompany.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_EditCompany : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SohaService.DataLayer.Entities.Company.Company>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCompany", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
  
    ViewData["Title"] = "ویرایش شرکت";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main>\r\n    <div class=\"container\">\r\n        <div class=\"user-account\">\r\n            <button class=\"header\">صفحه ی شرکت ");
#nullable restore
#line 10 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
                                          Write(Model.CompanyName);

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
                                    <li><button class=""button-a""><a");
            BeginWriteAttribute("href", " href=\"", 563, "\"", 606, 2);
            WriteAttributeValue("", 570, "/InformationCompany/", 570, 20, true);
#nullable restore
#line 17 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
WriteAttributeValue("", 590, Model.CompanyId, 590, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> مشخصات </a></button></li>\r\n");
#nullable restore
#line 18 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
                                     if (Model.IsDelete == false)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><button class=\"button-a button-a-Active\"><a");
            BeginWriteAttribute("href", " href=\"", 829, "\"", 865, 2);
            WriteAttributeValue("", 836, "/EditCompany/", 836, 13, true);
#nullable restore
#line 20 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
WriteAttributeValue("", 849, Model.CompanyId, 849, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ویرایش </a></button></li>\r\n                                        <li><button class=\"button-a\"><a");
            BeginWriteAttribute("href", " href=\"", 966, "\"", 1004, 2);
            WriteAttributeValue("", 973, "/DeleteCompany/", 973, 15, true);
#nullable restore
#line 21 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
WriteAttributeValue("", 988, Model.CompanyId, 988, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> حذف </a></button></li>\r\n");
#nullable restore
#line 22 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
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
                            <h1>ویرایش شرکت</h1>
                        </header>
                        <div class=""inner form-layer"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7ee6ac93da8f15cb6baa5d776c66615b58299388507", async() => {
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c7ee6ac93da8f15cb6baa5d776c66615b58299388797", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 36 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CompanyId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                <div class=""row"">
                                    <div class=""col-md-3 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">نام شرکت</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c7ee6ac93da8f15cb6baa5d776c66615b582993811239", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 46 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CompanyName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
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
                                    <div class=""col-md-3 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">تلفن شرکت</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c7ee6ac93da8f15cb6baa5d776c66615b582993814135", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 57 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CompanyPhone);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
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
                                    <div class=""col-md-3 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">آدرس شرکت</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c7ee6ac93da8f15cb6baa5d776c66615b582993817032", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 68 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Company\EditCompany.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CompanyAddress);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
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
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <button class=""btn btn-success""> ویرایش اطلاعات </button>
                                    </div>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </section>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SohaService.DataLayer.Entities.Company.Company> Html { get; private set; }
    }
}
#pragma warning restore 1591