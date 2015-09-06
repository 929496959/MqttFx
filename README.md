# nMqtt
dotnet mqtt client

# Examples
```c#
using System;
using System.Text;
using nMqtt.Messages;


namespace nMqtt.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MqttClient("server", "clientId");
            var state = client.Connect("username");
            if (state == ConnectionState.Connected)
            {
                client.MessageReceived += OnMessageReceived;
                client.Subscribe("a/b", Qos.AtLeastOnce);
            }
            Console.ReadKey();
        }

        static void OnMessageReceived(string topic, byte[] data)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("topic:{0}", topic);
            Console.WriteLine("data:{0}", Encoding.UTF8.GetString(data));
        }
    }
}
