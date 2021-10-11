using rwa_projekt_katlija_2407.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_projekt_katlija_2407
{
    public partial class AddCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlstate.DataSource = Repo.FillDDLStates();
                ddlstate.DataTextField = "Naziv";
                ddlstate.DataValueField = "IDDrzava";
                ddlstate.DataBind();
                StopDirectAccess();
            }
            lblStatus.Visible = false;
            ImageButton1.Visible = false;
            status.Visible = false;
            StopDirectAccess();

        }
        private void StopDirectAccess()
        {
            if (Request.Cookies["userData"] == null)
            {
                Response.Redirect("~/Login/Index");
            }
        }


        protected void add_Click(object sender, EventArgs e)
        {
            int b = Repo.CheckCity(new City
            {
                DrzavaID = int.Parse(ddlstate.SelectedValue),
                Naziv = AddAState.Text
            });
            if (b == 0)
            {
               
                int a = Repo.InsertCity(new City
                {
                    DrzavaID = int.Parse(ddlstate.SelectedValue),
                    Naziv = AddAState.Text
                });
                if (a > 0)
                {

                    lblStatus.Text = "City has been added";
                    lblStatus.Visible = true;
                    ImageButton1.Visible = true;
                    status.Visible = true;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showcityalert", "alert('City you are trying to add already exists in the selected state!');", true);
            }
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Customers.aspx");
        }
    }
}