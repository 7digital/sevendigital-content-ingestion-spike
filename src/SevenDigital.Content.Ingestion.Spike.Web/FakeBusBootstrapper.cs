using Nancy;
using SevenDigital.Content.Ingestion.Spike.Data;
using SevenDigital.Content.Ingestion.Spike.Domain.Boilerplate;
using SevenDigital.Content.Ingestion.Spike.Domain.Commands;
using SevenDigital.Content.Ingestion.Spike.Domain.EventStore;
using SevenDigital.Content.Ingestion.Spike.Domain.Events;
using SevenDigital.Content.Ingestion.Spike.Domain.Handlers;
using SevenDigital.Content.Ingestion.Spike.Domain.Models;
using SevenDigital.Content.Ingestion.Spike.Domain.Queuing;

namespace SevenDigital.Content.Ingestion.Spike.Web
{
    public class FakeBusBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            container.Register<IPersistentStore, PersistentStore>().AsSingleton();

            var bus = StickABusInIt(container.Resolve<IPersistentStore>());
            
            container.Register<ICommandSender, FakeBus>(bus);
            container.Register<IEventPublisher, FakeBus>(bus);
        }

        private static FakeBus StickABusInIt(IPersistentStore store)
        {
            var bus = new FakeBus();
            var depositDetector = new DepositDetector(new Repository<LabelDepositJob>(new EventStore(bus)));
            bus.RegisterHandler<FileDeposit>(depositDetector.Handle);

            var depositHandler = new DepositHandler(store);
            bus.RegisterHandler<DepositDetected>(depositHandler.Handle);

            return bus;
        }
    }
}