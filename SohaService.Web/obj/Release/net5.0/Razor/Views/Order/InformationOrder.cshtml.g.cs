#pragma checksum "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72de864e167d1e100866ca35cd7a25ac20e2e422"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_InformationOrder), @"mvc.1.0.view", @"/Views/Order/InformationOrder.cshtml")]
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
#line 1 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
using SohaService.Core.Convertor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72de864e167d1e100866ca35cd7a25ac20e2e422", @"/Views/Order/InformationOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_InformationOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SohaService.Core.DTOs.Order.InformationOrderViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("disabled", new global::Microsoft.AspNetCore.Html.HtmlString("disabled"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control no-resiaze"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rows", new global::Microsoft.AspNetCore.Html.HtmlString("5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
  
    ViewData["Title"] = "مشخصات سفارش";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<main>\r\n    <div class=\"container\">\r\n        <div class=\"user-account\">\r\n            <button class=\"header\">صفحه ی سفارش ");
#nullable restore
#line 11 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                           Write(Model.CustomerNameFamily);

#line default
#line hidden
#nullable disable
            WriteLiteral(" در تاریخ ");
#nullable restore
#line 11 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                                                              Write(Model.OrderSetDate.ToShamsi());

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
            BeginWriteAttribute("href", " href=\"", 670, "\"", 709, 2);
            WriteAttributeValue("", 677, "/InformationOrder/", 677, 18, true);
#nullable restore
#line 18 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 695, Model.OrderId, 695, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> مشخصات </a></button></li>\r\n");
#nullable restore
#line 19 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                     if (Model.IsDelete == false)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                         if (Model.OrderLevelId == 1)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li><button class=\"button-a\"><a");
            BeginWriteAttribute("href", " href=\"", 1034, "\"", 1066, 2);
            WriteAttributeValue("", 1041, "/EditOrder/", 1041, 11, true);
#nullable restore
#line 23 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 1052, Model.OrderId, 1052, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ویرایش </a></button></li>\r\n");
#nullable restore
#line 24 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                        }
                                        else if(Model.OrderLevelId == 4)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li><button class=\"button-a\"><a");
            BeginWriteAttribute("href", " href=\"", 1331, "\"", 1367, 2);
            WriteAttributeValue("", 1338, "/EditDoneOrder/", 1338, 15, true);
#nullable restore
#line 27 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 1353, Model.OrderId, 1353, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ویرایش </a></button></li>\r\n");
#nullable restore
#line 28 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><button class=\"button-a\"><a");
            BeginWriteAttribute("href", " href=\"", 1511, "\"", 1545, 2);
            WriteAttributeValue("", 1518, "/DeleteOrder/", 1518, 13, true);
#nullable restore
#line 29 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 1531, Model.OrderId, 1531, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> حذف </a></button></li>\r\n");
#nullable restore
#line 30 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
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
                                <div class=""col-md-4 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">تاریخ ثبت سفارش</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                  ");
            WriteLiteral("  <div class=\"input-group\">\r\n                                        <span class=\"input-group-addon\"><i class=\"zmdi zmdi-account\"></i></span>\r\n                                        <input type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 2857, "\"", 2895, 1);
#nullable restore
#line 52 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 2865, Model.OrderSetDate.ToShamsi(), 2865, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled=""disabled"">
                                    </div>
                                </div>
                                <div class=""col-md-4 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">وضعیت سفارش</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "72de864e167d1e100866ca35cd7a25ac20e2e42212636", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 63 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.OrderLevelTitle);

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
                                <div class=""col-md-4 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">زمان برآورد شده فرستادن کارشناس</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                        <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 4446, "\"", 4497, 1);
#nullable restore
#line 74 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 4454, Model.EstimatedToSendExpertTime.ToShamsi(), 4454, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled=""disabled"">
                                    </div>
                                </div>
                                <div class=""col-md-4 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">هزینه برآورد شده</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                        <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 5255, "\"", 5294, 1);
#nullable restore
#line 85 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 5263, Model.EstimatedAmount.ToRial(), 5263, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled=\"disabled\">\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 88 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                 if (Model.OrderLevelId == 4)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""col-md-4 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">هزینه قطعی</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 6180, "\"", 6215, 1);
#nullable restore
#line 98 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 6188, Model.FinalAmount.ToRial(), 6188, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled=""disabled"">
                                        </div>
                                    </div>
                                    <div class=""col-md-4 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">تخفیف</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 7006, "\"", 7038, 1);
#nullable restore
#line 109 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 7014, Model.Discount.ToRial(), 7014, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled=""disabled"">
                                        </div>
                                    </div>
                                    <div class=""col-md-4 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">هزینه کل</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 7832, "\"", 7865, 1);
#nullable restore
#line 120 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 7840, Model.TotalCost.ToRial(), 7840, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled=""disabled"">
                                        </div>
                                    </div>
                                    <div class=""col-md-4 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">پرداخت اولیه</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 8663, "\"", 8701, 1);
#nullable restore
#line 131 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 8671, Model.ReceivedAmount.ToRial(), 8671, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled=""disabled"">
                                        </div>
                                    </div>
                                    <div class=""col-md-4 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">هزینه باقی مانده</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 9503, "\"", 9542, 1);
#nullable restore
#line 142 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 9511, Model.RemainingAmount.ToRial(), 9511, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled=\"disabled\">\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 145 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-md-4 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">شرح خرابی</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72de864e167d1e100866ca35cd7a25ac20e2e42224379", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 154 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DamageDescription);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 157 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                 if (Model.OrderLevelId == 4)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""col-md-4 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">توضیحات نهایی</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72de864e167d1e100866ca35cd7a25ac20e2e42227204", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 167 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DoneDescription);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 170 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-md-4 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">قطعه</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "72de864e167d1e100866ca35cd7a25ac20e2e42229927", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 179 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
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
                                <div class=""col-md-4 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">مشتری</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "72de864e167d1e100866ca35cd7a25ac20e2e42232468", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 190 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CustomerNameFamily);

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
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 193 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                 if (Model.OrderLevelId == 4)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""col-md-4 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon"">کارشناس</span>
                                        </div>
                                    </div>
                                    <div class=""col-md-7 col-sm-8 col-xs-12"">
                                        <div class=""input-group"">
                                            <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "72de864e167d1e100866ca35cd7a25ac20e2e42235390", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 203 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ExpertNameFamily);

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
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 206 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-md-4 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">کارشناس ثبت کننده</span>
                                    </div>
                                </div>
                                <div class=""col-md-7 col-sm-8 col-xs-12"">
                                    <div class=""input-group"">
                                        <span class=""input-group-addon""><i class=""zmdi zmdi-account""></i></span>
                                        <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 14614, "\"", 14639, 1);
#nullable restore
#line 215 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\InformationOrder.cshtml"
WriteAttributeValue("", 14622, Model.registrant, 14622, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled=""disabled"">
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SohaService.Core.DTOs.Order.InformationOrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591