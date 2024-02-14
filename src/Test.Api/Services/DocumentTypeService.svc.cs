using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Test.Model.Enums;

namespace Test.Api.Services
{
    [ServiceContract]
    public class DocumentTypeService
    {
        [OperationContract]
        public string[] GetDocumentTypes()
        {
            // get strings values of the enum
            return Enum.GetNames(typeof(DocumentType));
        }
    }
}
