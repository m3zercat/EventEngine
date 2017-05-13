﻿using System.Linq;
using CodeConcepts.EventEngine.Contracts.Interfaces;
using CodeConcepts.EventEngine.IsaPolicy.Contracts.Events;

namespace CodeConcepts.EventEngine.IsaPolicy.Views.Views.PolicyView.EventEvaluators
{
    public class AppliedFundChargeEventEvaluator : IEventEvaluator<AppliedFundChargeEvent, Contracts.Views.PolicyView.Domain.PolicyView>
    {
        public void Evaluate(Contracts.Views.PolicyView.Domain.PolicyView view, AppliedFundChargeEvent @event)
        {
            var fund = view.Funds.Single(f => f.FundId == @event.FundId);
            //var allocation = fund.Allocations.Single(a => a.PortionId == @event.PortionId);
            //allocation.Units += @event.Units;
            //allocation.Charges.Add(new Charge{Units =@event.Units, Date = @event.ChargeDate});
            fund.TotalUnits += @event.Units;
        }
    }
}