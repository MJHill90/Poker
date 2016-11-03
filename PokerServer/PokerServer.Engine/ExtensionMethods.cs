using System.Collections.Generic;

namespace PokerServer.Engine
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Fisher-Yates Shuffle Algorithm
        /// </summary>
        public static void Shuffle<T>(this IList<T> cards, INumberGenerator numberGenerator)
        {
            int length = cards.Count;
            for (int i = 0; i < length; i++)
            {
                int r = i + (int)(numberGenerator.GenerateRandomDouble(0, 1) * (length - i));
                T card = cards[r-1];
                cards[r-1] = cards[i];
                cards[i] = card;
            }
        } 
    }
}