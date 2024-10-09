using System;
using System.Collections.Generic;
using System.Linq;
using Assets.ADV80s2.Scripts.ADV80s2.Interfaces;
using UnityEngine;
using VFolders.Libs;

namespace Assets.ADV80s2.Scripts.ADV80s2.Core {
    public class Dispatcher : MonoBehaviour, IStatusManagement
    {
        [SerializeField]
        private List<Subscriber> _subscribers = new List<Subscriber>();

        [SerializeField]
        private StatePool.StatePool _state_pool;

        private Dictionary<string, Subscriber> _subscribersDict = new Dictionary<string, Subscriber>();

        private Queue<Object.MessageObject> _messageQueue = new Queue<Object.MessageObject>();

        public Enumerators.State State { get; set; } = Enumerators.State.INITIALIZING;

        public bool IsStandBy ()
        {
            return State == Enumerators.State.STANDBY;
        }

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
            if (State == Enumerators.State.INITIALIZING) {
                // サブスクライバーが未登録の時はここで登録
                if (_subscribers.Count == 0) {
                    _subscribers = FindObjectsOfType<Subscriber>().ToList();

                    var foundNames = string.Join(",", _subscribers.ConvertAll(_subscriber => _subscriber.Name).ToArray());
                    Debug.Log($"Found Subscribers: {foundNames}");
                }

                // すべてのサブスクライバーの Name プロパティに値が設定されたら準備完了
                var isSetAllSubscriberName = _subscribers.All(subscriber => !subscriber.Name.IsEmpty());

                if (!isSetAllSubscriberName) {
                    Debug.Log("cannot got all subscriber name");

                    return;
                }

                var names = string.Join(",", _subscribers.ConvertAll(_subscriber => _subscriber.Name).ToArray());
                Debug.Log($"Got All Name of Subscribers: {names}");

                RefreshSubscribers();

                State = Enumerators.State.STANDBY;
            }

            // 受け入れ準備ができていないときは何もしない
            if (!IsStandBy()) {
                return;
            }

            // メッセージがキューになければ何もしない
            if (_messageQueue.Count == 0) {
                return;
            }

            State = Enumerators.State.PROCESSING;

            var currentMessage = _messageQueue.Dequeue();

            // 全部の Subscriber へ送信
            if (currentMessage.IsBroadcast) {
                _subscribers.ForEach(subscriber => subscriber.Subscribe(currentMessage));
            }
            // 適切な Subscriber が見つかった
            else if (_subscribersDict.ContainsKey(currentMessage.Type)) {
                // メッセージの形式に相応しいサブスクライバにメッセージを渡す
                var targetSubscriber = _subscribersDict[currentMessage.Type];

                // サブスクライバへサブスクライブすることでコンポーネントに処理を指示する
                targetSubscriber.Subscribe(currentMessage);
            }
            // 適切な Subscriber が見つからなかった
            else {
                Debug.LogError($"Unknown Type : ${currentMessage.Type}");
            }

            State = Enumerators.State.STANDBY;
        }
    }
}
