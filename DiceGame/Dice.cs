using System;

namespace DiceGame
{
    internal class Dice
    {
        private int value = 1;
        private int size;
        private static Random random;
        public  bool dead = false;

        public enum DrawState
        {
            After,
            Under
        };

        public int Value { get => value; set => this.value = value; }
        internal bool Dead { get => dead; set => dead = value; }

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

        internal void draw(DrawState state)
        {
            switch (state)
            {
                case DrawState.After:
                    break;
                case DrawState.Under:
                    this.drawUnder();
                    break;
                default:
                    break;
            }
        }
        internal void drawUnder()
        {
            switch (this.value) {
                case 0:
                    Console.WriteLine("╔═-------═╗");
                    Console.WriteLine("|         |");
                    Console.WriteLine("| D E A D |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("╚═-------═╝");
                    break;

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
        internal void drawAfter()
        {
            switch (this.value)

            {
                case 0:
                    Console.WriteLine("╔═-------═╗");
                    Console.WriteLine("|         |");
                    Console.WriteLine("| D E A D |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("╚═-------═╝");
                    break;

                case 1:
                    string[] one = new string[5];
                    one[0] = "╔═════════╗";
                    one[1] = "║         ║";
                    one[2] = "║    o    ║";
                    one[3] = "║         ║";
                    one[4] = "╚═════════╝";
                    for(int n = 0; n < 5; n++)
                    {
                        Console.MoveBufferArea(0,
                                                Console.WindowHeight,
                                                Console.WindowWidth - one[n].Length, 
                                                Console.WindowHeight - n, 
                                                Console.WindowWidth - one[n].Length, 
                                                Console.WindowHeight - n);
                    }
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