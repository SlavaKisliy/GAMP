namespace GAMP
{
    class Program
    {
        static void Main(string[] args)
        {
            GAMPSender sender = new GAMPSender();

            sender.SendTransactionId().GetAwaiter().GetResult();
        }
    }
}
