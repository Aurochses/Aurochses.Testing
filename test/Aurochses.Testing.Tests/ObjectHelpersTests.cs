using System;
using System.Collections.Generic;
using Aurochses.Testing.Tests.Fakes;
using Xunit;

namespace Aurochses.Testing.Tests
{
    public class ObjectHelpersTests
    {
        public static IEnumerable<object[]> EqualMemberData => new[]
        {
            new object[] {null, null, true},

            new object[] {new {Value = "TestValue"}, null, false},
            new object[] {null, new {Value = "TestValue"}, false},

            new object[] {new {}, new {}, true},
            new object[] {new {}, null, false},
            new object[] {null, new {}, false},

            new object[] {new {Value = "TestValue"}, new {OtherValue = "TestValue"}, false},
            new object[] {new {Value = "TestValue", SecondValue = "TestSecondValue"}, new {Value = "TestValue"}, false},
            new object[] {new {Value = "TestValue"}, new {Value = "TestValue", SecondValue = "TestSecondValue"}, false},

            new object[]
            {
                new {Value = new Guid("00000000-0000-0000-0000-000000000001"), SecondValue = "TestSecondValue"},
                new {Value = new Guid("00000000-0000-0000-0000-000000000001"), SecondValue = "TestSecondValue"},
                true
            },
            new object[]
            {
                new {Value = new Guid("00000000-0000-0000-0000-000000000001"), SecondValue = "TestSecondValue"},
                new {SecondValue = "TestSecondValue", Value = new Guid("00000000-0000-0000-0000-000000000001")},
                true
            },
            new object[]
            {
                new {Value = new Guid("00000000-0000-0000-0000-000000000001"), SecondValue = "TestSecondValue"},
                new {Value = new Guid("00000000-0000-0000-0000-000000000002"), SecondValue = "TestSecondValue"},
                false
            },

            new object[] {"TestValue", "TestValue", true},
            new object[] {"TestValue", "OtherTestValue", false},

            new object[] {1, 1, true},
            new object[] {1, 2, false},

            new object[]
            {
                new Guid("00000000-0000-0000-0000-000000000001"),
                new Guid("00000000-0000-0000-0000-000000000001"),
                true
            },
            new object[]
            {
                new Guid("00000000-0000-0000-0000-000000000001"),
                new Guid("00000000-0000-0000-0000-000000000002"),
                false
            },

            new object[] {"TestValue", 1, false},
            new object[] {1, "TestValue", false},
            new object[] {"TestValue", new Guid("00000000-0000-0000-0000-000000000001"), false},
            new object[] {new Guid("00000000-0000-0000-0000-000000000001"), "TestValue", false},

            new object[]
            {
                new ObjectHelpersEqualMemberDataModel {Value = null},
                new ObjectHelpersEqualMemberDataModel {Value = null},
                true
            },
            new object[]
            {
                new ObjectHelpersEqualMemberDataModel {Value = "One"},
                new ObjectHelpersEqualMemberDataModel {Value = "One"},
                true
            },
            new object[]
            {
                new ObjectHelpersEqualMemberDataModel {Value = "One"},
                new ObjectHelpersEqualMemberDataModel {Value = "Two"},
                false
            },
            new object[]
            {
                new ObjectHelpersEqualMemberDataModel {Value = null},
                new ObjectHelpersEqualMemberDataModel {Value = ""},
                false
            },
            new object[]
            {
                new ObjectHelpersEqualMemberDataModel {Value = ""},
                new ObjectHelpersEqualMemberDataModel {Value = null},
                false
            },

            new object[]
            {
                new ObjectHelpersEqualMemberDataListModel
                {
                    Items = null
                },
                new ObjectHelpersEqualMemberDataListModel
                {
                    Items = new List<ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel>
                    {
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "One"},
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "Two"}
                    }
                },
                false
            },
            new object[]
            {
                new ObjectHelpersEqualMemberDataListModel
                {
                    Items = new List<ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel>
                    {
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "One"},
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "Two"}
                    }
                },
                new ObjectHelpersEqualMemberDataListModel
                {
                    Items = new List<ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel>
                    {
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "One"},
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "OtherTwo"}
                    }
                },
                false
            },
            new object[]
            {
                new ObjectHelpersEqualMemberDataListModel
                {
                    Items = new List<ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel>
                    {
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "One"},
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "Two"}
                    }
                },
                new ObjectHelpersEqualMemberDataListModel
                {
                    Items = new List<ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel>
                    {
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "One"},
                        new ObjectHelpersEqualMemberDataListModel.ObjectHelpersEqualMemberDataListItemModel {Value = "Two"}
                    }
                },
                true
            },

            new object[]
            {
                null,
                new List<string>
                {
                    "One",
                    "Two"
                },
                false
            },
            new object[]
            {
                new List<string>
                {
                    "One",
                    "Two"
                },
                new List<string>
                {
                    "One",
                    "OtherTwo"
                },
                false
            },
            new object[]
            {
                new List<string>
                {
                    "One",
                    "Two"
                },
                new List<string>
                {
                    "One",
                    "Two"
                },
                true
            },

            new object[] {new {Value = "TestValue"}, new {Value = "OtherTestValue"}, false},
            new object[] {new {Value = 1}, new {Value = 2}, false},
            new object[] {new {Value = true}, new {Value = false}, false},
            new object[]
            {
                new {Value = new Guid("00000000-0000-0000-0000-000000000001")},
                new {Value = new Guid("00000000-0000-0000-0000-000000000002")},
                false
            },

            new object[] {new {Value = "TestValue"}, new {Value = "TestValue"}, true},
            new object[] {new {Value = 1}, new {Value = 1}, true},
            new object[] {new {Value = true}, new {Value = true}, true},
            new object[]
            {
                new {Value = new Guid("00000000-0000-0000-0000-000000000001")},
                new {Value = new Guid("00000000-0000-0000-0000-000000000001")},
                true
            }
        };

        [Theory]
        [MemberData(nameof(EqualMemberData))]
        public void Equal_Success(object obj, object objTo, bool isEqual)
        {
            // Arrange & Act & Assert
            Assert.Equal(isEqual, obj.Equal(objTo));
        }
    }
}