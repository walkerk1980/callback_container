#!/bin/bash
    domainjoin-cli join example.com $1 $2
    cd /opt/pbis/bin/
    ./config UserDomainPrefix example.com
    ./config AssumeDefaultDomain true
    ./config LoginShellTemplate /bin/bash
    ./config HomeDirTemplate %H/%U
    ./config HomeDirUmask 077
    ./config RequireMembershipOf 'example.com\PenLabSharedServers'
    