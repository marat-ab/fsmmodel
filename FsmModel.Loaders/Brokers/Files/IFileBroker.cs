namespace FsmModel.Loaders.Brokers.Files
{
    public interface IFileBroker<T>
    {
        T? Load(string fileName);
    }
}
