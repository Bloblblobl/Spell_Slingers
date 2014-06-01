using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using GameCore;

namespace GameMain
{
    class CardDatabase
    {
        private Dictionary<Card, Texture2D> _cardsDB = new Dictionary<Card,Texture2D>();
        Random _rand = new Random();

        public Texture2D LookupTexture(Card card)
        {
            return _cardsDB[card];
        }

        public Card SelectRandomCard()
        {
            var index =_rand.Next(_cardsDB.Count);
            return _cardsDB.Keys.ElementAt(index);
        }

        public void Add(Card card, Texture2D texture)
        {
            _cardsDB.Add(card, texture);
        }
    }
}
