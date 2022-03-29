using UnityEngine;

namespace HyperGnosys.Core
{
    public class GameObjectEventComponent : AEventComponent<GameObject>
    {
        public override void Raise(GameObject gameObject)
        {
            base.Raise(gameObject);
            HGDebug.Log("GameObject Game Event in " + transform.name + " raising " + gameObject?.name, GameEvent.Debugging);
        }
    }
}