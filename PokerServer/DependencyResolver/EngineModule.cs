using Ninject.Modules;
using PokerServer.Engine;

namespace DependencyResolver
{
    public class EngineModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICardService>().To<CardService>();
            Bind<IDeckService>().To<DeckService>();
            Bind<ICard>().To<Card>();
            Bind<IDeck<ICard>>().To<Deck>();
            Bind<INumberGenerator>().To<NumberGenerator>();
        }
    }
}
