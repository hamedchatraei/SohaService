#pragma checksum "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2ba5a960155c5b1d0f60efc90a73d44eba5045d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_DeniedOrders), @"mvc.1.0.view", @"/Views/Order/DeniedOrders.cshtml")]
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
#line 1 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
using SohaService.Core.Convertor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2ba5a960155c5b1d0f60efc90a73d44eba5045d", @"/Views/Order/DeniedOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_DeniedOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SohaService.Core.DTOs.Order.OrderViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sCustomer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control sohaselect"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "customerId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sUnit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "unitId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("filters-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
  
    ViewData["Title"] = "سفارشات انجام شده";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"filters\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2ba5a960155c5b1d0f60efc90a73d44eba5045d5832", async() => {
                WriteLiteral(@"
        <div class=""filter-input"" style=""margin: 10px 0 0"">
            <input type=""datetime"" id=""pcal1"" name=""fromDate"" class=""form-control"" style=""text-align: right"" placeholder=""از تاریخ ..."" autocomplete=""off"">
        </div>
        <div class=""filter-input"" style=""margin: 10px 0 0"">
            <input type=""datetime"" id=""pcal2"" name=""toDate"" class=""form-control"" style=""text-align: right"" placeholder=""تا تاریخ ..."" autocomplete=""off"">
        </div>
        <div class=""filter-input"" style=""margin: 10px 0 0"">
            <input id=""txtDmg"" type=""text"" name=""filterCustomerMobile"" class=""form-control"" placeholder=""موبایل مشتری"" />
        </div>
        <div class=""filter-input"" style=""margin: 10px 0 0"">
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2ba5a960155c5b1d0f60efc90a73d44eba5045d6882", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 21 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (ViewData["customers"] as SelectList);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </div>\r\n        <div class=\"filter-input\" style=\"margin: 10px 0 0\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2ba5a960155c5b1d0f60efc90a73d44eba5045d8851", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 24 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (ViewData["units"] as SelectList);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        </div>
        <div class=""filter-input"" style=""margin: 10px 0 0"">
            <a id=""btnEmpty"" class=""btn btn-default btn-sm"" href=""/Orders"">برو به امروز</a>
        </div>
        <div class=""filter-input"" style=""margin: 10px 0 0"">
            <a id=""btnRefresh"" class=""btn btn-default btn-sm"" href=""/Orders"">بازنشانی</a>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <div class=""col-md-12"" style=""margin: 10px 0;"">
        <div class=""main-content"">

            <div class=""container"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""table-wrap"">
                            <table class=""table table-responsive-xl"">
                                <thead>
                                <tr>
                                    <th style=""width: 10%;"">مشتری</th>
                                    <th style=""width: 10%;"">موبایل</th>
                                    <th style=""width: 16%;"">آدرس</th>
                                    <th style=""width: 10%;"">قطعه</th>
                                    <th style=""width: 14%;"">شرح خرابی</th>
                                    <th style=""width: 15%;"">تاریخ انجام شدن</th>
                                    <th style=""width: 15%;"">وضعیت تایید مدیر</th>
                                    <th style=""width: 20%;"">دستورات</th>
          ");
            WriteLiteral("                      </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 55 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                                 foreach (var item in Model.InformationOrder)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"alert\" role=\"alert\">\r\n                                        <td>");
#nullable restore
#line 58 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                                       Write(item.CustomerNameFamily);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 59 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                                       Write(item.CustomerMobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 60 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                                       Write(item.CustomerAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 61 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                                       Write(item.UnitName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 62 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                                       Write(item.DamageDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 63 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                                       Write(item.OrderChangeLevelDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3535, "\"", 3542, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary btn-sm"">
                                                <svg version=""1.1"" id=""Layer_1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" x=""0px"" y=""0px"" viewBox=""0 0 512 512"" style=""enable-background: new 0 0 512 512;"" xml:space=""preserve"">
                                                    <g>
                                                        <g>
                                                            <path d=""M437.019,74.981C388.668,26.628,324.379,0,256,0S123.332,26.628,74.981,74.981C26.629,123.333,0,187.62,0,256    c0,68.38,26.628,132.668,74.981,181.019C123.333,485.371,187.621,512,256,512s132.668-26.628,181.019-74.981    C485.371,388.667,512,324.38,512,256S485.372,123.332,437.019,74.981z M256,480.653C132.125,480.653,31.347,379.874,31.347,256    S132.125,31.347,256,31.347S480.653,132.126,480.653,256S379.875,480.653,256,480.653z""></path>
                                                        </g>
                                         ");
            WriteLiteral(@"           </g>
                                                    <g>
                                                        <g>
                                                            <path d=""M411.16,167.337l-66.497-66.496L256,189.503l-88.663-88.663l-66.497,66.496L189.503,256l-88.663,88.663l66.497,66.497    L256,322.497l88.663,88.663l66.497-66.497L322.497,256L411.16,167.337z M366.828,344.663l-22.167,22.165L256,278.165    l-88.663,88.663l-22.166-22.165L233.834,256l-88.663-88.663l22.166-22.165L256,233.835l88.663-88.663l22.166,22.165L278.166,256    L366.828,344.663z""></path>
                                                        </g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                         ");
            WriteLiteral(@"                           </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
              ");
            WriteLiteral(@"                                      </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                </svg>
                                            </a>
                                        </td>
                                        <td>
                                            <a");
            BeginWriteAttribute("href", " href=\"", 7249, "\"", 7287, 2);
            WriteAttributeValue("", 7256, "/InformationOrder/", 7256, 18, true);
#nullable restore
#line 111 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
WriteAttributeValue("", 7274, item.OrderId, 7274, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary btn-sm"">
                                                <svg version=""1.1"" id=""Layer_1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" x=""0px"" y=""0px"" viewBox=""0 0 512.08 512.08"" style=""enable-background:new 0 0 512.08 512.08;"" xml:space=""preserve"">
                                                    <g>
                                                        <g>
                                                            <polygon points=""82.944,79.656 34.192,134.84 16,116.328 4.592,127.544 34.816,158.312 94.944,90.248   ""></polygon>
                                                        </g>
                                                    </g>
                                                    <g>
                                                        <g>
                                                            <rect x=""159.44"" y=""88.936"" width=""188.032"" height=""16""></rect>
                                                        </g>");
            WriteLiteral(@"
                                                    </g>
                                                    <g>
                                                        <g>
                                                            <rect x=""159.44"" y=""136.824"" width=""352.64"" height=""16""></rect>
                                                        </g>
                                                    </g>
                                                    <g>
                                                        <g>
                                                            <rect x=""159.44"" y=""222.744"" width=""188.032"" height=""16""></rect>
                                                        </g>
                                                    </g>
                                                    <g>
                                                        <g>
                                                            <rect x=""159.44"" y=""270.632"" width=""352.64"" height=""16""></r");
            WriteLiteral(@"ect>
                                                        </g>
                                                    </g>
                                                    <g>
                                                        <g>
                                                            <rect x=""159.44"" y=""356.568"" width=""188.032"" height=""16""></rect>
                                                        </g>
                                                    </g>
                                                    <g>
                                                        <g>
                                                            <rect x=""159.44"" y=""404.456"" width=""352.64"" height=""16""></rect>
                                                        </g>
                                                    </g>
                                                    <g>
                                                        <g>
                                                     ");
            WriteLiteral(@"       <path d=""M43.248,210.76C19.408,210.76,0,230.472,0,254.68c0,24.208,19.408,43.92,43.248,43.92    c23.856,0,43.264-19.696,43.264-43.92C86.512,230.456,67.104,210.76,43.248,210.76z M43.248,282.6    C28.208,282.6,16,270.072,16,254.68c0-15.392,12.224-27.92,27.248-27.92c15.024,0,27.264,12.528,27.264,27.92    C70.512,270.072,58.288,282.6,43.248,282.6z""></path>
                                                        </g>
                                                    </g>
                                                    <g>
                                                        <g>
                                                            <path d=""M43.248,344.584C19.408,344.584,0,364.28,0,388.504s19.408,43.92,43.248,43.92c23.856,0,43.264-19.696,43.264-43.92    S67.104,344.584,43.248,344.584z M43.248,416.424c-15.024,0-27.248-12.528-27.248-27.92c0-15.392,12.224-27.92,27.248-27.92    c15.024,0,27.264,12.528,27.264,27.92C70.512,403.896,58.272,416.424,43.248,416.424z""></path>
                        ");
            WriteLiteral(@"                                </g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
        ");
            WriteLiteral(@"                                            <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                    <g>
                                                    </g>
                                                </svg>
                                            </a>
                                        </td>

                                    </tr>
");
#nullable restore
#line 193 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""dataTables_paginate paging_simple_numbers"" id=""dataTables-example_paginate"">
                        <ul class=""pagination"">

");
#nullable restore
#line 206 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                             for (int i = 1; i <= Model.PageCount; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li");
            BeginWriteAttribute("class", " class=\"", 13996, "\"", 14063, 2);
            WriteAttributeValue("", 14004, "paginate_button", 14004, 15, true);
#nullable restore
#line 208 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
WriteAttributeValue(" ", 14019, (i == Model.CurrentPage) ? "active" : "", 14020, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-controls=\"dataTables-example\" tabindex=\"0\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 14153, "\"", 14181, 2);
            WriteAttributeValue("", 14160, "/DoneOrders?PageId=", 14160, 19, true);
#nullable restore
#line 209 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
WriteAttributeValue("", 14179, i, 14179, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 209 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                                                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n");
#nullable restore
#line 211 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        
    </div>
</div>

<script src=""/BootstrapJalaliDatePicker/bootstrap-datepicker.min.js""></script>
<script src=""/BootstrapJalaliDatePicker/bootstrap-datepicker.fa.min.js""></script>

<script type=""text/javascript"">
    $(document).ready(function () {
        $('input[type=datetime]').datepicker({ dateFormat: ""yy/mm/dd"", isRTL: true, showButtonPanel: true });
    });
</script>

<script>

    $(document).ready(function () {

        function soha_ajax(rd = """", fd = """", td = """", pageId = 1) {

            $.ajax({
                type: ""POST"",
                url: """);
#nullable restore
#line 240 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Order\DeniedOrders.cshtml"
                 Write(Url.Action("DoneOrders"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                dataType: ""text"",
                data:
                {
                    filterCustomerMobile: $('#txtDmg').val(),
                    customerId: $('#sCustomer').val(),
                    unitId: $('#sUnit').val(),
                    estimatedTime: rd,
                    fromDate: fd,
                    toDate: td,
                    pageId: pageId
                },
                success: function (msg) {
                    var q = $(msg).find('.main-content');
                    $('.main-content').replaceWith(q);
                    console.log(q);
                },
                error: function (req, status, error) {
                    console.log(msg);
                }
            });
        }

        $('.form-control').on('input',function() {

            console.log($('#pcal1').val());
            console.log($('#pcal2').val());
            soha_ajax();

        });



        $('body').on('click','a.weekday',function() {

     ");
            WriteLiteral(@"       soha_ajax();

        });

        $(""#btnEmpty"").click(function (e) {

            e.preventDefault();

            $('.form-control').val('');
            $("".button-dayOfweek"").removeClass(""button-dayOfweek-active"");
            $("".today"").addClass(""button-dayOfweek-active"");
            soha_ajax('today');

        });

        $(""#btnRefresh"").click(function (e) {

            e.preventDefault();

            $('.form-control').val('');
            $("".button-dayOfweek"").removeClass(""button-dayOfweek-active"");
            $("".today"").addClass(""button-dayOfweek-active"");
            soha_ajax();

        });

        $("".button-dayOfweek"").click(function() {

            $("".button-dayOfweek"").removeClass(""button-dayOfweek-active"");
            $(this).addClass(""button-dayOfweek-active"");
            var date = $(this).find('.ready-date').text();
            console.log(date);
            soha_ajax(date);

        });

        $(""body"").on('click', '.pagination ");
            WriteLiteral(@"a', function (e) {
            e.preventDefault();

            var pageId = $(this).text();
            soha_ajax("""", """", """", pageId);

        });

        $('#ui-datepicker-div').on('click','.ui-datepicker-calendar td a',function(e) {

            var fd = $('#pcal1').val();
            var td = $('#pcal2').val();
            soha_ajax("""",fd,td);
        });

    });


</script>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SohaService.Core.DTOs.Order.OrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
