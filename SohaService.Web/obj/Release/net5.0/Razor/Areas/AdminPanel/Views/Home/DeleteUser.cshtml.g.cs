#pragma checksum "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Areas\AdminPanel\Views\Home\DeleteUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f66a1d9863e6c2d8aecf591835a93a9e9d881ff5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminPanel_Views_Home_DeleteUser), @"mvc.1.0.view", @"/Areas/AdminPanel/Views/Home/DeleteUser.cshtml")]
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
#line 1 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Areas\AdminPanel\Views\Home\DeleteUser.cshtml"
using SohaService.Core.Convertor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f66a1d9863e6c2d8aecf591835a93a9e9d881ff5", @"/Areas/AdminPanel/Views/Home/DeleteUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Areas/AdminPanel/Views/_ViewImports.cshtml")]
    public class Areas_AdminPanel_Views_Home_DeleteUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SohaService.Core.DTOs.User.InformationUserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Areas\AdminPanel\Views\Home\DeleteUser.cshtml"
  
    ViewData["Title"] = "حذف کاربر";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"col-md-12\">\r\n    <div class=\"panel panel-default\">\r\n        <div class=\"panel-heading\">\r\n            حذف کاربر\r\n        </div>\r\n        <div class=\"panel-body\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f66a1d9863e6c2d8aecf591835a93a9e9d881ff54072", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"UserId\"");
                BeginWriteAttribute("value", " value=\"", 404, "\"", 442, 1);
#nullable restore
#line 16 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Areas\AdminPanel\Views\Home\DeleteUser.cshtml"
WriteAttributeValue("", 412, ViewData["UserId"].ToString(), 412, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n                <dl class=\"dl-horizontal\">\r\n                    <dt>نام کاربری : </dt>\r\n                    <dd>");
#nullable restore
#line 20 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Areas\AdminPanel\Views\Home\DeleteUser.cshtml"
                   Write(Model.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</dd>\r\n                    <dt>موبایل : </dt>\r\n                    <dd>");
#nullable restore
#line 22 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Areas\AdminPanel\Views\Home\DeleteUser.cshtml"
                   Write(Model.Mobile);

#line default
#line hidden
#nullable disable
                WriteLiteral("</dd>\r\n                    <dt>تاریخ عضویت : </dt>\r\n                    <dd>");
#nullable restore
#line 24 "C:\Users\Phoenix\Desktop\New folder (2)\SohaService\SohaService\SohaService.Web\Areas\AdminPanel\Views\Home\DeleteUser.cshtml"
                   Write(Model.RegisterDate.ToShamsi());

#line default
#line hidden
#nullable disable
                WriteLiteral("</dd>\r\n                    <dt></dt>\r\n                    <dd>\r\n                        <input type=\"submit\" value=\"حذف\" class=\"btn btn-danger\" />\r\n                    </dd>\r\n                </dl>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <!-- /.panel-body -->\r\n    </div>\r\n    <!-- /.panel -->\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SohaService.Core.DTOs.User.InformationUserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
