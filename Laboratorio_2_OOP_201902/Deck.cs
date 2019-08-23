using Laboratorio_2_OOP_201902;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Deck : Card
    {


        private List<Card> cardsOfPlayers;

        public Deck()
        {
            this.cardsOfPlayers = new List<Card>();
        }

        public List<Card> CardsOfPlayers { get => cardsOfPlayers; set => cardsOfPlayers = value; }

        public void AddCard(Card card)
        {
            cardsOfPlayers.Add(card);
        }
    
        public void DestroyCard()
        {
            cardsOfPlayers.Clear();
        }

        public void Shuffle() { 
            throw new NotImplementedException();
        }
    }
}
