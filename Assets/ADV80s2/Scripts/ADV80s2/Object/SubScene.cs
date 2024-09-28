using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    public class SubScene: BaseObject
    {
        public new string Type { get; set; } = "sub_scene";
        public List<SubScene> SubScenes  { get; set; } = new List<SubScene>();
        public List<Command> Comands {  get; set; } = new List<Command>();
    }
}
