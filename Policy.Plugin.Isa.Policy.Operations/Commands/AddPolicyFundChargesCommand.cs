﻿using System;
using Policy.Plugin.Isa.Policy.Operations.BaseTypes;

namespace Policy.Plugin.Isa.Policy.Operations.Commands
{
    public class AddPolicyFundChargesCommand : IsaPolicyCommand
    {
        public AddPolicyFundChargesCommand(string policyNumber, DateTime chargeDate)
        {
            PolicyNumber = policyNumber;
            ChargeDate = chargeDate;
        }

        public string PolicyNumber { get; }

        public DateTime ChargeDate { get; }
    }
}
