using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADV80s2Subscriber : MonoBehaviour
{
    [SerializeField]
    private ADV80s2Core _core;

    public bool StandBy { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        StandBy = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Core の準備ができているときのみ Core への引き渡しが可能
        if (_core == null || !_core.StandBy) {
            return;
        }
    }
}
