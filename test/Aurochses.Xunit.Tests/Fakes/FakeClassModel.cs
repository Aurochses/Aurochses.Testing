using System.Diagnostics.CodeAnalysis;

namespace Aurochses.Xunit.Tests.Fakes
{
    [ExcludeFromCodeCoverage]
    [FakeClass]
    public class FakeClassModel
    {
        [FakeProperty("TestProtectedValue", Value = "TestValue")]
        public string Value { get; set; }

        [FakeMethod]
        public void Get(string value)
        {

        }

        [FakeMethod]
        public void Get()
        {

        }
    }
}