﻿using System;
using System.Linq;
using D3Sharp.Net;
using D3Sharp.Net.Packets;
using bnet.protocol;

namespace D3Sharp.Core.Services
{
    [Service(serviceID: 0x1, serviceName: "bnet.protocol.authentication.AuthenticationServer", clientHash: 0x71240E35)]
    public class AuthenticationService:Service
    {
        [ServiceMethod(0x1)]
        public void Logon(IClient client, Packet packetIn)
        {
            var request = bnet.protocol.authentication.LogonRequest.ParseFrom(packetIn.Payload.ToArray());
            if(request.HasEmail) client.Email = request.Email.ToLower();

            Logger.Trace("RPC:Authentication:Logon()");
            var response = bnet.protocol.authentication.LogonResponse.CreateBuilder()
                .SetAccount(EntityId.CreateBuilder().SetHigh(0x100000000000000).SetLow(0))
                .SetGameAccount(EntityId.CreateBuilder().SetHigh(0x200006200004433).SetLow(0))
                .Build();

            var packet = new Packet(
                new Header(0xfe, 0x0, packetIn.Header.RequestID, (uint)response.SerializedSize),
                response.ToByteArray());

            client.Send(packet);
        }       
    }
}