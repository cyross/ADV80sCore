using System;
using UnityEngine;

namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    [Serializable]
    public class CurrentScenarioPointer
    {
        public string ScenarioName { get; set; } = "";
        public string PlotName { get; set; } = "";
        public string SceneName { get; set; } = "";
        public string SubSceneName { get; set; } = "";
        public int CommandPointer { get; set; } = 0;
    }

    [Serializable]
    public class ScenarioPointer: BaseObject<CurrentScenarioPointer>
    {
        public new string Type { get; set; } = "scenario_pointer";

        public void Reset()
        {
          Body.ScenarioName = "";
          Body.PlotName = "";
          Body.SceneName = "";
          Body.SubSceneName = "";
          Body.CommandPointer = 0;
        }

      public void DeSerialize(string jsonString) {
          string[] states = JsonUtility.FromJson<string[]>(jsonString);
      
          Body.ScenarioName = states[0];
          Body.PlotName = states[1];
          Body.SceneName = states[2];
          Body.SubSceneName = states[3];
          Body.CommandPointer = JsonUtility.FromJson<int>(states[4]);
      }

      public string Serialize() {
          string command_pointer_string = JsonUtility.ToJson(Body.CommandPointer);

          return JsonUtility.ToJson(
            new string[5]{
              Body.ScenarioName,
              Body.PlotName,
              Body.SceneName,
              Body.SubSceneName,
              command_pointer_string
            }
          );
      }
    }
}
