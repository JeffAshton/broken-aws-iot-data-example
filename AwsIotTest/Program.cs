using System;
using Amazon.IotData;
using Amazon.IotData.Model;

namespace AwsIotTest {

	public static class Program {

		public static void Main( string[] args ) {

			IAmazonIotData client = new AmazonIotDataClient(
				serviceUrl: "https://data.iot.us-east-1.amazonaws.com/"
			);

			Publish( client, topic: "test/123" );
			Publish( client, topic: "test,123" );
		}

		private static void Publish(
				IAmazonIotData client,
				string topic
			) {

			try {
				Console.Out.Write( "Publishing to '{0}': ", topic );

				PublishRequest request = new PublishRequest {
					Topic = topic,
					Qos = 1
				};

				PublishResponse response = client.Publish( request );
				Console.Out.WriteLine( response.HttpStatusCode );

			} catch( Exception err ) {
				Console.Error.WriteLine( err.Message );
			}
		}
	}
}
