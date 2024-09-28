namespace Assets.ADV80s2.Scripts.ADV80s2.Interfaces {
    public interface IADV80s2Component
    {
        public void DoMessage(Object.MessageObject message);
        public bool StandBy { get; set; }
    }
}
