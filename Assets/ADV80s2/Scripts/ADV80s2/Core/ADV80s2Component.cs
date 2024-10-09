using UnityEngine;

namespace Assets.ADV80s2.Scripts.ADV80s2.Core {
    public class ADV80s2Component : MonoBehaviour, Interfaces.IADV80s2Component
    {
        [SerializeField]
        private Publisher _publisher;

        [SerializeField]
        private GameObject _component;

        public void SendMessage(Object.MessageObject message) {
            if (_publisher == null) {
                return;
            }

            _publisher.Publish(message);
        }

        public void DoMessage(Object.MessageObject message) {
            if (_component == null) {
                return;
            }

            // 継承先で実装
        }

        public Enumerators.State State { get; set; } = Enumerators.State.STANDBY;

        public bool IsStandBy ()
        {
            return State == Enumerators.State.STANDBY;
        }

        // Start is called before the first frame update
        void Start()
        {
            State = Enumerators.State.STANDBY;
        }

        // Update is called once per frame
        void Update()
        {
            if (State != Enumerators.State.STANDBY) {
                return;
            }
        }
    }
}
