using VContainer;

namespace Core
{
    public class ActionFactory : IActionFactory
    {
        private readonly IObjectResolver _resolver;

        public ActionFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public T Resolve<T>() where T : class
        {
            return _resolver.Resolve<T>();
        }
    }
}