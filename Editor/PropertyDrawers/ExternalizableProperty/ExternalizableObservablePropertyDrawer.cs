using UnityEditor;
namespace HyperGnosys.Core
{
    [CustomPropertyDrawer(typeof(ExternalizableObservableProperty<>))]
    public class ExternalizableObservablePropertyDrawer : ExternalizablePropertyDrawer
    {
    }
}