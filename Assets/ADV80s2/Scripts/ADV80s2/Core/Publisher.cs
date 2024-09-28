using UnityEngine;

namespace Assets.ADV80s2.Scripts.ADV80s2.Core {
    public class Publisher : MonoBehaviour
    {
        [SerializeField]
        private Dispatcher _dispatcher;

        public bool StandBy { get; set; }

        public void Publish(Object.MessageObject message) {
            // Dispatcher と自分自身の受け入れ準備ができているときのみ Dispatcher への引き渡しが可能
            if (_dispatcher == null || !_dispatcher.StandBy || !StandBy) {
                return;
            }

            _dispatcher.Enqueue(message);
        }

        // Start is called before the first frame update
        void Start()
        {
            StandBy = true;
        }

        // Update is called once per frame
        void Update() {}
    }
}

