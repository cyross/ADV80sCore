using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Interfaces {
    public interface IStatusManagement
    {
        public Enumerators.State State { get; set; }
        public bool IsStandBy();
    }
}
