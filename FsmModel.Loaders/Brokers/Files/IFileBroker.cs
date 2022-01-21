namespace FsmModel.Loaders.Brokers.Files
{
    public interface IFileBroker
    {
        T? Load<T>(string fileName);
    }
}
