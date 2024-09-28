using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADV80s2Core : MonoBehaviour
{
    [SerializeField] private ADV80s2Dispatcher _dispatcher;

    public bool StandBy { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        StandBy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_dispatcher == null) {
            return;
        }

        switch(_dispatcher.Type()){
            case "plot":
            case "scenario":
            case "scene":
            case "sub_scene":
                break;
        }
    }
}
