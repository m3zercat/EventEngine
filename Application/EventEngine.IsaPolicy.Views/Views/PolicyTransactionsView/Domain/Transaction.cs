﻿using System;

namespace CodeConcepts.EventEngine.IsaPolicy.Views.Views.PolicyTransactionsView.Domain
{
    public class Transaction
    {
        public string Type { get; set; }

        public decimal Value { get; set; }

        public DateTime TransactionDateTime { get; set; }
    }
}