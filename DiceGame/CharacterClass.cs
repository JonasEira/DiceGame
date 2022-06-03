using System;

namespace DiceGame
{
    internal class CharacterClass
    {
        public string characterName;
        public int health;
        public Dice dice;

        public CharacterClass(string name)
        {
            this.CharacterName = name;
            this.health = 100;
            this.dice = new Dice();
        }

        public string CharacterName { get => characterName; set => characterName = value; }

        internal void changeHealth(int health)
        {
            this.health = health;
        }

        internal void draw(Dice.DrawState after)
        {
            this.dice.draw(after);
        }

        internal void rollTheDice()
        {
            if (dice.Value > 0)
            {
                this.dice.roll();

            } else
            {
                this.dice.Dead = true;
            }
        }

        internal int getLastRoll()
        { 
            return this.dice.Value;
        }
    }
}