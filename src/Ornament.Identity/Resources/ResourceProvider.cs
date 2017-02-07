using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Ornament.Identity.Resources
{
    public interface IPermissionResourceProvider
    {
        string Name { get; }

        Enum Operators { get; }
    }

    public class PermissionResourceProvider<T, TOperator> : IPermissionResourceProvider
        where T : class

    {
        public string Name { get; }

        public Enum Operators { get; }
    }
}
