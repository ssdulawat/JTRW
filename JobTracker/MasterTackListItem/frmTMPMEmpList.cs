using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JTToaster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.MasterTackListItem
{
    public partial class frmTMPMEmpList : Form
    {
        #region Declaration
        private DataTable dtmasteritem = new DataTable();
        private string CheckString;
        private static frmTMPMEmpList _Instance;
        private const string PMTMVal = "PM_TM";
        public Notification ToasterNoty;
        #endregion

        public frmTMPMEmpList()
        {
            InitializeComponent();
        }

        #region Events
        private void btnadd_Click(System.Object sender, System.EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            if (cmbGroup.SelectedItem == PMTMVal)
            {
                MessageBox.Show("You can't insert new record with 'PM_TM' selection please set it to defualt selection in filter Dropdown.", this.Text, MessageBoxButtons.OK);
                return;
            }
            if (btnadd.Text == "Insert")
            {
                btnadd.Text = "Save";
                DataRow datarow = dtmasteritem.NewRow();
                datarow["Id"] = 0;
                datarow["cGroup"] = "";
                datarow["cTrack"] = "";
                datarow["BillableRate"] = "0";
                datarow["EmpId"] = 0;
                dtmasteritem.Rows.Add(datarow);
                grdListitem.DataSource = dtmasteritem;
                grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cTrack"];
            }
            else
            {
                grdListitem.Rows[0].Cells[5].Selected = true;
                grdListitem.EndEdit();
                try
                {
                    if (grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cmbGroup"].FormattedValue.ToString() == "" && cmbGroup.SelectedItem.ToString() != PMTMVal)
                    {
                        MessageBox.Show("Please select Group ", "Message");
                        grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cmbGroup"];
                        return;
                    }
                    int inx = grdListitem.Rows.Count - 1;
                    string msg = AlreadyExist(grdListitem.Rows[inx].Cells["Emailaddress"].Value.ToString(), grdListitem.Rows[inx].Cells["UserName"].Value.ToString(), Convert.ToInt32(grdListitem.Rows[inx].Cells["EmpId"].Value));
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "Message");
                        return;
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    int cnt = grdListitem.Rows.Count - 1;
                    string cGroupColValue = grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cGroup"].Value.ToString();
                    var empid = Convert.ToInt32(grdListitem.Rows[cnt].Cells["EmpId"].Value);
                    string query = "DECLARE @newid int ";
                    string empQuery = "INSERT INTO EmployeeDetails(Address,Mobile,Designation,UserName,Password,Emailaddress,UserType,BillableRate,FirstName,LastName) VALUES(@Address,@Mobile,@Designation,@UserName,@Password,@Emailaddress,'U',@BillableRate,@FirstName,@LastName) SELECT @newId= SCOPE_IDENTITY() ";
                    if (empid != 0)
                    {
                        query = query + " SET @newid= " + empid + " ";
                    }
                    else
                    {
                        query = query + empQuery;
                    }
                    query = query + " INSERT INTO MasterItem(cGroup,cTrack,IsNewRecord,IsDisable,EmpId) values(@group,@track,@IsNewRecord,@IsDisable,@newId) ";
                    if (cmbGroup.SelectedItem.ToString() == PMTMVal || cGroupColValue == PMTMVal)
                    {
                        query = query + " INSERT INTO MasterItem(cGroup,cTrack,IsNewRecord,IsDisable,EmpId) values('TM',@track,@IsNewRecord,@IsDisable,@newId)";
                    }

                    string cGroup = (cmbGroup.SelectedItem == PMTMVal || cGroupColValue == PMTMVal) ? "PM" : grdListitem.Rows[cnt].Cells["cmbGroup"].Value.ToString();
                    cmd = new SqlCommand(query);
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@IsNewRecord", 1));
                    param.Add(new SqlParameter("@group", cGroup));
                    param.Add(new SqlParameter("@track", grdListitem.Rows[cnt].Cells["cTrack"].Value.ToString()));
                    object isDisable = (Convert.IsDBNull(grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["IsDisable"].Value) == true) ? (object)false : grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["IsDisable"].Value;
                    param.Add(new SqlParameter("@IsDisable", Convert.ToBoolean(isDisable)));
                    //EmployeeDetail
                    param.Add(new SqlParameter("@Address", grdListitem.Rows[cnt].Cells["Address"].Value.ToString()));
                    param.Add(new SqlParameter("@Mobile", grdListitem.Rows[cnt].Cells["Mobile"].Value.ToString()));
                    param.Add(new SqlParameter("@Designation", grdListitem.Rows[cnt].Cells["Designation"].Value.ToString()));
                    param.Add(new SqlParameter("@UserName", grdListitem.Rows[cnt].Cells["UserName"].Value.ToString()));
                    param.Add(new SqlParameter("@Password", grdListitem.Rows[cnt].Cells["Password"].Value.ToString()));
                    param.Add(new SqlParameter("@Emailaddress", grdListitem.Rows[cnt].Cells["Emailaddress"].Value.ToString()));
                    param.Add(new SqlParameter("@BillableRate", grdListitem.Rows[cnt].Cells["BillableRate"].Value.ToString()));
                    param.Add(new SqlParameter("@FirstName", grdListitem.Rows[cnt].Cells["FirstName"].Value.ToString()));
                    param.Add(new SqlParameter("@LastName", grdListitem.Rows[cnt].Cells["LastName"].Value.ToString()));

                    using (EFDbContext db = new EFDbContext())
                    {
                        int i = db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());
                        if (i > 0)
                        {
                            Fillgrid();
                        }

                        if (grdListitem.Rows.Count > 0)
                        {
                            //System.Windows.Forms.MessageBox.Show("Record Saved!", "Message")
                            StMethod.LoginActivityInfo(db, "Update", this.Text);
                            grdListitem.Rows[grdListitem.Rows.Count - 1].Selected = true;
                            grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cTrack"];
                            btnadd.Text = "Insert";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message");
                }
            }
        }

        private void frmMasterListItem_Load(object sender, System.EventArgs e)
        {
            //fillcomb()
            Setfill();
            Fillgrid();
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                Fillgrid();
                // grdListitem.Columns[0].ReadOnly = False
            }
            catch (Exception ex)
            {

            }
            cmbGroup.SelectedIndex = -1;
            txtTrack.Clear();
            txtEmail.Clear();
            txtUserName.Clear();
        }

        private void grdListitem_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnadd.Text.Trim() == "Save" && e.ColumnIndex == 0)
                {
                    btnadd_Click(sender, e);
                    return;
                }
                if (Convert.ToInt32(grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["Id"].Value.ToString()) != 0 || cmbGroup.SelectedItem == PMTMVal)
                {
                    if (e.ColumnIndex == 0 && e.RowIndex > -1)
                    {
                        string msg = AlreadyExist(grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["Emailaddress"].Value.ToString(), grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["UserName"].Value.ToString(), Convert.ToInt32(grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["EmpId"].Value));
                        if (!string.IsNullOrEmpty(msg))
                        {
                            MessageBox.Show(msg, "Message");
                            return;
                        }
                        btnadd.Text = "Insert";
                        try
                        {
                            object obj = grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["IsDisable"].Value;
                            bool IsDisable = (Convert.IsDBNull(obj) == true) ? false : true;
                            SqlCommand cmd = null;
                            if (cmbGroup.SelectedItem.ToString() == PMTMVal)
                            {
                                ShowNotification("'Value' column can't be update with PM_TM selection in filter.");
                            }
                            else
                            {
                                string whereCondition = " WHERE id=" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["Id"].Value.ToString();
                                string includeGroup = "cgroup='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cmbGroup"].Value.ToString() + "',";
                                if (grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cGroup"].Value.ToString() == PMTMVal)
                                {
                                    whereCondition = " WHERE cGroup IN ('PM','TM') AND cTrack='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                                    includeGroup = "";
                                }
                                cmd = new SqlCommand("update MasterItem set " + includeGroup + " cTrack='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "',IsChange=1,ChangeDate='" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "',IsDisable='" + IsDisable.ToString() + "'" + whereCondition);
                                if (grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cGroup"].Value == PMTMVal && cmbGroup.SelectedItem != PMTMVal)
                                {
                                    string u = grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString();
                                    cmd.CommandText = cmd.CommandText + " IF (SELECT COUNT(*) FROM MasterItem WHERE cTrack='" + u + "' AND cGroup IN('PM','TM'))=1 " + "BEGIN INSERT INTO MasterItem (cGroup,cTrack,EmpId,IsChange) " + "VALUES ( " + "CASE WHEN(SELECT cGroup FROM MasterItem WHERE cTrack='" + u + "' AND cGroup IN('PM','TM'))='PM' THEN 'TM' ELSE 'PM' END," + "                           '" + u + "'," + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["EmpId"].Value + ",0)	END";
                                }
                                using (EFDbContext db = new EFDbContext())
                                {
                                    db.Database.ExecuteSqlCommand(cmd.CommandText);
                                    StMethod.LoginActivityInfo(db, "Update", this.Text);
                                }
                            }


                            if (grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["EmpId"].Value.ToString() != "0")
                            {
                                UpdateEmpDetail(grdListitem.CurrentRow.Index);
                            }
                            else
                            {
                                InsertEmployeeDetails(grdListitem.CurrentRow.Index);
                            }


                            fillcomb();
                            grdListitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            MessageBox.Show("Updated Record!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Message");
                        }
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        ShowNotification("Deleted record will be removed from other refers places as well.");
                        if (MessageBox.Show("Are you sure about to delete!", this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }

                        // Dim q As String = "delete from masteritem where id=" & grdListitem.Rows["id", grdListitem.CurrentRow.Index].Value.ToString & ""

                        try
                        {
                            string q = "";
                            if (cmbGroup.SelectedItem != PMTMVal && grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cGroup"].Value != PMTMVal)
                            {
                                q = "UPDATE masteritem SET IsDelete=1  where id=" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["id"].Value.ToString() + "";
                                q = q + " UPDATE EmployeeDetails SET IsDelete=1 WHERE Id=" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["EmpId"].Value.ToString();
                            }
                            else
                            {
                                q = "UPDATE masteritem SET IsDelete=1  where cTrack='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                                q = q + " UPDATE EmployeeDetails SET IsDelete=1 WHERE Id=" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["EmpId"].Value.ToString();
                            }

                            //Dim con As New DataAccessLayer
                            SqlCommand cmd = new SqlCommand(q);
                            int r;
                            using (EFDbContext db = new EFDbContext())
                            {
                                r = db.Database.ExecuteSqlCommand(cmd.CommandText);
                            }

                            if (r > 0)
                            {
                                if (cmbGroup.SelectedItem == PMTMVal || grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cGroup"].Value == PMTMVal)
                                {
                                    Remove_cmbItem("PM");
                                    Remove_cmbItem("TM");
                                }
                                else
                                {
                                    Remove_cmbItem(grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cGroup"].Value.ToString().Trim());
                                }
                            }
                            grdListitem.Rows.RemoveAt(grdListitem.CurrentRow.Index);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Message");
                        }
                    }
                    //Else
                    //    MessageBox.Show("Please click save button", "Message")
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbGroup_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            //If cmbGroup.SelectedIndex = 0 Or cmbGroup.Text = "ADD" Then
            //    cmbGroup.SelectedText = ""
            //    cmbGroup.Focus()
            //End If
            Fillgrid();
            if (cmbGroup.Text == PMTMVal)
            {
                grdListitem.Columns["cmbGroup"].ReadOnly = true;
            }
            else
            {
                grdListitem.Columns["cmbGroup"].ReadOnly = false;
            }
        }

        private void txtTrack_TextChanged(System.Object sender, System.EventArgs e)
        {
            Fillgrid();
        }

        private void grdListitem_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            CheckString = grdListitem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
        private void grdListitem_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (grdListitem.Rows[e.RowIndex].Cells["cmbGroup"].Value.ToString() == PMTMVal && grdListitem.Columns[e.ColumnIndex].Name == "cmbGroup" && cmbGroup.SelectedItem == PMTMVal)
            {
                grdListitem.CancelEdit();
                ShowNotification("You can't select this option!");
            }
            else
            {
                if (CheckString == PMTMVal && cmbGroup.SelectedItem == "" && Convert.ToInt32(grdListitem.Rows[e.RowIndex].Cells["Id"].Value) != 0)
                {
                    grdListitem.CancelEdit();
                    ShowNotification("You can't change it!");
                }
                if (CheckString != grdListitem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                {
                    grdListitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                }

                if (btnadd.Text == "Save")
                {
                    if (grdListitem.Columns[e.ColumnIndex].Name == "cTrack")
                    {
                        grdListitem.Rows[e.RowIndex].Cells["UserName"].Value = grdListitem.Rows[e.RowIndex].Cells["cTrack"].Value;
                        //ShowNotification("Value column value will use same for UserName as well")
                    }
                }

            }
            if (grdListitem.Columns[e.ColumnIndex].Name == "cTrack")
            {
                FindEmployeeBycTrack(grdListitem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), e.RowIndex);
            }

        }
        #endregion

        #region Methods

        public object Remove_cmbItem(string Str)
        {
            string Query = "";
            switch (Str)
            {
                case "Bill State":
                    Query = "update JobTracking set BillState='' where BillState='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                    break;
                case "Borough":
                    Query = "update JobList set Borough='' where Borough='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                    break;
                case "Description":
                    Query = "update JobList set Description='' where Description='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                    break;
                case "PM":
                    //Query = "update JobList set Description='' where Description='" & grdListitem.Rows["cTrack", grdListitem.CurrentRow.Index].Value.ToString & "'"
                    Query = "update JobList set Handler='' where Handler='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                    break;
                case "TM":
                    Query = "update JobTracking set TaskHandler='' where TaskHandler='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                    break;
                case "Track":
                    Query = "update JobTracking set Track='' where Track='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                    break;
                case "Track PreReqt":
                    //Query = "update JobTracking set Track='' where Track='" & grdListitem.Rows["", grdListitem.CurrentRow.Index].Value.ToString & "'"
                    break;
                case "Track Permits":
                    break;
                case "Track Notes":
                    break;
                case "Track Report":
                    // Query = "update JobTracking set Track='' where Track='" & grdListitem.Rows["", grdListitem.CurrentRow.Index].Value.ToString & "'"
                    break;
                case "Track Sub":
                    Query = "update JobTracking set TrackSub='' where TrackSub='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                    break;
                case "Status":
                    Query = "update JobTracking set Status='' where Status='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "'";
                    break;
            }
            using (EFDbContext db = new EFDbContext())
            {
                db.Database.ExecuteSqlCommand(Query);
            }
            return null;
        }

        private void Setfill()
        {
            string queryString = "SELECT Id, cGroup, cTrack FROM  MasterItem where Id=0";
            using (EFDbContext db = new EFDbContext())
            {
                var data = db.Database.SqlQuery<MasterTrackSetData>(queryString).ToList();
                grdListitem.DataSource = data;
            }
            int i = grdListitem.Rows.Count;

            //Combo TM
            string[] arrGroup = new string[4];
            arrGroup[0] = "";
            arrGroup[1] = "PM";
            arrGroup[2] = "TM";
            arrGroup[3] = PMTMVal;
            DataGridViewComboBoxColumn colGroup = new DataGridViewComboBoxColumn();
            colGroup.DisplayIndex = 2;
            colGroup.HeaderText = "Group Name";
            colGroup.DataPropertyName = "cGroup";
            colGroup.Width = 150;
            colGroup.Name = "cmbGroup";
            colGroup.Items.AddRange(arrGroup);
            grdListitem.Columns.Add(colGroup);
            grdListitem.Columns["id"].Visible = false;
            grdListitem.Columns["cGroup"].Visible = false;
            grdListitem.Columns["cTrack"].Width = 350;
        }
        private void Fillgrid()
        {
            try
            {
                dtmasteritem.Clear();

                string queryString = MergeQuery();
                if (string.IsNullOrEmpty(queryString))
                {

                    string PMTMcolumns = " 0 as Id,'" + PMTMVal + "' as cGroup,m.cTrack,ISNULL(e.Id,0) As EmpId,e.FirstName,e.LastName,e.[Address],e.Mobile,e.EmailAddress,e.UserName,e.[Password],e.BillableRate,e.Designation,0 as IsDisable ";

                    string defaultColumn = " m.Id,m.cGroup,m.cTrack,ISNULL(e.Id,0) As EmpId,e.FirstName,e.LastName,e.[Address],e.Mobile,e.EmailAddress,e.UserName,e.[Password],e.BillableRate,e.Designation,m.IsDisable ";

                    queryString = "SELECT " + ((cmbGroup.Text == PMTMVal) ? PMTMcolumns : defaultColumn) + " FROM MasterItem m LEFT JOIN EmployeeDetails e ON m.EmpId=e.Id Where m.ID <> 0 and (m.IsDelete=0 or m.IsDelete is null ) AND m.cGroup in ('TM','PM') ";
                    if (!string.IsNullOrEmpty(this.txtTrack.Text))
                    {
                        queryString = queryString + " and m.cTrack Like'%" + txtTrack.Text + "%'";
                    }
                    if (!string.IsNullOrEmpty(this.txtEmail.Text))
                    {
                        queryString = queryString + " and e.EmailAddress Like'%" + txtEmail.Text + "%'";
                    }
                    if (!string.IsNullOrEmpty(this.txtUserName.Text))
                    {
                        queryString = queryString + " and e.UserName Like'%" + txtUserName.Text + "%'";
                    }
                    if (this.cmbGroup.SelectedItem != "" && cmbGroup.SelectedItem != PMTMVal)
                    {
                        queryString = queryString + " and m.cGroup='" + cmbGroup.SelectedItem + "'";
                    }
                    else if (cmbGroup.SelectedItem == PMTMVal)
                    {
                        queryString = queryString + " GROUP BY m.cTrack,e.id,e.FirstName,e.LastName,e.[Address],e.Mobile,e.EmailAddress,e.UserName,e.[Password],e.BillableRate,e.Designation HAVING COUNT(*)>1  ORDER BY m.cTrack";
                    }
                    if (cmbGroup.SelectedItem != PMTMVal)
                    {
                        queryString = queryString + " order by m.Cgroup";
                    }
                }
                using (EFDbContext db = new EFDbContext())
                {
                    //var data = db.Database.SqlQuery<>(queryString);
                    //grdListitem.DataSource = data;
                }
                grdListitem.Columns["cGroup"].Visible = false;
                grdListitem.Columns["cTrack"].HeaderText = "Value";
                grdListitem.Columns["cTrack"].Width = 60;
                grdListitem.Columns["Id"].Visible = false;
                grdListitem.Columns["EmpId"].Visible = false;
                grdListitem.Columns["IsDisable"].HeaderText = "Disable";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnadd.Text = "Insert";
        }
        private string MergeQuery()
        {
            string query = "";
            if (cmbGroup.SelectedItem == "")
            {
                query = "SELECT  MAX(m.Id) AS Id," + "(CASE WHEN COUNT(m.cGroup)>1 THEN 'PM_TM' ELSE MAX(cGroup) END)as cGroup," + "m.cTrack,ISNULL(e.Id,0) As EmpId,e.FirstName,e.LastName,e.[Address],e.Mobile,e.EmailAddress,e.UserName,e.[Password],e.BillableRate,e.Designation,CAST(MAX(CAST(m.IsDisable AS SMALLINT)) as BIT) as IsDisable " + " FROM MasterItem m LEFT JOIN EmployeeDetails e ON m.EmpId=e.Id " + " WHERE (m.IsDelete=0 or m.IsDelete is null ) AND m.cGroup in ('TM','PM') AND m.cTrack LIKE '" + txtTrack.Text + "%'" + " AND e.EmailAddress LIKE '" + txtEmail.Text + "%'" + " AND e.USerName LIKE '" + txtUserName.Text + "%'" + " GROUP BY m.cTrack,e.id,e.FirstName,e.LastName,e.[Address],e.Mobile,e.EmailAddress,e.UserName,e.[Password],e.BillableRate,e.Designation" + " ORDER BY m.cTrack";
            }
            return query;
        }

        private string AlreadyExist(string email, string username, int empId = 0)
        {
            using (EFDbContext db = new EFDbContext())
            {
                if (!string.IsNullOrEmpty(email))
                {
                    int count = db.Database.SqlQuery<int>("SELECT COUNT(*) FROM EmployeeDetails WHERE EmailAddress='" + email + "' AND (IsDelete=0 OR IsDelete IS NULL) " + ((empId == 0) ? "" : " AND Id<>" + empId)).FirstOrDefault();
                    if (count > 0)
                    {
                        return "Email aready exist.";
                    }
                }
                if (!string.IsNullOrEmpty(username))
                {
                    int count = db.Database.SqlQuery<int>("SELECT COUNT(*) FROM EmployeeDetails WHERE UserName='" + username + "' AND (IsDelete=0 OR IsDelete IS NULL) " + ((empId == 0) ? "" : " AND Id<>" + empId)).FirstOrDefault();
                    if (count > 0)
                    {
                        return "User name already exist.";
                    }
                }
            }
            return "";
        }
        private void UpdateEmpDetail(int cnt)
        {
            try
            {
                string query = "UPDATE EmployeeDetails SET Address=@Address,Mobile=@Mobile,Designation=@Designation,UserName=@UserName,Password=@Password,Emailaddress=@Emailaddress,BillableRate=@BillableRate,FirstName=@FirstName,LastName=@LastName WHERE Id=@EmpId";
                var cmd = new SqlCommand(query);
                List<SqlParameter> param = new List<SqlParameter>();
                //EmployeeDetail
                param.Add(new SqlParameter("@Address", grdListitem.Rows[cnt].Cells["Address"].Value.ToString()));
                param.Add(new SqlParameter("@Mobile", grdListitem.Rows[cnt].Cells["Mobile"].Value.ToString()));
                param.Add(new SqlParameter("@Designation", grdListitem.Rows[cnt].Cells["Designation"].Value.ToString()));
                param.Add(new SqlParameter("@UserName", grdListitem.Rows[cnt].Cells["UserName"].Value.ToString()));
                param.Add(new SqlParameter("@Password", grdListitem.Rows[cnt].Cells["Password"].Value.ToString()));
                param.Add(new SqlParameter("@Emailaddress", grdListitem.Rows[cnt].Cells["Emailaddress"].Value.ToString()));
                param.Add(new SqlParameter("@BillableRate", grdListitem.Rows[cnt].Cells["BillableRate"].Value.ToString()));
                param.Add(new SqlParameter("@FirstName", grdListitem.Rows[cnt].Cells["FirstName"].Value.ToString()));
                param.Add(new SqlParameter("@LastName", grdListitem.Rows[cnt].Cells["LastName"].Value.ToString()));
                param.Add(new SqlParameter("@EmpId", grdListitem.Rows[cnt].Cells["EmpId"].Value.ToString()));
                using (EFDbContext db = new EFDbContext())
                {
                    int i = db.Database.ExecuteSqlCommand(cmd.CommandText,param.ToArray());
                    if (i > 0)
                    {
                        Fillgrid();
                        //fillcomb()
                    }
                    if (grdListitem.Rows.Count > 0)
                    {
                        //System.Windows.Forms.MessageBox.Show("Record Saved!", "Message")
                        StMethod.LoginActivityInfo(db,"Update", this.Text);
                        btnadd.Text = "Insert";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message");
            }
        }
        private void InsertEmployeeDetails(int cnt)
        {
            string query = "INSERT INTO EmployeeDetails(Address,Mobile,Designation,UserName,Password,Emailaddress,UserType,BillableRate,FirstName,LastName) VALUES(@Address,@Mobile,@Designation,@UserName,@Password,@Emailaddress,'U',@BillableRate,@FirstName,@LastName) SELECT SCOPE_IDENTITY() ";
            SqlCommand cmd = new SqlCommand(query);
            //EmployeeDetail
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Address", grdListitem.Rows[cnt].Cells["Address"].Value.ToString()));
            param.Add(new SqlParameter("@Mobile", grdListitem.Rows[cnt].Cells["Mobile"].Value.ToString()));
            param.Add(new SqlParameter("@Designation", grdListitem.Rows[cnt].Cells["Designation"].Value.ToString()));
            param.Add(new SqlParameter("@UserName", grdListitem.Rows[cnt].Cells["UserName"].Value.ToString()));
            param.Add(new SqlParameter("@Password", grdListitem.Rows[cnt].Cells["Password"].Value.ToString()));
            param.Add(new SqlParameter("@Emailaddress", grdListitem.Rows[cnt].Cells["Emailaddress"].Value.ToString()));
            param.Add(new SqlParameter("@BillableRate", grdListitem.Rows[cnt].Cells["BillableRate"].Value.ToString()));
            param.Add(new SqlParameter("@FirstName", grdListitem.Rows[cnt].Cells["FirstName"].Value.ToString()));
            param.Add(new SqlParameter("@LastName", grdListitem.Rows[cnt].Cells["LastName"].Value.ToString()));

            using (EFDbContext db = new EFDbContext())
            {
                int i = db.Database.ExecuteSqlCommand(cmd.CommandText,param.ToArray());
                //Dim cGroupName As String = grdListitem.Rows[cnt].Cells["cGroup"].Value
                //cmd.CommandText = "UPDATE MasterItem SET EmpId=" & i & " WHERE " & IIf(cmbGroup.SelectedItem = PMTMVal Or cGroupName = PMTMVal, String.Format("cTrack='{0}'", grdListitem.Rows[cnt].Cells["cTrack"].Value.ToString()), String.Format("Id={0}", grdListitem.Rows[cnt].Cells["Id"].Value.ToString))

                cmd.CommandText = "UPDATE MasterItem SET EmpId=" + i + " WHERE " + string.Format("cTrack='{0}'", grdListitem.Rows[cnt].Cells["cTrack"].Value.ToString());
                db.Database.ExecuteSqlCommand(cmd.CommandText);
                if (i > 0)
                {
                    Fillgrid();
                    //fillcomb()
                }
            }
        }

        private void ShowNotification(string message)
        {
            if (ToasterNoty != null)
            {
                ToasterNoty.Close();
            }
            ToasterNoty = new Notification(this.Text, message, -1, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up);
            ToasterNoty.Show();
        }

        private void FindEmployeeBycTrack(string cTrack, int row)
        {
            if (string.IsNullOrEmpty(cTrack))
            {
                return;
            }
            using (EFDbContext db = new EFDbContext())
            {
                var data = db.Database.SqlQuery<EmployeeData>(string.Format("SELECT * FROM EmployeeDetails WHERE UserName='{0}'", cTrack)).ToList();
                if (data.Count != 0)
                {
                    if (grdListitem.Rows[row].Cells["EmpId"].Value is null || Convert.ToInt32(grdListitem.Rows[row].Cells["EmpId"].Value) == 0)
                    {
                        if (MessageBox.Show("We found existing employee detail based on Value you have entered, do you want to use that employee information?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            EmployeeData dr = data[0];
                            grdListitem.Rows[row].Cells["Address"].Value = dr.Address;
                            grdListitem.Rows[row].Cells["Mobile"].Value = dr.Mobile;
                            grdListitem.Rows[row].Cells["Designation"].Value = dr.Designation;
                            grdListitem.Rows[row].Cells["UserName"].Value = dr.UserName;
                            grdListitem.Rows[row].Cells["Password"].Value = dr.Password;
                            grdListitem.Rows[row].Cells["Emailaddress"].Value = dr.EmailAddress;
                            grdListitem.Rows[row].Cells["BillableRate"].Value = dr.BillableRate;
                            grdListitem.Rows[row].Cells["FirstName"].Value = dr.FirstName;
                            grdListitem.Rows[row].Cells["LastName"].Value = dr.LastName;
                            grdListitem.Rows[row].Cells["EmpId"].Value = dr.Id;
                        }
                    }
                }
            }
        }

        private void fillcomb()
        {
            try
            {
                //DataAccessLayer dl = new DataAccessLayer();
                //string query = "select distinct * from masterlist";
                //dt = dl.Filldatatable(query);
                //cmbGroup.DataSource = ds;
                //cmbGroup.DisplayMember = ds.Tables(0).Columns("cGroup").ToString();
                //cmbGroup.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}