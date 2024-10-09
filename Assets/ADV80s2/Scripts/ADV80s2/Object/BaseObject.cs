namespace Assets.ADV80s2.Scripts.ADV80s2.Object {
  public class BaseObject<T>: Interfaces.IObject<T>
  {
    public string Type { set; get; } = "";
    public string Name { set; get; } = "";

    public T Body { set; get;} = default;
  }
}
