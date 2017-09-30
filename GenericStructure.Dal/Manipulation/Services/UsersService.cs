﻿using GenericStructure.Dal.Manipulation.Repositories;
using GenericStructure.Dal.Manipulation.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Manipulation.Services
{
    public class UsersService : BaseService
    {
        private CustomerRepository customerRepository;

        public UsersService() : base() { }

        public CustomerRepository CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                    this.customerRepository = new CustomerRepository(this.context);

                return this.customerRepository;
            }
        }
    }
}