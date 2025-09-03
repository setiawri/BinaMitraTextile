using BinaMitraTextileWebCore.Controllers;
using BinaMitraTextileWebCore.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq.Expressions;
using System.Web;

namespace BinaMitraTextileWebCore
{
	public class BaseController : Controller
	{ 
		protected AppDBContext dbContext => HttpContext == null ? Helper.CreateDBContext() : (AppDBContext)HttpContext.RequestServices.GetService(typeof(AppDBContext));
		//protected string ControllerName => this.ControllerContext.ActionDescriptor.ControllerName;
		//protected UserAccountRolesModel userAccess => HttpContext == null ? null : UserAccountsController.getUserAccess(HttpContext);
	}

    public class HelperController : Controller
	{
		public string getUrl(string action, string controller)
		{
			return this.Url.Action(action, controller);
		}
	}

	public struct Breadcrumb
	{
		public string DisplayText;
		public string URL = null;

		public Breadcrumb(string displayText, string url = null)
		{
			DisplayText = displayText;
			URL = url;
		}
	}

	public struct ModelMember
    {
        public string Name;
        public Guid Id;
        public string Display;
        public string LogDisplay;
    }

    public class Select2Pagination
    {
        public class Select2Results
        {
            public Guid id { get; set; }
            public string text { get; set; }
            public string info1 { get; set; }
            public string info2 { get; set; }
            public string info3 { get; set; }
        }

        public class Select2Page
        {
            public bool more { get; set; }
        }
    }

    public static class HtmlExtensions
	{        
        //public static HtmlString DropDownList(this HtmlHelper html, string name, SelectList values, bool disabled)
        //{
        //    if (!disabled)
        //    {
        //        return html.DropDownList(name, values);
        //    }
        //    return html.DropDownList(name, values, new { disabled = "disabled" });
        //}

        //public static HtmlHelper DisplayMultiline<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression)
        //      {
        //          return HtmlString.Empty;
        //          //return new Microsoft.AspNetCore.Html.HtmlString(str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Aggregate((a, b) => a + "<br />" + b));

        //          //         var value = Convert.ToString(Microsoft.AspNetCore.Mvc.ViewFeatures.ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData).Model);

        //          //if (string.IsNullOrEmpty(value))
        //          //	return HtmlString.Empty;

        //          //value = string.Join("<br/>", value.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(HttpUtility.HtmlEncode));

        //          //return new HtmlString(value);
        //      }
    }
}
