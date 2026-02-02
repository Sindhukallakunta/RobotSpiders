using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Domain
{
    /// <summary>Immutable grid coordinate.</summary>
    public sealed record Position(int X, int Y);
}
