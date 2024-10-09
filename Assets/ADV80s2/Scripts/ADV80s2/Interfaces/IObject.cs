using System;
using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Interfaces {
    public interface IObject<T>
    {
      public string Type { set; get; }
      public Boolean IsBroadcast { set; get; }
      public T Body { set; get;}
    }
}
