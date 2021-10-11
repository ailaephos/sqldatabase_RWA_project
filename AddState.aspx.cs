using rwa_projekt_katlija_2407.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_projekt_katlija_2407
{
    public partial class AddState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            lblStatus.Visible = false;
            ImageButton1.Visible = false;
            status.Visible = false;
            StopDirectAccess();
            }
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
            int b = Repo.CheckState(new State
            {
                Naziv = AddAState.Text
            });
            if (b == 0)
            {
                int a = Repo.InsertState(new State
                {
                    Naziv = AddAState.Text
                });
                if (a > 0)
                {
                    lblStatus.Text = "State has been added";
                    lblStatus.Visible = true;
                    ImageButton1.Visible = true;
                    status.Visible = true;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showstatealert", "alert('State you are trying to add already exists!');", true);
            }
            
        }
    
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Customers.aspx");
        }
    }
}