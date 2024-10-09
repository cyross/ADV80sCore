using Assets.ADV80s2.Scripts.ADV80s2.Interfaces;
using UnityEngine;

namespace Assets.ADV80s2.Scripts.ADV80s2.Core {
    public class Publisher : MonoBehaviour, IStatusManagement
    {
        [SerializeField]
        private Dispatcher _dispatcher;

        public Enumerators.State State { get; set; } = Enumerators.State.STANDBY;

        public bool IsStandBy ()
        {
            return State == Enumerators.State.STANDBY;
        }

        public void Publish(Object.MessageObject message) {
            // Dispatcher と自分自身の受け入れ準備ができているときのみ Dispatcher への引き渡しが可能
            if (_dispatcher == null || !_dispatcher.IsStandBy() || !IsStandBy()) {
                return;
            }

            _dispatcher.Enqueue(message);
        }

        // Start is called before the first frame update
        void Start()
        {
            State = Enumerators.State.STANDBY;
        }

        // Update is called once per frame
        void Update() {}
    }
}

