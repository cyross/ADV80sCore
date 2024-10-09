namespace Assets.ADV80s2.Scripts.ADV80s2.Interfaces {
    public interface IADV80s2Component: IStatusManagement
    {
        public void DoMessage(Object.MessageObject message);
        public new Enumerators.State State { get; set; }
        public new bool IsStandBy();
    }
}
