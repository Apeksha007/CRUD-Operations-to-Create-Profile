using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for BusinessLayer
/// </summary>
public class BusinessLayer
{
	DataLayer DL = new DataLayer();
    public BusinessLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void ExecuteQuery(string qry)
    {
        DL.Execute(qry);
    }
    public DataSet returnDateSet(string qry)
    {

        return (DL.dataset(qry));


    }
    public string ReturnString(string qry)
    {

        SqlDataReader read = (SqlDataReader)(DL.GetReader(qry));

        if (read.Read())
        {
            return read[0].ToString();
        }
        return "";

    }


    public void save_EmpDeatails(string EmpId, string  EmpName, string EmpLastName, string OrganisationName, string city, string Address, string Date)
    {
        string qry = "insert into EmpDetails (EmpId,EmpName,EmpLastName,OrganisationName,city,Address,Date) select '" + EmpId + "','" + EmpName + "','" + EmpLastName + "','" + OrganisationName + "','" + city + "','" + Address + "',Convert(DateTime,'" + Date + "',105 ) ";
        DL.Execute(qry);
    }
    public void save_photo(string Emp_id, string Extension, string code)
    {
        //string qry = "insert into [Album] (AlbumID,AlbumName) select isnull(max(AlbumID),0)+1,'" + AlbumName + "' from [Album]";
        string qry = "insert into [Photo] (slno,Emp_id,Extensions) values('" + code + "','" + Emp_id + "','" + Extension + "')";
        DL.Execute(qry);
    }

    public void save_Resume(string Emp_id, string Extension, string code)
    {
        //string qry = "insert into [Album] (AlbumID,AlbumName) select isnull(max(AlbumID),0)+1,'" + AlbumName + "' from [Album]";
        string qry = "insert into [Resume] (slno,Emp_id,Extensions) values('" + code + "','" + Emp_id + "','" + Extension + "')";
        DL.Execute(qry);
    }
    public void save_Id(string Emp_id, string Extension, string code)
    {
        //string qry = "insert into [Album] (AlbumID,AlbumName) select isnull(max(AlbumID),0)+1,'" + AlbumName + "' from [Album]";
        string qry = "insert into [IdProof] (slno,Emp_id,Extensions) values('" + code + "','" + Emp_id + "','" + Extension + "')";
        DL.Execute(qry);
    }


    public void Fill_EMPSearch_grid(GridView list)
    {
        DataTable dt = new DataTable();


        string qry = "SELECT * FROM   EmpDetails order by EmpId ";
        dt = (DL.GetDataTable(qry));
        list.DataSource = dt;
        list.DataBind();

    }

    public void SelectEditEmployee(string EmpId, TextBox EmpId1, TextBox EmpName, TextBox EmpLastName, TextBox OrganisationName, TextBox city, TextBox Address, TextBox Date)
    {

        string b = "";
        // string qry = "SELECT *, convert(varchar,EnquiryDate,105) as EnquiryDate1,convert(varchar,Inddate,105) as Inddate1 from  EnquiryMain where EnquiryNo='" + EnquiryNo + "' and  AcademicYear='" + AcademicYear + "' ";
       

        string qry = "select *,convert(varchar,Date,105) as Date1 from EmpDetails where EmpId='" + EmpId + "' ";
        SqlDataReader read = (SqlDataReader)(DL.GetReader(qry));
        if (read.Read())
        {

            EmpId = read["EmpId"].ToString();




            EmpId1.Text = read["EmpId"].ToString();
            EmpName.Text = read["EmpName"].ToString();
            EmpLastName.Text = read["EmpLastName"].ToString();
            OrganisationName.Text = read["OrganisationName"].ToString();
            city.Text = read["city"].ToString();
            Address.Text = read["Address"].ToString();
            Date.Text = read["Date1"].ToString();
            //SupplierCode.Text = read["SupplierCode"].ToString();
            //  name = read["SupplierCode"].ToString();

          



        }
    }


}