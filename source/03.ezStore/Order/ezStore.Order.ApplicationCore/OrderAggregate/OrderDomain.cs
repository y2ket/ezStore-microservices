﻿using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.Order.ApplicationCore.ProductAggregate
{
    public class OrderDomain : AggregateRoot
    {
        public OrderDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }
    }
}