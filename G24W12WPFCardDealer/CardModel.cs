using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace G24W12WPFCardDealer;
class Card
{
    public static readonly int NUMBER_OF_SUIT = 4;
    public static readonly int NUMBER_OF_VALUES = 13;

    public Card(int suit,int value)
    {
        Suit = suit;
        Value = value;
    }
    public Card(int number)
    {
        Suit = number / NUMBER_OF_VALUES;
        Value = number % NUMBER_OF_VALUES;
    }
    public int Suit { get; set; }
    public int Value { get; set; } 
}

class CardModel
{
    public static readonly int NUMBER_OF_CARDS = 5;

    private List<Card> _cards = new List<Card>();

    public List<Card> Cards { get { return _cards;} }
    public CardModel() 
    {
        for (int i = 0; i < NUMBER_OF_CARDS; i++)
        {
            _cards.Add(new Card(-1, -1));
        }    
    }

    public List<Card> DealCards()
    {
        HashSet<int> cardSet = new HashSet<int>();

        Random random = new Random();
        while (cardSet.Count < NUMBER_OF_CARDS )
        {
            cardSet.Add(random.Next(Card.NUMBER_OF_SUIT * Card.NUMBER_OF_VALUES));
        }
        List<int> cardList = cardSet.ToList();
        cardList.Sort();

        _cards.Clear();
        foreach (int card in cardList)
        {
            _cards.Add(new Card(card));
        }

        return _cards;
    }
}