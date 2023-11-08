﻿using ECommerceApplication.Application.Persistence;
using ECommerceApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(ECommergeApplicationContext context) : base(context)
        {
        }
    }
}
