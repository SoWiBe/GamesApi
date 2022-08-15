using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesApi.Domain.Base
{
    public interface IDbContext<out T> : IEnumerable<T>
    {
    }
}
