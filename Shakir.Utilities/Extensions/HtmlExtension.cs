using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shakir.Utilities.Extensions
{
    public static class HtmlExtension
    {
        public static MvcHtmlString SubmitLink(this HtmlHelper html, string buttonText)
        {
            var tag = new TagBuilder("input");

            tag.Attributes.Add("type", "submit");
            tag.Attributes.Add("value", buttonText);
            tag.Attributes.Add("style", "border: none;  background: transparent;  cursor: pointer");

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper html, string buttonText)
        {
            var tag = new TagBuilder("input");

            tag.Attributes.Add("type", "submit");
            tag.Attributes.Add("value", buttonText);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString InlineSubmitButton(this HtmlHelper html, string buttonText)
        {
            var tag = new TagBuilder("input");

            tag.Attributes.Add("type", "submit");
            tag.Attributes.Add("data-inline", "true");
            tag.Attributes.Add("value", buttonText);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static RouteValueDictionary AnonymousObjectToHtmlAttributes(object htmlAttributes)
        {
            var result = new RouteValueDictionary();

            if (htmlAttributes == null)
                return result;

            foreach (System.ComponentModel.PropertyDescriptor property in System.ComponentModel.TypeDescriptor.GetProperties(htmlAttributes))
            {
                result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
            }

            return result;
        }

        public static MvcHtmlString Html5ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes, object htmlDataAttributes)
        {
            if (string.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException(string.Empty, nameof(linkText));
            }

            var html = new RouteValueDictionary(htmlAttributes);

            foreach (var attributes in new RouteValueDictionary(htmlDataAttributes))
            {
                html.Add($"data-{attributes.Key}", attributes.Value);
            }

            return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null, actionName, controllerName, new RouteValueDictionary(routeValues), html));
        }

        public static MvcHtmlString RadioLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string stringValue, string choice)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (string.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            var tag = new TagBuilder("label");

            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(
                $"{htmlFieldName}-{choice}"));
            tag.SetInnerText(stringValue);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString MyRadioButtonFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string stringValue, bool boolValue, string choice)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (string.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            var tag = new TagBuilder("input");

            tag.Attributes.Add("name", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.Attributes.Add("id", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(
                $"{htmlFieldName}-{choice}"));
            tag.Attributes.Add("type", "radio");
            if (boolValue) tag.Attributes.Add("checked", "checked");

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString LabelForChoice(this HtmlHelper html, string id, string value)
        {
            var tag = new TagBuilder("label");
            tag.Attributes.Add("for", id);
            tag.SetInnerText(value);
            var result = tag.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString LabelForRadio(this HtmlHelper html, string id, string value, bool hidden = false)
        {
            var tag = new TagBuilder("label");
            tag.Attributes.Add("for", id);

            if (hidden)
            {
                tag.Attributes.Add("class", "ui-hidden-accessible");
            }

            tag.SetInnerText(value);

            var result = tag.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ImageSubmitButton(this HtmlHelper html, string buttonText, string icon)
        {
            var tag = new TagBuilder("input");

            tag.Attributes.Add("type", "submit");
            tag.Attributes.Add("data-iconpos", "notext");
            tag.Attributes.Add("value", buttonText);
            tag.Attributes.Add("data-icon", icon);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ImageFor(this HtmlHelper html, string src, string alt)
        {
            var tag = new TagBuilder("img");

            tag.Attributes.Add("src", src);
            tag.Attributes.Add("alt", alt);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString SearchFor(this HtmlHelper html, string type, string id, string placeholder, string value)
        {
            var tag = new TagBuilder("input");

            tag.MergeAttribute("type", type);
            tag.MergeAttribute("id", id);
            tag.MergeAttribute("placeholder", placeholder);
            tag.MergeAttribute("value", value);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ExCheckBox(this HtmlHelper html, string id, bool value)
        {
            var tag = new TagBuilder("input");

            tag.MergeAttribute("type", "checkbox");
            tag.MergeAttribute("id", id);
            tag.MergeAttribute("name", id);

            if (value)
            {
                tag.MergeAttribute("checked", "checked");
            }

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}
