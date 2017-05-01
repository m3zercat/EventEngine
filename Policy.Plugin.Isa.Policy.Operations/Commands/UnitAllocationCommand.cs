﻿using System;
using Policy.Plugin.Isa.Policy.Operations.BaseTypes;

namespace Policy.Plugin.Isa.Policy.Operations.Commands
{
    public class UnitAllocationCommand : IsaPolicyCommand
    {
        public UnitAllocationCommand(string policyNumber, DateTime dateOfAllocation)
        {
            PolicyNumber = policyNumber;
            DateOfAllocation = dateOfAllocation;
        }

        public string PolicyNumber { get; }

        public DateTime DateOfAllocation { get; }
    }
}
