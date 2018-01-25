﻿using System;
using EventEngine.Interfaces;

namespace EventEngine.UnitTests
{
    public class TestStateObject : IView
    {
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}