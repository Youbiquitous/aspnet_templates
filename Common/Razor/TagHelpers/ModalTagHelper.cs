﻿///////////////////////////////////////////////////////////////////
//
// ISPIRO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ybq31.Ispiro.Server.Common.Razor.TagHelpers
{
    [HtmlTargetElement("modal")]
    public class ModalTagHelper : TagHelper
    {
        public ModalTagHelper()
        {
            Ok = false;
            Fade = false;
        }

        /// <summary>
        /// Id of the element (probably useless)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Whether to add an OK button
        /// </summary>
        public bool Ok { get; set; }

        /// <summary>
        /// Whether to apply the fade animation
        /// </summary>
        public bool Fade { get; set; }

        /// <summary>
        /// Internal HTML factory 
        /// </summary>
        /// <param name="context">Custom markup tree</param>
        /// <param name="output">HTML final tree</param>
        public override void Process(
            TagHelperContext context, TagHelperOutput output)
        {
            // Create the context for child elements
            var modalContext = new ModalContext
            {
                Id = Id, //output.Attributes["id"].Value.ToString(),
                OkButton = Ok,
                Fade = Fade
            };
            context.Items[typeof(ModalContext)] = modalContext;

            // Replace <modal> with <div> 
            output.TagName = "div";
            if (output.Attributes.ContainsName("id"))
                output.Attributes.Remove(context.AllAttributes["id"]);
            if (output.Attributes.ContainsName("ok"))
                output.Attributes.Remove(context.AllAttributes["ok"]);
            if (output.Attributes.ContainsName("fade"))
                output.Attributes.Remove(context.AllAttributes["fade"]);
        }
    }
}

