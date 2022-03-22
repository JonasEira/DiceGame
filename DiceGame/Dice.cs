using System;

namespace DiceGame
{
    internal class Dice
    {
        private int value;
        private int size;
        private static Random random;

        public Dice()
        {
            random = new Random();
        }

        public Dice(int size)
        {
            value = 1;
            this.size = size;
            random = new Random();
        }

        public void roll()
        {
            this.value = random.Next(6) + 1;
        }
        internal void draw()
        {
            switch (this.value) { 
                case 1:
                    Console.WriteLine("╔═════════╗");
                    Console.WriteLine("║         ║");
                    Console.WriteLine("║    o    ║");
                    Console.WriteLine("║         ║");
                    Console.WriteLine("╚═════════╝");
                    break;
                case 2:
                    Console.WriteLine("╔═════════╗");
                    Console.WriteLine("║ o       ║");
                    Console.WriteLine("║         ║");
                    Console.WriteLine("║       o ║");
                    Console.WriteLine("╚═════════╝");
                    break;
                case 3:
                    Console.WriteLine("╔═════════╗");
                    Console.WriteLine("║ o       ║");
                    Console.WriteLine("║    o    ║");
                    Console.WriteLine("║       o ║");
                    Console.WriteLine("╚═════════╝");
                    break;
                case 4:
                    Console.WriteLine("╔═════════╗");
                    Console.WriteLine("║ o     o ║");
                    Console.WriteLine("║         ║");
                    Console.WriteLine("║ o     o ║");
                    Console.WriteLine("╚═════════╝");
                    break;
                case 5:
                    Console.WriteLine("╔═════════╗");
                    Console.WriteLine("║ o     o ║");
                    Console.WriteLine("║    o    ║");
                    Console.WriteLine("║ o     o ║");
                    Console.WriteLine("╚═════════╝");
                    break;
                case 6:
                    Console.WriteLine("╔═════════╗");
                    Console.WriteLine("║ o     o ║");
                    Console.WriteLine("║ o     o ║");
                    Console.WriteLine("║ o     o ║");
                    Console.WriteLine("╚═════════╝");
                    break;
                default:
                    break;
            }
        }
    }
}