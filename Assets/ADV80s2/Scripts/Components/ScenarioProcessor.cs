using UnityEngine;
using  Assets.ADV80s2.Scripts.ADV80s2.Core;
using  Assets.ADV80s2.Scripts.ADV80s2.Object;

public class ScenarioProcessor : MonoBehaviour
{
    [SerializeField]
    private Publisher _publisher;

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
        if (_publisher == null) {
            Debug.LogError("Not attempt ADV80s2Publisher!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // パブリッシャーが登録されていない、スクリプトがロードされていないときは何もしない
        if (_publisher == null || _compiled == null) {
            return;
        }
    }
}
