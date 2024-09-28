using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADV80s2Publisher : MonoBehaviour
{
    [SerializeField]
    private ADV80s2Subscriber _subscriber;

    public bool StandBy { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        StandBy = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Subscriber の準備ができているときのみ Subscriber への引き渡しが可能
        if (_subscriber == null || !_subscriber.StandBy) {
            return;
        }
    }
}
