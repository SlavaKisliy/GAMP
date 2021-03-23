using GoogleMeasurementProtocol;
using GoogleMeasurementProtocol.Parameters.ECommerce;
using GoogleMeasurementProtocol.Parameters.User;
using System;
using System.Threading.Tasks;

namespace GAMP
{
    public class GAMPSender
    {
        private const string TrackingId = "UA-192871103-1";

        public async Task SendTransactionId()
        {
            var transId = await TransactionHelper.GetLastTransactionHashAsync();

            var factory = new GoogleAnalyticsRequestFactory(TrackingId);

            var request = factory.CreateRequest(HitTypes.Transaction);

            request.Parameters.Add(new TransactionId(transId));

            var clientId = new ClientId(Guid.NewGuid());

            await request.PostAsync(clientId);
        }
    }
}
