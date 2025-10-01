namespace Core
{
    public interface IActionFactory
    {
        T Resolve<T>() where T : class;
    }
}