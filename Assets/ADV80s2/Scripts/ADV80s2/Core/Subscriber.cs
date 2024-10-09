using Assets.ADV80s2.Scripts.ADV80s2.Interfaces;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.ADV80s2.Scripts.ADV80s2.Core {
    public class Subscriber : MonoBehaviour, IStatusManagement
    {
        public string Name = "";

        public ADV80s2Component Component;

        private Queue<Object.MessageObject> _messageQueue = new Queue<Object.MessageObject>();

        public Enumerators.State State { get; set; } = Enumerators.State.STANDBY;

        public bool IsStandBy ()
        {
            return State == Enumerators.State.STANDBY;
        }

        public void Subscribe(Object.MessageObject message)
        {
            _messageQueue.Enqueue(message);
        }

        // Start is called before the first frame update
        void Start()
        {
            // 名前が未登録の場合は付与されている GameObject の名前を設定
            if (Name == "") {
                Name = gameObject.name;
            }

            State = Enumerators.State.STANDBY;
        }

        // Update is called once per frame
        void Update()
        {
            // Component が 紐づけられており、 Component と自分自身の StandBy が true のときのみ
            // Component への引き渡しが可能
            if (Component == null || !Component.IsStandBy() || !IsStandBy()) {
                return;
            }

            State = Enumerators.State.PROCESSING;

            var message = _messageQueue.Dequeue();

            Component.DoMessage(message);

            State = Enumerators.State.STANDBY;
        }
    }
}

