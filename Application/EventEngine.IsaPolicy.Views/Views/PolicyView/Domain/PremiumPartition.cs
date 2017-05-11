﻿using System;

namespace CodeConcepts.EventEngine.IsaPolicy.Views.Views.PolicyView.Domain
{
    public class PremiumPartition
    {
        public string FundId { get; set; }

        public decimal Amount { get; set; }

        public Guid PortionId { get; set; }
    }
}