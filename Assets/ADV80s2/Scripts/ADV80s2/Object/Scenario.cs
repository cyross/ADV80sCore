using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    public class Scenario: BaseObject<List<Plot>>
    {
        public new string Type { get; set; } = "scenario";
        public new List<Plot> Body  { get; set; } = new List<Plot>();
    }
}
