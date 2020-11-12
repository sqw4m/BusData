using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pachkoriya_HW09.Infrastructure.TagHelpers
{
    // tag helper будет применяться к элементам td с атрибутом weight-alert
    [HtmlTargetElement("td", Attributes = "weight-alert", ParentTag = "tr")]
    public class MaxWeightTagHelper : TagHelper
    {
        // Так как при генерации результата будет использоваться асинхронный метод, используется
        // асинхронный вариант метода Process
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // получение контента элемента, для которого применяется вспомогательный класс
            string content = (await output.GetChildContentAsync()).GetContent();

            if (int.TryParse(content, out int result))
            {
                if (result > 100 )
                {
                    output.Attributes.SetAttribute("class", "alert");
                } // if
            } // if
        } // ProcessAsync
    } // MaxWeightTagHelper
}
