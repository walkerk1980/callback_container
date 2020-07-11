#!/usr/bin/env python
# Copyright (c) 2012 Tom Steele
# See the file license.txt for copying permission
# egscape-server
# uses scapy to capture, tcp[syn] and udp packets
# authors: Tom Steele (tom@huptwo34.com), Dan Kottmann

import sys
import logging
import collections
from optparse import OptionParser, OptionGroup
from scapy.all import *

logging.getLogger("scapy.runtime").setLevel(logging.ERROR)


def make_csv(open_ports, csv):
    """Write the output to a CSV file
    """

    with open(csv, "w") as outfile:
        # process tcp list
        if open_ports['tcp']:
            ports = list(open_ports['tcp'])
            ports.sort()
            for port in ports:
                outfile.write("tcp,{0}\n".format(port))

        # process tcp list
        if open_ports['udp']:
            ports = list(open_ports['udp'])
            ports.sort()
            for port in ports:
                outfile.write("udp,{0}\n".format(port))


def output_ports(open_ports):
    """Process open_ports dict and print to stdout
    """
    # process tcp list
    if open_ports['tcp']:
        # convert set to list and sort list
        ports = list(open_ports['tcp'])
        ports.sort()
        print "\033[1;32m[+] Received tcp attempts on the following port(s):"
        for port in ports:
            print port
        print "\033[1;m"
    else:
        print "[-] No tcp connection attempts received"

    # process udp list
    if open_ports['udp']:
        # convert set to list and sort list
        ports = list(open_ports['udp'])
        ports.sort()
        print "\033[1;32m[+] Received udp attempts on the following port(s):"
        for port in open_ports['udp']:
            print port
        print "\033[1;m"
    else:
        print "[-] No udp connection attempts received"


def handle_packet(pkt, verbose, open_ports, src):
    """Handle a received packet from the target source

    This is used as the callback function by the scapy sniff function. This
    function is called for each received packet and simply tracks the
    protocol and destination port of the received packet. As a source IP
    filter is applied, the destination port in the received packets indicate
    a port which bypasses any egress filtering.
    """
    # Process TCP and UDP packets only.
    if pkt.haslayer(TCP):
        dport = pkt.getlayer(TCP).dport
        prot = "tcp"
    elif pkt.haslayer(UDP):
        dport = pkt.getlayer(UDP).dport
        prot = "udp"
    else:
        return

    open_ports[prot].add(dport)
    #open_ports.add("{0}/{1}".format(dport, prot))
    if verbose:
        outstring = "[+] Received data destined for {0}/{1} from {2}"
        print outstring.format(dport, prot, src)
    return


def main():
    """Main Function

    Starts the sniffer and processes results.
    """
    usage = "usage: %prog [-v] [--csv=OUTFILE] <interface> <ipaddress>"
    description = """%prog provides the server-side handling of the egressive
egress filter toolset. Both the source IP and interface
command line switches are required."""

    parser = OptionParser(usage=usage, version="%prog 1.0",
                          description=description)
    parser.add_option("-v", "--verbose", default=False, action="store_true",
                      help="Verbose mode.")
    parser.add_option("--csv", default=False, metavar="FILE",
                      type=str, action="store")
    (options, args) = parser.parse_args()

    if len(args) != 2:
        print >> sys.stderr, parser.get_usage()
        sys.exit(1)

    interface = args[0]
    src = args[1]
    verbose = options.verbose
    csv = options.csv
    open_ports = collections.defaultdict(set)

    # Build the pcap filter:
    #    Only examine packets from the client source IP
    #    Process all UDP packets
    #    Process only TCP packets with SYN flag set
    pcap_filter = "src {0} and (udp or (tcp and (tcp[13] & 2!=0)))".format(src)

    print "[+] Starting listener. Press Ctrl-C to quit..."
    if verbose:
        print "[DEBUG] Filter: {0}".format(pcap_filter)
        print "[DEBUG] Interface: {0}".format(interface)

    try:
        sniff(filter=pcap_filter, iface=interface,
              prn=lambda x: handle_packet(x, verbose, open_ports, src))
    except Scapy_Exception as e:
        print >> sys.stderr, "[!] Scapy error:{0}".format(e)
    except socket.error as e:
        print >> sys.stderr, "[!] Socket error, check interface: {0}".format(e)
    except KeyboardInterrupt:
        pass
    print "[+] Interrupt detected. Processing results..."
    output_ports(open_ports)

    if csv:
        print "[+] Writing port(s) to {0}...".format(csv)
        make_csv(open_ports, csv)


if __name__ == '__main__':
    main()

