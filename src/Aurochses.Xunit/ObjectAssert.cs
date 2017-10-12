using Aurochses.Runtime;
using Xunit;

namespace Aurochses.Xunit
{
    /// <summary>
    /// ObjectAssert.
    /// </summary>
    public static class ObjectAssert
    {
        /// <summary>
        /// Validate two object are equal based on values.
        /// </summary>
        /// <param name="expected">The expected object.</param>
        /// <param name="actual">The actual object.</param>
        public static void ValueEquals(object expected, object actual)
        {
            Assert.True(expected.ValueEquals(actual));
        }
    }
}