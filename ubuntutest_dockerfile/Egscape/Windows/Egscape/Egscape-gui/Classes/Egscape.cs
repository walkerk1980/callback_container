using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Egscape_gui
{
    class Egscape : CommonTools
    {
        public string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Egscape", "Egscape.log");

        public void RunScan(string protocol, string host, string ports, string portType)
        {
            Scan sc = new Scan();
            if (sc.IsPortStringValid(ports, portType))
            {
                MessageBox.Show("Hit OK to scan..." + Environment.NewLine + Environment.NewLine + "Protocol: " + protocol + Environment.NewLine + "Host: " + host + Environment.NewLine + "Ports: " + ports + Environment.NewLine + Environment.NewLine + "Logging output to \"Documents\\Egscape\"");
                switch (protocol)
                {
                    case "TCP":
                        sc.TcpScan(ParsePortString(ports, portType), host, logPath);
                        break;
                    case "UDP":
                        sc.UdpScan(ParsePortString(ports, portType), host, logPath);
                        break;
                    case "Proxy":
                        sc.ProxyScan(ParsePortString(ports, portType), host, logPath);
                        break;
                    default:
                        break;
                }
            }


        }

    }
}
