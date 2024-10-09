using System.Collections.Generic;
using UnityEngine;
using  Assets.ADV80s2.Scripts.ADV80s2.Object;

namespace Assets.ADV80s2.Scripts.ADV80s2.StatePool {
    public class StatePool : MonoBehaviour
    {
        private Dictionary<string, Variable> variables = new Dictionary<string, Variable>();
        private Dictionary<string, Const> constants = new Dictionary<string, Const>();
        private readonly Flags flags = new Flags();
        private readonly ScenarioPointer pointer = new ScenarioPointer();

        // Start is called before the first frame update
        void Start()
        {
            variables.Clear();
            constants.Clear();
            pointer.Reset();
            flags.Clear();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void DeSerialize(string jsonString) {
            string[] states = JsonUtility.FromJson<string[]>(jsonString);

            variables = JsonUtility.FromJson<Dictionary<string, Variable>>(states[0]);
            constants = JsonUtility.FromJson<Dictionary<string, Const>>(states[1]);
            pointer.DeSerialize(states[2]);
            flags.DeSerialize(states[3]);
        }

        public string Serialize() {
            string variables_string = JsonUtility.ToJson(variables);
            string constants_string = JsonUtility.ToJson(constants);
            string pointer_string = pointer.Serialize();
            string flags_string = flags.Serialize();

            return JsonUtility.ToJson(new string[4]{variables_string, constants_string, pointer_string, flags_string});
        }
    }
}

