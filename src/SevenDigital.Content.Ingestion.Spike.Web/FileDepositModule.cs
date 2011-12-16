using Nancy;
using SevenDigital.Content.Ingestion.Spike.Domain.Commands;
using SevenDigital.Content.Ingestion.Spike.Domain.Queuing;

namespace SevenDigital.Content.Ingestion.Spike.Web
{
    public class FileDepositModule : NancyModule
    {
        public FileDepositModule(ICommandSender sender)
        {
            Get["/deposit"] = _ =>
                           {
                               sender.Send(new FileDeposit());
                               return "File Deposit Made";
                           };
        }
    }
}