using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace G24W12WPFCardDealer;

class CardViewModel : INotifyPropertyChanged
{
    private CardModel cardModel;

    private ObservableCollection<string> _cardResources;

    public ObservableCollection<string> CardResources
    {
        get { return _cardResources; }
    }

    public CardViewModel(CardModel cardModel)
    {
        this.cardModel= cardModel;
        _cardResources = new ObservableCollection<string>();

        GetResourcesName(cardModel.Cards);
    }

    private void GetResourcesName(List<Card> cards)
    {
        _cardResources.Clear();

        foreach (Card card in cards)
        {
            _cardResources.Add(GetCardImageName(card));
        }
        OnPropertyChagned(nameof(CardResources));
    }

    private string GetCardImageName(Card card)
    {
        string[] suits = ["spades", "diamonds", "hearts", "clubs",];
        string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king",];

        if (card.Suit < 0 || card.Value < 0)
            return "Images/black_joker.png";

        string suit = suits[card.Suit];
        string value = values[card.Value];

        return (value == "jack" || value == "queen" || value == "king")
            ? $"Images/{value}_of_{suit}2.png"
            : $"Images/{value}_of_{suit}.png";
    }

    public void DealCards()
    {
        var newCards = cardModel.DealCards();

        GetResourcesName(newCards);

    }

    public event PropertyChangedEventHandler? PropertyChanged;
    // "CardResource"가 argument로 전달됨.

    protected void OnPropertyChagned([CallerMemberName] string propName = "")
    {
        PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propName));
    }
}
