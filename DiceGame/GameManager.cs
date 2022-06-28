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
        private List<int> winResults;
        private List<int> lossResults;
        private List<int> tieResults;
        private GameMode mode;
        private Menu menu;

        public enum Menu
        {
            One,
            Two,
            Three
        };

        private enum GameMode
        {
            MainMenu,
            Running
        };

        private enum ChangeState
        {
            Add, Remove
        };

        public GameManager(CharacterClass gameChar)
        {
            this.gameChar = gameChar;
            this.menu = Menu.One;
            this.enemyList = new List<CharacterClass>();
            this.winResults = new List<int>();
            this.lossResults = new List<int>();
            this.tieResults = new List<int>();
            this.running = true;
            this.mode = GameMode.MainMenu;
            this.currentEnemy = 0;
            this.enemyList.Add(new CharacterClass(1 + " "));
            this.winResults.Add(0);
            this.lossResults.Add(0);
            this.tieResults.Add(0);

        }

        internal void engine()
        {
            while (running)
            {
                inpKey = Console.ReadKey();
                Console.Clear();
                switch (mode) {
                    case GameMode.MainMenu:
                        menuOption();
                        break;
                    case GameMode.Running:
                        this.printGameState();
                        break;
                }
                Thread.Sleep(50);
            }
            
        }

        private void printGameState()
        {
            switch (inpKey.Key)
            {
                case ConsoleKey.Spacebar:
                    this.rollTheDice();
                    this.resultAction();
                    Console.WriteLine("Press M for menu");
                    Console.WriteLine("Player:" + gameChar.CharacterName
                        + " Health: " + gameChar.health);
                    gameChar.draw(Dice.DrawState.Under);
                    Console.Write("Current opponent -----");
                    enemyList[currentEnemy].draw(Dice.DrawState.After);
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        Console.WriteLine("Opponent: " + enemyList[i].CharacterName);
                        enemyList[i].draw(Dice.DrawState.Under);
                        Console.WriteLine("Wins: "+ winResults[i] 
                            + " Losses: " + lossResults[i] 
                            + " Ties: " + tieResults[i]
                            + " Health: " + enemyList[i].health);  
                    }   
                    break;
                case ConsoleKey.A:
                    Console.WriteLine("Adding next opponent");
                    changeOpponent(ChangeState.Add);
                    break;
                case ConsoleKey.R:
                    Console.WriteLine("Removing last opponent");
                    changeOpponent(ChangeState.Remove);
                    break;
                case ConsoleKey.M:
                    Console.WriteLine("Opening menu");
                    mode = GameMode.MainMenu;
                    break;
                default:
                    break;
            }
        }

        private void changeOpponent(ChangeState state)
        {
            switch (state)
            {
                case ChangeState.Add:
                    this.enemyList.Add(new CharacterClass(enemyList.Count + 1 + ""));
                    this.winResults.Add(0); 
                    this.lossResults.Add(0); 
                    this.tieResults.Add(0);
                    break;
                case ChangeState.Remove:
                    this.enemyList.RemoveAt(enemyList.Count - 1);
                    this.winResults.RemoveAt(winResults.Count - 1);
                    this.lossResults.RemoveAt(lossResults.Count - 1);
                    this.tieResults.RemoveAt(tieResults.Count - 1);
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
                if (enemyList[i].getLastRoll() <= gameChar.getLastRoll())
                {
                    enemyList[i].changeHealth(enemyList[i].health - 1);
                } else
                {
                    gameChar.changeHealth(gameChar.health - 1);
                }
            }

        }

        internal void resultAction()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (gameChar.getLastRoll() > enemyList[i].getLastRoll())
                {
                    winResults[i] += 1;
                }
                if (gameChar.getLastRoll() < enemyList[i].getLastRoll())
                {
                    lossResults[i] += 1;
                }
                if (gameChar.getLastRoll() == enemyList[i].getLastRoll())
                {
                    tieResults[i] += 1;
                }
            }
        }

        internal void menuOption()
        {

            switch (inpKey.Key)
            {
                case ConsoleKey.D1:
                    mode = GameMode.Running;
                    break;
                case ConsoleKey.D2:
                    menu = Menu.Two;
                    break;
                case ConsoleKey.D3:
                    menu = Menu.Three;
                    break;
                case ConsoleKey.D4:
                    running = false;
                    break;
                default:
                    menu = Menu.One;
                    break;
            }

            switch (menu)
            {
                case Menu.One:
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("1. Start Game");
                    Console.WriteLine("2. Change name");
                    Console.WriteLine("3. Set Opponents names");
                    Console.WriteLine("4. Quit game");
                    break;
                case Menu.Two:
                    Console.Write("Enter name:");
                    string name = Console.ReadLine();
                    this.gameChar.CharacterName = name;
                    break;
                case Menu.Three:
                    Console.WriteLine("Number of enemies: " + enemyList.Count);
                    Console.Write("Change enemy number: ");
                    try
                    {
                        int number = Int32.Parse(Console.ReadLine()) - 1;
                        Console.Write("\nName: ");
                        string enemyName = Console.ReadLine();
                        enemyList[number].CharacterName = enemyName;
                    } catch (Exception e)
                    {
                        Console.WriteLine("Sorry, wrong input. " + e.Message);
                    }
                    break;
                
            }
        }
    }
}