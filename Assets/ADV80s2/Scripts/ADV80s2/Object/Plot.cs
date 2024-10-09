using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    public class Plot: BaseObject<List<Scene>>
    {
        public new string Type { get; set; } = "plot";
        public new List<Scene> Body  { get; set; } = new List<Scene>();
    }
}
