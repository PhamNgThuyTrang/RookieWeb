#pragma checksum "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\Home\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1943ad1a6c568ce2bfad7df497cdfe4d76e873f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Home_Pages_Index), @"mvc.1.0.razor-page", @"/Areas/Home/Pages/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1943ad1a6c568ce2bfad7df497cdfe4d76e873f8", @"/Areas/Home/Pages/Index.cshtml")]
    public class Areas_Home_Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_AdvantagesPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\Home\Pages\Index.cshtml"
  
    ViewData["Title"] = "RookieShop";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <!-- /#banner-slider-->\r\n    <div id=\"banner\" class=\"owl-carousel owl-theme\">\r\n");
#nullable restore
#line 12 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\Home\Pages\Index.cshtml"
         foreach (var item in Model.Banners.Items)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"item\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 407, "\"", 428, 1);
#nullable restore
#line 15 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\Home\Pages\Index.cshtml"
WriteAttributeValue("", 413, item.ImagePath, 413, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n");
#nullable restore
#line 17 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\Home\Pages\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n<!--\r\n*** ADVANTAGES HOMEPAGE ***\r\n_________________________________________________________\r\n-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1943ad1a6c568ce2bfad7df497cdfe4d76e873f84380", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<!-- *** ADVANTAGES END ***-->\r\n\r\n<!--\r\n*** HOT PRODUCT SLIDESHOW ***\r\n_________________________________________________________\r\n-->\r\n");
#nullable restore
#line 31 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\Home\Pages\Index.cshtml"
Write(await Component.InvokeAsync("NewArrival"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n<!-- /#hotproduct-->\r\n\r\n");
            DefineSection("ajax", async() => {
                WriteLiteral(@"
    <script>
        $(function () {
            $(document).ready(function () {
                $(""#banner"").owlCarousel({
                    autoplay: true,
                    navigation: true,
                    loop: true,
                    items: 1,
                    autoHeight: true,
                });
                $(""#hot .owl-carousel"").owlCarousel({
                    center: true,
                    loop: true,
                    autoplay: true,
                    margin: 15,
                    items: 1,
                    autoHeight: true,
                    responsive: {
                        600: {
                            items: 2
                        },
                        900: {
                            items: 3
                        },
                        1200: {
                            items: 4
                        }
                    }
                });
            });
        });</script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Rookie.CustomerSite.Pages.Home.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Rookie.CustomerSite.Pages.Home.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Rookie.CustomerSite.Pages.Home.IndexModel>)PageContext?.ViewData;
        public Rookie.CustomerSite.Pages.Home.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
