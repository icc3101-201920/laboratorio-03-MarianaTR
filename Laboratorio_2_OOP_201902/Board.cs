using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Board : Card
    {
        //Constantes
        private const int DEFAULT_NUMBER_OF_PLAYERS = 2;

        //Atributos

        private Dictionary<string, List<Card>>[] playerCards;
        private List<SpecialCard> weatherCards;

        //Propiedades
        
       
        public List<SpecialCard> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }

        public Dictionary<string, List<Card>>[] PlayerCards
        {
            get
            {
                return this.playerCards;
            }
            set
            {
                playerCards = value;
            }
        }


        //Constructor
        public Board()
        {
            
            this.weatherCards = new List<SpecialCard>();
            this.playerCards = new Dictionary<string, List<Card>>[
            DEFAULT_NUMBER_OF_PLAYERS];
            this.playerCards[0] = new Dictionary<string, List<Card>>();
            this.playerCards[1] = new Dictionary<string, List<Card>>();
        }



        //Metodos

        //Nuevo
        public void AddCard(Card card, int playerId = -1, string buffType
        = null)        {
            if (card.GetType().Name == nameof(CombatCard))            {
                if (playerId == 0 || playerId == 1)
                {
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        playerCards[playerId][card.Type].Add(card);
                    }                    else
                    {
                        playerCards[playerId].Add(card.Type, new List<Card>() { card });
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }
            }
            else
            {
                if (playerId == 0 || playerId == 1)
                {
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        if (card.Type == "weather")
                        {
                            weatherCards.Add((SpecialCard) card);
                            
                        }
                        else
                        {
                            throw new IndexOutOfRangeException("The player have a Card");
                        }
                    }
                    else
                    {
                        if (card.Type == "capitan")
                        {
                            playerCards[playerId].Add(card.Type, new List<Card>() { card });
                        }
                        else if (card.Type == "buffer")
                        {
                            if (playerCards[playerId].ContainsKey(card.Type + buffType))
                            {
                                throw new IndexOutOfRangeException("The player have a capitan Card");
                                
                            }
                            else
                            {
                                playerCards[playerId].Add(card.Type + buffType, new List<Card>() { card });
                            }
                        }
                    }
                }
            }
        }

        
        public void DestroyCards()
        {
            List<Card>[] captainCards = new List<Card>[DEFAULT_NUMBER_OF_PLAYERS]
            {
                new List <Card >(playerCards[0]["captain"]),new List <Card >(playerCards[1]["captain"])
            };
            weatherCards.Clear();
            this.playerCards = new Dictionary<string, List<Card>>[DEFAULT_NUMBER_OF_PLAYERS];
            this.playerCards[0] = new Dictionary<string, List<Card>>();
            this.playerCards[1] = new Dictionary<string, List<Card>>();
            for (int i=0; i<captainCards.Length;)
            {
                playerCards[i].Add("captain", captainCards[0]);
            }


        }
        public int[] GetMeleeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas melee y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i=0; i < 2; i++)
            {
                foreach (CombatCard meleeCard in meleeCards[i])
                {
                    totalAttack[i] += meleeCard.AttackPoints;
                }
            }
            return totalAttack;
            
        }
        public int[] GetRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas range y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                foreach (CombatCard rangeCard in rangeCards[i])
                {
                    totalAttack[i] += rangeCard.AttackPoints;
                }
            }
            return totalAttack;
        }
        public int[] GetLongRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas longRange y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                foreach (CombatCard longRangeCard in longRangeCards[i])
                {
                    totalAttack[i] += longRangeCard.AttackPoints;
                }
            }
            return totalAttack;
        }
    }
}
