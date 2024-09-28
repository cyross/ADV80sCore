using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    public class Plot: BaseObject
    {
        public new string Type { get; set; } = "plot";
        public List<Scene> Scenes  { get; set; } = new List<Scene>();
    }
}
