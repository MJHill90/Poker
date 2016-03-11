using System;
using System.Collections.Generic;

namespace PokerServer.Engine
{
    public class Deck : IDeck<ICard>
    {
        public IList<ICard> Cards { get; set; }

        public int Count
        {
            get { return Cards.Count; }
        }

        public Deck()
        {
            Cards = new List<ICard>();
        }

        public void Remove(ICard card)
        {
            throw new NotImplementedException();
        }

        public void Shuffle(INumberGenerator numberGenerator)
        {
            int length = Cards.Count;
            for (int i = 0; i < length; i++)
            {
                int r = i + (int)(numberGenerator.GenerateRandomDouble(0,1) * (length - i)) - 1;
                ICard card = Cards[r];
                Cards[r] = Cards[i];
                Cards[i] = card;
            }
        }

        public override string ToString()
        {
            return string.Join(",", Cards);
        }
    }
}