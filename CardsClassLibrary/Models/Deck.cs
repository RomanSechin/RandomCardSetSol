using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CardsClassLibrary
{
    class Deck
    {
        List<Card> cards;
        public Deck() { cards = new List<Card>(); }
        public Deck Shuffle()
        {
            Random random = new Random();
            Card tempCard;
            int tempIndex;
            for (int i = 0; i < cards.Count; i++)
            {
                tempCard = cards[i];
                tempIndex = random.Next(i);
                cards[i] = tempCard;
                cards[tempIndex] = cards[i];
            }
            return this;
        }
        public Deck(string filename)
        {
            string tempString = "";

            using (StreamReader reader = new StreamReader(filename))
            {
                while (reader.EndOfStream == false)
                {
                    var nextCard = reader.ReadLine();
                    var cardParts = nextCard.Split(' ');
                    var value = cardParts[0] switch
                    {
                        "Ace" => Value.Ace,
                        "King" => Value.King,
                        "Queen" => Value.Queen,
                        "Jack" => Value.Jack,
                        "Ten" => Value.Ten,
                        "Nine" => Value.Nine,
                        "Eight" => Value.Eight,
                        "Seven" => Value.Seven,
                        "Six" => Value.Six,
                        "Five" => Value.Five,
                        "Four" => Value.Four,
                        "Three" => Value.Three,
                        "Two" => Value.Two,
                        _ => throw new InvalidDataException($"{nextCard}")
                    };
                    var suit = cardParts[2] switch
                    {
                        "Spades" => Suit.Spades,
                        "Clubs" => Suit.Clubs,
                        "Hearts" => Suit.Hearts,
                        "Diamonds" => Suit.Diamonds,
                        _ => throw new InvalidDataException($"Unrecognized card suit: {cardParts[2]}"),
                    };
                    cards.Add(new Card { Value = value, Suit = suit });
                }

            }

        }
        public void WriteCards(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    writer.WriteLine(this.cards[i].Name);
                }
            }
        }
    }
}
