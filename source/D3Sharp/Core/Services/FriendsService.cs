﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D3Sharp.Net;
using D3Sharp.Net.Packets;

namespace D3Sharp.Core.Services
{
    [Service(serviceID: 0x6, serverHash: 0xA3DDB1BD, clientHash: 0x6F259A13)]
    public class FriendsService : Service
    {
        [ServiceMethod(0x1)]
        public void SubscribeToFriends(IClient client, Packet packetIn)
        {

        }
    }
}
