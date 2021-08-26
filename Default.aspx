<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
        <link id="Link2" runat="server" rel="icon" href="~/CSS/images/logo.ico" type="image/ico" />
    <link href="../CSS/bootstrap.css" rel="stylesheet" type="text/css" />
   
    <script src="../js/1.11.1jquery.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.js"></script>
    <script src="../js/toster.js" type="text/javascript"></script>
   
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/toster.css" rel="stylesheet" type="text/css" />
    <link href="../css/Style.css" rel="stylesheet" type="text/css" />
      <script src="js/toster.js"></script>
    <script type="text/javascript">

        function success(msg) {
            toastr.options.positionClass = "toast-bottom-right";
            toastr.success(msg);
        }
        function warning(msg) {
            toastr.options.timeOut = 1500; // 1.5s
            toastr.options.positionClass = "toast-bottom-right";
            toastr.warning(msg);
        }
        function info(msg) {
            toastr.options.positionClass = "toast-bottom-right";
            toastr.info(msg);
        }
        function error(msg) {
            toastr.options.positionClass = "toast-bottom-right";
            toastr.error(msg);
        }
    </script>

<!------ Include the above in your HEAD tag ---------->

<script type="text/javascript" src="http://www.clubdesign.at/floatlabels.js"></script>
    <style>
        body{
 
    background: -webkit-gradient(radial, center center, 0, center center, 460, from(#1a82f7), to(#2F2727));

 
    background: -webkit-radial-gradient(circle, #1a82f7, #2F2727);

 
    background: -moz-radial-gradient(circle, #1a82f7, #2F2727);

 
    background: -ms-radial-gradient(circle, #1a82f7, #2F2727);
    height:600px;
}

.centered-form{
	margin-top: 60px;
}

.centered-form .panel{
	background: rgba(255, 255, 255, 0.8);
	box-shadow: rgba(0, 0, 0, 0.3) 20px 20px 20px;
}

label.label-floatlabel {
    font-weight: bold;
    color: #46b8da;
    font-size: 11px;
}
    </style>
    <script>
        $(function () {
            $('input').floatlabel({ labelEndTop: 0 });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
   <div class="container">
        <div class="row centered-form">

        <div class="col-md-12">
            	<div class="panel-heading">
                     
                                                               
                        <div class="col-xs-12 pull-right ">
             <a class="btn btn-default pull-right icon btn-sm" data-toggle="modal" data-target="#SearchModal"><i class="fa fa-search" aria-hidden="true"></i>
                       
                        Search</a>
                           <%-- <asp:HyperLink ID="hlReceipt" runat="server" CssClass="btn btn-default pull-right icon btn-sm" Target="_blank"><i class="fa fa-print" aria-hidden="true"></i>&nbsp;Print</asp:HyperLink>--%>
                            <%--<asp:LinkButton ID="btnPrint" runat="server " CssClass="btn btn-default pull-right icon"><i class="fa fa-print" aria-hidden="true"></i>&nbsp;Print</asp:LinkButton>--%>
                           <a class="btn btn-default pull-right icon btn-sm" href="BillDetails.aspx"><i class="fa fa-times" aria-hidden="true" ></i>&nbsp;Clear</a>
                            
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-default pull-right icon btn-sm" ValidationGroup="Save" OnClick="btnSave_Click" ><i class="fa fa-check" aria-hidden="true"></i>&nbsp;Save</asp:LinkButton>



                        </div>
			 			</div>
        	<div class="panel panel-default">
        	
			 			<div class="panel-body">
			    		
			    			<div class="row">
                                
                                     <div class="col-md-3">
                     
                       
                        <div class="col-md-8">
                            <label>Attach Photo</label>
                            <div class="list-group-item" style="background-color: white; color: Maroon;">
                                <asp:Image ID="img_Photo" runat="server" class="  img-responsive" 
                                    Width="100px" Height="100px" />
                                &nbsp;
                                <asp:FileUpload ID="avatarUpload3" runat="server" CssClass="form-control" onchange='previewFile()'  />
                              
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Marks Card Attachment is required"
                                    Display="None" ControlToValidate="avatarUpload3" SetFocusOnError="true" ValidationGroup="Profdtl"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server" TargetControlID="RequiredFieldValidator23"
                                    PopupPosition="BottomLeft">
                                </asp:ValidatorCalloutExtender>
                            </div>
                            
                        </div>
                        
                         </div>
                                 <div class="col-md-8">
                                     <div class="row">
                                         <div class=" col-md-6">
                                     <label>Employee ID</label>
			    					<div class="form-group">
			       <asp:TextBox ID="txtEmpId" runat="server"   CssClass="form-control input-sm "  Enabled="false"  ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Employee ID"
                                                Display="None" ControlToValidate="txtEmpId" SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"
                                                PopupPosition="BottomLeft">
                                            </asp:ValidatorCalloutExtender>
			    					</div>
			    				</div>
			    				<div class=" col-md-6">
                                    <label>Name<a>*</a></label>
			    					<div class="form-group">
			       <asp:TextBox ID="txtName" runat="server"   CssClass="form-control input-sm "   ></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter your Name"
                                                Display="None" ControlToValidate="txtName" SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                PopupPosition="BottomLeft">
                                            </asp:ValidatorCalloutExtender>
			    					</div>
			    				</div>
			    		
                                         </div>
                                     <div class="row">
			    						<div class=" col-md-6">
                                     <label> Last Name <a>*</a></label>
			    					<div class="form-group">
			    						  <asp:TextBox ID="txtLastName" runat="server"   CssClass="form-control input-sm "   ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter your Last Name"
                                                Display="None" ControlToValidate="txtLastName" SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                                                PopupPosition="BottomLeft">
                                            </asp:ValidatorCalloutExtender>
			    					</div>
			    				</div>
                                                               		<div class=" col-md-6">
                                     <label>Organisation Name</label>
			    					<div class="form-group">
			    						  <asp:TextBox ID="txtOrgName" runat="server"   CssClass="form-control input-sm "   ></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Employee ID"
                                                Display="None" ControlToValidate="txtOrgName" SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4"
                                                PopupPosition="BottomLeft">
                                            </asp:ValidatorCalloutExtender>
			    					</div>
			    				</div>
			    		
                                         </div>
                                                    <div class="row">
                                  
			    				<div class=" col-md-6">

                                     <label>City</label>
			    					<div class="form-group">
			       <asp:TextBox ID="txtCity" runat="server"   CssClass="form-control input-sm "   ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Employee ID"
                                                Display="None" ControlToValidate="txtCity" SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5"
                                                PopupPosition="BottomLeft">
                                            </asp:ValidatorCalloutExtender>
			    					</div>
			    				</div>
                                                        <div class="col-md-6">
                                     <label>Date</label>
			    					<div class="form-group">
			      <asp:TextBox ID="txtdate" class="form-control input-sm" runat="server"  AutoComplete="off" AutoPostBack="false"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarFrom" runat="server" TargetControlID="txtdate"
                                            Format="dd-MM-yyyy">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter the Date"
                                            Display="None" ControlToValidate="txtdate" SetFocusOnError="true" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator6">
                                        </asp:ValidatorCalloutExtender>

			    					</div>
			    				</div>
			    				
                                         </div>
                                     </div>

			    			</div>

			    			
                            
			    			<div class="row">
			    				<div class=" col-md-12">
                                    <label>Address <a>*</a></label>
			    					<div class="form-group">
			    						  <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"  CssClass="form-control input-sm "   ></asp:TextBox>
			    					</div>
			    				</div>
			    				
			    			</div>
			    			
			    			<div class="row">
                                <div class=" col-md-12">
                                 <div class="col-md-2">
                                     </div>
                                                        <div class="col-md-5">
                     
                       
                        <div class="col-md-8">
                            <label>Attach PhotoCopy of C.V</label>
                            <div class="list-group-item" style="background-color: white; color: Maroon;">
                                  <asp:Image ID="Image2" runat="server" class="img-responsive " 
                                    Width="100px" Height="100px" />
                                &nbsp;
                                <asp:FileUpload ID="avatarUpload" runat="server" CssClass="form-control" onchange='previewFile1()'  />
                              
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Marks Card Attachment is required"
                                    Display="None" ControlToValidate="avatarUpload"  SetFocusOnError="true" ValidationGroup="Profdtl"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RequiredFieldValidator8"
                                    PopupPosition="BottomLeft">
                                </asp:ValidatorCalloutExtender>
                            </div>
                            
                        </div>
                        
                         </div>
                                  
                                                        <div class="col-md-5">
                     
                       
                        <div class="col-md-8">
                            <label>Attach PhotoCopy of Id(Any Id Proof)</label>
                            <div class="list-group-item" style="background-color: white; color: Maroon;">
                              <asp:Image ID="Image1" runat="server" class=" img-responsive " 
                                    Width="100px" Height="100px" />
                                &nbsp;
                               
                                <asp:FileUpload ID="avatarUpload4" runat="server" CssClass="form-control" onchange='previewFile2()'  />
                              
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="ID Proof Attachment is required"
                                    Display="None" ControlToValidate="avatarUpload4" SetFocusOnError="true" ValidationGroup="Profdtl"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RequiredFieldValidator9"
                                    PopupPosition="BottomLeft">
                                </asp:ValidatorCalloutExtender>
                            </div>
                            
                        </div>
                        
                         </div>
                                      </div>
                                </div>
			    		
			    	
			    	</div>
	    		</div>
    		</div>
    	</div>
    </div>
          <asp:HiddenField ID="hfID" runat="server" />
        <asp:HiddenField ID="hfID1" runat="server" />
        <asp:HiddenField ID="hfID2" runat="server" />
        <asp:HiddenField ID="hfID3" runat="server" />
            <div id="SearchModal" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Search Items<button type="button" class="close" data-dismiss="modal"><i class="fa fa-close "></i></button>
                    </h4>
                </div>
                <div class="modal-body" style="width: 100%; overflow: auto">

                     <asp:GridView ID="grid" runat="server" CellPadding="4" Font-Size="10px" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" CssClass="table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:BoundField DataField="EmpId" HeaderText="Employee Id" ItemStyle-Width="50px" HeaderStyle-Width="50px" />
                            <asp:BoundField DataField="EmpName" HeaderText="Employee Name" ItemStyle-Width="350px" HeaderStyle-Width="350px" />
                            <asp:BoundField DataField="EmpLastName" HeaderText="LastName" ItemStyle-Width="250px" HeaderStyle-Width="250px" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="200px" HeaderStyle-Width="200px" />
                            <asp:BoundField DataField="city" HeaderText="city" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                           
                            <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                           
                           
                            <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>
                </div>

            </div>

        </div>
    </div>

    </form>
</body>
     <script type="text/javascript">

         function previewFile() {
             var preview = document.querySelector('#<%=img_Photo.ClientID %>');
            var file = document.querySelector('#<%=avatarUpload3.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {

                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }

            </script>
         <script type="text/javascript">
             function previewFile1() {
                 var preview = document.querySelector('#<%=Image2.ClientID %>');
            var file = document.querySelector('#<%=avatarUpload.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {

                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }

        }
              </script>
          <script type="text/javascript">
              function previewFile2() {
                  var preview = document.querySelector('#<%=Image1.ClientID %>');
                 var file = document.querySelector('#<%=avatarUpload4.ClientID %>').files[0];
                 var reader = new FileReader();

                 reader.onloadend = function () {
                     preview.src = reader.result;
                 }

                 if (file) {

                     reader.readAsDataURL(file);
                 } else {
                     preview.src = "";
                 }
             }
    </script>
</html>
