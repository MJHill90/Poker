using System;

namespace PokerServer.Engine
{
    public class Card : ICard
    {
        public RankEnum Rank { get; private set; }

        public byte RankValue
        {
            get
            {
                return GetRankValue();
            }
        }

        public SuitEnum Suit { get; private set; }

        public Card(RankEnum rank, SuitEnum suit)
        {
            Rank = rank;
            Suit = suit;
        }

        private byte GetRankValue()
        {
            return (byte) Rank;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", Rank, Enum.GetName(typeof(SuitEnum), Suit));
        }

        public override bool Equals(object obj)
        {
            var card = obj as ICard;
            if (card == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Suit == card.Suit) && (Rank == card.Rank);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Rank * 397) ^ (int)Suit;
            }
        }
    }
}
