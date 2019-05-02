using Markdig.Helpers;
using Markdig.Syntax.Inlines;

namespace Visp.ProblemManagement.AzureFunctions.Templating
{
    internal class VariableInline : LeafInline
    {
        public StringSlice VariableName { get; set; }
    }
}
