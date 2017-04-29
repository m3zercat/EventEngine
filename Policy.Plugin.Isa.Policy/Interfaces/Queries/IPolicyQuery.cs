﻿using System.Collections.Generic;
using Policy.Plugin.Isa.Policy.Views.PolicyView;

namespace Policy.Plugin.Isa.Policy.Interfaces.Queries
{
    public interface IPolicyQuery
    {
        PolicyView Read(string policyNumber);

        IEnumerable<PolicyView> Read(int customerId);
    }
}