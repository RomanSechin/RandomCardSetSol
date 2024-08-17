using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsClassLibrary
{
    public enum Suit { 
        Diamonds,
        Clubs,
        Hearts,
        Spades
    }
    public enum Value { 
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
        Jocker
    }
    public class Card : IComparable<Card>
    {
        public Suit Suit {  get; set; }
        public Value Value { get; set; }
        public int CompareTo(Card other)
        {
            if (this.Value > other.Value)
                return 1;
            else if (this.Value < other.Value)
                return -1;
            else
                if (this.Suit > other.Suit)
                return 1;
                else if (this.Suit < other.Suit)
                    return -1;
            return 0;
        }
        public string Name {
            get { return $"{Value} of {Suit}"; }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
