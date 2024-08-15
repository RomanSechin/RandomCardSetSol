//Создать перечисление Suits, Values, класс Card
//В Program добавить два стат. метода: RandomCard -> случайная карта, PrintCards -> List<Card>
//Создать класс CardComparerByValue, реализующий IComparer<Card>. отсортиовать список карт сначала
//1 - по value, 2 - по value и suit
//Вывести список до и после сортировки, разделив выводы строкой "... sorting the cards ..."

using System.ComponentModel.DataAnnotations;
using CardsClassLibrary;
using CardsClassLibrary.Models;

namespace СardRandomSetApp
{
    internal class Program
    {
        static Random random = new Random();
        static List<Card> cards = new List<Card>();
        static void Main(string[] args)
        {   
            int countOfCards = GetNumberOfCards();
            int typeOfSort = GetNumberOfSorting();            
            FillSetOfCards(countOfCards);            
            PrintCards();
            if (typeOfSort == 1)
            {
                cards.Sort();                
            }
            else if(typeOfSort == 2)
            {
                cards.Sort(new CardComparerByValue());
            }
            Console.WriteLine("\n... sorting the cards ...\n");
            PrintCards();
        }
        static int GetNumberOfSorting() {
            string result = "";
            while (result != "1" && result != "2")
            {
                Console.WriteLine("enter the NUMBER of sorting (1 - by value, 2 - by value and then by suit): ");
                result = Console.ReadLine();
            } 
            return int.Parse(result);
        }
        static void FillSetOfCards(int countOfCards)
        {
            for (int i = 0; i < countOfCards; i++)
            {
                cards.Add(RandomCard());
            }
        }
        static int GetNumberOfCards() {
            int result;
            do
            {
                Console.WriteLine("enter the NUMBER of cards: ");
            } while(int.TryParse(Console.ReadLine(), out result) == false);
            return result;
        }
        static Card RandomCard()
        {            
            Card card = new Card
            {
                Suit = (Suit)(random.Next(Enum.GetNames(typeof(Suit)).Length)),
                Value = (Value)(random.Next(Enum.GetNames(typeof(Value)).Length))
            };
            return card;
        }
        static void PrintCards() {
            foreach (Card card in cards) {
                Console.WriteLine(card.GetInfo());
            }
        }
    }
}

