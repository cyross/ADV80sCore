using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    [Serializable]
    public class Flags: BaseObject<Dictionary<string, bool>>
    {
        public new string Type { get; set; } = "const";

        public void Clear()
        {
            Body.Clear();
        }

        public void DeSerialize(string jsonString)
        {
            Body = JsonUtility.FromJson<Dictionary<string, bool>>(jsonString);
        }

        public string Serialize()
        {
            return JsonUtility.ToJson(Body);
        }
    }
}
