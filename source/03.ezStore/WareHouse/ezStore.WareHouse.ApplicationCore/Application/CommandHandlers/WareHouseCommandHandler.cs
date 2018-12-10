﻿using ezStore.WareHouse.ApplicationCore.Application.Commands;
using ezStore.WareHouse.ApplicationCore.WareHouseAggregate;
using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using Microservice.DataAccess.Core.Interfaces;
using System.Threading.Tasks;

namespace ezStore.WareHouse.ApplicationCore.Application.CommandHandlers
{
    public class WareHouseCommandHandler : ICommandHandler<CreateWareHouseCommand>,
        ICommandHandler<UpdateWareHouseCommand>,
        ICommandHandler<DeleteWareHouseCommand>
    {
        private readonly IDomainService domainService;
        private readonly IDataAccessWriteService writeService;

        public WareHouseCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            this.domainService = domainService;
            this.writeService = writeService;
        }

        public Task ExecuteAsync(CreateWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(writeService);
            wareHouseDomain.CreateWareHouse(command.Name);

            domainService.ApplyChanges(wareHouseDomain);
            domainService.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(writeService);
            wareHouseDomain.UpdateWareHouse(command.Id, command.Name);

            domainService.ApplyChanges(wareHouseDomain);
            domainService.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(writeService);
            wareHouseDomain.DeleteWareHouse(command.Id);

            domainService.ApplyChanges(wareHouseDomain);
            domainService.SaveChanges();
            return Task.CompletedTask;
        }
    }
}