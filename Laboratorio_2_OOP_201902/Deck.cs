using Laboratorio_2_OOP_201902.Card;
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

        public void AddCombatCard(CombatCard combatCard)
        {
            throw new NotImplementedException();
        }
        public void AddSpecialCard(SpecialCard specialCard)
        {
            throw new NotImplementedException();
        }
        public void DestroyCombatCard(int cardId)
        {
            throw new NotImplementedException();
        }
        public void DestroySpecialCard(int cardId)
        {
            throw new NotImplementedException();
        }
        public void Shuffle() { 
            throw new NotImplementedException();
        }
    }
}
