#pragma checksum "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b9c59d23af1e2eb9a9921b4ce7bdf7fa78de489"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_IndexLogin), @"mvc.1.0.view", @"/Views/Home/IndexLogin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b9c59d23af1e2eb9a9921b4ce7bdf7fa78de489", @"/Views/Home/IndexLogin.cshtml")]
    public class Views_Home_IndexLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebTareas.Models.IndexLogin>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
  
    ViewBag.Title = "Login | Task Organizer";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container vh-100"">
    <div class=""row justify-content-center pt-5"">
        <header>
            <div>
                <h2 class=""text-center fw-bold"">To Do List</h2>
            </div>
        </header>

        <div class=""row w-50"">
");
#nullable restore
#line 16 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
             using (Html.BeginForm("Login", "Home"))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
           Write(Html.LabelFor(m => m.User, "User", new { @class = "form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 19 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
           Write(Html.EditorFor(m => m.User, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <br /><br />\r\n");
#nullable restore
#line 21 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
           Write(Html.LabelFor(m => m.Password, "Password", new { @class = "form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 22 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
           Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
           Write(Html.HiddenFor(m => m.Attempts));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <br /><br />\r\n");
            WriteLiteral("                <input type=\"submit\" value=\"Login\" class=\"px-5 btn\"/>\r\n");
#nullable restore
#line 27 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n        <div class=\"row form-text text-danger\">\r\n            ");
#nullable restore
#line 31 "C:\Users\Land_\Desktop\ISTEA\Proyectos\PersonalToDoList\WebTareas\Views\Home\IndexLogin.cshtml"
       Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebTareas.Models.IndexLogin> Html { get; private set; }
    }
}
#pragma warning restore 1591
