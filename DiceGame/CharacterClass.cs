using System;

namespace DiceGame
{
    internal class CharacterClass
    {
        private string characterName;
        private int health;
        private Dice dice;

        public CharacterClass(string name)
        {
            CharacterName = name;
            health = 100;
            dice = new Dice();
        }

        public string CharacterName { get => characterName; set => characterName = value; }

        internal void changeHealth(int health)
        {
            this.health = health;
        }

        internal void draw()
        {
            this.dice.draw();
        }

        internal void rollTheDice()
        {
            this.dice.roll();
        }
    }
}