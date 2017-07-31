using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Don.Sportsstore.Web.Models.Product;

namespace Don.Sportsstore.Web.HtmlHelpers
{
    public static class PagingHelpers
    {

       // public static MvcHtmlString Pagelinks2(this HtmlHelper html,)

        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 1; i < pagingInfo.TotalPages +1; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                 var pageUrlVar = pageUrl(i);
                //var currentPage = i + 1;
                //var pageUrlVar = pageUrl(currentPage);

                tag.MergeAttribute("href", pageUrlVar);
                 tag.InnerHtml = i.ToString();
                //tag.InnerHtml = currentPage.ToString();

                if (i==pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                stringBuilder.Append(tag);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}