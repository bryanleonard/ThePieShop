using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ThePieShop.TagHelpers
{
    public class EmailTagHelper: TagHelper
    {
        public string Address { get; set; }
        public string Content { get; set; }

        // overwriting the Process method here... Not sure if that's a good thing.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(Content);
        }
    }
}
