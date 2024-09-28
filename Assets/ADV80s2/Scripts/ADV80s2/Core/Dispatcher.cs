using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VFolders.Libs;

namespace Assets.ADV80s2.Scripts.ADV80s2.Core {
    public class Dispatcher : MonoBehaviour
    {
        [SerializeField]
        private List<Subscriber> _subscribers = new List<Subscriber>();

        private Dictionary<string, Subscriber> _subscribersDict = new Dictionary<string, Subscriber>();

        private Queue<Object.MessageObject> _messageQueue = new Queue<Object.MessageObject>();

        private bool _setupCompleted = false;

        public bool StandBy { get; set; }

        // メッセージキューにメッセージを追加
        public void Enqueue(Object.MessageObject message) {
            _messageQueue.Enqueue(message);
        }

        // スクリプト内で新規のサブスクライバを登録
        public void AddSubscriber(Subscriber subscriber) {
            _subscribers.Add(subscriber);

            RefreshSubscribers();
        }

        // スクリプト内でサブスクライバを除外
        public void RemoveSubscriber(string name) {
            if (!_subscribersDict.ContainsKey(name)) {
                Debug.LogError($"Unknown Name : ${name}");

                return;
            }

            var target = _subscribers.Find(subscriber => subscriber.Name == name);

            _subscribers.Remove(target);

            RefreshSubscribers();
        }

        public void RefreshSubscribers() {
            _subscribersDict.Clear();

            // 振り分けできるように、List で登録したサブスクライバを Dictionary に置き換え
            _subscribersDict = _subscribers.ToDictionary(subscriber => subscriber.Name, subscriber => subscriber);
        }

        // Start is called before the first frame update
        void Start() {}

        // Update is called once per frame
        void Update()
        {
            if (!_setupCompleted) {
                // サブスクライバーが未登録の時はここで登録
                if (_subscribers.Count == 0) {
                    _subscribers = FindObjectsOfType<Subscriber>().ToList();

                    var foundNames = string.Join(",", _subscribers.ConvertAll(_subscriber => _subscriber.Name).ToArray());
                    Debug.Log($"Found Subscribers: {foundNames}");
                }

                // すべてのサブスクライバーの Name プロパティに値が設定されタラ準備完了
                var isSetAllSubscriberName = _subscribers.All(subscriber => !subscriber.Name.IsEmpty());

                if (!isSetAllSubscriberName) {
                    Debug.Log("cannot got all subscriber name");

                    return;
                }

                var names = string.Join(",", _subscribers.ConvertAll(_subscriber => _subscriber.Name).ToArray());
                Debug.Log($"Got All Name of Subscribers: {names}");

                RefreshSubscribers();

                _setupCompleted = true;
                StandBy = true;
            }

            // 受け入れ準備ができていないときは何もしない
            if (!StandBy) {
                return;
            }

            // メッセージがキューになければ何もしない
            if (_messageQueue.Count == 0) {
                return;
            }

            StandBy = false;

            var currentMessage = _messageQueue.Dequeue();

            if (!_subscribersDict.ContainsKey(currentMessage.Type)) {
                Debug.LogError($"Unknown Type : ${currentMessage.Type}");

                return;
            }

            // メッセージの形式に相応しいサブスクライバにメッセージを渡す
            var targetSubscriber = _subscribersDict[currentMessage.Type];

            // サブスクライバへサブスクライブすることでコンポーネントに処理を指示する
            targetSubscriber.Subscribe(currentMessage);

            StandBy = true;
        }
    }
}
