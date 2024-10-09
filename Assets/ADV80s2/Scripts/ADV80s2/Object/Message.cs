namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
    public class MessageObject: BaseObject<object>
    {
        public BaseObject<object> Object { get; set; }
        public new string Type { get; set; } = "message";

        public MessageObject(string targetType, BaseObject<object> targetObject) {
            Type = targetType;
            Object = targetObject;
        }
    }
}
