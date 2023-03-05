using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Common
{
    public interface IAdapter<T1, T2>
    {
        T2 AdaptTo(T1 source);
        T1 AdaptFrom(T2 source);
    }
}
