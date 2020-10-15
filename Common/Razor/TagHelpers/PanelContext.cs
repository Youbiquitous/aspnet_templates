///////////////////////////////////////////////////////////////////
//
// ISPIRO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

namespace Ybq31.Ispiro.Server.Common.Razor.TagHelpers
{
    /// <summary>
    /// Internal context class to pass information around the MODAL custom markup tree
    /// </summary>
    public class PanelContext
    {
        public string Id { get; set; }
        public bool Collapsable { get; set; }
        public CollapseStatus CollapseStatus { get; set; }
    }
}