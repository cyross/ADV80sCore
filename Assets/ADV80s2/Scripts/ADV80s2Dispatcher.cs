using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADV80s2Object;

public class ADV80s2Dispatcher : MonoBehaviour
{
    private Queue<ADV80s2Object.MessageObject> _messages = new Queue<ADV80s2Object.MessageObject>();

    public void Publish(ADV80s2Object.MessageObject message) {
        _messages.Enqueue(message);
    }

    public ADV80s2Object.MessageObject Subscribe(ADV80s2Object.MessageObject message) {
        return _messages.Dequeue();
    }

    public string Type() {
        if(_messages.Count == 0) {
            return "";
        }

        return _messages.Peek().Type();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
