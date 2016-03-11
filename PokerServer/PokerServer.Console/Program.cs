using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerServer.Engine;

namespace PokerServer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = Encoding.UTF8;
            ConsoleKeyInfo cki;
            do
            {
                System.Console.WriteLine("Press [C] to generate a card.");
                System.Console.WriteLine("Press [D] to generate a randomized deck.");
                System.Console.WriteLine("Press [ESC] to exit");
                cki = System.Console.ReadKey(true);

                INumberGenerator numberGenerator = new NumberGenerator();
                ICardService cardService = new CardService(numberGenerator);
                IDeckService deckService = new DeckService(cardService, numberGenerator);

                if (cki.Key != ConsoleKey.Escape)
                {
                    if (cki.Key == ConsoleKey.C)
                    {
                        ICard card = cardService.GenerateCard();
                        System.Console.WriteLine(card.ToString());
                    }
                    if (cki.Key == ConsoleKey.D)
                    {
                        IDeck<ICard> deck = deckService.CreateDeck(true);
                        System.Console.WriteLine(deck.ToString());
                    }
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
