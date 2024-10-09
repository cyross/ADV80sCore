using System;
using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Enumerators {

  [Serializable]
    public enum State {
      IDLE = 0,
      INITIALIZING = 1,
      STANDBY = 2,
      PROCESSING = 3,
    }
}
