#pragma checksum "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb880622586a8c245970ef20957a766d5bcf04b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Repair_DeletedRepairs), @"mvc.1.0.view", @"/Views/Repair/DeletedRepairs.cshtml")]
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
#line 1 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
using SohaService.Core.Convertor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb880622586a8c245970ef20957a766d5bcf04b8", @"/Views/Repair/DeletedRepairs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Repair_DeletedRepairs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SohaService.Core.DTOs.Repair.RepairViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sCustomer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control sohaselect"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "filterCustomerId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sUnit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "filterUnitId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sCompany"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "filterCompanyId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("filters-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
  
    ViewData["Title"] = "تعمیرات حذف شده";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"filters\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb880622586a8c245970ef20957a766d5bcf04b86297", async() => {
                WriteLiteral(@"
        <div class=""filter-input"" style=""margin: 10px 0 0"">
            <input id=""txtDmg"" type=""text"" name=""filterCustomerMobile"" class=""form-control"" placeholder=""موبایل مشتری"" />
        </div>
        <div class=""filter-input"" style=""margin: 10px 0 0"">
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb880622586a8c245970ef20957a766d5bcf04b86845", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 15 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb880622586a8c245970ef20957a766d5bcf04b88817", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 18 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
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
                WriteLiteral("\r\n        </div>\r\n        <div class=\"filter-input\" style=\"margin: 10px 0 0\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb880622586a8c245970ef20957a766d5bcf04b810785", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 21 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (ViewData["company"] as SelectList);

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
            <input type=""datetime"" id=""pcal1"" name=""estimatedTime"" class=""form-control"" style=""text-align: right"" placeholder=""انتخاب تاریخ ..."" autocomplete=""off"">
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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
                                        <th style=""width: 15%;"">آخرین وضعیت</th>
                                        <th style=""width: 20%;"">دستورات</th>

                                    </tr>
              ");
            WriteLiteral("                  </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 55 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                     foreach (var item in Model.InformationRepairViewModels)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr class=\"alert\" role=\"alert\">\r\n                                            <td>");
#nullable restore
#line 58 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                           Write(item.CustomersNameFamily);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 59 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                           Write(item.CustomerMobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 60 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                           Write(item.CustomerAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 61 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                           Write(item.UnitName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 62 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                           Write(item.DamageDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 63 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                             if (item.IsReady)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td>در دست تعمیر</td>\r\n");
#nullable restore
#line 66 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                            }
                                            else if (item.IsRepair)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td>تعمیر شده</td>\r\n");
#nullable restore
#line 70 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                            }
                                            else if (item.IsSend)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td>انجام شده</td>\r\n");
#nullable restore
#line 74 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\r\n\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 3965, "\"", 4005, 2);
            WriteAttributeValue("", 3972, "/InformationRepair/", 3972, 19, true);
#nullable restore
#line 77 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
WriteAttributeValue("", 3991, item.RepairId, 3991, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary btn-sm"">
                                                    <svg version=""1.1"" id=""Layer_1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" x=""0px"" y=""0px"" viewBox=""0 0 512.08 512.08"" style=""enable-background: new 0 0 512.08 512.08;"" xml:space=""preserve"">
                                                    <g>
                                                    <g>
                                                    <polygon points=""82.944,79.656 34.192,134.84 16,116.328 4.592,127.544 34.816,158.312 94.944,90.248   ""></polygon>
                                                            </g>
                                                        </g>
                                                    <g>
                                                    <g>
                                                    <rect x=""159.44"" y=""88.936"" width=""188.032"" height=""16""></rect>
                                                            </g>
     ");
            WriteLiteral(@"                                                   </g>
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
                                                    <rect x=""159.44"" y=""270.632"" width=""352.64"" height=""16""></rect>
                 ");
            WriteLiteral(@"                                           </g>
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
                                                    <path d=""M43.248,210.76C19.4");
            WriteLiteral(@"08,210.76,0,230.472,0,254.68c0,24.208,19.408,43.92,43.248,43.92    c23.856,0,43.264-19.696,43.264-43.92C86.512,230.456,67.104,210.76,43.248,210.76z M43.248,282.6    C28.208,282.6,16,270.072,16,254.68c0-15.392,12.224-27.92,27.248-27.92c15.024,0,27.264,12.528,27.264,27.92    C70.512,270.072,58.288,282.6,43.248,282.6z""></path>
                                                            </g>
                                                        </g>
                                                    <g>
                                                    <g>
                                                    <path d=""M43.248,344.584C19.408,344.584,0,364.28,0,388.504s19.408,43.92,43.248,43.92c23.856,0,43.264-19.696,43.264-43.92    S67.104,344.584,43.248,344.584z M43.248,416.424c-15.024,0-27.248-12.528-27.248-27.92c0-15.392,12.224-27.92,27.248-27.92    c15.024,0,27.264,12.528,27.264,27.92C70.512,403.896,58.272,416.424,43.248,416.424z""></path>
                                                            </g");
            WriteLiteral(@">
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
            WriteLiteral(@"                                             <g>
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

                               ");
            WriteLiteral("         </tr>\r\n");
#nullable restore
#line 159 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"

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
#line 173 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                             for (int i = 1; i <= Model.PageCount; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li");
            BeginWriteAttribute("class", " class=\"", 10765, "\"", 10832, 2);
            WriteAttributeValue("", 10773, "paginate_button", 10773, 15, true);
#nullable restore
#line 175 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
WriteAttributeValue(" ", 10788, (i == Model.CurrentPage) ? "active" : "", 10789, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-controls=\"dataTables-example\" tabindex=\"0\">\r\n                                    <a id=\"aPage\"");
            BeginWriteAttribute("href", " href=\"", 10933, "\"", 10957, 2);
            WriteAttributeValue("", 10940, "/Orders?PageId=", 10940, 15, true);
#nullable restore
#line 176 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
WriteAttributeValue("", 10955, i, 10955, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 176 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n");
#nullable restore
#line 178 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
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

        function soha_ajax(rd = """",pageId=1) {
            console.log('');
            $.ajax({
                type: ""POST"",
                url: """);
#nullable restore
#line 206 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Views\Repair\DeletedRepairs.cshtml"
                 Write(Url.Action("DeletedRepairs"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                dataType: ""text"",
                data:
                {
                    filterCustomerMobile: $('#txtDmg').val(),
                    filterCustomerId: $('#sCustomer').val(),
                    filterUnitId: $('#sUnit').val(),
                    filterCompanyId: $('#sCompany').val(),
                    estimatedTime: rd,
                    pageId : pageId,
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

            var date = $("".button-dayOfweek-active .ready-date"").text();
            soha_ajax(date);

        });

        $(""body"").on('click','#btnEmpty',function (e) {

            e");
            WriteLiteral(@".preventDefault();

            $('.form-control').val('');
            $("".button-dayOfweek"").removeClass(""button-dayOfweek-active"");
            $("".today"").addClass(""button-dayOfweek-active"");
            soha_ajax($("".days"").data(""today""));

        });

        $(""#btnRefresh"").click(function (e) {

            e.preventDefault();

            $('.form-control').val('');
            $("".button-dayOfweek"").removeClass(""button-dayOfweek-active"");
            $("".today"").addClass(""button-dayOfweek-active"");
            soha_ajax();

        });

        $(""body"").on('click','.button-dayOfweek',function() {

            $("".button-dayOfweek"").removeClass(""button-dayOfweek-active"");
            $(this).addClass(""button-dayOfweek-active"");
            var date = $(this).find('.ready-date').text();
            console.log(date);
            soha_ajax(date);

        });

        $(""body"").on('click','.pagination a',function (e) {
            e.preventDefault();

            var ");
            WriteLiteral(@"date = $("".button-dayOfweek-active .ready-date"").text();
            var pageId = $(this).text();
            console.log(date, pageId);
            soha_ajax(date,pageId);


        });


        $('#ui-datepicker-div').on('click','.ui-datepicker-calendar td a',function(e) {

            $("".button-dayOfweek-active"").removeClass(""button-dayOfweek-active"");
           // $(this).addClass(""button-dayOfweek-active"");
            var date = $('#pcal1').val();
            console.log(date);
            soha_ajax(date);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SohaService.Core.DTOs.Repair.RepairViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
