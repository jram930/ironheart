using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoreGenerator
{
    public interface IWorldEvent
    {
        #region Operations

        void ActOnWorld(World world);

        #endregion
    }
}
