﻿using System;
using CliConsole.Interfaces;
using CliConsole.Interfaces.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CliConsole.UnitTests
{
    [TestClass]
    public class ConsoleDispatcherUnitTests
    {
        private ICommandInstanceFactory _instanceFactory;
        private IConsoleParser _parser;
        private IConsoleProxy _consoleProxy;
        private IConsoleDispatcher _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _parser = Substitute.For<IConsoleParser>();
            _consoleProxy = Substitute.For<IConsoleProxy>();
            _instanceFactory = Substitute.For<ICommandInstanceFactory>();
            _target = new ConsoleDispatcher(_instanceFactory, _parser, _consoleProxy);
        }

        [TestMethod]
        public void WhenIExecuteTheDispatcherWithOneMatchingCommandItIsRun()
        {
            var expectedCommandName = Guid.NewGuid().ToString();
            var args = new[] { expectedCommandName };
            var commands = new[] {
                CreateCliCommand(expectedCommandName),
                CreateCliCommand(Guid.NewGuid().ToString())
            };
            var expectedInstanceCommand = CreateCliCommand(expectedCommandName);

            _instanceFactory.Create(commands[0].GetType()).Returns(expectedInstanceCommand);
            _parser.Parse(expectedInstanceCommand, args).Returns(true);
            _target.DispatchCommand(commands, args);

            expectedInstanceCommand.Received(1).Run();
            _consoleProxy.Received(2).WriteLine(Arg.Is<string>(c => IsValidDebug(c, $"Executed {expectedCommandName}")));
        }

        [TestMethod]
        public void WhenIExecuteTheDispatcherWithMultipleMatchingCommandsTheyAreRun()
        {
            var expectedCommandName = Guid.NewGuid().ToString();
            var args = new[] { expectedCommandName };
            var commands = new[] {
                CreateCliCommand(expectedCommandName),
                CreateCliCommand(expectedCommandName)
            };
            var expectedInstanceCommand = CreateCliCommand(expectedCommandName);

            _instanceFactory.Create(commands[0].GetType()).Returns(expectedInstanceCommand);
            _parser.Parse(expectedInstanceCommand, args).Returns(true);
            _target.DispatchCommand(commands, args);

            expectedInstanceCommand.Received(2).Run();
            _consoleProxy.Received(4).WriteLine(Arg.Is<string>(c => IsValidDebug(c, $"Executed {expectedCommandName}")));
        }

        [TestMethod]
        public void WhenIExecuteTheDispatcherWithNoArgumentsNothingIsExecuted()
        {
            var commandName = Guid.NewGuid().ToString();
            var args = new string[] { };
            var commands = new[] {
                CreateCliCommand(commandName),
                CreateCliCommand(Guid.NewGuid().ToString())
            };
            var expectedInstanceCommand = CreateCliCommand(commandName);

            _parser.Parse(expectedInstanceCommand, args).Returns(true);
            _target.DispatchCommand(commands, args);

            _parser.DidNotReceive().Parse(Arg.Any<ICommand>(), Arg.Any<string[]>());
            _consoleProxy.DidNotReceive().WriteLine(Arg.Any<string>());
        }

        private static ICommand CreateCliCommand(string commandName)
        {
            var command = Substitute.For<ICommand>();
            command.CommandName.Returns(commandName);
            return command;
        }

        private static bool IsValidDebug(string consoleString, string expectedString)
        {
            return consoleString == string.Empty || consoleString.StartsWith(expectedString);
        }
    }
}
