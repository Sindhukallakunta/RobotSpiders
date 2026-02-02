using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Application.Commands
{
    /// <summary>Executable instruction</summary>
    public interface ICommand
    {
        void Execute();
    }
}
