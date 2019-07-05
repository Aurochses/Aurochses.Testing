using KellermanSoftware.CompareNetObjects;
using Xunit.Sdk;

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
        public static void DeepEquals(object expected, object actual)
        {
            var comparisonResult = new CompareLogic().Compare(expected, actual);

            if (!comparisonResult.AreEqual)
            {
                throw new AssertActualExpectedException(expected, actual, comparisonResult.DifferencesString);
            }
        }
    }
}