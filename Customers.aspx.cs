using rwa_projekt_katlija_2407.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_projekt_katlija_2407
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {            
                ShowMaxCustomers();
                tblHolder.Visible = false;
                filterContainer.Visible = false;
                ViewState["sortExpression"] = "--";
                StopDirectAccess();              
            }
                       
                StopDirectAccess();
        }

        private void StopDirectAccess()
        {
           if(Request.Cookies["userData"]== null)
            {
                Response.Redirect("~/Login/Index");
            }
        }

        private void ShowMaxCustomers()
        {

            var num = Repo.GetMaxCustomers();           
            maxCustomers.Text = num.ToString();
            RangeValidator.MaximumValue = num.ToString();
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

            tblHolder.Visible = true;
            filterContainer.Visible = true;
            FillDDLState();
            GvDataBindfromBase();
            if (ddlCities.Visible == true && lblCity.Visible == true && AddACity.Visible == true)
            {
                ddlCities.Visible = false;
                lblCity.Visible = false;
                AddACity.Visible = false;
            }

        }

        protected void numOfCustomers_TextChanged(object sender, EventArgs e)
        {
            ViewState["NumberOfCustomers"] = int.Parse(numOfCustomers.Text);
        }
        //fillddl
        private void FillDDLState()
        {
            ddlStates.DataSource = Repo.FillDDLStates();
            ddlStates.DataTextField = "Naziv";
            ddlStates.DataValueField = "IDDrzava";
            ddlStates.DataBind();
            ddlStates.Items.Insert(0, "-------Select-------");
        }
        private void FillDDLCities()
        {
            var selectedState = int.Parse(ddlStates.SelectedValue);
            ddlCities.DataSource = Repo.FillDDLCities(selectedState);
            ddlCities.DataTextField = "Naziv";
            ddlCities.DataValueField = "IDGrad";
            ddlCities.DataBind();
            ddlCities.Items.Insert(0, "----Select----");
        }
        //binddata
        private void GvDataBindfromBase()
        {
            var a = (int)ViewState["NumberOfCustomers"];
            gvCustomers.DataSource = Repo.GetCustomers(a).ToList();
            gvCustomers.DataBind();
            ViewState["gvCustomers"] = Repo.GetCustomers(a).ToList();

        }
        private void GvDataBindfromView()
        {
            List<Customer> customers = new List<Customer>();
            customers = (List<Customer>)ViewState["gvCustomers"];
            gvCustomers.DataSource = customers;
            gvCustomers.DataBind();
        }
        //gridview eventi
        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCustomers.PageIndex = e.NewPageIndex;
            GvDataBindfromView();
        }

        protected void gvCustomers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCustomers.EditIndex = e.NewEditIndex;
            GvDataBindfromView();
        }

        protected void gvCustomers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCustomers.EditIndex = -1;
            GvDataBindfromView();
        }

        protected void gvCustomers_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            ViewState["sortExpression"] = sortExpression;


            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, "DESC");
            }

            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, "ASC");
            }
        }

        //ddl eventi
        protected void ddlStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStates.SelectedIndex > 0)
            {
                FillDDLCities();

                ddlCities.Visible = true;
                lblCity.Visible = true;
                AddACity.Visible = true;
                FilterDataByState();
            }
            else
            {
                ddlCities.Visible = false;
                lblCity.Visible = false;
                AddACity.Visible = false;
                GvDataBindfromBase();
            }
        }

        protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStates.SelectedIndex != 0 && ddlCities.SelectedIndex != 0)
            {
                FilterDataByCity();
            }
            else
            {
                ddlCities.Visible = false;
                AddACity.Visible = false;            
                lblCity.Visible = false;
                FilterDataByState();
            }
        }
        protected void gvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvCustomers.EditIndex == e.Row.RowIndex)
            {
                DropDownList chsState = (DropDownList)e.Row.FindControl("ChooseState");
                chsState.DataSource = Repo.FillDDLStates();
                chsState.DataTextField = "Naziv";
                chsState.DataValueField = "IDDrzava";
                chsState.DataBind();
                chsState.SelectedValue = gvCustomers.DataKeys[e.Row.RowIndex].Values[4].ToString();

                DropDownList chsCity = (DropDownList)e.Row.FindControl("ChooseCity");
                chsCity.DataSource = Repo.FillDDLCities(int.Parse(chsState.SelectedValue));
                chsCity.DataTextField = "Naziv";
                chsCity.DataValueField = "IDGrad";
                chsCity.DataBind();
                chsCity.SelectedValue = gvCustomers.DataKeys[e.Row.RowIndex].Values[3].ToString();

                e.Row.FindControl("receiptsButton").Visible = false;
                e.Row.FindControl("moreInfoButton").Visible = false;
            }
        }
        protected void gvCustomers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow updateRow = gvCustomers.Rows[e.RowIndex];
            DropDownList ddlc = (DropDownList)gvCustomers.Rows[e.RowIndex].FindControl("ChooseCity");
            DropDownList ddls = (DropDownList)gvCustomers.Rows[e.RowIndex].FindControl("ChooseState");
            var idKupac = (int)gvCustomers.DataKeys[e.RowIndex].Values[0];
            var ime = updateRow.Cells[1].Controls.OfType<TextBox>().First().Text;
            var prezime = updateRow.Cells[2].Controls.OfType<TextBox>().First().Text;
            var email = gvCustomers.DataKeys[e.RowIndex].Values[1].ToString();
            var telefon = gvCustomers.DataKeys[e.RowIndex].Values[2].ToString();
            var gradID = int.Parse(ddlc.SelectedValue);
            var drzavaID = int.Parse(ddls.SelectedValue);
            var drzava = ddls.SelectedItem.Text;
            var grad = ddlc.SelectedItem.Text;

            Customer customer = new Customer
            {
                IDKupac = idKupac,
                Ime = ime,
                Prezime = prezime,
                Drzava = drzava,
                Grad = grad,
                Telefon = telefon,
                Email = email,
                GradID = gradID,
                DrzavaID = drzavaID
            };

            Repo.UpdateCustomer(customer);
            gvCustomers.EditIndex = -1;
            ddlStates.SelectedIndex = 0;
            ddlCities.Visible = false;
            lblCity.Visible = false;
            AddACity.Visible = false;
            GvDataBindfromBase();
        }
        protected void gvCustomers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell tc in e.Row.Cells)
                {

                    if (tc.HasControls())
                    {
                        LinkButton lnk = (LinkButton)tc.Controls[0];
                        if (lnk != null)
                        {
                            lnk.Attributes.Add("style", "text-decoration:none; color: black;");
                            Image img = new Image();
                            img.ImageUrl = "~/Images/sort-desc.png";
                            tc.Controls.Add(new LiteralControl(" "));
                            tc.Controls.Add(img);

                            if ((ViewState["sortExpression"]).ToString() == lnk.CommandArgument)
                            {
                                Image img1 = new Image();
                                img.ImageUrl = "~/Images/sort-" + ((GridViewSortDirection) == SortDirection.Ascending ? "asc" : "desc") + ".png";
                                tc.Controls.Add(new LiteralControl(" "));
                                tc.Controls.Add(img);
                            }

                        }
                    }
                }
            }
        }

        //FilterData
        private void FilterDataByState()
        {
            gvCustomers.DataSource = Repo.ShowCustomerFromState(int.Parse(ddlStates.SelectedValue), int.Parse(numOfCustomers.Text)).ToList();
            gvCustomers.DataBind();
            ViewState["gvCustomers"] = Repo.ShowCustomerFromState(int.Parse(ddlStates.SelectedValue), int.Parse(numOfCustomers.Text)).ToList();
        }
        private void FilterDataByCity()
        {
            gvCustomers.DataSource = Repo.ShowCustomerFromStateAndCity(int.Parse(ddlStates.SelectedValue), int.Parse(numOfCustomers.Text), int.Parse(ddlCities.SelectedValue)).ToList();
            gvCustomers.DataBind();
            ViewState["gvCustomers"] = Repo.ShowCustomerFromStateAndCity(int.Parse(ddlStates.SelectedValue), int.Parse(numOfCustomers.Text), int.Parse(ddlCities.SelectedValue)).ToList();
        }
        //sortmethods
        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                {
                    ViewState["sortDirection"] = SortDirection.Descending;
                }
                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }
        private void SortGridView(string sortExpression, string direction)
        {

            List<Customer> customers = new List<Customer>();
            customers = (List<Customer>)ViewState["gvCustomers"];

            if (sortExpression == "Ime" && direction == "ASC")
            {
                customers.Sort(delegate (Customer x, Customer y)
                {
                    return x.Ime.CompareTo(y.Ime);

                });
                gvCustomers.DataSource = customers;
                gvCustomers.DataBind();
                ViewState["gvCustomers"] = customers;
            }
            if (sortExpression == "Ime" && direction == "DESC")
            {
                customers.Sort(delegate (Customer x, Customer y)
                {
                    return -x.Ime.CompareTo(y.Ime);

                });
                gvCustomers.DataSource = customers;
                gvCustomers.DataBind();
                ViewState["gvCustomers"] = customers;
            }
            if (sortExpression == "Prezime" && direction == "DESC")
            {
                customers.Sort(delegate (Customer x, Customer y)
                {
                    return x.Prezime.CompareTo(y.Prezime);

                });
                gvCustomers.DataSource = customers;
                gvCustomers.DataBind();
                ViewState["gvCustomers"] = customers;
            }

            if (sortExpression == "Prezime" && direction == "ASC")
            {
                customers.Sort(delegate (Customer x, Customer y)
                {
                    return -x.Prezime.CompareTo(y.Prezime);

                });
                gvCustomers.DataSource = customers;
                gvCustomers.DataBind();
                ViewState["gvCustomers"] = customers;
            }
        }
        //edit mode
        protected void ChooseState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            DropDownList ddlc = (DropDownList)row.FindControl("ChooseCity");
            ddlc.DataSource = Repo.FillDDLCities(int.Parse(ddl.SelectedValue));
            ddlc.DataValueField = "IDGrad";
            ddlc.DataTextField = "Naziv";
            ddlc.DataBind();
        }

        //add new
        protected void AddAState_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddState.aspx");
        }

        protected void AddACity_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddCity.aspx");
        }
        //mvc redirect
        protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "moreInfo")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var id = (int)(gvCustomers.DataKeys[index]["IDKupac"]);
                Response.Redirect($"~/Customer/ShowMoreInfo/{id}");             
            }
            if(e.CommandName == "showReceipts")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var id = (int)(gvCustomers.DataKeys[index]["IDKupac"]);         
                Response.Redirect($"~/Receipt/ShowReceipts/{id}");         

            }

        }
    }
}
