#pragma checksum "C:\Users\Phoenix\Desktop\SohaService\SohaService.Web\Views\Shared\_MainMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c5f7fb29beeb80c62c096b6f0f32eb90a62b39b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MainMenu), @"mvc.1.0.view", @"/Views/Shared/_MainMenu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c5f7fb29beeb80c62c096b6f0f32eb90a62b39b", @"/Views/Shared/_MainMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MainMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"main-menu\">\r\n    <div class=\"container\">\r\n        <nav>\r\n            <span class=\"responsive-sign\"><i class=\"zmdi zmdi-menu\"></i></span>\r\n            <ul>\r\n                <li>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 212, "\"", 219, 0);
            EndWriteAttribute();
            WriteLiteral(@"> دانش آموزان </a>
                    <ul>
                        <li><a href=""/Students""> لیست دانش آموزان </a></li>
                        <li><a href=""/DeletedStudents""> دانش آموزان حذف شده </a></li>
                        <li><a href=""/CanceledStudent""> دانش آموزان انصرافی </a></li>
                    </ul>
                </li>
                <li>
                    <a");
            BeginWriteAttribute("href", " href=\"", 611, "\"", 618, 0);
            EndWriteAttribute();
            WriteLiteral(@"> مشاوران جذب </a>
                    <ul>
                        <li><a href=""/Advisers"">لیست مشاوران جذب</a></li>
                        <li><a href=""/DeletedAdvisers"">مشاوران جذب حذف شده</a></li>
                    </ul>
                </li>
                <li>
                    <a");
            BeginWriteAttribute("href", " href=\"", 919, "\"", 926, 0);
            EndWriteAttribute();
            WriteLiteral(@">مشاوران برنامه ریزی</a>
                    <ul>
                        <li><a href=""/SyllabusAdvisers"">لیست مشاوران برنامه ریزی</a></li>
                        <li><a href=""/DeletedSyllabusAdvisers"">مشاوران برنامه ریزی حذف شده</a></li>
                    </ul>
                </li>
                <li>
                    <a");
            BeginWriteAttribute("href", " href=\"", 1265, "\"", 1272, 0);
            EndWriteAttribute();
            WriteLiteral(@">برنامه های رادیویی و تلویزیونی</a>
                    <ul>
                        <li><a href=""/ShowTVCourses"">لیست برنامه های تلویزیونی</a></li>
                        <li><a href=""/ShowRadioCourses"">لیست برنامه های رادیویی</a></li>
                        <li><a href=""/ShowDeletedTVCourses"">لیست برنامه های تلویزیونی حذف شده</a></li>
                        <li><a href=""/ShowDeletedRadioCourses"">لیست برنامه های رادیویی حذف شده</a></li>
                    </ul>
                </li>
                <li>
                    <a");
            BeginWriteAttribute("href", " href=\"", 1818, "\"", 1825, 0);
            EndWriteAttribute();
            WriteLiteral(@">طرح های مشاوره</a>
                    <ul>
                        <li><a href=""/ShowPlans"">لیست طرح ها</a></li>
                        <li><a href=""/ShowDeletedPlan"">طرح های حذف شده</a></li>
                    </ul>
                </li>
                <li>
                    <a");
            BeginWriteAttribute("href", " href=\"", 2119, "\"", 2126, 0);
            EndWriteAttribute();
            WriteLiteral(@">مالی</a>
                    <ul>
                        <li><a href=""/Accounts"">لیست حساب ها</a></li>
                        <li><a href=""/ShowPos"">لیست کارتخوان ها</a></li>
                        <li><a href=""/DeletedAccounts"">لیست حساب های حذف شده</a></li>
                        <li><a href=""/DeletedPos"">لیست کارتخوان های حذف شده</a></li>
                    </ul>
                </li>
                <li>
                    <a");
            BeginWriteAttribute("href", " href=\"", 2576, "\"", 2583, 0);
            EndWriteAttribute();
            WriteLiteral(@">پرداخت ها</a>
                    <ul>
                        <li><a href=""/ShowAllPayPecuniary"">پرداخت های نقدی</a></li>
                        <li><a href=""/ShowAllPayCard"">کارت به کارت</a></li>
                        <li><a href=""/ShowAllPayPos"">کارتخوان</a></li>
                        <li><a href=""/ShowAllCheque"">چک</a></li>
                        <li><a href=""/ShowAllInstallment"">قسط</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
    </div>
</div>");
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
