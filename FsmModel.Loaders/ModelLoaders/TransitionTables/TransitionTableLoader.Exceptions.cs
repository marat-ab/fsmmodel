using FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions;
using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables
{
    public partial class TransitionTableLoader
    {
        private delegate TransitionTable? LoadTableModelFunction();

        private TransitionTable? TryCatch(LoadTableModelFunction loadTableModelFunction)
        {
            try
            {
                return loadTableModelFunction();
            }
            catch (TransitionTableModelIsNullException e)
            {
                throw CreateTableModelValidationException(e);
            }
            catch (StateMapException e)
            {
                throw CreateTableModelValidationException(e);
            }
            catch (InitialStateException e)
            {
                throw CreateTableModelValidationException(e);
            }
            catch (FinishStatesException e)
            {
                throw CreateTableModelValidationException(e);
            }
            catch (OutMapException e)
            {
                throw CreateTableModelValidationException(e);
            }
            catch (Exception e)
            {
                throw CreateTableModelException(e);
            }
        }

        private TransitionTableValidationException CreateTableModelValidationException(Exception exception)
        {
            var tableModelValidationException = new TransitionTableValidationException(exception);
            return tableModelValidationException;
        }

        private TransitionTableException CreateTableModelException(Exception exception)
        {
            var tableModelException = new TransitionTableException(exception);
            return tableModelException;
        }
    }
}
