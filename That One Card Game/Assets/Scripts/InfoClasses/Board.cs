﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.InfoClasses
{
    public class Board
    {
        public List<Card> Cards { get; protected set; }
        public event Action<Card> OnMinionAdded;

        public int CardCount
        {
            get
            {
                return Cards.Count;
            }
        }

        public Board()
        {
            Cards = new List<Card>();
        }

        public void PlayCard(Card c)
        {
            if (c.OnCardPlayed != null)
                c.OnCardPlayed(c);
            if (c.CardData.CardType == CardType.Minion)
            {
                Cards.Add(c);
                if (OnMinionAdded != null)
                    OnMinionAdded(c);
            }
            else if (c.CardData.CardType == CardType.Spell)
            {
                // FIXME: What should we do here? Should this even be in this class?

            }
        }

        // FIXME: We should have a centralized Random Manager (maybe so that people could share seeds?)
        public Card GetRandomCardOnBoard(Random r)
        {
            return Cards[r.Next(Cards.Count)];
        }
    }

}