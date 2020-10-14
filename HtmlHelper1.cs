using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gui_
{
    public static class CustomHtmlHelepers
    {
        public static IHtmlString ImageActionLink(this HtmlHelper htmlHelper, string linkText, string action, string controller, object routeValues, object htmlAttributes, string imageSrc, int size)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var img = new TagBuilder("img");
            if(imageSrc!=null)
            {
                
                img.Attributes.Add("src", VirtualPathUtility.ToAbsolute("~/images/"+imageSrc));
            }
            
            img.Attributes.Add("style", $"width:{size}px");
            var anchor = new TagBuilder("a")
            {
                InnerHtml = img.ToString(TagRenderMode.SelfClosing)
            };
            anchor.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            anchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(anchor.ToString());
        }

        public static MvcHtmlString DropDownListForUsers(this HtmlHelper htmlHelper, string name)
        {
            DrugAdminLogic bl = new DrugAdminLogic();
            string options = "";
            foreach (var user in bl.listMedicine())
            {
                options += $"<option value ='{user.Name}'> {user.Name} </option>";
            }
            return new MvcHtmlString($"<select  name={name} style='color:black'>{options}</select>");
        }

        public static MvcHtmlString DropDownListForDctors(this HtmlHelper htmlHelper, string name)
        {
            DoctorAdminLogic bl = new DoctorAdminLogic();
            string options = "";
            foreach (var user in bl.listDoctors())
            {
                options += $"<option value ='{user.IdP}'> {user.IdP} </option>";
            }
            return new MvcHtmlString($"<select  name={name}  style='color:black style:position:relative; width:220px;'>{options}</select>");
        }

        public static MvcHtmlString DropDownListForPatient(this HtmlHelper htmlHelper, string name)
        {
            PatientAdminLogic bl = new PatientAdminLogic();
            string options = "";
            foreach (var user in bl.listPatient())
            {
                options += $"<option value ='{user.IdP}'> {user.IdP} </option>";
            }
            return new MvcHtmlString($"<select  name={name}  style='color:black style:position:relative; width:220px;'>{options}</select>");
        }

       
    }
          
 }
    

