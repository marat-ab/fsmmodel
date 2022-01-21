using FsmModel.Loaders.Brokers.Files;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables
{
    public partial class TransitionTableLoader
    {
        private readonly IFileBroker fileBroker;

        public TransitionTableLoader(IFileBroker fileBroker) =>
            this.fileBroker = fileBroker;

        public TransitionTable? Load(string fileName) =>
            TryCatch(() =>
            {
                var model = fileBroker.Load<TransitionTable>(fileName);

                ValidateTableModel(model);

                return model;
            });
    }
}
