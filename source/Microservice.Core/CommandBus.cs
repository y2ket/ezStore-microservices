﻿using System;
using System.Threading.Tasks;
using Microservice.Core.Interfaces;
using Microservice.Core.Service;

namespace Microservice.Core
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _provider;

        public CommandBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            var handler = _provider.GetService(typeof(ICommandHandler<TCommand>));

            if (handler == null)
                throw new CommandHandlerNotFoundException();

            return (handler as ICommandHandler<TCommand>).ExecuteAsync(command);
        }
    }
}