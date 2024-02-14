using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using Test.Common.Interfaces;
using Test.Model;
using Test.Model.Entities;

namespace Test.Repository.Repositories
{
    public class CustomerRepo : BaseRepo<Customer>, IRetriveUC<Customer, long>, IPersistsUC<Customer, long>
    {
        public CustomerRepo(TestDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Customer> GetAll()
        {

            var customers = DbContext.Database.SqlQuery<Customer>("exec test.spGetCustomers").ToList();

            foreach (var customer in customers)
            {
                var sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customer.CustomerId)
                };

                customer.Address = DbContext.Database
                    .SqlQuery<Address>("exec test.spGetAddressByCustomerId @customerId", sqlParams)
                    .ToList();
            }

            // en lo personal prefiero utilizar linQ para hacer las consultas
            var customers2 = (from c in DbContext.Customers
                              join a in DbContext.Addresses on c.CustomerId equals a.CustomerId
                              where c.DeletedAt == null && a.DeletedAt == null
                              select new { c, a }
                              ).ToList();
            return customers;
        }

        public Customer GetById(long id)
        {
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter("@customerId", id)
            };

            var customer = DbContext.Database.
                SqlQuery<Customer>("exec test.spGetCustomerById @customerId", sqlParams)
                .FirstOrDefault();

            if (customer != null)
            {
                var sqlParams2 = new SqlParameter[]
                {
                    new SqlParameter("@customerId", id)
                };

                customer.Address = DbContext.Database
                    .SqlQuery<Address>("exec test.spGetAddressByCustomerId @customerId", sqlParams2)
                    .ToList();
            }

            // en lo personal prefiero utilizar linQ para hacer las consultas
            var customer2 = (from c in DbContext.Customers
                             join a in DbContext.Addresses on c.CustomerId equals a.CustomerId
                             where c.CustomerId == id && c.DeletedAt == null && a.DeletedAt == null
                             select new { c, a }
                             ).FirstOrDefault();
            return customer;
        }

        public void Put(long id, Customer entity)
        {
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter("@customerId", id),
                new SqlParameter("@idNumber", entity.IdNumber),
                new SqlParameter("@idType", entity.IdType),
                new SqlParameter("@firstName", entity.FirstName),
                new SqlParameter("@secondName", entity.SecondName),
                new SqlParameter("@firstLastName", entity.FirstLastName),
                new SqlParameter("@secondLastName", entity.SecondLastName),
                new SqlParameter("@status", entity.Status)
            };

            DbContext.Database
                .ExecuteSqlCommand(
                    "exec test.spUpdateCustomer @customerId, @idNumber, @idType, @firstName, @secondName, @firstLastName, @secondLastName, @status",
                    sqlParams
                );

            foreach (var address in entity.Address)
            {
                var addressParams = new SqlParameter[]
                {
                    new SqlParameter("@addressId", address.AddressId),
                    new SqlParameter("@description", address.Description),
                    new SqlParameter("@status", address.Status),
                    new SqlParameter("@isPrimary", address.IsPrimary)
                };

                DbContext.Database
                    .ExecuteSqlCommand(
                        "exec test.spUpdateAddress @addressId, @description, @status, @isPrimary",
                        addressParams
                     );
            }


            /*
             En lo personal prefiero utilizar el DbContext para hacer las actualizaciones
            foreach (var address in entity.Address)
            {
                DbContext.Entry(address).State = EntityState.Modified;
            }

            DbContext.Entry(entity).State = EntityState.Modified;

            DbContext.SaveChanges();*/
        }

        public Customer Save(Customer entity)
        {
            DbContext.Customers.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }


        public void Delete(long id)
        {
            var customer = DbContext.Customers.Find(id);

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            customer.Status = Status.Deleted.ToString();
            customer.DeletedAt = DateTime.Now;
            DbContext.Entry(customer).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
