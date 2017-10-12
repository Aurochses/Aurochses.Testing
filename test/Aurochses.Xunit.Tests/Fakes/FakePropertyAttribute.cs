using System;

namespace Aurochses.Xunit.Tests.Fakes
{
    public class FakePropertyAttribute : Attribute
    {
        public FakePropertyAttribute(string protectedValue)
        {
            ProtectedValue = protectedValue;
        }

        public string Value { get; set; }
        protected string ProtectedValue { get; set; }
    }
}