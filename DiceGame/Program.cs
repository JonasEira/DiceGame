using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name to start playing: ");
            string name = Console.ReadLine();
            CharacterClass gameChar = new CharacterClass(name);
            GameManager gm = new GameManager(gameChar);
            Thread t = new Thread(new ThreadStart(gm.engine));
            t.Start();
        }
    }
}
