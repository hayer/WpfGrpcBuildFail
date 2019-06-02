using Greet;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace DemoWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestService();
        }

        private async Task TestService()
        {

            // The port number(50051) must match the port of the gRPC server.
            var channel = new Channel("localhost:5000",
                                       ChannelCredentials.Insecure);
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
