using System;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    [Serializable]
    public class Variable: BaseObject<object>
    {
        public new string Type { get; set; } = "variable";
    }
}
