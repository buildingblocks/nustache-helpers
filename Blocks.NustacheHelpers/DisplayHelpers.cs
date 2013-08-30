using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nustache.Core;

namespace Blocks.NustacheHelpers
{
    public class DisplayHelpers
    {
        public static void Register()
        {
            if (!Helpers.Contains("nl2br"))
                Helpers.Register("nl2br", Nl2BrHelper);
        }

        internal static void Nl2BrHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                         RenderBlock fn, RenderBlock inverse)
        {
            var text = args[0].ToString();
            var nl2br = Regex.Replace(text, "([^>\r\n]?)(\r\n|\n\r|\r|\n)", "$1<br>$2");
            ctx.Write(nl2br);
        }
    }
}