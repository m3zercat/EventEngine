﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CodeConcepts.CliConsole.Interfaces;
using CodeConcepts.CliConsole.Interfaces.Factories;

namespace CodeConcepts.CliConsole
{
    public class ConsoleDispatcher : IConsoleDispatcher
    {
        private readonly ICommandInstanceFactory _instanceFactory;
        private readonly IConsoleParser _parser;
        private readonly IConsoleProxy _console;

        public ConsoleDispatcher(ICommandInstanceFactory instanceFactory, IConsoleParser parser, IConsoleProxy console)
        {
            _instanceFactory = instanceFactory;
            _parser = parser;
            _console = console;
        }

        public void DispatchCommand(IEnumerable<ICliCommand> commands, string[] args)
        {
            if (args == null || args.Length == 0)
                return;

            var matchingCommands = commands.Where(t => string.Equals(t.CommandName, args[0], StringComparison.InvariantCultureIgnoreCase));
            foreach (var command in matchingCommands)
            {
                ParseCommandAndExecute(args, _console, command);
            }
        }

        private void ParseCommandAndExecute(string[] args, IConsoleProxy console, ICliCommand cliCommand)
        {
            var instance = _instanceFactory.Create(cliCommand.GetType());
            
            if (!_parser.Parse(instance, args))
                return;

            WriteExecutionInformationToConsole(console, cliCommand, instance);
        }

        private static void WriteExecutionInformationToConsole(IConsoleProxy console, ICliCommand cliCommand, ICliCommand instance)
        {
            var timer = new Stopwatch();
            timer.Start();
            instance.Run();
            timer.Stop();
            console.WriteLine($"Executed {cliCommand.CommandName} in {timer.Elapsed.TotalSeconds:0.000000} seconds");
            console.WriteLine(string.Empty);
        }
    }
}