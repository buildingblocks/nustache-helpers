using System;
using System.Collections.Generic;
using Nustache.Core;

namespace Blocks.NustacheHelpers
{
    public class EqualityHelpers
    {
        public static void Register()
        {
            if (!Helpers.Contains("if_eq"))
                Helpers.Register("if_eq", IfEqHelper);

            if (!Helpers.Contains("unless_eq"))
                Helpers.Register("unless_eq", UnlessEqHelper);

            if (!Helpers.Contains("if_gt"))
                Helpers.Register("if_gt", IfGtHelper);

            if (!Helpers.Contains("unless_gt"))
                Helpers.Register("unless_gt", UnlessGtHelper);

            if (!Helpers.Contains("if_lt"))
                Helpers.Register("if_lt", IfLtHelper);

            if (!Helpers.Contains("unless_lt"))
                Helpers.Register("unless_lt", UnlessLtHelper);

            if (!Helpers.Contains("if_gteq"))
                Helpers.Register("if_gteq", IfGtEqHelper);

            if (!Helpers.Contains("unless_gteq"))
                Helpers.Register("unless_gteq", UnlessGtEqHelper);

            if (!Helpers.Contains("if_lteq"))
                Helpers.Register("if_lteq", IfLtEqHelper);

            if (!Helpers.Contains("unless_lteq"))
                Helpers.Register("unless_lteq", UnlessLtEqHelper);
        }

        /// <summary>
        /// if_eq this compare=that
        /// </summary>
        internal static void IfEqHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                        RenderBlock fn, RenderBlock inverse)
        {
            if (args[0] == null)
            {
                inverse(args[0]);
                return;
            }
            if (args[0].Equals(options["compare"]))
                fn(args[0]);
            else
                inverse(args[0]);
        }

        /// <summary>
        /// unless_eq this compare=that
        /// </summary>
        internal static void UnlessEqHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                            RenderBlock fn, RenderBlock inverse)
        {
            if (args[0] == null)
            {
                fn(args[0]);
                return;
            }

            if (args[0].Equals(options["compare"]))
                inverse(args[0]);
            else
                fn(args[0]);
        }

        /// <summary>
        /// if_gt this compare=that
        /// </summary>
        internal static void IfGtHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                        RenderBlock fn, RenderBlock inverse)
        {
            if (Compare(args[0], options["compare"]) > 0)
                fn(args[0]);
            else
                inverse(args[0]);
        }

        /// <summary>
        /// unless_gt this compare=that
        /// </summary>
        internal static void UnlessGtHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                            RenderBlock fn, RenderBlock inverse)
        {
            if (Compare(args[0], options["compare"]) > 0)
                inverse(args[0]);
            else
                fn(args[0]);
        }

        /// <summary>
        /// if_lt this compare=that
        /// </summary>
        internal static void IfLtHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                        RenderBlock fn, RenderBlock inverse)
        {
            if (Compare(args[0], options["compare"]) < 0)
                fn(args[0]);
            else
                inverse(args[0]);
        }

        /// <summary>
        /// unless_lt this compare=that
        /// </summary>
        internal static void UnlessLtHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                            RenderBlock fn, RenderBlock inverse)
        {
            if (Compare(args[0], options["compare"]) < 0)
                inverse(args[0]);
            else
                fn(args[0]);
        }

        /// <summary>
        /// if_gteq this compare=that
        /// </summary>
        internal static void IfGtEqHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                          RenderBlock fn, RenderBlock inverse)
        {
            if (Compare(args[0], options["compare"]) >= 0)
                fn(args[0]);
            else
                inverse(args[0]);
        }

        /// <summary>
        /// unless_gteq this compare=that
        /// </summary>
        internal static void UnlessGtEqHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                              RenderBlock fn, RenderBlock inverse)
        {
            if (Compare(args[0], options["compare"]) >= 0)
                inverse(args[0]);
            else
                fn(args[0]);
        }

        /// <summary>
        /// if_lteq this compare=that
        /// </summary>
        internal static void IfLtEqHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                          RenderBlock fn, RenderBlock inverse)
        {
            if (Compare(args[0], options["compare"]) <= 0)
                fn(args[0]);
            else
                inverse(args[0]);
        }

        /// <summary>
        /// unless_lteq this compare=that
        /// </summary>
        internal static void UnlessLtEqHelper(RenderContext ctx, IList<object> args, IDictionary<string, object> options,
                                              RenderBlock fn, RenderBlock inverse)
        {
            if (Compare(args[0], options["compare"]) <= 0)
                inverse(args[0]);
            else
                fn(args[0]);
        }

        private static int Compare(object target, object comparand)
        {
            if (target == null && comparand == null)
                return 0;

            if (comparand != null && target == null)
                return -1;

            if (comparand == null)
                return 1;

            var left = target as IComparable;
            var right = comparand as IComparable;

            if (left == null || right == null)
                throw new InvalidOperationException("The objects being compared must implement IComparable.");

            return left.CompareTo(right);
        }
    }
}