using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    BusinessLayer BL = new BusinessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BL.Fill_EMPSearch_grid(grid);
            txtdate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtEmpId.Text == "")
            {
                hfID.Value = BL.ReturnString("select isnull(max([EmpId]),0)+1 from [EmpDetails]");
                BL.save_EmpDeatails(hfID.Value, txtName.Text.Trim(), txtLastName.Text.Trim(), txtOrgName.Text.Trim(), txtCity.Text.Trim(), txtAddress.Text.Trim(), txtdate.Text.Trim());
                foreach (HttpPostedFile postedFile in avatarUpload3.PostedFiles)
                {
                    if (postedFile.ContentLength < 5000000)
                    {

                        int length = postedFile.ContentLength;
                        byte[] imgbyte = new byte[length];
                        postedFile.InputStream.Read(imgbyte, 0, length);
                        string code = BL.ReturnString("select isnull(max([slno]),0)+1 from [Photo]");
                        string extension = Path.GetExtension(postedFile.FileName);
                        string FileName = hfID.Value + extension;
                        Stream strm = postedFile.InputStream;
                        string path = Server.MapPath("Photo/thumb/" + FileName);
                        var targetFile = path;
                        GenerateThumbnails(0.5, strm, targetFile);
                        postedFile.SaveAs(Server.MapPath("Photo/original/" + FileName));

                        string ext = Path.GetExtension(avatarUpload3.FileName);
                        BL.save_photo(hfID.Value, ext, code);



                    }
                    else
                    {
                        string msg = "Image size should be less then 500kb.";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "error('" + msg + "')", true);
                    }
                }
                foreach (HttpPostedFile postedFile in avatarUpload.PostedFiles)
                {
                    if (postedFile.ContentLength < 5000000)
                    {

                        int length = postedFile.ContentLength;
                        byte[] imgbyte = new byte[length];
                        postedFile.InputStream.Read(imgbyte, 0, length);
                        string code = BL.ReturnString("select isnull(max([slno]),0)+1 from [Resume]");
                        string extension = Path.GetExtension(postedFile.FileName);
                        string FileName = hfID.Value + extension;
                        Stream strm = postedFile.InputStream;
                        string path = Server.MapPath("Resume/thumb/" + FileName);
                        var targetFile = path;
                        GenerateThumbnails(0.5, strm, targetFile);
                        postedFile.SaveAs(Server.MapPath("Resume/original/" + FileName));

                        string ext = Path.GetExtension(avatarUpload.FileName);
                        BL.save_Resume(hfID.Value, ext, code);



                    }
                    else
                    {
                        string msg = "Image size should be less then 500kb.";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "error('" + msg + "')", true);
                    }
                }
                foreach (HttpPostedFile postedFile in avatarUpload4.PostedFiles)
                {
                    if (postedFile.ContentLength < 5000000)
                    {

                        int length = postedFile.ContentLength;
                        byte[] imgbyte = new byte[length];
                        postedFile.InputStream.Read(imgbyte, 0, length);
                        string code = BL.ReturnString("select isnull(max([slno]),0)+1 from [IdProof]");
                        string extension = Path.GetExtension(postedFile.FileName);
                        string FileName = hfID.Value + extension;
                        Stream strm = postedFile.InputStream;
                        string path = Server.MapPath("id/thumb/" + FileName);
                        var targetFile = path;
                        GenerateThumbnails(0.5, strm, targetFile);
                        postedFile.SaveAs(Server.MapPath("id/original/" + FileName));

                        string ext = Path.GetExtension(avatarUpload4.FileName);
                        BL.save_Id(hfID.Value, ext, code);


                    }


                    else
                    {
                        string msg = "Image size should be less then 500kb.";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "error('" + msg + "')", true);
                    }
                }

                string msg1 = "Saved..";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "success('" + msg1 + "')", true);
                clear();
                BL.Fill_EMPSearch_grid(grid);
            }
            else
            {
                hfID.Value = txtEmpId.Text;
                DataSet ds = new DataSet();
                ds = BL.returnDateSet("delete from EmpDetails where EmpId='" + hfID.Value + "' ");
                //ds = BL.returnDateSet("delete from IdProof where Emp_id='" + hfID.Value + "' ");
                //ds = BL.returnDateSet("delete from Photo where Emp_id='" + hfID.Value + "' ");
                //ds = BL.returnDateSet("delete from Resume where Emp_id='" + hfID.Value + "' ");
            

                ds = BL.returnDateSet("select [slno], [Extensions] from [Photo] where [Emp_id]='" + hfID.Value + "'");
                ds = BL.returnDateSet("select [slno], [Extensions] from [Resume] where [Emp_id]='" + hfID.Value + "'");
                ds = BL.returnDateSet("select [slno], [Extensions] from [IdProof] where [Emp_id]='" + hfID.Value + "'");

                string a = avatarUpload3.FileName;
                string b = avatarUpload.FileName;
                string c = avatarUpload4.FileName;
                
                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                       
                        if (a != "")
                        {
                            string file = ds.Tables[0].Rows[i][0].ToString() + ds.Tables[0].Rows[i][1].ToString();
                            if (File.Exists(Server.MapPath("~/Photo/Original/" + file)))
                            {
                                File.Delete(Server.MapPath("~/Photo/Original/" + file));
                            }
                            if (File.Exists(Server.MapPath("~/Photo/thumb/" + file)))
                            {
                                File.Delete(Server.MapPath("~/Photo/thumb/" + file));
                            }
                            ds = BL.returnDateSet("delete from IdProof where Emp_id='" + hfID.Value + "' ");
                        }
                       if (b!= "")
                       {
                           string file1 = ds.Tables[0].Rows[i][0].ToString() + ds.Tables[0].Rows[i][1].ToString();
                           if (File.Exists(Server.MapPath("~/Resume/original/" + file1)))
                           {
                               File.Delete(Server.MapPath("~/Resume/original/" + file1));
                           }
                           if (File.Exists(Server.MapPath("~/Resume/thumb/" + file1)))
                           {
                               File.Delete(Server.MapPath("~/Resume/thumb/" + file1));
                           }
                           ds = BL.returnDateSet("delete from Photo where Emp_id='" + hfID.Value + "' ");
                       }
                       if (c != "")
                       {
                           string file2 = ds.Tables[0].Rows[i][0].ToString() + ds.Tables[0].Rows[i][1].ToString();
                           if (File.Exists(Server.MapPath("~/id/original/" + file2)))
                           {
                               File.Delete(Server.MapPath("~/id/original/" + file2));
                           }
                           if (File.Exists(Server.MapPath("~/id/thumb/" + file2)))
                           {
                               File.Delete(Server.MapPath("~/id/thumb/" + file2));
                           }
                           ds = BL.returnDateSet("delete from Resume where Emp_id='" + hfID.Value + "' ");
                           ;
                 
                       }

                       break;
                    }
              
                }
               
               

                //  hfID.Value = txtEmpId.Text;
                BL.save_EmpDeatails(hfID.Value, txtName.Text.Trim(), txtLastName.Text.Trim(), txtOrgName.Text.Trim(), txtCity.Text.Trim(), txtAddress.Text.Trim(), txtdate.Text.Trim());
                if(a != ""){

                foreach (HttpPostedFile postedFile in avatarUpload3.PostedFiles)
                {
                    if (postedFile.ContentLength < 5000000)
                    {

                        int length = postedFile.ContentLength;
                        byte[] imgbyte = new byte[length];
                        postedFile.InputStream.Read(imgbyte, 0, length);
                        string code = BL.ReturnString("select isnull(max([slno]),0)+1 from [Photo]");

                        string extension = Path.GetExtension(postedFile.FileName);
                        string FileName = hfID.Value + extension;
                        Stream strm = postedFile.InputStream;
                        string path = Server.MapPath("Photo/thumb/" + FileName);
                        var targetFile = path;
                        GenerateThumbnails(0.5, strm, targetFile);
                        postedFile.SaveAs(Server.MapPath("Photo/original/" + FileName));

                        string ext = Path.GetExtension(avatarUpload3.FileName);
                        BL.save_photo(hfID.Value, ext, code);



                    }
                    else
                    {
                        string msg = "Image size should be less then 500kb.";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "error('" + msg + "')", true);
                    }
                }
                    }
                if (b != "")
                {
                    foreach (HttpPostedFile postedFile in avatarUpload.PostedFiles)
                    {
                        if (postedFile.ContentLength < 5000000)
                        {

                            int length = postedFile.ContentLength;
                            byte[] imgbyte = new byte[length];
                            postedFile.InputStream.Read(imgbyte, 0, length);
                            string code = BL.ReturnString("select isnull(max([slno]),0)+1 from [Resume]");
                            string extension = Path.GetExtension(postedFile.FileName);
                            string FileName = hfID.Value + extension;
                            Stream strm = postedFile.InputStream;
                            string path = Server.MapPath("Resume/thumb/" + FileName);
                            var targetFile = path;
                            GenerateThumbnails(0.5, strm, targetFile);
                            postedFile.SaveAs(Server.MapPath("Resume/original/" + FileName));

                            string ext = Path.GetExtension(avatarUpload.FileName);
                            BL.save_Resume(hfID.Value, ext, code);



                        }
                        else
                        {
                            string msg = "Image size should be less then 500kb.";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "error('" + msg + "')", true);
                        }
                    }
                }
                if (c != "")
                {
                    foreach (HttpPostedFile postedFile in avatarUpload4.PostedFiles)
                    {
                        if (postedFile.ContentLength < 5000000)
                        {

                            int length = postedFile.ContentLength;
                            byte[] imgbyte = new byte[length];
                            postedFile.InputStream.Read(imgbyte, 0, length);
                            string code = BL.ReturnString("select isnull(max([slno]),0)+1 from [IdProof]");
                            string extension = Path.GetExtension(postedFile.FileName);
                            string FileName = hfID.Value + extension;
                            Stream strm = postedFile.InputStream;
                            string path = Server.MapPath("id/thumb/" + FileName);
                            var targetFile = path;
                            GenerateThumbnails(0.5, strm, targetFile);
                            postedFile.SaveAs(Server.MapPath("id/original/" + FileName));

                            string ext = Path.GetExtension(avatarUpload4.FileName);
                            BL.save_Id(hfID.Value, ext, code);



                        }


                        else
                        {
                            string msg = "Image size should be less then 500kb.";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "error('" + msg + "')", true);
                        }
                    }
                }
                string msg1 = "Saved..";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "success('" + msg1 + "')", true);
                clear();
                BL.Fill_EMPSearch_grid(grid);

            }
        }

        catch (Exception ex)
        {
            string msg = "error : " + ex.Message;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "error('" + msg + "')", true);
        }
    }



    private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            var newWidth = (int)(image.Width * scaleFactor);
            var newHeight = (int)(image.Height * scaleFactor);
            var thumbnailImg = new System.Drawing.Bitmap(newWidth, newHeight);
            var thumbGraph = System.Drawing.Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            var imageRectangle = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }

    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

            string code = grid.SelectedRow.Cells[0].Text;


            BL.SelectEditEmployee(code, txtEmpId, txtName, txtLastName, txtOrgName, txtCity, txtAddress, txtdate);
            img_Photo.ImageUrl = "~/Photo/thumb/" + BL.ReturnString("select  convert(varchar,Emp_id)+Extensions from Photo where Emp_id='" + code + "' ");
            Image2.ImageUrl = "~/Resume/thumb/" + BL.ReturnString("select convert(varchar,Emp_id)+Extensions from Resume where Emp_id='" + code + "'");
            Image1.ImageUrl = "~/id/thumb/" + BL.ReturnString("select convert(varchar,Emp_id)+Extensions from IdProof where Emp_id='" + code + "'");
            //avatarUpload3.ToolTip = BL.ReturnString("select  Extensions from Photo where Emp_id='" + code + "' ");
            //avatarUpload.ToolTip = BL.ReturnString("select  Extensions from Resume where Emp_id='" + code + "' ");
            //avatarUpload4.ToolTip = BL.ReturnString("select  Extensions from IdProof where Emp_id='" + code + "' ");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "MyModal();", true);
          
        }
        catch (Exception ex)
        {
            string msg = "error : " + ex.Message;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "error('" + msg + "')", true);
        }

    }

    public void clear()
    {
        txtName.Text = "";
        txtLastName.Text = "";
        txtOrgName.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtdate.Text = "";

    }

}