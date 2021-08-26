using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{
    SqlConnection conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Emp"].ConnectionString.ToString());
   
	public DataLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Execute(string mstQry)
    {
        conObj.Close();
        SqlTransaction sqlTrans;

        conObj.Open();

        sqlTrans = conObj.BeginTransaction();
        SqlCommand cmd = new SqlCommand(mstQry, conObj);
        cmd.Transaction = sqlTrans;
        cmd.ExecuteNonQuery();
        sqlTrans.Commit();
        conObj.Close();

    }



    //------------------------------- new codes--------------------


    public DataSet dataset(string mrtQry)
    {
        conObj.Close();
        conObj.Open();
        SqlCommand cmd = new SqlCommand(mrtQry, conObj);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds != null)
        {
            return ds;
        }
        else
        {
            return null;
        }
    }
    public bool available(string qry)
    {

        conObj.Close();
        conObj.Open();
        SqlCommand cmd = new SqlCommand(qry, conObj);
        SqlDataReader dtrData;
        dtrData = cmd.ExecuteReader();
        return (dtrData.Read());
       
    }
    public DataTable GetDataTable(string qry)
    {
        conObj.Close();
        conObj.Open();
        SqlCommand cmd = new SqlCommand(qry, conObj);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt != null)
        {
            return dt;
        }
        else
        {
            return null;
        }
       
    }

    
    public SqlDataReader GetReader(string qry)
    {
        conObj.Close();
        SqlCommand cmdData = new SqlCommand(qry, conObj);
        cmdData.Connection = conObj;
        conObj.Open();
        SqlDataReader read = cmdData.ExecuteReader();
        return read;
       
    }

    public void UpdateConfigurationImg(string code, byte[] image,string  licence)
    {
        string sql = "";
        conObj.Close();
        conObj.Open();
        if (code == "cover")
        {
            sql = "UPDATE [configuration] SET [cover]=@photo  ";
        }
        else if (code == "logo")
        {
            sql = "UPDATE [configuration] SET [logo]=@photo  ";
        }

        SqlCommand cmd = new SqlCommand(sql, conObj);
        cmd.Parameters.AddWithValue("@photo", SqlDbType.Image).Value = image;
        cmd.ExecuteScalar();
        conObj.Close();
    }
    public void insertphoto(string id, byte[] image )
    {

        conObj.Open();
        string sql = "UPDATE Login SET photo=@photo WHERE userid=@userid  ";
        SqlCommand cmd = new SqlCommand(sql, conObj);
        cmd.Parameters.AddWithValue("@userid", SqlDbType.NVarChar).Value = id;
        cmd.Parameters.AddWithValue("@photo", SqlDbType.Image).Value = image;
        cmd.ExecuteNonQuery();
        conObj.Close();
    }
    
}
