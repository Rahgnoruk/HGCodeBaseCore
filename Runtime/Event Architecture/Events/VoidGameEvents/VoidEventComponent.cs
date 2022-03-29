namespace HyperGnosys.Core
{
    public class VoidEventComponent : AEventComponent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}