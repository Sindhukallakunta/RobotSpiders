using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Application
{
    /// <summary>
    /// Executes a sequence of instructions. Normalises input and delegates behaviour creation.
    /// </summary>
    public sealed class CommandProcessor
    {
        private readonly CommandFactory _factory;

        public CommandProcessor(CommandFactory factory)
        {
            _factory = factory;
        }

        public void Execute(string instructions)
        {
            foreach (var c in instructions.ToUpperInvariant())
                _factory.Create(c).Execute();
        }
    }
}
