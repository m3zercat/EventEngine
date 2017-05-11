﻿using System.Linq;
using CodeConcepts.EventEngine.Application.Interfaces;
using CodeConcepts.EventEngine.IsaPolicy.Events.Events;

namespace CodeConcepts.EventEngine.IsaPolicy.Views.Views.PolicyView.EventEvaluators
{
    public class PremiumReceivedEventEvaluator : IEventEvaluator<PremiumReceivedEvent, Domain.PolicyView>
    {
        public void Evaluate(Domain.PolicyView view, PremiumReceivedEvent @event)
        {
            view.Premiums.Single(p => p.PremiumId == @event.PremiumId).IsReceived = true;
        }
    }
}