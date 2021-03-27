using GoogleMeasurementProtocol;
using GoogleMeasurementProtocol.Parameters.CustomDimensions;
using GoogleMeasurementProtocol.Parameters.EventTracking;
using GoogleMeasurementProtocol.Parameters.User;
using System;
using System.Threading.Tasks;

namespace GAMP
{
    public class GAMPSender
    {
        private const string TrackingId = "UA-192871103-1";

        public async Task Send()
        {
            var unconfirmedCount = await TransactionHelper.GetUnconfirmedTransCountAsync();

            var factory = new GoogleAnalyticsRequestFactory(TrackingId);

            var request = factory.CreateRequest(HitTypes.Event);

            request.Parameters.Add(new EventCategory("Transaction"));
            request.Parameters.Add(new EventAction("TransactionRefresh"));
            request.Parameters.Add(new CustomMetric(unconfirmedCount, 3));

            var clientId = new ClientId(Guid.NewGuid());

            await request.GetAsync(clientId);
        }
    }
}
