namespace ProductCatalog.ClientConsole
{
    public interface IFactory<T>
    {
        T Create();
    }
}
