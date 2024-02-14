using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Model.Entities;

namespace Test.Web
{
    public partial class _Default : Page
    {
        private void SetCustomers(Customer[] customers)
        {
            viewClient.DataSource = customers;
            viewClient.DataBind();
            tableEmpty.Visible = customers.Length == 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (CustomerService.CustomerServiceClient client = new CustomerService.CustomerServiceClient())
            {
                SetCustomers(client.GetAll());
            }
        }

        public void BtnEdit_Click(object sender, EventArgs e)
        {
            var id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("editar-cliente?id=" + id);
        }

        public void BtnDelete_Click(object sender, EventArgs e)
        {
            var id = ((LinkButton)sender).CommandArgument;
            using (CustomerService.CustomerServiceClient client = new CustomerService.CustomerServiceClient())
            {
                client.Delete(long.Parse(id));
                SetCustomers(client.GetAll());
            }
        }
    }
}