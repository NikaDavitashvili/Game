using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Warrior_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var warrior_game = new GameController();
            warrior_game.ShowGame();
        }
    }
}
