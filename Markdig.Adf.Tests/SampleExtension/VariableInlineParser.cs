using System;
using System.Collections.Generic;
using System.Text;
using Markdig.Helpers;
using Markdig.Parsers;

namespace Visp.ProblemManagement.AzureFunctions.Templating
{
    class VariableInlineParser : InlineParser
    {
        private static readonly char[] openingCharacters = { '$' };

        public VariableInlineParser()
        {
            OpeningCharacters = openingCharacters;
        }

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            if (slice.CurrentChar == '$' && slice.PeekChar(1) == '(')
            {
                slice.NextChar();
                slice.NextChar();

                int start = slice.Start;
                int end = start;

                while (slice.CurrentChar != ')')
                {
                    end = slice.Start;
                    slice.NextChar();
                }

                processor.GetSourcePosition(slice.Start, out int line, out int column);

                processor.Inline = new VariableInline
                {
                    Line = line,
                    Column = column,
                    VariableName = new StringSlice(slice.Text, start, end)
                };

                slice.NextChar();

                return true;
            }

            return false;
        }
    }
}
