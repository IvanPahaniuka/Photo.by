#pragma checksum "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1ed21deb055dbe275f8a03ab5feb48c8cbd3953"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Album_Index), @"mvc.1.0.view", @"/Views/Album/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Album/Index.cshtml", typeof(AspNetCore.Views_Album_Index))]
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
#line 1 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\_ViewImports.cshtml"
using ASPNetCoreTest3;

#line default
#line hidden
#line 2 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\_ViewImports.cshtml"
using ASPNetCoreTest3.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1ed21deb055dbe275f8a03ab5feb48c8cbd3953", @"/Views/Album/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ea87ea51fcceef5df1cecf62589009594799171", @"/Views/_ViewImports.cshtml")]
    public class Views_Album_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASPNetCoreTest3.Models.Album>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/carousel.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(37, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
  
    ViewData["Title"] = $"Альбом: {Model.Name}";

#line default
#line hidden
            BeginContext(96, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9dc7e7dd31cd416f804287f18ad110ee", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(147, 154, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div id=\"carousel\" class=\"carousel slide carousel-fade\" data-ride=\"carousel\">\r\n        <ol class=\"carousel-indicators\">\r\n");
            EndContext();
#line 11 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
             for (int i = 0; i < ViewBag.Photos.Count; i++)
            {

#line default
#line hidden
            BeginContext(377, 59, true);
            WriteLiteral("                <li data-target=\"#carousel\" data-slide-to=\"");
            EndContext();
            BeginContext(437, 1, false);
#line 13 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
                                                      Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(438, 2, true);
            WriteLiteral("\" ");
            EndContext();
            BeginContext(442, 32, false);
#line 13 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
                                                           Write(i == 0 ? "class=\"active\"" : "");

#line default
#line hidden
            EndContext();
            BeginContext(475, 8, true);
            WriteLiteral("></li>\r\n");
            EndContext();
#line 14 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(498, 100, true);
            WriteLiteral("        </ol>\r\n        <!-- Carousel items -->\r\n        <div class=\"carousel-inner carousel-zoom\">\r\n");
            EndContext();
#line 18 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
             for (int i = 0; i < ViewBag.Photos.Count; i++)
            {

#line default
#line hidden
            BeginContext(674, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 694, "\"", 732, 2);
            WriteAttributeValue("", 702, "item", 702, 4, true);
#line 20 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
WriteAttributeValue("", 706, i == 0 ? " active" : "", 706, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(733, 50, true);
            WriteLiteral(">\r\n                    <img class=\"img-responsive\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 783, "\"", 814, 1);
#line 21 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
WriteAttributeValue("", 789, ViewBag.Photos[i].Source, 789, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(815, 83, true);
            WriteLiteral(">\r\n                    <div class=\"carousel-caption\">\r\n                        <h2>");
            EndContext();
            BeginContext(899, 22, false);
#line 23 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
                       Write(ViewBag.Photos[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(921, 34, true);
            WriteLiteral("</h2>\r\n                        <p>");
            EndContext();
            BeginContext(956, 29, false);
#line 24 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
                      Write(ViewBag.Photos[i].Description);

#line default
#line hidden
            EndContext();
            BeginContext(985, 58, true);
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 27 "D:\Programs\Projects\Photo.by\ASPNetCoreTest3\Views\Album\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1058, 234, true);
            WriteLiteral("        </div>\r\n        <!-- Carousel nav -->\r\n        <a class=\"carousel-control left\" href=\"#carousel\" data-slide=\"prev\">‹</a>\r\n        <a class=\"carousel-control right\" href=\"#carousel\" data-slide=\"next\">›</a>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASPNetCoreTest3.Models.Album> Html { get; private set; }
    }
}
#pragma warning restore 1591