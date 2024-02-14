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
    public partial class editar_cliente : System.Web.UI.Page
    {
        long idCustomer;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string idParam = Request.QueryString["id"];

            if(idParam != null)
            {
                idCustomer = long.Parse(idParam);
            }
            else
            {
                idCustomer = 0;
            }

            if(idCustomer == 0)
            {
                Response.Redirect("/");
            }

            if (!IsPostBack)
            {
                using (DocumentTypeServiceClient documentTypeService = new DocumentTypeServiceClient())
                {
                    SetDocumentTypes(documentTypeService.GetDocumentTypes());
                }
            }

            if (!IsPostBack)
            {
                using (CustomerServiceClient client = new CustomerServiceClient())
                {
                    var customer = client.GetById(idCustomer);
                    if (customer != null)
                    {
                        SetCustomer(customer);
                    }
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

        private void SetCustomer(Customer customer)
        {
            TxtFirstName.Text = customer.FirstName;
            TxtSecondName.Text = customer.SecondName;
            TxtFirstLastName.Text = customer.FirstLastName;
            TxtSecondLastName.Text = customer.SecondLastName;
            TxtIdNumber.Text = customer.IdNumber;
            DropListIdType.SelectedValue = customer.IdType;
            TxtCity.Text = customer.Address.FirstOrDefault().City;
            TxtState.Text = customer.Address.FirstOrDefault().State;
            TxtCountry.Text = customer.Address.FirstOrDefault().Country;
            TxtNeighborhood.Text = customer.Address.FirstOrDefault().Neighborhood;
            TxtAddress.Text = customer.Address.FirstOrDefault().Description;
        }

        public void BtnRegisterCustomer_Click(Object sender, EventArgs e)
        {

            using (CustomerServiceClient client = new CustomerServiceClient())
            {
                var customer = client.GetById(idCustomer);
                
                customer.FirstName = TxtFirstName.Text;
                customer.SecondName = TxtSecondName.Text;
                customer.FirstLastName = TxtFirstLastName.Text;
                customer.SecondLastName = TxtSecondLastName.Text;
                customer.IdNumber = TxtIdNumber.Text;
                customer.IdType = DropListIdType.SelectedValue;
                customer.Address.FirstOrDefault().City = TxtCity.Text;
                customer.Address.FirstOrDefault().State = TxtState.Text;
                customer.Address.FirstOrDefault().Country = TxtCountry.Text;
                customer.Address.FirstOrDefault().Neighborhood = TxtNeighborhood.Text;
                customer.Address.FirstOrDefault().Description = TxtAddress.Text;
                
                client.Put(idCustomer, customer);

                Response.Redirect("/");
            }
        }
    }
}