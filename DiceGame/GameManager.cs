using System;
using System.Collections.Generic;
using System.Threading;

namespace DiceGame
{
    internal class GameManager
    {
        private CharacterClass gameChar;
        private List<CharacterClass> enemyList;
        private bool running;
        private int currentEnemy;
        private ConsoleKeyInfo inpKey;
        private int nOfTargets;

        public GameManager(CharacterClass gameChar)
        {
            this.gameChar = gameChar;
            this.enemyList = new List<CharacterClass>();
            this.running = true;
            this.currentEnemy = 0;
            this.nOfTargets = 1;
            this.enemyList.Add(new CharacterClass("One"));
            this.enemyList.Add(new CharacterClass("Two"));
            this.enemyList.Add(new CharacterClass("Three"));
            this.enemyList.Add(new CharacterClass("Four"));
            this.enemyList.Add(new CharacterClass("Five"));

        }

        internal void engine()
        {
            while (running)
            {
                inpKey = Console.ReadKey();
                Console.Clear();
                this.printGameState();
                Thread.Sleep(50);
            }
            
        }

        private void printGameState()
        {
            switch (inpKey.Key)
            {
                case ConsoleKey.Spacebar:
                    this.rollTheDice();
                    Console.WriteLine("Player:" + gameChar.CharacterName);
                    gameChar.draw();
                    for(int i = 0; i < nOfTargets; i++)
                    {
                        Console.WriteLine("Opponent: " + enemyList[i].CharacterName);
                        enemyList[i].draw();
                    }   
                    break;
                case ConsoleKey.A:
                    Console.WriteLine("Adding next opponent");
                    nOfTargets += 1;
                    break;
                default:
                    break;
            }
        }

        internal void rollTheDice()
        {
            gameChar.rollTheDice();
            for(int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].rollTheDice();
            }
        }

        internal void changeOpponent()
        {
            
        }

        internal void resultAction()
        {
 
        }

        internal void menuOption()
        {
            
        }
    }
}