using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    public class Scenario: BaseObject
    {
        public new string Type { get; set; } = "scenario";
        public List<Plot> Plots  { get; set; } = new List<Plot>();
    }
}
