﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficCourts.Messaging.MessageContracts
{
    public interface DisputeRejected: IMessage
    {
        string Reason { get; set; }
    }
}