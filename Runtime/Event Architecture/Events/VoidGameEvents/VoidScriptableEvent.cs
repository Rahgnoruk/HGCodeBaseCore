using UnityEngine;

namespace HyperGnosys.Core
{
    [CreateAssetMenu(fileName = "New Scriptable Void Event", menuName = "HyperGnosys/Events/Scriptable Void Event")]
    public class VoidScriptableEvent : AScriptableEvent<Void>
    {
        /// <summary>
        /// Declara un Raise unico del Void Game Event que 
        /// llama el metodo base de Raise con un nuevo Void
        /// </summary>
        public void Raise() => Raise(new Void());
    }
}