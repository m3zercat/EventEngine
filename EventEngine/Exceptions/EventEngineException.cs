﻿using System;

namespace EventEngine.Exceptions
{
    public class EventEngineException : Exception
    {
        public EventEngineException(string message)
            : base(message)
        {
        }
    }
}