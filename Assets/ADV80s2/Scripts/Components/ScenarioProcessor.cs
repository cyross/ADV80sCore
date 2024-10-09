using UnityEngine;
using  Assets.ADV80s2.Scripts.ADV80s2.Core;
using  Assets.ADV80s2.Scripts.ADV80s2.Object;

public class ScenarioProcessor : ADV80s2Component
{
    private Scenario _compiled = null;

    private Scenario Compile(string script) {
        return new Scenario();
    }

    public void Load(string script) {
        _compiled = Compile(script);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (publisher == null) {
            Debug.LogError("Not attempt ADV80s2Publisher!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // パブリッシャーが登録されていない、スクリプトがロードされていないときは何もしない
        if (publisher == null || _compiled == null) {
            return;
        }
    }
}
