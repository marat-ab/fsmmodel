using FsmModel.Loaders.Brokers.Files;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables
{
    public partial class TransitionTableLoader
    {
        private readonly IFileBroker<TransitionTable> fileBroker;

        public TransitionTableLoader(IFileBroker<TransitionTable> fileBroker) =>
            this.fileBroker = fileBroker;

        public TransitionTable? Load(string fileName) =>
            TryCatch(() =>
            {
                var model = fileBroker.Load(fileName);

                ValidateTableModel(model);

                return model;
            });
    }
}
