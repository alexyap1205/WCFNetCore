using System;
using System.ServiceModel;
using WCFService;

namespace WCFClientCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculatorDuplexCallback callback = new CallbackHandler();
            InstanceContext context = new InstanceContext(callback);

            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            EndpointAddress endpoint = new EndpointAddress("net.tcp://localhost/ServiceModelSamples/Service.svc");
            DuplexChannelFactory<ICalculator> chanFac =
                new DuplexChannelFactory<ICalculator>(context, binding, endpoint);
            ICalculator clientProxy = chanFac.CreateChannel();


            // Create a client with given client endpoint configuration
            // Call the AddT0 service operation.
            double value1 = 100.00D;

            clientProxy.AddTo(value1);
            Console.WriteLine("AddTo({0}) called", value1);

            // Call the SubtractFrom service operation.
            var value2 = 76.54D;
            clientProxy.SubtractFrom(value2);
            Console.WriteLine("SubtractFrom({0}) called", value2);

            // Call the MultiplyBy service operation.
            value1 = 10.00D;
            clientProxy.MultiplyBy(value1);
            Console.WriteLine("MultiplyBy({0}) called", value1);

            // Call the DivideBy service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            clientProxy.DivideBy(value2);
            Console.WriteLine("DivideBy({0}) called", value2);

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
            //Closing the client gracefully closes the connection and cleans up resources
            chanFac.Close();

        }
    }
}
