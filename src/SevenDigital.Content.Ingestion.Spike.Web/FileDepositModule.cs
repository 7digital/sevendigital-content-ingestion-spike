using Nancy;
using SevenDigital.Content.Ingestion.Spike.Domain.Commands;
using SevenDigital.Content.Ingestion.Spike.Domain.Handlers;
using SevenDigital.Content.Ingestion.Spike.Domain.Queuing;

namespace SevenDigital.Content.Ingestion.Spike.Web
{
    public class FileDepositModule : NancyModule
    {
        public FileDepositModule(ICommandSender sender): base("deposit")
        {
            Get["/"] = _ =>
                           {
                               sender.Send(new FileDeposit());
                               return "File Deposit Made";
                           };
        }
    }

    public class FakeBusBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            var bus = new FakeBus();
            var depositDetector = new DepositDetector();
            bus.RegisterHandler<FileDeposit>(depositDetector.Handle);
            container.Register<ICommandSender, FakeBus>(bus).AsSingleton();
            base.ConfigureApplicationContainer(container);
        }
    }
}