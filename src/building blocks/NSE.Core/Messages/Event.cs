﻿using MediatR;
using System;

namespace NSE.Core.Messages
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        public Event()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
