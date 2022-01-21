using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.Brokers.Files
{
    public interface IFileBroker
    {
        T? Load<T>(string fileName);
    }
}
