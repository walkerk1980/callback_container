using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Egscape_gui
{
    public class Scan : CommonTools
    {
        int timeout = 50;
        public void TcpScan(List<int> ports, String host, string logPath)
        {
            foreach (int port in ports)
            {
                File.AppendAllText(logPath, Environment.NewLine + "sending port " + port);
                TcpClient connection = new TcpClientWithTimeout(host, port, timeout).Connect();
            }
        }


        public void UdpScan(List<int> ports, String host, string logPath)
        {
            foreach (int port in ports)
            {
                File.AppendAllText(logPath, Environment.NewLine + "sending port " + port);
                UdpClient udpClient = new UdpClient();
                udpClient.Connect(host, port);
                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes("ping");
                udpClient.Send(sendBytes, sendBytes.Length);
                udpClient.Close();
                Thread.Sleep(10);
            }
        }


        public void ProxyScan(List<int> ports, String host, string logPath)
        {
            // sends connections on specified ports through proxy
            // via webrequest.
            CancellationTokenSource cancellationSource = new CancellationTokenSource();
            ParallelOptions options = new ParallelOptions();
            options.CancellationToken = cancellationSource.Token;
            // max amount of requests, this will be an option in the gui
            options.MaxDegreeOfParallelism = 50;

            try
            {
                // MICROSOFT HAS THOUGHT OF EVERYTHING!
                ParallelLoopResult loopResult = Parallel.For(0, ports.Count, options, i =>
                {
                    File.AppendAllText(logPath, Environment.NewLine + "sending port " + ports[i]);
                    String url = "http://" + host + ":" + Convert.ToString(ports[i]);
                    try
                    {
                        WebRequest request = WebRequest.Create(url);
                        // this seems to be a good timeout
                        request.Timeout = 1000;
                        WebResponse response = request.GetResponse();
                        new StreamReader(response.GetResponseStream()).ReadToEnd();
                    }
                    catch (Exception)
                    {
                    }
                });

                if (loopResult.IsCompleted)
                {
                    Console.WriteLine("\rProxy Scan Complete!");
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
