#pragma checksum "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "469b3b0a2b4a9f65c1eef851120fa30b65e3e7cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ProductDetail_Pages_Index), @"mvc.1.0.razor-page", @"/Areas/ProductDetail/Pages/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"469b3b0a2b4a9f65c1eef851120fa30b65e3e7cb", @"/Areas/ProductDetail/Pages/Index.cshtml")]
    public class Areas_ProductDetail_Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "ProductByCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_RibbonSalePartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_RibbonNewPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
  
    ViewData["Title"] = "RookieShop";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""all"">
    <div id=""content"">
        <div class=""container"">
            <div class=""row"">
                <!-- breadcrumb-->
                <div class=""col-12"" style=""padding-right: 0"">
                    <nav aria-label=""breadcrumb"">
                        <ol class=""breadcrumb"">
                            <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "469b3b0a2b4a9f65c1eef851120fa30b65e3e7cb5250", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                            <li class=\"breadcrumb-item\">\r\n                                ");
#nullable restore
#line 20 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                           Write(Model.Product.ProductModel.SubCategory.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </li>\r\n                            <li class=\"breadcrumb-item\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "469b3b0a2b4a9f65c1eef851120fa30b65e3e7cb6946", async() => {
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 26 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                               Write(Model.Product.ProductModel.SubCategory.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-subCategoryId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                                WriteLiteral(Model.Product.ProductModel.SubCategory.Category.CategoryId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["subCategoryId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-subCategoryId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["subCategoryId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n                            <li aria-current=\"page\" class=\"breadcrumb-item active\">");
#nullable restore
#line 29 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                                                              Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                        </ol>
                    </nav>
                </div>

                <!--ProductMain-->
                <div class=""col-12"">
                    <div id=""productMain"" class=""row"">
                        <!--product_slider-->
                        <div class=""col-lg-8 col-md-6"">
                            <div id=""main-slider"" class=""owl-carousel owl-theme"" itemprop=""image"">
");
#nullable restore
#line 40 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                 foreach (var image in Model.ProductImage.Items)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"item\">\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 1971, "\"", 1993, 1);
#nullable restore
#line 43 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
WriteAttributeValue("", 1977, image.ImagePath, 1977, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid owl-height\"");
            BeginWriteAttribute("alt", " alt=\"", 2023, "\"", 2048, 1);
#nullable restore
#line 43 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
WriteAttributeValue("", 2029, Model.Product.Name, 2029, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    </div>\r\n");
#nullable restore
#line 45 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n");
#nullable restore
#line 47 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                             if (Model.Product.SellingPrice < Model.Product.ListedPrice)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "469b3b0a2b4a9f65c1eef851120fa30b65e3e7cb12688", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 50 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                             if (Model.Product.DateUpload > DateTime.Today.AddDays(-14))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "469b3b0a2b4a9f65c1eef851120fa30b65e3e7cb14402", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 54 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <!--product_color-->\r\n                            <div id=\"getcolor\" class=\"d-flex justify-content-center flex-wrap\">\r\n\r\n");
#nullable restore
#line 58 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                 if (Model.Color.Items.Count() > 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div>\r\n                                        <h4>");
#nullable restore
#line 61 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                       Write(Model.Color.Items.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" colors available</h4>\r\n                                    </div>\r\n");
#nullable restore
#line 63 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                    foreach (var color in Model.Color.Items)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "469b3b0a2b4a9f65c1eef851120fa30b65e3e7cb17146", async() => {
                WriteLiteral("\r\n                                                <img");
                BeginWriteAttribute("src", " src=\"", 3387, "\"", 3409, 1);
#nullable restore
#line 67 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
WriteAttributeValue("", 3393, color.ImagePath, 3393, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                                                                             WriteLiteral(color.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n");
#nullable restore
#line 70 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n\r\n                        <!--product_details-->\r\n                        <div class=\"col-lg-4 col-md-6 box\">\r\n                            <h2 itemprop=\"name\">");
#nullable restore
#line 77 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                           Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            <h4><i>");
#nullable restore
#line 78 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                              Write(Model.Product.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></h4>\r\n");
            WriteLiteral("                            <p class=\"price\">\r\n                                <del>\r\n");
#nullable restore
#line 82 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                     if (Model.Product.SellingPrice < Model.Product.ListedPrice)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                         Write(String.Format("{0:0,0}", Model.Product.ListedPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ ");
#nullable restore
#line 84 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                                                                                              
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </del>\r\n                            </p>\r\n                            <p class=\"price-sale\" itemprop=\"price\">\r\n                                <text> ");
#nullable restore
#line 89 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                  Write(String.Format("{0:0,0}", Model.Product.SellingPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ </text>\r\n                            </p>\r\n                            <div id=\"getsize\" class=\"sizes\">\r\n");
#nullable restore
#line 92 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                 if (Model.ProductSizes.Items != null)
                                {
                                    foreach (var sizes in Model.ProductSizes.Items)
                                    {
                                        if (sizes.Quantity > 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <div class=\"gl-label\">\r\n                                                <input id=\"size\" name=\"size\" type=\"radio\"");
            BeginWriteAttribute("value", " value=\"", 5212, "\"", 5231, 1);
#nullable restore
#line 99 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
WriteAttributeValue("", 5220, sizes.Size, 5220, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" required />\r\n                                                <span> ");
#nullable restore
#line 100 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                                  Write(sizes.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                            </div>\r\n");
#nullable restore
#line 102 "C:\Users\kayke\OneDrive\Documents\Rookie\RookieWeb\Rookie.CustomerSite\Areas\ProductDetail\Pages\Index.cshtml"
                                        }
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                            <p class=""text-center buttons"">
                                <input type=""submit"" class=""btn btn-primary"" value=""Add to cart"" /><!--<i class=""fa fa-shopping-cart""></i>-->
                            </p>
                        </div>
                    </div>
                    <!-- /.col-md-9-->
                </div>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("ajax", async() => {
                WriteLiteral(@"
    <script>
        $(function () {
            $(document).ready(function () {
                $("".owl-carousel"").owlCarousel({
                    autoplay: true,
                    navigation: true,
                    loop: true,
                    items: 1,
                    autoHeight: true,
                });
            });
        });
    </script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Rookie.CustomerSite.Pages.ProductDetail.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Rookie.CustomerSite.Pages.ProductDetail.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Rookie.CustomerSite.Pages.ProductDetail.IndexModel>)PageContext?.ViewData;
        public Rookie.CustomerSite.Pages.ProductDetail.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
