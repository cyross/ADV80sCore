using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADV80s2Object
{
    public class MessageObject
    {
        private CoreObject _object = null;

        public CoreObject Object { get; set; }

        public string Type() {
            if (_object == null) {
                return "";
            }

            return _object.Type;
        }
    }
}