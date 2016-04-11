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
            Cards.Shuffle(numberGenerator);
        }

        public override string ToString()
        {
            return string.Join(",", Cards);
        }
    }
}