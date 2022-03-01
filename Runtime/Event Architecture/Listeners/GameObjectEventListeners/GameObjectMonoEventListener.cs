using UnityEngine;

namespace HyperGnosys.Core
{
    public class GameObjectMonoEventListener : AEventListenerComponent<GameObject>
    {
        public override void OnEventRaised(GameObject item)
        {
            base.OnEventRaised(item);    
            HGDebug.Log("GameObject Event Listener in " + transform.name + " transmitting " + item.name, EventListener.Debugging);    
        }
    }
}