///////////////////////////////////////////////////////////////////
//
// ISPIRO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Globalization;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ybq31.Ispiro.Server.Common.Razor.TagHelpers
{
    /// <summary>
    /// Razor tag helper for element CARD
    /// </summary>
    [HtmlTargetElement("card")]
    public class CardTagHelper : TagHelper
    {
        public CardTagHelper()
        {
            Value = 0;
            Text = "";
            Icon = "";
            Title = "";
            Type = ElementStatus.Active;
        }

        /// <summary>
        /// Determines the visual style according to Bootstrap states (primary|warning|etc)
        /// </summary>
        public ElementStatus Type { get; set; }

        /// <summary>
        /// Title of the card
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Full FA icon to show (fa fa-xxx ...)
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Text to display (takes precedence over Value)
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// If specified, shows a progress bar
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Internal HTML factory 
        /// </summary>
        /// <param name="context">Custom markup tree</param>
        /// <param name="output">HTML final tree</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string cardTypeClass = "";
            string titleTypeClass = "";
            string bgTypeClass = "";
            string val = "";

            if (Type == ElementStatus.Active)
            {
                cardTypeClass = "border-left-primary";
                titleTypeClass = "text-primary";
            }
            else if (Type == ElementStatus.Success)
            {
                cardTypeClass = "border-left-success";
                titleTypeClass = "text-success";
                bgTypeClass = "bg-success";
            }
            else if (Type == ElementStatus.Info)
            {
                cardTypeClass = "border-left-info";
                titleTypeClass = "text-info";
                bgTypeClass = "bg-info";
            }
            else if (Type == ElementStatus.Warning)
            {
                cardTypeClass = "border-left-warning";
                titleTypeClass = "text-warning";
                bgTypeClass = "bg-warning";

            }

            if(Text != "" && Value > 0)
            {
                val = Text;
            }
            else if(Text != "" && Value <= 0)
            {
                val = Text;
            }
            else if(Text == "" && Value > 0)
            {
                val = Value.ToString(CultureInfo.InvariantCulture);
            }
            if(Text != "")
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "col-xl-3 col-md-6 mb-4");
                output.Content.AppendHtml("<div class=\"card " + cardTypeClass + " shadow h-100 py-2\">");
                output.Content.AppendHtml("<div class=\"card-body\">");
                output.Content.AppendHtml("<div class=\"row no-gutters align-items-center\">");
                output.Content.AppendHtml("<div class=\"col mr-2\">");
                output.Content.AppendHtml("<div class=\"text-xs font-weight-bold " + titleTypeClass + " text-uppercase mb-1\">" + Title + "</div>");
                output.Content.AppendHtml("<div class=\"h5 mb-0 font-weight-bold text-gray-800\">" + val + "</div>");
                output.Content.AppendHtml("</div>");
                output.Content.AppendHtml("<div class=\"col-auto\">");
                output.Content.AppendHtml("<i class=\"" + Icon + " text-gray-300\"></i>");
                output.Content.AppendHtml("</div></div></div></div>");
                output.TagMode = TagMode.StartTagAndEndTag;
            }
            else if (Text == "" && (Value > 0 && Value <= 100))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "col-xl-3 col-md-6 mb-4");
                output.Content.AppendHtml("<div class=\"card " + cardTypeClass + " shadow h-100 py-2\">");
                output.Content.AppendHtml("<div class=\"card-body\">");
                output.Content.AppendHtml("<div class=\"row no-gutters align-items-center\">");
                output.Content.AppendHtml("<div class=\"col mr-2\">");
                output.Content.AppendHtml("<div class=\"text-xs font-weight-bold " + titleTypeClass + " text-uppercase mb-1\">" + Title + "</div>");
                output.Content.AppendHtml("<div class=\"row no-gutters align-items-center\">");
                output.Content.AppendHtml("<div class=\"col-auto\">");
                output.Content.AppendHtml("<div class=\"h5 mb-0 font-weight-bold text-gray-800 mr-3\">" + val + "%</div>");
                output.Content.AppendHtml("</div>");
                output.Content.AppendHtml("<div class=\"col\">");
                output.Content.AppendHtml("<div class=\"progress progress-sm mr-2\">");
                output.Content.AppendHtml("<div class=\"progress-bar " + bgTypeClass + "\" role=\"progressbar\" style=\"width:" + val +"%\" aria-valuenow=\"" + val + "\" aria-valuemin=\"0\" aria-valuemax=\"100\"></div>");
                output.Content.AppendHtml("</div></div></div></div>");
                output.Content.AppendHtml("<div class=\"col-auto\">");
                output.Content.AppendHtml("<i class=\"" + Icon + " text-gray-300\"></i>");
                output.Content.AppendHtml("</div></div></div></div>");
                output.TagMode = TagMode.StartTagAndEndTag;
            }
            else
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "col-xl-3 col-md-6 mb-4");
                output.Content.AppendHtml("<div class=\"card " + cardTypeClass + " shadow h-100 py-2\">");
                output.Content.AppendHtml("<div class=\"card-body\">");
                output.Content.AppendHtml("<div class=\"row no-gutters align-items-center\">");
                output.Content.AppendHtml("<div class=\"col mr-2\">");
                output.Content.AppendHtml("<div class=\"text-xs font-weight-bold " + titleTypeClass + " text-uppercase mb-1\">" + Title + "</div>");
                output.Content.AppendHtml("<div class=\"h5 mb-0 font-weight-bold text-gray-800\">" + val + "</div>");
                output.Content.AppendHtml("</div>");
                output.Content.AppendHtml("<div class=\"col-auto\">");
                output.Content.AppendHtml("<i class=\"" + Icon + " text-gray-300\"></i>");
                output.Content.AppendHtml("</div></div></div></div>");
                output.TagMode = TagMode.StartTagAndEndTag;
            }
        }
    }
}
