﻿using CodeConcepts.EventEngine.Application.Interfaces;
using CodeConcepts.EventEngine.Contracts.Interfaces;

namespace CodeConcepts.EventEngine.Application.PropertyBags
{
    public class Snapshot<TView> : ISnapshot<TView>
        where TView : class, IView
    {
        public Snapshot(IEvent @event, TView view)
        {
            Event = @event;
            View = view;
        }

        public IEvent Event { get; set; }

        public TView View { get; set; }
    }
}