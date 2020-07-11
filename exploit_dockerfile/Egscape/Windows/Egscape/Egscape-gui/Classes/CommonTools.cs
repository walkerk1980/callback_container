using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Egscape_gui
{
    public class CommonTools
    {
        public bool InputIsNotNullOrVoid(string protocol, string host, string ports, string portType)
        {
            if (String.Equals(protocol,"Protocol") || String.IsNullOrEmpty(host) || String.IsNullOrEmpty(ports) || String.Equals(portType,"Port Input Type"))
            {
                System.Windows.Forms.MessageBox.Show("Input is not fully configured!" + Environment.NewLine + "You must supply a Protocol, Hostname or IP, Port List or Range, Port Input Type.");
                return false;
            }
            else
                return true;
        }

        public bool IsPortStringValid(string portString, string portType)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(portString, "[0-9,-]"))
            {
                if(!portString.Contains(",") && !portString.Contains("-"))
                {
                    int portnum = 0;
                    if (Int32.TryParse(portString, out portnum))
                    {
                        if (portnum > 0 && portnum < 65536)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Port is out of Range!");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot parse port!");
                        return false;
                    }
                }
                else if(portString.Contains(",") && portString.Contains("-"))
                {
                    MessageBox.Show("Port List cannot contain both a list and a range!");
                    return false;
                }
                else if(portString.Contains("-") && String.Equals(portType, "Dash Seperated Range") && !(System.Text.RegularExpressions.Regex.IsMatch(portString, "^-") || System.Text.RegularExpressions.Regex.IsMatch(portString, "-$")))
                {
                    int portnum1, portnum2;
                    if(Int32.TryParse(portString.Substring(0,portString.IndexOf("-")),out portnum1) && Int32.TryParse(portString.Substring(portString.IndexOf("-")+1), out portnum2))
                    {
                        if (portnum1 < portnum2)
                        {
                            if (portnum1 > 0 && portnum2 < 65536) { return true; }
                            else { MessageBox.Show("Port input is out of range!"); return false; }
                        }
                        else { MessageBox.Show("Port range is backwards!"); return false; }
                    }
                    else { MessageBox.Show("Something is wrong with port input!"); return false; }
                }
                else if(portString.Contains(",") && String.Equals(portType, "Comma Seperated Ports") && !(System.Text.RegularExpressions.Regex.IsMatch(portString, "^,") || System.Text.RegularExpressions.Regex.IsMatch(portString, ",$")))
                {
                    return true;
                }
                else { MessageBox.Show("Something wrong with port input or type!"); return false; }
            }
            else
            {
                MessageBox.Show("Port list contains invalid Characters");
                return false;
            }
        }

        protected List<int> ParsePortString(String portString, string portType)
        {
            var ports = new List<int>();
            //single port
            if (!portString.Contains(",") && !portString.Contains("-"))
            {
                ports.Add(Int32.Parse(portString));
                return ports;
            }
            if (String.Equals(portType, "Comma Seperated Ports"))
            {
                string[] splitPorts = portString.Split(',');
                foreach (string port in splitPorts)
                {
                    ports.Add(Convert.ToInt32(port));
                }
                return ports;
            }
            else if (String.Equals(portType, "Dash Seperated Range"))
            {
                int portnum1, portnum2;
                portnum1 = Int32.Parse(portString.Substring(0, portString.IndexOf("-")));
                portnum2 = Int32.Parse(portString.Substring(portString.IndexOf("-") + 1));
                ports.AddRange(Enumerable.Range(portnum1, portnum2 - portnum1 +1));
                return ports;
            }
            else
            {
                MessageBox.Show("Something went wrong!");
                return ports;
            }
        }
    }
}
