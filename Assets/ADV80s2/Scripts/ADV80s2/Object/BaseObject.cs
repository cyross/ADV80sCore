namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
  public class BaseObject<T>: Interfaces.IObject<T>
  {
    public string Type { set; get; } = "";
    public bool IsBroadcast { set; get; } = false;
    public string Name { set; get; } = "";

    public T Body { set; get;} = default;
  }
}
