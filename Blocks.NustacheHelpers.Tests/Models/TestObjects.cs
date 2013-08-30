using System;

namespace Blocks.NustacheHelpers.Tests.Models
{
    public class Comparable : IComparable
    {
        public string Thing { get; set; }

        public int CompareTo(object obj)
        {
            var comparable = obj as Comparable;
            if (comparable != null)
            {
                return Thing.CompareTo(comparable.Thing);
            }
            
            throw new ArgumentException("Object is not a Comparable.");
        }
    }

    public class Incomparable
    {
        public string Thing { get; set; }
    }
}