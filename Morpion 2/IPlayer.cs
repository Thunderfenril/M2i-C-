using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion_2
{
    internal interface IPlayer
    {
            public Result<PlayerMoves> GetNextMove();
            public char icon { get; }
    }
}
