namespace HyperGnosys.Core
{
    /// <summary>
    /// Interface que esperan los eventos para suscribir un Listener
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}