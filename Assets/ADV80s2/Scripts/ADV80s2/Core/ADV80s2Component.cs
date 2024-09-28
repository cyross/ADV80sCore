using UnityEngine;

namespace Assets.ADV80s2.Scripts.ADV80s2.Core {
    public class ADV80s2Component : MonoBehaviour, Interfaces.IADV80s2Component
    {
        public void DoMessage(Object.MessageObject message) {
            // 継承先で実装
        }

        public bool StandBy { get; set; } = false;

        // Start is called before the first frame update
        void Start()
        {
            StandBy = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (!StandBy) {
                return;
            }
        }
    }
}
