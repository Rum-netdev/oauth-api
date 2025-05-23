using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace OAuthSystem.Web.TagHelpers
{
    [HtmlTargetElement("self-script")]
    public class SelfScriptTagHelper : TagHelper
    {
        private readonly IWebHostEnvironment _env;

        [HtmlAttributeName("script-name")]
        public string ScriptName { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public SelfScriptTagHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var viewPath = ViewContext.ExecutingFilePath;   // e.g /Views/Shared/.../*.cshtml
            var viewDirectory = Path.GetDirectoryName(viewPath)!.Replace("\\", "/");

            var scriptPath = $"{viewDirectory}/{this.ScriptName}.cshtml.js";
            output.TagName = "script";
            output.Attributes.Add("src", scriptPath);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
