using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HicomInterview.Web.TagHelpers
{
    [HtmlTargetElement(Attributes = "hicom-grid")]
    public class HicomConditionalDisplayTagHelper : TagHelper
    {
        [HtmlAttributeName("hicom-grid")]
        public bool IsGrid { get; set; }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            if (IsGrid)
            {
                var id = output.Attributes["id"]?.Value.ToString();

                var contentBuilder = new HtmlContentBuilder();

                var renderGrid = new TagBuilder("div")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                renderGrid.Attributes["id"] = $"{id}Rendered";
                contentBuilder.AppendHtml(renderGrid);

                var script = new TagBuilder("script")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                script.InnerHtml.AppendHtml($@"
                    new HicomGrid('{id}', '{id}Rendered');
                ");
                contentBuilder.AppendHtml(script);


                output.PostElement.SetHtmlContent(contentBuilder);
            }
        }
    }
}
