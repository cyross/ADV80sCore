using UnityEngine;
using VFolders.Libs;

namespace Assets.ADV80s2.Scripts.ADV80s2.Core {
    public class Subscriber : MonoBehaviour
    {
        public string Name = "";

        public ADV80s2Component Component;

        private Object.MessageObject _message = null;

        public bool StandBy { get; set; }

        public void Subscribe(Object.MessageObject message) {
            _message = message;
        }

        // Start is called before the first frame update
        void Start()
        {
            // 名前が未登録の場合は付与されている GameObject の名前を設定
            if (Name.IsEmpty()) {
                Name = gameObject.name;
            }

            StandBy = true;
        }

        // Update is called once per frame
        void Update()
        {
            // Component が 紐づけられており、 Component と自分自身の StandBy が true のときのみ
            // Component への引き渡しが可能
            if (_message == null || Component == null || !Component.StandBy || !StandBy ) {
                return;
            }

            StandBy = false;

            Component.DoMessage(_message);

            _message = null;

            StandBy = true;
        }
    }
}

