﻿namespace EventEngine.Interfaces.Commands
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}