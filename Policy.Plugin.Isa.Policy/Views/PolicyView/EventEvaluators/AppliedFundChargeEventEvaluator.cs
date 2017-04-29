﻿using Policy.Application.Interfaces;
using Policy.Plugin.Isa.Policy.Events;
using Policy.Plugin.Isa.Policy.Interfaces.Domain;

namespace Policy.Plugin.Isa.Policy.Views.PolicyView.EventEvaluators
{
    public class AppliedFundChargeEventEvaluator : IEventEvaluator<AppliedFundChargeEvent, IPolicyContext, PolicyView>
    {
        public void Evaluate(PolicyView view, AppliedFundChargeEvent @event)
        {
            
        }
    }
}