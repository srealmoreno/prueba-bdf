using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Test.BussinesLogic;
using Test.Common.Interfaces;
using Test.Model.Entities;

namespace Test.Api.Services
{
    [ServiceContract]
    public class CustomerService : BaseService<CustomerBL>, IRetriveUC<Customer, long>, IPersistsUC<Customer, long>
    {
        [OperationContract]
        [ApplyDataContractResolver]
        public IEnumerable<Customer> GetAll()
        {
            return ControllerBl.GetAll();
        }

        [OperationContract]
        [ApplyDataContractResolver]
        public Customer GetById(long id)
        {
            return ControllerBl.GetById(id);
        }

        [OperationContract]
        [ApplyDataContractResolver]
        public void Put(long id, Customer entity)
        {
            ControllerBl.Put(id, entity);
        }

        [OperationContract]
        [ApplyDataContractResolver]
        public Customer Save(Customer entity)
        {
            return ControllerBl.Save(entity);
        }

        [OperationContract]
        [ApplyDataContractResolver]
        public void Delete(long id)
        {
            ControllerBl.Delete(id);
        }

    }
}
