namespace HyperGnosys.Core
{
    public class VoidMonoEvent : AEventComponent<Void>
    {
        /// <summary>
        /// Declara un Raise unico del Void Game Event que 
        /// llama el metodo base de Raise con un nuevo Void
        /// </summary>
        public void Raise() => Raise(new Void());
    }
}