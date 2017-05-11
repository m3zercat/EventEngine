﻿using System.Collections.Generic;
using CodeConcepts.EventEngine.Application.Interfaces;

namespace CodeConcepts.EventEngine.IsaPolicy.Views.Views.PolicyView.Domain
{
    public class PolicyView : IView
    {
        public string PolicyNumber { get; set; }

        public int CustomerId { get; set; }

        public IList<Premium> Premiums { get; set; } = new List<Premium>();

        public IList<Fund> Funds { get; set; } = new List<Fund>();
    }
}