using System.Collections.Generic;

namespace Aurochses.Testing.Tests.Fakes
{
    public class ObjectHelpersEqualMemberDataListModel
    {
        public List<ObjectHelpersEqualMemberDataListItemModel> Items { get; set; }

        public class ObjectHelpersEqualMemberDataListItemModel
        {
            public string Value { get; set; }
        }
    }
}