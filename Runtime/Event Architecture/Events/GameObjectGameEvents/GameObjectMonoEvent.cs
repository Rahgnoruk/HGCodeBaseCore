using HyperGnosys.Core;
using UnityEngine;
public class GameObjectMonoEvent : AEventComponent<GameObject>
{
    public override void Raise(GameObject gameObject)
    {
        base.Raise(gameObject);
        HGDebug.Log("GameObject Game Event in " + transform.name + " raising " + gameObject?.name, this.GameEvent.Debugging);
    }
}