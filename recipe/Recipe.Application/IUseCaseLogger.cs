using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application
{
    public interface IUseCaseLogger
    {
        void Log(UseCaseLog log);
    }
}
