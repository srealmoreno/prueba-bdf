using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Model.Entities;
using Test.Web.CustomerService;
using Test.Web.DocumentTypeService;

namespace Test.Web
{
    public partial class Nuevo_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (DocumentTypeServiceClient client = new DocumentTypeServiceClient())
                {
                    var documentTypes = client.GetDocumentTypes();
                    SetDocumentTypes(documentTypes);
                }
            }
        }

        private void SetDocumentTypes(string[] documentTypes)
        {
            DropListIdType.Items.Clear();
            foreach (var documentType in documentTypes)
            {
                var item = new ListItem(documentType, documentType);
                item.Attributes.Add("class", "select-items");
                DropListIdType.Items.Add(item);
            }
        }

        public void BtnRegisterCustomer_Click(Object sender, EventArgs e)
        {

            using (CustomerServiceClient client = new CustomerServiceClient())
            {
                var customer = new Customer
                {
                    FirstName = TxtFirstName.Text,
                    SecondName = TxtSecondName.Text,
                    FirstLastName = TxtFirstLastName.Text,
                    SecondLastName = TxtSecondLastName.Text,
                    IdType = DropListIdType.SelectedValue,
                    IdNumber = TxtIdNumber.Text,
                    Address = new List<Address>{
                       new Address{
                        City = TxtCity.Text,
                        State = TxtState.Text,
                        Country = TxtCountry.Text,
                        Neighborhood = TxtNeighborhood.Text,
                        IsPrimary = true,
                        Description = TxtAddress.Text
                    }}
                };

                client.Save(customer);

                Response.Redirect("/");
            }
        }
    }
}
