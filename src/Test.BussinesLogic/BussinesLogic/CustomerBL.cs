using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test.Common.Interfaces;
using Test.Model;
using Test.Model.Entities;
using Test.Repository.Repositories;

namespace Test.BussinesLogic
{
    public class CustomerBL : BaseBL<CustomerRepo>, IRetriveUC<Customer, long>, IPersistsUC<Customer, long>
    {
        public CustomerBL(TestDbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(long id)
        {
            Repository.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return Repository.GetAll();
        }

        public Customer GetById(long id)
        {
            return Repository.GetById(id);
        }

        public void Put(long id, Customer entity)
        {
            entity.ModifiedAt = DateTime.Now;
            foreach (var address in entity.Address)
            {
                address.ModifiedAt = DateTime.Now;
                DbContext.Entry(address).State = EntityState.Modified;
            }
            Repository.Put(id, entity);
        }

        public Customer Save(Customer entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.Status = Status.Active.ToString();

            foreach (var address in entity.Address)
            {
                address.CreatedAt = DateTime.Now;
                address.Status = Status.Active.ToString();
            }
            return Repository.Save(entity);
        }

        /*public override long Create(Customer entity)
        {
            entity.Status = Status.Active.ToString();
            entity.CreatedAt = DateTime.Now;

            foreach (var address in entity.Address)
            {
                address.Status = Status.Active.ToString();
                address.CreatedAt = DateTime.Now;
                address.IsPrimary = address.Description == entity.Address.FirstOrDefault().Description;
            }


            DbContext.Customers.Add(entity);
            return DbContext.SaveChanges();
            /*var sqlParams = new SqlParameter[]
            {
                new SqlParameter("@idNumber", entity.idNumber),
                new SqlParameter("@idType", entity.idType),
                new SqlParameter("@firstName", entity.firstName),
                new SqlParameter("@secondName", entity.secondName),
                new SqlParameter("@firstLastName", entity.firstLastName),
                new SqlParameter("@secondLastName", entity.secondLastName)
            };

            var result = DbContext.Database
                .SqlQuery<decimal>("exec test.spCreateCustomer @idNumber, @idType, @firstName, @secondName, @firstLastName, @secondLastName", sqlParams)
                .First();

            long customerId = Convert.ToInt64(result);

            foreach(var address in entity.Address)
            {
                var addressSqlParams = new SqlParameter[]
                {
                    new SqlParameter("@customerId", customerId),
                    new SqlParameter("@description", address.description)
                };

                DbContext.Database.ExecuteSqlCommand("exec test.spCreateAddress @customerId, @description", addressSqlParams);
            }

            return customerId;*/
        //}

        /* public override void Delete(long id)
         {
             var sqlParams = new SqlParameter[]
             {
                 new SqlParameter("@id", id)
             };

             DbContext.Database.ExecuteSqlCommand("exec test.spDeleteCustomer @id", sqlParams);
         }

         public override IEnumerable<Customer> RetrieveAll()
         {
             //return DbContext.Customers.ToList();
             IEnumerable<Customer> customers = DbContext.Database.SqlQuery<Customer>("exec test.spGetCustomers").ToList();

             foreach (var customer in customers)
             {
                 var sqlParams = new SqlParameter[]
                 {
                     new SqlParameter("@customerId", customer.CustomerId)
                 };

                 //customer.Address = DbContext.Database.SqlQuery<Address>("exec test.spGetAddressByCustomerId @customerId", sqlParams);
                 customer.Address = (from a in
                                         DbContext.Addresses
                                     where
                                         a.CustomerId == customer.CustomerId
                                     &&
                                         a.IsPrimary == true
                                     select a
                                    ).ToList();
             }

             return customers;
             //return DbContext.Database.SqlQuery<Customer>("exec test.spGetCustomers").ToList();
         }

         public override Customer RetrieveById(long id)
         {
             var sqlParams = new SqlParameter[]
             {
                 new SqlParameter("@id", id)
             };

             return DbContext.Database.SqlQuery<Customer>("exec test.spGetCustomerById @id", sqlParams).FirstOrDefault();
         }

         public override long Update(Customer entity)
         {
             throw new NotImplementedException();
         }*/
    }
}
