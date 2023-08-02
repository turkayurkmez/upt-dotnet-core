using eshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace eshop.MVC.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationBuilder : TagHelper
    {
        public string PageAction { get; set; }
        public PagingInfo PageModel { get; set; }

        IUrlHelperFactory urlHelperFactory;

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public PaginationBuilder(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder div = new TagBuilder("div");
            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            for (int i = 1; i <= PageModel.PageCount; i++)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                if (i == PageModel.CurrentPage)
                {
                    li.AddCssClass("active");
                }
                TagBuilder a = new TagBuilder("a");
                a.AddCssClass("page-link");
                a.InnerHtml.AppendHtml(i.ToString());
                a.Attributes["href"] = urlHelper.Action(PageAction, new { pageNo = i });

                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);

            }

            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);

        }


    }
}

/*
 * 
  <ul class="pagination pagination-lg">
    <li class="page-item active" aria-current="page">
      <span class="page-link">1</span>
    </li>
    <li class="page-item"><a class="page-link" href="/Home/Index?page=2">2</a></li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
  </ul>

 */