using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    public class Command: BaseObject<object>
    {
        public new string Type { get; set; } = "command";
        public Dictionary<string, object> Parameters { get; set;} = new Dictionary<string, object>();
    }
}
