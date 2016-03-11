using System.Collections.Generic;

namespace PokerServer.Engine
{
    public interface IDeck<T> where T : ICard
    {
        IList<T> Cards { get; set; } 
        int Count { get; }
        void Remove(T card);
        void Shuffle(INumberGenerator numberGenerator);
    }
}