using System;
using System.Collections.Generic;
using System.Text;
using DependencyResolver;
using Ninject;
using Ninject.Modules;
using PokerServer.Engine;

namespace PokerServer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();

            var modules = new List<INinjectModule>
            {
                new EngineModule(),
            };
            kernel.Load(modules);

            System.Console.OutputEncoding = Encoding.UTF8;
            ConsoleKeyInfo cki;
            do
            {
                System.Console.WriteLine("Press [C] to generate a card.");
                System.Console.WriteLine("Press [D] to generate a randomized deck.");
                System.Console.WriteLine("Press [ESC] to exit");
                cki = System.Console.ReadKey(true);

                var cardService = kernel.Get<ICardService>();
                var deckService = kernel.Get<IDeckService>();

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
