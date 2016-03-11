using System;

namespace PokerServer.Engine
{
    public class DeckService : IDeckService
    {
        private readonly ICardService _cardService;
        private readonly INumberGenerator _numberGenerator;

        public DeckService(ICardService cardService, INumberGenerator numberGenerator)
        {
            _cardService = cardService;
            _numberGenerator = numberGenerator;
        }

        public IDeck<ICard> CreateDeck(bool shuffle)
        {
            var deck = new Deck();
            foreach (SuitEnum suit in Enum.GetValues(typeof(SuitEnum)))
            {
                foreach (RankEnum rank in Enum.GetValues(typeof(RankEnum)))
                {
                    deck.Cards.Add(_cardService.GenerateCard(rank, suit));
                }
            }

            if(shuffle)
                deck.Shuffle(_numberGenerator);

            return deck;
        }
    }
}