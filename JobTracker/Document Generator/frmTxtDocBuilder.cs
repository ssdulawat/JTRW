using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
//using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using uno.util;
using unoidl.com.sun.star.awt;
using unoidl.com.sun.star.beans;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.uno;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using Exception = System.Exception;
using MessageBoxButtons = System.Windows.Forms.MessageBoxButtons;
using Word = Microsoft.Office.Interop.Word;

namespace JobTracker.Document_Generator
{
    public partial class frmTxtDocBuilder : Form
    {
        #region Declaration
        private System.Data.DataTable dtmasteritem = new System.Data.DataTable();
        private string CheckString;
        private static frmTxtDocBuilder _Instance;
        private List<KeywordContainer> KeywordCollection = new List<KeywordContainer>();
        #endregion
        public frmTxtDocBuilder()
        {
            InitializeComponent();
        }

        #region Events        
        private void frmTxtDocBuilder_Load(System.Object sender, System.EventArgs e)
        {
            FillCompanyData();
            FillContactsData();
            FillJobNumberData();
            FillTrackData();
            fillDocListItem();

            CreateColumnKeywordRef();
            buttonDecorationOn(btnInserContacts, false);
            buttonDecorationOn(btnInsertCompany, false);
            buttonDecorationOn(btnInserKeywordValue, false);
            VisibleCheckBoxCompany(false);
            VisibleCheckBoxContact(false);
            VisibleCheckBoxJobNumber(false);
            VisibleCheckBoxTypical(false);
        }

        private void jtTxtCompany_TxtJTTextChange()
        {
            FillCompanyData();
        }

        private void JtTxtContactsSearch_TxtJTTextChange()
        {
            FillContactsData();
        }

        private void JtTxtJobnumber_TxtJTTextChange()
        {
            FillJobNumberData();
        }

        private void jtTxtTrack_TxtJTTextChange()
        {
            FillTrackData();
        }

        private void grdListitem_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 3 && e.RowIndex > -1)
                {
                    grdListitem.Rows[e.RowIndex].Cells[3] = fillcolumncombo();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void grdListitem_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                chkGrdTypical.CheckedChanged -= chkGrdTypical_CheckedChanged;
                foreach (DataGridViewRow grdRow in grdListitem.Rows)
                {
                    if (grdRow.Index == e.RowIndex)
                    {
                        if ((bool)grdRow.Cells[chkTypicalGrid.Name].EditedFormattedValue == false)
                        {
                            chkGrdTypical.Checked = true;
                            break;
                        }
                        else
                        {
                            chkGrdTypical.Checked = false;
                        }
                    }
                    else
                    {
                        if ((bool)grdRow.Cells[chkTypicalGrid.Name].EditedFormattedValue == true)
                        {
                            chkGrdTypical.Checked = true;
                            break;
                        }
                    }
                }
                chkGrdTypical.CheckedChanged += chkGrdTypical_CheckedChanged;
            }

            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                try
                {
                    int ID = Convert.ToInt32(grdListitem.Rows[e.RowIndex].Cells["DocTypical_ID"].Value);
                    //Get id of DocTypical Category
                    string str = grdListitem.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                    List<SqlParameter> param1 = new List<SqlParameter>();
                    param1.Add(new SqlParameter("@CategoryName", str));

                    //Int32 queryDocCategoryID = StMethod.GetSingleInt("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'");

                    Int32 queryDocCategoryID;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        queryDocCategoryID = StMethod.GetSingleIntNew("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'");
                    }
                    else
                    {
                        queryDocCategoryID = StMethod.GetSingleInt("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'");
                    }

                    //******
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@DocTypical_Category", queryDocCategoryID));
                    Param.Add(new SqlParameter("@DocTypical_Text", grdListitem.Rows[e.RowIndex].Cells["DocTypical_Text"].Value.ToString()));
                    Param.Add(new SqlParameter("@ID", ID));
                    
                    //StMethod.UpdateRecord("UPDATE DocTypicalListItem SET DocTypical_Category=@DocTypical_Category,DocTypical_Text=@DocTypical_Text WHERE DocTypical_ID=@ID", Param);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        StMethod.UpdateRecordNew("UPDATE DocTypicalListItem SET DocTypical_Category=@DocTypical_Category,DocTypical_Text=@DocTypical_Text WHERE DocTypical_ID=@ID", Param);


                    }
                    else
                    {
                        StMethod.UpdateRecord("UPDATE DocTypicalListItem SET DocTypical_Category=@DocTypical_Category,DocTypical_Text=@DocTypical_Text WHERE DocTypical_ID=@ID", Param);

                    }


                    MessageBox.Show("Record updated.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                try
                {
                    if (MessageBox.Show("Are sure want to delete it?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int ID = (int)grdListitem.Rows[e.RowIndex].Cells["DocTypical_ID"].Value;
                        //StMethod.UpdateRecord("DELETE FROM DocTypicalListItem WHERE DocTypical_ID=" + ID);
                        //fillDocListItem();

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            StMethod.UpdateRecordNew("DELETE FROM DocTypicalListItem WHERE DocTypical_ID=" + ID);
                        }
                        else
                        {
                            StMethod.UpdateRecord("DELETE FROM DocTypicalListItem WHERE DocTypical_ID=" + ID);
                        }

                        fillDocListItem();
                    }

                   

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkGrdTypical_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkgrdCompany.Checked == true)
            {
                foreach (DataGridViewRow grdRow in grdCompany.Rows)
                {
                    grdRow.Cells[chkCompanyGrd.Name].Value = CheckState.Checked;
                }
            }
            else
            {
                foreach (DataGridViewRow grdRow in grdCompany.Rows)
                {
                    grdRow.Cells[chkCompanyGrd.Name].Value = CheckState.Unchecked;
                }
            }
        }

        private void rdbMSOffice_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            tooltipDocBuilder.RemoveAll();
            buttonDecorationOn(btnInserContacts, false);
            buttonDecorationOn(btnInsertCompany, false);
            buttonDecorationOn(btnInserKeywordValue, false);
            switch (cmbDocmentType.Text)
            {
                case "FAX  US Crane and Rigging":
                    //btnInsertCompany.t = "Fill data in document on basics of select current record in company grid and contacts grid"
                    if (rdbMSOffice.Checked == true)
                    {

                        tooltipDocBuilder.SetToolTip(btnInsertCompany, "Fill data into \"FAX  US Crane and Rigging document\" on basics of select current record." + "\r\n" + " Company Name and Address fill form Company grid and contacts detail fill from contacts grid.");
                        tooltipDocBuilder.SetToolTip(btnInserContacts, "Fill data into \"FAX  US Crane and Rigging document\" on basics of select current record." + "\r\n" + " Company Name and Address fill form Company grid and contacts detail fill from contacts grid.");
                        buttonDecorationOn(btnInserContacts, true);
                        buttonDecorationOn(btnInsertCompany, true);
                    }
                    else
                    {
                        buttonDecorationOn(btnInserContacts, true);
                        chkActiveCompanySelect.Checked = true;

                    }
                    break;
                case "Word Tax":
                case "Word Transmittal":
                    //If cmbDocmentType.Text = "Word Tax" Or cmbDocmentType.Text = "Word Transmittal" Then
                    buttonDecorationOn(btnInserContacts, true);
                    //Else
                    //buttonDecorationOn(btnInserContacts, False)
                    //End If
                    break;
                case "Standard Letter":
                    buttonDecorationOn(btnInserKeywordValue, true);
                    break;
            }

        }

        private void rdbOpenOffice_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            tooltipDocBuilder.RemoveAll();
            buttonDecorationOn(btnInserContacts, false);
            buttonDecorationOn(btnInsertCompany, false);
            buttonDecorationOn(btnInserKeywordValue, false);
            switch (cmbDocmentType.Text)
            {
                case "FAX  US Crane and Rigging":
                    //btnInsertCompany.t = "Fill data in document on basics of select current record in company grid and contacts grid"
                    if (rdbMSOffice.Checked == true)
                    {
                        tooltipDocBuilder.SetToolTip(btnInsertCompany, "Fill data into \"FAX  US Crane and Rigging document\" on basics of select current record." + "\r\n" + " Company Name and Address fill form Company grid and contacts detail fill from contacts grid.");
                        tooltipDocBuilder.SetToolTip(btnInserContacts, "Fill data into \"FAX  US Crane and Rigging document\" on basics of select current record." + "\r\n" + " Company Name and Address fill form Company grid and contacts detail fill from contacts grid.");
                        buttonDecorationOn(btnInserContacts, true);
                        buttonDecorationOn(btnInsertCompany, true);
                    }
                    else
                    {
                        buttonDecorationOn(btnInserContacts, true);
                        chkActiveCompanySelect.Checked = true;
                    }
                    break;
                case "Word Tax":
                case "Word Transmittal":
                    //If cmbDocmentType.Text = "Word Tax" Or cmbDocmentType.Text = "Word Transmittal" Then
                    buttonDecorationOn(btnInserContacts, true);
                    //Else
                    //buttonDecorationOn(btnInserContacts, False)
                    //End If
                    break;
                case "Standard Letter":
                    buttonDecorationOn(btnInserKeywordValue, true);
                    break;
            }

        }

        private void btnInsertDocTypicalText_Click(System.Object sender, System.EventArgs e)
        {
            if (btnInsertDocTypicalText.Text == "Insert")
            {
                btnInsertDocTypicalText.Text = "Save";
                DataTable data =(DataTable) grdListitem.DataSource;
                DataRow dr = data.NewRow();
                data.Rows.Add(dr);
                grdListitem.DataSource = data;
                if (grdListitem.Rows.Count > 0)
                {
                    grdListitem.Rows[grdListitem.Rows.Count - 1].Selected = true;
                    grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["DocTypical_Text"];
                }
            }
            else
            {
                try
                {
                    string str = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["CategoryName"].Value.ToString();
                    //Get id of DocTypical Category

                    //Int32 queryDocCategoryID = StMethod.GetSingleInt("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'");

                    Int32 queryDocCategoryID;
                    //******

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        queryDocCategoryID = StMethod.GetSingleIntNew("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'");
                    }
                    else
                    {
                        queryDocCategoryID = StMethod.GetSingleInt("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'");
                    }

                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@DocTypical_Category", queryDocCategoryID));
                    param.Add(new SqlParameter("@DocTypical_Text", grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["DocTypical_Text"].Value.ToString()));
                    
                    //StMethod.UpdateRecord("INSERT INTO DocTypicalListItem(DocTypical_Category,DocTypical_Text) VALUES(@DocTypical_Category,@DocTypical_Text)", param);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.UpdateRecordNew("INSERT INTO DocTypicalListItem(DocTypical_Category,DocTypical_Text) VALUES(@DocTypical_Category,@DocTypical_Text)", param);
                    }
                    else
                    {
                        StMethod.UpdateRecord("INSERT INTO DocTypicalListItem(DocTypical_Category,DocTypical_Text) VALUES(@DocTypical_Category,@DocTypical_Text)", param);
                    }

                    btnInsertDocTypicalText.Text = "Insert";
                    fillDocListItem();
                    MessageBox.Show("New record inserted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (grdListitem.Rows.Count > 0)
                    {
                        grdListitem.Rows[grdListitem.Rows.Count - 1].Selected = true;
                        grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["DocTypical_Text"];
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCanceDocTypicalText_Click(System.Object sender, System.EventArgs e)
        {
            btnInsertDocTypicalText.Text = "Insert";
            fillDocListItem();
        }

        private void btnInsertCompany_Click(System.Object sender, System.EventArgs e)
        {
            if (cmbDocmentType.Text == "FAX  US Crane and Rigging")
            {
                FAX_US_Crane_and_Rigging(sender);
            }

        }
        private void FAX_US_Crane_and_Rigging(System.Object sender)
        {
            try
            {
                Button clickButton = (Button)sender;
                //Word.Application WordApplication = Microsoft.VisualBasic.Interaction.GetObject("Word.Application");
                Word.Application WordApplication = (Microsoft.Office.Interop.Word.Application)Interaction.GetObject(null, "Word.Application");

                Word.Document WordDocument = WordApplication.ActiveDocument;
                Word.Tables docTables = WordDocument.Content.Tables;
                Word.Table d_table=null;
                foreach (Word.Table tbl in docTables)
                {
                    d_table = tbl;
                    break;
                }

                //Dim str As String = ""
                //For r As Integer = 0 To d_table.Rows.Count - 1
                //    For c As Integer = 0 To d_table.Columns.Count - 1
                //        str = str + "Cell(" & r & "," & c & ")= " & d_table.Cell(r, c).Range.Text
                //    Next
                //    str = str & vbCrLf
                //Next
                //MessageBox.Show(str)

                int Roindex = grdCompany.CurrentRow.Index;
                int cont_Rindex = grdContact.CurrentRow.Index;
                int tblRows = (d_table == null) ? 0 : d_table.Rows.Count;
                for (int r = 0; r < tblRows; r++)
                {
                    for (int c = 0; c < d_table.Columns.Count; c++)
                    {
                        if (clickButton.Name == btnInsertCompany.Name)
                        {
                            //company Name
                            if (r == 1 && c == 2)
                            {
                                d_table.Cell(r, c).Range.Text = grdCompany.Rows[Roindex].Cells["CompanyName"].Value.ToString();
                            }
                            //Address
                            if (r == 0 && c == 2)
                            {
                                d_table.Cell(r, c).Range.Text = grdCompany.Rows[Roindex].Cells["Address"].Value.ToString() + "," + grdCompany.Rows[Roindex].Cells["State"].Value.ToString();
                            }
                        }
                        if (clickButton.Name == btnInserContacts.Name)
                        {
                            //Fax no
                            if (r == 2 && c == 2)
                            {
                                d_table.Cell(r, c).Range.Text = grdContact.Rows[cont_Rindex].Cells["FaxNumber"].Value.ToString();
                            }
                            //Phone no
                            if (r == 3 && c == 2)
                            {
                                d_table.Cell(r, c).Range.Text = grdContact.Rows[cont_Rindex].Cells["WorkPhone"].Value.ToString();
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "Cannot create ActiveX component.")
                {
                    MSOffice_FAX_US_Crane_and_Rigging();
                }
                else
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void chkActiveCompanySelect_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            FillContactsData();
        }
        private void grdCompany_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (chkActiveCompanySelect.Checked == true)
            {
                FillContactsData();
            }

            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                chkgrdCompany.CheckedChanged -= chkgrdCompany_CheckedChanged;
                foreach (DataGridViewRow grdRow in grdCompany.Rows)
                {
                    if (grdRow.Index == e.RowIndex)
                    {
                        if ((bool)grdRow.Cells[chkCompanyGrd.Name].EditedFormattedValue == false)
                        {
                            chkgrdCompany.Checked = true;
                            break;
                        }
                        else
                        {
                            chkgrdCompany.Checked = false;
                        }
                    }
                    else
                    {
                        if ((bool)grdRow.Cells[chkCompanyGrd.Name].EditedFormattedValue == true)
                        {
                            chkgrdCompany.Checked = true;
                            break;
                        }
                    }
                }
                chkgrdCompany.CheckedChanged += chkgrdCompany_CheckedChanged;
            }
        }
        private void cmbDocmentType_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            tooltipDocBuilder.RemoveAll();
            buttonDecorationOn(btnInserContacts, false);
            buttonDecorationOn(btnInsertCompany, false);
            buttonDecorationOn(btnInserKeywordValue, false);
            VisibleCheckBoxCompany(false);
            VisibleCheckBoxContact(false);
            VisibleCheckBoxJobNumber(false);
            VisibleCheckBoxTypical(false);

            switch (cmbDocmentType.Text)
            {
                case "FAX  US Crane and Rigging":
                    //btnInsertCompany.t = "Fill data in document on basics of select current record in company grid and contacts grid"
                    if (rdbMSOffice.Checked == true)
                    {

                        tooltipDocBuilder.SetToolTip(btnInsertCompany, "Fill data into \"FAX  US Crane and Rigging document\" on basics of select current record." + "\r\n" + " Company Name and Address fill form Company grid and contacts detail fill from contacts grid.");
                        tooltipDocBuilder.SetToolTip(btnInserContacts, "Fill data into \"FAX  US Crane and Rigging document\" on basics of select current record." + "\r\n" + " Company Name and Address fill form Company grid and contacts detail fill from contacts grid.");
                        buttonDecorationOn(btnInserContacts, true);
                        buttonDecorationOn(btnInsertCompany, true);
                    }
                    else
                    {
                        buttonDecorationOn(btnInserContacts, true);
                        chkActiveCompanySelect.Checked = true;

                    }
                    break;
                case "Word Transmittal":

                    buttonDecorationOn(btnInserContacts, true);
                    VisibleCheckBoxCompany(false);
                    VisibleCheckBoxContact(false);
                    VisibleCheckBoxJobNumber(true);
                    VisibleCheckBoxTypical(false);

                    break;
                case "Word Tax":
                    buttonDecorationOn(btnInserContacts, true);
                    VisibleCheckBoxCompany(false);
                    VisibleCheckBoxContact(false);
                    VisibleCheckBoxJobNumber(false);
                    VisibleCheckBoxTypical(false);
                    break;
                case "Standard Letter":
                    buttonDecorationOn(btnInserKeywordValue, true);
                    VisibleCheckBoxCompany(true);
                    VisibleCheckBoxContact(true);
                    VisibleCheckBoxJobNumber(true);
                    VisibleCheckBoxTypical(true);
                    break;
            }


        }
        private void btnInserContacts_Click(System.Object sender, System.EventArgs e)
        {
            //MessageBox.Show(getOpenOfficeVersion())
            if (cmbDocmentType.Text == "FAX  US Crane and Rigging")
            {
                if (rdbMSOffice.Checked == true)
                {
                    FAX_US_Crane_and_Rigging(sender);
                }
                else
                {
                    OpenOffice_FAX_US_Crane_and_Rigging(btnInserContacts);
                }
            }
            if (cmbDocmentType.Text == "Word Tax")
            {
                if (rdbMSOffice.Checked == true)
                {
                    wordFAX();
                }
                else
                {
                    OpenOffice_WordFax();
                }
            }
            if (cmbDocmentType.Text == "Word Transmittal")
            {
                //CryWordTrasmittal()
                if (rdbMSOffice.Checked == true)
                {
                    WordTranmittal();
                }
                else
                {
                    OpenOffice_WordTransmittal();
                }
            }
        }
        private void grdCompany_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = grdCompany.HitTest(e.X, e.Y);
                if (info.RowIndex == -1 && info.ColumnIndex != -1)
                {
                    grdCompany.DoDragDrop("[Company_" + grdCompany.Columns[info.ColumnIndex].Name.ToString() + "]", DragDropEffects.Copy);
                }
            }
        }
        private void txtcompanyKeyword_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void txtcompanyKeyword_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                txtKeyword.Text = txtKeyword.Text + e.Data.GetData(DataFormats.StringFormat);
                txtKeyword.Select(txtKeyword.Text.Length - 1, txtKeyword.Text.Length);
            }
        }
        private void grdContact_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = grdContact.HitTest(e.X, e.Y);
                if (info.RowIndex == -1 && info.ColumnIndex != -1)
                {
                    grdContact.DoDragDrop("[Contact_" + grdContact.Columns[info.ColumnIndex].Name.ToString() + "]", DragDropEffects.Copy);
                }
            }
        }
        private void grdJobNumber_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = grdJobNumber.HitTest(e.X, e.Y);
                if (info.RowIndex == -1 && info.ColumnIndex != -1)
                {
                    grdJobNumber.DoDragDrop("[JobNo_" + grdJobNumber.Columns[info.ColumnIndex].Name.ToString() + "]", DragDropEffects.Copy);
                }
            }
        }
        private void grdTrackItem_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = grdTrackItem.HitTest(e.X, e.Y);
                if (info.RowIndex == -1 && info.ColumnIndex != -1)
                {
                    grdTrackItem.DoDragDrop("[Track_" + grdTrackItem.Columns[info.ColumnIndex].Name.ToString() + "]", DragDropEffects.Copy);
                }
            }
        }
        private void grdListitem_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = grdListitem.HitTest(e.X, e.Y);
                if (info.RowIndex == -1 && info.ColumnIndex != -1)
                {
                    grdListitem.DoDragDrop("[Typ_Text_" + grdListitem.Columns[info.ColumnIndex].Name.ToString() + "]", DragDropEffects.Copy);
                }
            }
        }
        private void btnInserKeywordValue_Click(System.Object sender, System.EventArgs e)
        {
            if (rdbMSOffice.Checked == true)
            {
                Standard_Letter();
            }
            else
            {
                OpenOffice_Standard_Letter();
            }
            //Try
            //    Dim WordApplication As Word.Application = CType(GetObject(, "Word.Application"), Word.Application)
            //    Dim WordDocument As Word.Document = WordApplication.ActiveDocument
            //    setCurrentSelectValue()
            //    For Each key_call As KeywordContainer In KeywordCollection
            //        If Not key_call.Value.Contains("^") Then
            //            WordDocument.Content.Find.Execute(FindText:=key_call.Keyword.ToString(), ReplaceWith:=key_call.Value.ToString(), Replace:=Word.WdReplace.wdReplaceAll)
            //        End If
            //    Next
            //Catch ex As System.Exception
            //    MessageBox.Show(ex.Message)
            //End Try
            //While WordDocument.Content.Find.Execute(FindText:="  ", Wrap:=Word.WdFindWrap.wdFindContinue)
            //    WordDocument.Content.Find.Execute(FindText:="  ", ReplaceWith:=" ", Replace:=Word.WdReplace.wdReplaceAll, Wrap:=Word.WdFindWrap.wdFindContinue)
            //End While
        }
        private void txtKeyword_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                txtKeyword.SelectAll();
            }
        }
        private void buttonDecorationOn(Button Button, bool decoration)
        {
            if (decoration)
            {
                Button.FlatAppearance.BorderColor = Color.Red;
                Button.FlatAppearance.BorderSize = 2;
                Button.Visible = true;
            }
            else
            {
                Button.FlatAppearance.BorderColor = Color.Black;
                Button.FlatAppearance.BorderSize = 1;
                Button.Visible = false;
            }

        }
        public void TransmittalTable_insertIntoCell(string sCellName, string sText, XTextTable xTable)
        {
            unoidl.com.sun.star.table.XCell xCell = xTable.getCellByName(sCellName);

            XPropertySet xcellProperties = (XPropertySet)xCell;
            IEnumerable<Property> objetQproperties = xcellProperties.getPropertySetInfo().getProperties().AsEnumerable();

            XSimpleText xSimpleTextCell = (XSimpleText)xCell;

            XTextCursor xCursor = xSimpleTextCell.createTextCursor();

            XPropertySet xPropertySetCursor = (XPropertySet)xCursor;

            switch (sCellName)
            {
                case "A1":
                case "B1":
                case "C1":
                    xPropertySetCursor.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(2)));
                    xPropertySetCursor.setPropertyValue("CharFontName", new uno.Any("Arial"));
                    xPropertySetCursor.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(9.5)));
                    xPropertySetCursor.setPropertyValue("CharWeight", new uno.Any(FontWeight.BOLD));
                    break;
                default:
                    xPropertySetCursor.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(2)));
                    xPropertySetCursor.setPropertyValue("CharFontName", new uno.Any("Arial"));
                    xPropertySetCursor.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(9.5)));
                    xPropertySetCursor.setPropertyValue("CharWeight", new uno.Any(FontWeight.NORMAL));
                    break;
            }
            //xPropertySetCursor.setPropertyValue("HoriOrient", New uno.Any(HoriOrientation.CENTER))
            //xPropertySetCursor.setPropertyValue("", New uno.Any(""))
            //xPropertySetCursor.setPropertyValue("CharColor", New uno.Any(&HFFFFFF))

            xSimpleTextCell.insertString(xCursor, sText, false);
        }
        private void chkgrdCompany_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkgrdCompany.Checked == true)
            {
                foreach (DataGridViewRow grdRow in grdCompany.Rows)
                {
                    grdRow.Cells[chkCompanyGrd.Name].Value = CheckState.Checked;
                }
            }
            else
            {
                foreach (DataGridViewRow grdRow in grdCompany.Rows)
                {
                    grdRow.Cells[chkCompanyGrd.Name].Value = CheckState.Unchecked;
                }
            }
        }
        private void chkGrdContacts_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkGrdContacts.Checked == true)
            {
                foreach (DataGridViewRow grdRow in grdContact.Rows)
                {
                    grdRow.Cells[chkContacts.Name].Value = CheckState.Checked;
                }
            }
            else
            {
                foreach (DataGridViewRow grdRow in grdContact.Rows)
                {
                    grdRow.Cells[chkContacts.Name].Value = CheckState.Unchecked;
                }
            }
        }
        private void chkGrdJobNumber_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkGrdJobNumber.Checked == true)
            {
                foreach (DataGridViewRow grdRow in grdJobNumber.Rows)
                {
                    grdRow.Cells[chkJobGrd.Name].Value = CheckState.Checked;
                }
            }
            else
            {
                foreach (DataGridViewRow grdRow in grdJobNumber.Rows)
                {
                    grdRow.Cells[chkJobGrd.Name].Value = CheckState.Unchecked;
                }
            }
        }
        private void grdContact_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                chkGrdContacts.CheckedChanged -= chkGrdContacts_CheckedChanged;
                foreach (DataGridViewRow grdRow in grdContact.Rows)
                {
                    if (grdRow.Index == e.RowIndex)
                    {
                        if ((bool)grdRow.Cells[chkContacts.Name].EditedFormattedValue == false)
                        {
                            chkGrdContacts.Checked = true;
                            break;
                        }
                        else
                        {
                            chkGrdContacts.Checked = false;
                        }
                    }
                    else
                    {
                        if ((bool)grdRow.Cells[chkContacts.Name].EditedFormattedValue == true)
                        {
                            chkGrdContacts.Checked = true;
                            break;
                        }
                    }
                }
                chkGrdContacts.CheckedChanged += chkGrdContacts_CheckedChanged;
            }
        }
        private void grdJobNumber_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                chkGrdJobNumber.CheckedChanged -= chkGrdJobNumber_CheckedChanged;
                foreach (DataGridViewRow grdRow in grdJobNumber.Rows)
                {
                    if (grdRow.Index == e.RowIndex)
                    {
                        if ((bool)grdRow.Cells[chkJobGrd.Name].EditedFormattedValue == false)
                        {
                            chkGrdJobNumber.Checked = true;
                            break;
                        }
                        else
                        {
                            chkGrdJobNumber.Checked = false;
                        }
                    }
                    else
                    {
                        if ((bool)grdRow.Cells[chkJobGrd.Name].EditedFormattedValue == true)
                        {
                            chkGrdJobNumber.Checked = true;
                            break;
                        }
                    }
                }
                chkGrdJobNumber.CheckedChanged += chkGrdJobNumber_CheckedChanged;
            }
        }
        #endregion

        #region Methods
        private void CreateColumnKeywordRef()
        {
            try
            {
                foreach (DataGridViewColumn col in grdCompany.Columns)
                {
                    KeywordCollection.Add(new KeywordContainer("[Company_" + col.Name + "]", col.Name));
                }
                foreach (DataGridViewColumn col in grdContact.Columns)
                {
                    KeywordCollection.Add(new KeywordContainer("[Contact_" + col.Name + "]", col.Name));
                }
                foreach (DataGridViewColumn col in grdJobNumber.Columns)
                {
                    KeywordCollection.Add(new KeywordContainer("[JobNo_" + col.Name + "]", col.Name));
                }
                foreach (DataGridViewColumn col in grdTrackItem.Columns)
                {
                    KeywordCollection.Add(new KeywordContainer("[Track_" + col.Name + "]", col.Name));
                }
                foreach (DataGridViewColumn col in grdListitem.Columns)
                {
                    // If col.Index Then
                    KeywordCollection.Add(new KeywordContainer("[Typ_Text_" + col.Name + "]", col.Name));
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void setCurrentSelectValue()
        {
            try
            {
                DataGridViewRow currentRow = grdCompany.CurrentRow;
                foreach (DataGridViewColumn col in grdCompany.Columns)
                {
                    string Key = "[Company_" + col.Name + "]";
                    KeywordContainer companyData = KeywordCollection.Where((k) => k.Keyword == Key).FirstOrDefault();
                    companyData.Value = currentRow.Cells[col.Name].Value.ToString();
                }
                currentRow = grdContact.CurrentRow;
                foreach (DataGridViewColumn col in grdContact.Columns)
                {
                    string Key = "[Contact_" + col.Name + "]";
                    KeywordContainer ContactsData = KeywordCollection.Where((k) => k.Keyword == Key).FirstOrDefault();
                    ContactsData.Value = currentRow.Cells[col.Name].Value.ToString();
                }
                currentRow = grdJobNumber.CurrentRow;
                foreach (DataGridViewColumn col in grdJobNumber.Columns)
                {
                    string Key = "[JobNo_" + col.Name + "]";
                    KeywordContainer JobData = KeywordCollection.Where((k) => k.Keyword == Key).FirstOrDefault();
                    JobData.Value = currentRow.Cells[col.Name].Value.ToString();
                }
                currentRow = grdTrackItem.CurrentRow;
                foreach (DataGridViewColumn col in grdTrackItem.Columns)
                {
                    string Key = "[Track_" + col.Name + "]";
                    KeywordContainer TrackData = KeywordCollection.Where((k) => k.Keyword == Key).FirstOrDefault();
                    TrackData.Value = currentRow.Cells[col.Name].Value.ToString();
                }
                currentRow = grdListitem.CurrentRow;
                foreach (DataGridViewColumn col in grdListitem.Columns)
                {
                    string Key = "[Typ_Text_" + col.Name + "]";
                    KeywordContainer Typl_Data = KeywordCollection.Where((k) => k.Keyword == Key).FirstOrDefault();
                    Typl_Data.Value = currentRow.Cells[col.Name].Value.ToString();
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        private DataGridViewComboBoxCell fillcolumncombo()
        {
            try
            {
                var query = "SELECT CategoryName FROM DocTypicalCategoryList";
                DataGridViewComboBoxCell columnComboBox = new DataGridViewComboBoxCell();

                //var list = StMethod.GetList<string>(query);

                var list = StMethod.GetList<string>(query);
                list = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    list = StMethod.GetListNew<string>(query);
                }
                else
                {
                    list = StMethod.GetList<string>(query);
                }


                foreach (var item in list)                
                {
                    columnComboBox.Items.Add(item);
                }
                return columnComboBox;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        private void fillDocListItem()
        {
            try
            {
                //VariousInfo = New VariousInfoEntities()
                
                string Query = "SELECT DocTypicalCategoryList.CategoryName, DocTypicalListItem.DocTypical_ID, DocTypicalListItem.DocTypical_Text, DocTypicalListItem.DocTypical_Category FROM DocTypicalCategoryList INNER JOIN DocTypicalListItem ON DocTypicalCategoryList.TypeCategoryID = DocTypicalListItem.DocTypical_Category"; //From a In VariousInfo.DocTypicalListItems Select a
                                                                                                                                                                                                                                                                                                                                                                //DAL = New DataAccessLayer

                //grdListitem.DataSource = StMethod.GetListDT<DocTypeData>(Query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    grdListitem.DataSource = StMethod.GetListDTNew<DocTypeData>(Query);
                }
                else
                {
                    grdListitem.DataSource = StMethod.GetListDT<DocTypeData>(Query);
                }

                grdListitem.Columns["DocTypical_Category"].HeaderText = "Type Category";
                grdListitem.Columns["DocTypical_ID"].Visible = false;
                grdListitem.Columns["DocTypical_Text"].HeaderText = "Typical Text";
                grdListitem.Columns["DocTypical_Category"].Visible = false;
                grdListitem.Columns["DocTypical_Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdListitem.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillCompanyData()
        {
            string Query = "SELECT Company.CompanyID, Company.CompanyName, Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode,Company.DotInsuranceExp,Company.AirborneExpNUM,Company.IBMNUM, Company.FedExNUM, Company.UserName, Company.Password FROM Company  WHERE Company.CompanyID > 0 and (Company.IsDelete=0 or Company.IsDelete is null) ";
            if (jtTxtCompany.txtJT.Text.Trim() != jtTxtCompany.TextBoxLable)
            {
                Query = Query + " AND CompanyName LIKE '%" + jtTxtCompany.txtJT.Text + "%'";
            }

            //grdCompany.DataSource = StMethod.GetListDT<CompanyUsers>(Query);


            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                grdCompany.DataSource = StMethod.GetListDTNew<CompanyUsers>(Query);
            }
            else
            {
                grdCompany.DataSource = StMethod.GetListDT<CompanyUsers>(Query);
            }


            grdCompany.Columns["CompanyID"].Visible = false;
        }
        private void FillContactsData()
        {
            string Query = "SELECT ContactsID, CompanyID,FirstName , MiddleName , LastName, (FirstName +' '+ MiddleName +' '+ LastName) as ContactName , ContactTitle,Address, City,State, PostalCode,  Country, MobilePhone, EmailAddress, Notes, SpecialRiggerNUM, MasterRiggerNUM,  SpecialSignNUM, MasterSignNUM, Prefix, Suffix,  HomePhone, WorkPhone, FaxNumber, AlternativePhone, FieldPhone,  Pager ,Accounting FROM  Contacts WHERE (IsDelete=0 or IsDelete is null) ";
            if (JtTxtContactsSearch.txtJT.Text.Trim() != JtTxtContactsSearch.TextBoxLable)
            {
                Query = Query + " AND (FirstName+' '+ MiddleName +' '+ LastName) Like '%" + JtTxtContactsSearch.txtJT.Text + "%'";
            }
            if (chkActiveCompanySelect.Checked == true)
            {
                Query = Query + " AND CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();
            }

            //grdContact.DataSource = StMethod.GetListDT<CompanyData>(Query);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                grdContact.DataSource = StMethod.GetListDTNew<CompanyData>(Query);
            }
            else
            {
                grdContact.DataSource = StMethod.GetListDT<CompanyData>(Query);
            }

            grdContact.Columns["CompanyID"].Visible = false;
            grdContact.Columns["ContactsID"].Visible = false;

        }
        private void FillJobNumberData()
        {
            string Query = "SELECT DISTINCT JobList.JobListID, JobList.JobNumber, Company.CompanyID, JobList.DateAdded, JobList.Description, JobList.Handler, JobList.Borough, JobList.Address,      Contacts.FirstName + ' ' + Contacts.MiddleName + ' ' + Contacts.LastName AS Contacts, Contacts.EmailAddress, Contacts.ContactsID,   Company.CompanyName,JobList.ACContacts,JobList.ACEmail,JobList.OwnerName,JobList.OwnerAddress,JobList.OwnerPhone,JobList.OwnerFax,Company.CompanyNo FROM  JobList LEFT OUTER JOIN            Contacts ON JobList.ContactsID = Contacts.ContactsID LEFT OUTER JOIN      Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN        JobTracking ON JobList.JobListID = JobTracking.JobListID     WHERE (JobList.IsDelete=0 or JobList.IsDelete is null) ";

            if (JtTxtJobnumber.txtJT.Text.Trim() != JtTxtJobnumber.TextBoxLable)
            {
                Query = Query + " AND JobNumber Like '%" + JtTxtJobnumber.txtJT.Text + "%'";
            }


            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                grdJobNumber.DataSource = StMethod.GetListDTNew<JobNumberData>(Query);
            }
            else
            {
                grdJobNumber.DataSource = StMethod.GetListDT<JobNumberData>(Query);
            }

            //grdJobNumber.DataSource = StMethod.GetListDT<JobNumberData>(Query);
            grdJobNumber.Columns["JobListID"].Visible = false;
            grdJobNumber.Columns["CompanyID"].Visible = false;
            grdJobNumber.Columns["ContactsID"].Visible = false;
        }
        private void FillTrackData()
        {
            string Query = "SELECT Id, TrackSet, TrackName FROM MasterTrackSet WHERE (MasterTrackSet.IsDelete=0 or MasterTrackSet.IsDelete is null) ";

            if (jtTxtTrack.txtJT.Text.Trim() != jtTxtTrack.TextBoxLable)
            {
                Query = Query + " AND TrackName Like '%" + jtTxtTrack.txtJT.Text + "%'";
            }
            
            //grdTrackItem.DataSource = StMethod.GetListDT<MasterTrackSetData>(Query);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                grdTrackItem.DataSource = StMethod.GetListDTNew<MasterTrackSetData>(Query);
            }
            else
            {
                grdTrackItem.DataSource = StMethod.GetListDT<MasterTrackSetData>(Query);
            }

            grdTrackItem.Columns["Id"].Visible = false;
        }
        private void wordFAX()
        {
            try
            {
                if (grdContact.Rows.Count == 0)
                {
                    MessageBox.Show("First Select Contact Name");
                    return;
                }
                Word.Application WordFax = null;
                Word.Document WordDoc = null;
                WordFax = (Word.Application)System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Word.Application"));
                WordDoc = WordFax.Documents.Add();
                WordFax.Visible = true;
                WordFax.Activate();
                Word.Range HeaderRang = WordDoc.Paragraphs.Add().Range;
                HeaderRang.InlineShapes.AddPicture(Application.StartupPath + "\\Header.Jpg");
                //WordDoc.SaveAs(Application.StartupPath + "\Word.doc")
                Word.Range FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial Black";
                FAXtext.Font.Size = float.Parse( "54");
                FAXtext.Font.Bold =1;
                FAXtext.InsertBefore("Fax");
                Word.Table insertTable = WordDoc.Tables.Add(WordDoc.Words.Last, 4, 4);
                insertTable.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto;
                //.PreferredWidth = 91.5
                insertTable.LeftPadding = 18;
                insertTable.AllowAutoFit = true;
                for (int i = 1; i <= 4; i++)
                {
                    insertTable.Cell(i, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    insertTable.Cell(i, 1).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 1).PreferredWidth = 12;
                    insertTable.Cell(i, 1).Range.Font.Name = "Arial Black";
                    insertTable.Cell(i, 1).Range.Font.Size = float.Parse("10");
                    insertTable.Cell(i, 3).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 3).PreferredWidth = 12;
                    insertTable.Cell(i, 3).Range.Font.Name = "Arial Black";
                    insertTable.Cell(i, 3).Range.Font.Size = float.Parse( "10");
                    insertTable.Cell(i, 2).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 2).PreferredWidth = 40;
                    insertTable.Cell(i, 4).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 4).PreferredWidth = 40;
                }
                insertTable.Cell(1, 1).Range.Text = "To:";
                insertTable.Cell(1, 2).Range.Text = grdContact.Rows[grdContact.CurrentRow.Index].Cells["FirstName"].Value.ToString() + " " + grdContact.Rows[grdContact.CurrentRow.Index].Cells["LastName"].Value.ToString();
                insertTable.Cell(2, 1).Range.Text = "Fax:";
                insertTable.Cell(2, 2).Range.Text = grdContact.Rows[grdContact.CurrentRow.Index].Cells["FaxNumber"].Value.ToString();
                insertTable.Cell(3, 1).Range.Text = "Phone:";
                insertTable.Cell(3, 2).Range.Text = grdContact.Rows[grdContact.CurrentRow.Index].Cells["MobilePhone"].Value.ToString();
                insertTable.Cell(4, 1).Range.Text = "Re:";
                insertTable.Cell(1, 3).Range.Text = "From:";
                insertTable.Cell(1, 4).Range.Text = "Steve Valjato";
                insertTable.Cell(2, 3).Range.Text = "Pages:";
                insertTable.Cell(2, 4).Range.Text = "1 (including this cover sheet)";
                insertTable.Cell(3, 3).Range.Text = "Date:";
                insertTable.Cell(3, 4).Range.Text = DateTime.Now.ToString("D", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                insertTable.Cell(4, 3).Range.Text = "CC:";
                //.Range.Select()
                //.Tables.Item(1).Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter
                // WordDoc.Tables.Item(1).Select()
                WordDoc.Tables[1].Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
                //Dim par As Word.Paragraph = WordDoc.LastParagraph
                Word.FormField WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                WordcheckBox.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore("\r");
                FAXtext.InsertAfter("Urgent");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("For Review");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Please Comment");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Please Reply");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("For your use");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("As Requested");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r");
                FAXtext.InlineShapes.AddHorizontalLineStandard(WordDoc.Words.Last);
                FAXtext.InsertBefore("\r");
                FAXtext = WordDoc.Paragraphs.Add().Range;
                WordDoc.Paragraphs.Add(FAXtext).Range.ListFormat.ApplyBulletDefault(Word.WdBuiltinStyle.wdStyleListBullet2);
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyMed;
                //.ListFormat.ApplyBulletDefault(Word.WdBuiltinStyle.wdStyleListContinue2)
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("10");
                FAXtext.Font.Bold = 1;
                FAXtext.InsertBefore("Comments:");
                //.Select()
                //Dim SaveExportLocation As New SaveFileDialog
                //SaveExportLocation.Filter = "DOC|*.doc"
                //If SaveExportLocation.ShowDialog = DialogResult.OK Then
                //    WordFax.ChangeFileOpenDirectory(SaveExportLocation.FileName)
                //    WordDoc.Save
                //    WordDoc.Close()
                //    WordDoc = Nothing
                //    WordFax = Nothing
                //    Shell(SaveExportLocation.FileName, AppWinStyle.Hide)
                //End If
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WordTranmittal()
        {
            try
            {
                if (grdContact.Rows.Count == 0)
                {
                    MessageBox.Show("First Select Contact Name");
                    return;
                }
                Word.Application WordFax = null;
                Word.Document WordDoc = null;
                WordFax = (Word.Application)System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Word.Application"));
                WordDoc = WordFax.Documents.Add();
                WordFax.Visible = true;
                WordFax.Activate();
                Word.Range HeaderRang = WordDoc.Paragraphs.Add().Range;
                HeaderRang.InlineShapes.AddPicture(Application.StartupPath + "\\Header.Jpg");
                //WordDoc.SaveAs(Application.StartupPath + "\Word.doc")

                Word.Range FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n");

                FAXtext = WordDoc.Paragraphs.Add().Range;

                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial Black";
                FAXtext.Font.Size = float.Parse("13");
                FAXtext.Font.Bold = 1;
                FAXtext.InsertBefore("TRANSMITTAL");

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n");
                string Str_ContDate = grdContact.Rows[grdContact.CurrentRow.Index].Cells["ContactName"].Value.ToString() + "\t" + "\t" + "\t" + "\t" + "\t" + "DATE: " + DateTime.Now.ToString("MM/dd/yy");
                Word.Range PrintAttention = WordDoc.Paragraphs.Add().Range;
                PrintAttention.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                PrintAttention.Font.Name = "Arial";
                PrintAttention.Font.Size = float.Parse("11");
                PrintAttention.Font.Bold = 1;
                PrintAttention.Font.Underline =Word.WdUnderline.wdUnderlineSingle;
                PrintAttention.InsertBefore("ATTENTION: " + Str_ContDate);
                //.InsertAfter(Str_ContDate)

                Word.Range editFormat = WordDoc.Range(PrintAttention.End - (Str_ContDate.Length + 1), PrintAttention.End);
                editFormat.Font.Bold = 0;
                editFormat.Font.Underline = 0;
                editFormat.Font.Name = "Arial";
                editFormat.Font.Size = float.Parse("9.5");
                editFormat.Find.MatchCase = true;
                editFormat.Find.Text = "DATE:";
                editFormat.Find.ClearFormatting();
                editFormat.Find.Replacement.ClearFormatting();
                editFormat.Find.Replacement.Font.Bold = 1;
                editFormat.Find.Replacement.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
                editFormat.Find.Replacement.Font.Name = "Arial";
                editFormat.Find.Replacement.Font.Size = float.Parse("11");
                editFormat.Find.Execute(Replace: Word.WdReplace.wdReplaceAll);

                //FAXtext = WordDoc.Paragraphs.Add.Range
                //With FAXtext
                //    .InsertBefore(vbCrLf)
                //End With

                Word.Range CompanyAddress = WordDoc.Paragraphs.Add().Range;
                string Address = null;
                Address = "\r\n" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyName"].Value.ToString() + "\r\n" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["Address"].Value.ToString() + "," + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["City"].Value.ToString() + "\r\n" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["State"].Value.ToString() + "," + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["Country"].Value.ToString() + "," + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["PostalCode"].Value.ToString();

                //.InsertBefore(vbCrLf)
                CompanyAddress.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                CompanyAddress.Font.Name = "Arial";
                CompanyAddress.Font.Size = float.Parse("9.5");
                CompanyAddress.Font.Bold = 1;
                CompanyAddress.InsertBefore(Address);
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n" + "\r\n" + "\r\n");
                Word.Range InserREstr = WordDoc.Paragraphs.Add().Range;

                InserREstr.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                InserREstr.Font.Name = "Arial";
                InserREstr.Font.Size = float.Parse("11");
                InserREstr.Font.Bold = 1;
                InserREstr.InsertBefore("RE:");

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InlineShapes.AddHorizontalLineStandard(WordDoc.Words.Last);
                //Dim par As Word.Paragraph = WordDoc.LastParagraph
                Word.FormField WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                WordcheckBox.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Urgent");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9.5");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("For Review");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Please Comment");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Please Reply");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("For your use");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("As Requested");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InlineShapes.AddHorizontalLineStandard(WordDoc.Words.Last);
                FAXtext.InsertBefore("\r\n");

                FAXtext = WordDoc.Paragraphs.Add().Range;
                WordDoc.Paragraphs.Add(FAXtext).Range.ListFormat.ApplyBulletDefault(Word.WdBuiltinStyle.wdStyleListBullet2);
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyMed;
                //.ListFormat.ApplyBulletDefault(Word.WdBuiltinStyle.wdStyleListContinue2)
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("10");
                FAXtext.Font.Bold = 1;
                FAXtext.InsertBefore("Comments:");

                //.Select()
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n");
                Word.Table insertTable = WordDoc.Tables.Add(WordDoc.Words.Last, 9, 3);
                insertTable.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto;
                //.PreferredWidth = 91.5
                insertTable.LeftPadding = 18;
                insertTable.AllowAutoFit = true;
                for (int i = 1; i <= 3; i++)
                {
                    insertTable.Cell(i, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    insertTable.Cell(i, 1).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 1).PreferredWidth = 12;
                    insertTable.Cell(i, 1).Range.Font.Name = "Arial";
                    insertTable.Cell(i, 1).Range.Font.Size = float.Parse("9.5");
                    insertTable.Cell(i, 2).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 2).PreferredWidth = 12;
                    insertTable.Cell(i, 2).Range.Font.Name = "Arial";
                    insertTable.Cell(i, 2).Range.Font.Size = float.Parse("9.5");
                    insertTable.Cell(i, 3).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                }
                insertTable.Cell(1, 1).Range.Text = "JOB #:";
                insertTable.Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyMed;
                insertTable.Cell(1, 2).Range.Text = "COPIES:";
                insertTable.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyMed;
                insertTable.Cell(1, 3).Range.Text = "DESCRIPTION:";
                insertTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyMed;
                WordDoc.Tables[1].Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n");

                FAXtext = WordDoc.Paragraphs.Add().Range;

                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("11");
                FAXtext.InsertBefore("Please call if the enclosed package is incomplete.");
                string LineStr = "___________" + "\r\n" + "Steve Valjato";
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("11");
                FAXtext.InsertBefore(LineStr);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Standard_Letter()
        {
            try
            {
                Word.Application WordFax = null;
                Word.Document WordDoc = null;
                WordFax = (Word.Application)System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Word.Application"));
                WordDoc = WordFax.Documents.Add();
                WordFax.Visible = true;
                WordFax.Activate();
                Word.Range HeaderRang = WordDoc.Paragraphs.Add().Range;
                HeaderRang.InlineShapes.AddPicture(Application.StartupPath + "\\Header.Jpg");

                Word.Range FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n");

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Times New Roman";
                FAXtext.Font.Size = float.Parse("12");
                FAXtext.InsertBefore(DateTime.Now.ToString("MMM dd,yyyy"));

                //FAXtext = WordDoc.Paragraphs.Add.Range
                //With FAXtext
                //    .InsertBefore(vbCrLf)
                //End With

                string Contact = null;
                foreach (DataGridViewRow selectedDR in grdCompany.Rows)
                {
                    if ((bool)selectedDR.Cells[chkCompanyGrd.Name].EditedFormattedValue == true)
                    {

                        Contact = "\r\n" + selectedDR.Cells["CompanyName"].Value.ToString() + "\r\n" + selectedDR.Cells["Address"].Value.ToString() + "," + selectedDR.Cells["City"].Value.ToString() + "\r\n" + selectedDR.Cells["State"].Value.ToString() + "," + selectedDR.Cells["Country"].Value.ToString() + "," + selectedDR.Cells["PostalCode"].Value.ToString();
                        FAXtext = WordDoc.Paragraphs.Add().Range;
                        FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        FAXtext.Font.Name = "Arial";
                        FAXtext.Font.Size = float.Parse("12");
                        FAXtext.InsertBefore(Contact);
                    }
                }


                string JobDescription = null;
                foreach (DataGridViewRow selectedDR in grdJobNumber.Rows)
                {
                    if ((bool)selectedDR.Cells[chkJobGrd.Name].EditedFormattedValue == true)
                    {

                        JobDescription = "\r\n" + selectedDR.Cells["JobNumber"].Value.ToString() + " , " + selectedDR.Cells["Address"].Value.ToString() + "," + selectedDR.Cells["Description"].Value.ToString();
                        FAXtext = WordDoc.Paragraphs.Add().Range;
                        FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        FAXtext.Font.Name = "Arial";
                        FAXtext.Font.Size = float.Parse("12");
                        FAXtext.InsertBefore(JobDescription);

                    }
                }

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n" + "\r\n");

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("12");
                FAXtext.InsertBefore("Dear Mr. Rasheed:");

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n" + "\r\n");

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("12");
                FAXtext.InsertBefore("In response to your objections dated 04/14/12:");

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r\n" + "\r\n");

                foreach (DataGridViewRow selectedDR in grdListitem.Rows)
                {
                    if ((bool)selectedDR.Cells[chkTypicalGrid.Name].EditedFormattedValue == true)
                    {
                        FAXtext = WordDoc.Paragraphs.Add().Range;
                        FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        FAXtext.Font.Name = "Arial";
                        FAXtext.Font.Size = float.Parse("12");
                        FAXtext.InsertBefore("\r\n" + selectedDR.Cells["DocTypical_Text"].Value.ToString());
                    }
                }

                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("12");
                FAXtext.InsertBefore("\r\n" + "\r\n" + "\r\n" + "Please do not hesitate to call with any questions or comments." + "\r\n" + "\r\n" + "Sincerely," + "\r\n" + "Steve Valjato P.E.");

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenOffice_Standard_Letter()
        {
            try
            {
                XComponentContext xContext = Bootstrap.bootstrap();
                XMultiServiceFactory xFactory = (XMultiServiceFactory)xContext.getServiceManager();

                //Create the Desktop
                unoidl.com.sun.star.frame.XDesktop xDesktop = (unoidl.com.sun.star.frame.XDesktop)xFactory.createInstance("com.sun.star.frame.Desktop");

                //Open a new empty writer document
                unoidl.com.sun.star.frame.XComponentLoader xComponentLoader = (unoidl.com.sun.star.frame.XComponentLoader)xDesktop;
                PropertyValue[] arProps = new PropertyValue[0];
                unoidl.com.sun.star.lang.XComponent xComponent = xComponentLoader.loadComponentFromURL("private:factory/swriter", "_blank", 0, arProps);
                XTextDocument xTextDocument = (XTextDocument)xComponent;

                //Create a text object
                XText xText = xTextDocument.getText();

                XSimpleText xSimpleText = (XSimpleText)xText;

                //Insert Image
                //Create a cursor object
                XTextCursor xCursor = xSimpleText.createTextCursor();

                //Create a GraphicObject. 
                object objGraphicObject = ((unoidl.com.sun.star.lang.XMultiServiceFactory)xComponent).createInstance("com.sun.star.text.GraphicObject");

                XTextContent xGraphicObject = (XTextContent)objGraphicObject;

                //Set the size of the GraphicObject 
                unoidl.com.sun.star.awt.Size GraphicObjectSize = new unoidl.com.sun.star.awt.Size(15000, 3000);
                ((unoidl.com.sun.star.drawing.XShape)xGraphicObject).setSize(GraphicObjectSize);

                //Set anchortype 
                XPropertySet xPropertySetGraphicObject = (XPropertySet)xGraphicObject;
                xPropertySetGraphicObject.setPropertyValue("AnchorType", new uno.Any(typeof(TextContentAnchorType), TextContentAnchorType.AS_CHARACTER));
                //Set Left margin of image
                xPropertySetGraphicObject.setPropertyValue("LeftMargin", new uno.Any(1282));
                //Set Picture path: 
                //First Method with OOO notation for Windows Notation see PathConverter method 
                string path = "file:///" + Application.StartupPath + "\\Header.Jpg";
                xPropertySetGraphicObject.setPropertyValue("GraphicURL", new uno.Any(path));

                //insert the GraphicObject 
                xText.insertTextContent(xCursor, xGraphicObject, false);

                //Insert Today date
                //Create a cursor object
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                string DateStr = DateTime.Now.ToString("MMM dd,yyyy");
                XPropertySet xProperties_dateStr = (XPropertySet)xCursor;
                xProperties_dateStr.setPropertyValue("CharFontName", new uno.Any("Times New Roman"));
                xText.insertString(xCursor, "\r\n" + DateStr, false);

                xProperties_dateStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                //xProperties_dateStr.setPropertyValue("CharScaleWidth", New uno.Any(Convert.ToInt16(12)))

                //Inser contact
                string Contact = null;
                foreach (DataGridViewRow selectedDR in grdCompany.Rows)
                {
                    if ((bool)selectedDR.Cells[chkCompanyGrd.Name].EditedFormattedValue == true)
                    {
                        Contact = "\r" + selectedDR.Cells["CompanyName"].Value.ToString() + "\r" + selectedDR.Cells["Address"].Value.ToString() + "," + selectedDR.Cells["City"].Value.ToString() + "\r" + selectedDR.Cells["State"].Value.ToString() + "," + selectedDR.Cells["Country"].Value.ToString() + "," + selectedDR.Cells["PostalCode"].Value.ToString();
                        xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                        xText.insertString(xCursor, Contact, false);
                    }
                }



                string JobDescription = null;
                foreach (DataGridViewRow selectedDR in grdJobNumber.Rows)
                {
                    if ((bool)selectedDR.Cells[chkJobGrd.Name].EditedFormattedValue == true)
                    {
                        JobDescription = "\r" + selectedDR.Cells["JobNumber"].Value.ToString() + " , " + selectedDR.Cells["Address"].Value.ToString() + "," + selectedDR.Cells["Description"].Value.ToString();
                        xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                        xText.insertString(xCursor, JobDescription, false);
                    }
                }

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xText.insertString(xCursor, "\r" + "\r", false);

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xText.insertString(xCursor, "Dear Mr. Rasheed:", false);

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xText.insertString(xCursor, "\r" + "\r", false);

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xText.insertString(xCursor, "In response to your objections dated 04/14/12:", false);

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xText.insertString(xCursor, "\r" + "\r", false);


                foreach (DataGridViewRow selectedDR in grdListitem.Rows)
                {
                    if ((bool)selectedDR.Cells[chkTypicalGrid.Name].EditedFormattedValue == true)
                    {
                        xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                        xText.insertString(xCursor, "\r" + selectedDR.Cells["DocTypical_Text"].Value.ToString(), false);
                    }
                }

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xText.insertString(xCursor, "\r" + "\r" + "\r" + "Please do not hesitate to call with any questions or comments." + "\r" + "\r" + "Sincerely," + "\r\n" + "Steve Valjato P.E.", false);

            }
            catch (unoidl.com.sun.star.configuration.InvalidBootstrapFileException bootStrapExp)
            {
                MessageBox.Show(bootStrapExp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (unoidl.com.sun.star.configuration.MissingBootstrapFileException bootstrapMissig)
            {
                MessageBox.Show(bootstrapMissig.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenOffice_FAX_US_Crane_and_Rigging(System.Object sender)
        {
            try
            {
                XComponentContext xContext = Bootstrap.bootstrap();
                XMultiServiceFactory xFactory = (XMultiServiceFactory)xContext.getServiceManager();

                //Create the Desktop
                unoidl.com.sun.star.frame.XDesktop xDesktop = (unoidl.com.sun.star.frame.XDesktop)xFactory.createInstance("com.sun.star.frame.Desktop");

                //Open a new empty writer document
                unoidl.com.sun.star.frame.XComponentLoader xComponentLoader = (unoidl.com.sun.star.frame.XComponentLoader)xDesktop;
                PropertyValue[] arProps = new PropertyValue[0];
                unoidl.com.sun.star.lang.XComponent xComponent = xComponentLoader.loadComponentFromURL("private:factory/swriter", "_blank", 0, arProps);
                XTextDocument xTextDocument = (XTextDocument)xComponent;

                //Create a text object
                XText xText = xTextDocument.getText();

                XSimpleText xSimpleText = (XSimpleText)xText;

                //Insert Image
                //Create a cursor object
                XTextCursor xCursor = xSimpleText.createTextCursor();

                //Create a GraphicObject. 
                object objGraphicObject = ((unoidl.com.sun.star.lang.XMultiServiceFactory)xComponent).createInstance("com.sun.star.text.GraphicObject");

                XTextContent xGraphicObject = (XTextContent)objGraphicObject;

                //Set the size of the GraphicObject 
                unoidl.com.sun.star.awt.Size GraphicObjectSize = new unoidl.com.sun.star.awt.Size(15000, 3000);
                ((unoidl.com.sun.star.drawing.XShape)xGraphicObject).setSize(GraphicObjectSize);

                //Set anchortype 
                XPropertySet xPropertySetGraphicObject = (XPropertySet)xGraphicObject;
                xPropertySetGraphicObject.setPropertyValue("AnchorType", new uno.Any(typeof(TextContentAnchorType), TextContentAnchorType.AS_CHARACTER));
                //Set Left margin of image
                xPropertySetGraphicObject.setPropertyValue("LeftMargin", new uno.Any(1282));
                //Set Picture path: 
                //First Method with OOO notation for Windows Notation see PathConverter method 
                string path = "file:///" + Application.StartupPath + "\\Header.Jpg";
                xPropertySetGraphicObject.setPropertyValue("GraphicURL", new uno.Any(path));

                //insert the GraphicObject 
                xText.insertTextContent(xCursor, xGraphicObject, false);

                //Insert Today date
                //Create a cursor object
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                string DateStr = "Fax";
                XPropertySet xProperties_FaxStr = (XPropertySet)xCursor;
                uno.Any charWidth;
                uno.Any charHeight;
                charWidth = xProperties_FaxStr.getPropertyValue("CharScaleWidth");
                charHeight = xProperties_FaxStr.getPropertyValue("CharHeight");
                xProperties_FaxStr.setPropertyValue("CharFontName", new uno.Any("Arial Black"));
                xProperties_FaxStr.setPropertyValue("CharScaleWidth", new uno.Any(Convert.ToInt16(53)));
                xProperties_FaxStr.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(53)));
                xText.insertString(xCursor, DateStr, false);
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xProperties_FaxStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_FaxStr.setPropertyValue("CharScaleWidth", charWidth);
                xProperties_FaxStr.setPropertyValue("CharHeight", charHeight);

                //Create instance of a text table with 4 columns and 4 rows
                object objTextTable = ((unoidl.com.sun.star.lang.XMultiServiceFactory)xTextDocument).createInstance("com.sun.star.text.TextTable");
                XTextTable xTextTable = (XTextTable)objTextTable;
                XPropertySet Table_Properties = (XPropertySet)xTextTable;
                //Dim objetQproperties As IEnumerable(Of Property) = Table_Properties.getPropertySetInfo().getProperties().AsEnumerable()
                //Table_Properties.setPropertyValue("LeftMargin", New uno.Any(Convert.ToInt32(1480)))
                TableColumnSeparator[] xTempColumnSep =
                {
                new TableColumnSeparator()
                {
                    Position = 1500,
                    IsVisible = false
                },
                new TableColumnSeparator()
                {
                    Position = 4000,
                    IsVisible = true
                },
                new TableColumnSeparator()
                {
                    Position = 1500,
                    IsVisible = true
                }
            };
                Table_Properties.setPropertyValue("TableColumnSeparators", new uno.Any(typeof(TableColumnSeparator[]), xTempColumnSep));
                Table_Properties.setPropertyValue("HoriOrient", new uno.Any(HoriOrientation.CENTER));
                Table_Properties.setPropertyValue("Width", new uno.Any(Convert.ToInt32(9000)));

                xTextTable.initialize(4, 4);
                xText.insertTextContent(xCursor, xTextTable, false);

                //Get first row
                unoidl.com.sun.star.table.XTableRows xTableRows = xTextTable.getRows();
                uno.Any anyRow = ((unoidl.com.sun.star.container.XIndexAccess)xTableRows).getByIndex(0);

                //Set a different background color for the first row
                XPropertySet xPropertySetFirstRow = (XPropertySet)anyRow.Value;


                //Fill the first table row
                insertIntoCell("A1", "To:", xTextTable);
                insertIntoCell("B1", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyName"].Value.ToString(), xTextTable);
                insertIntoCell("C1", "From:", xTextTable);
                insertIntoCell("D1", "", xTextTable);

                insertIntoCell("A2", "Fax:", xTextTable);
                insertIntoCell("B2", grdContact.Rows[grdContact.CurrentRow.Index].Cells["FaxNumber"].Value.ToString(), xTextTable);
                insertIntoCell("C2", "Pages:", xTextTable);
                insertIntoCell("D2", "8 (including this cover sheet)", xTextTable);

                insertIntoCell("A3", "Phone:", xTextTable);
                insertIntoCell("B3", grdContact.Rows[grdContact.CurrentRow.Index].Cells["WorkPhone"].Value.ToString(), xTextTable);
                insertIntoCell("C3", "Date:", xTextTable);
                insertIntoCell("D3", DateTime.Now.ToString("MM/dd/yyyy"), xTextTable);

                insertIntoCell("A4", "Re:", xTextTable);
                insertIntoCell("B4", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["Address"].Value.ToString() + "," + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["State"].Value.ToString(), xTextTable);
                insertIntoCell("C4", "CC:", xTextTable);
                insertIntoCell("D4", "", xTextTable);


                //Create a paragraph break
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);


                // xCursor = xSimpleText.createTextCursor()
                XPropertySet xProperties = (XPropertySet)xCursor;
                charWidth = xProperties.getPropertyValue("CharScaleWidth");
                charHeight = xProperties.getPropertyValue("CharHeight");
                xProperties.setPropertyValue("CharFontName", new uno.Any("Arial Black"));
                xProperties.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(9)));
                xProperties.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(3)));
                xText.insertString(xCursor, "__Urgent   __ For Review   __ Please Comment   __ Please Reply     __ Please Recycle" + "\r" + "___________________________________________________________________________________________", false);

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xProperties.setPropertyValue("ParaLeftMargin", new uno.Any(1480));
                xProperties.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(2)));
                xText.insertString(xCursor, "\r\n" + "Comments:  ", false);
                xProperties.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties.setPropertyValue("CharScaleWidth", charWidth);
                xProperties.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(10)));
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);

                xText.insertString(xCursor, "\r" + "Tom," + "\r", false);
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xText.insertString(xCursor, "As per our conversation, attached are the mobile crane invoices for the above referenced address.  These invoices are completely separate from any invoice item associated with the tower crane and tower crane assist crane.  As per the conference call with Mike McGuire, you should forward these to his attention for reimbursement.," + "\r", false);
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xText.insertString(xCursor, "Best Regards," + "\r" + "\r" + "Steve", false);
            }
            catch (unoidl.com.sun.star.configuration.InvalidBootstrapFileException bootStrapExp)
            {
                MessageBox.Show(bootStrapExp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (unoidl.com.sun.star.configuration.MissingBootstrapFileException bootstrapMissig)
            {
                MessageBox.Show(bootstrapMissig.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void insertIntoCell(string sCellName, string sText, XTextTable xTable)
        {
            unoidl.com.sun.star.table.XCell xCell = xTable.getCellByName(sCellName);

            XPropertySet xcellProperties = (XPropertySet)xCell;
            IEnumerable<Property> objetQproperties = xcellProperties.getPropertySetInfo().getProperties().AsEnumerable();

            XSimpleText xSimpleTextCell = (XSimpleText)xCell;

            XTextCursor xCursor = xSimpleTextCell.createTextCursor();

            XPropertySet xPropertySetCursor = (XPropertySet)xCursor;

            switch (sCellName)
            {
                case "A1":
                case "A2":
                case "A3":
                case "A4":
                case "C1":
                case "C2":
                case "C3":
                case "C4":
                    xPropertySetCursor.setPropertyValue("CharFontName", new uno.Any("Arial Black"));
                    xPropertySetCursor.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(9)));
                    break;
                default:
                    xPropertySetCursor.setPropertyValue("CharFontName", new uno.Any("Arial"));
                    xPropertySetCursor.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(12)));
                    break;
            }
            //xPropertySetCursor.setPropertyValue("HoriOrient", New uno.Any(HoriOrientation.CENTER))
            //xPropertySetCursor.setPropertyValue("", New uno.Any(""))
            //xPropertySetCursor.setPropertyValue("CharColor", New uno.Any(&HFFFFFF))
            xSimpleTextCell.insertString(xCursor, sText, false);
        }
        private void OpenOffice_WordTransmittal()
        {
            try
            {
                XComponentContext xContext = Bootstrap.bootstrap();
                XMultiServiceFactory xFactory = (XMultiServiceFactory)xContext.getServiceManager();

                //Create the Desktop
                unoidl.com.sun.star.frame.XDesktop xDesktop = (unoidl.com.sun.star.frame.XDesktop)xFactory.createInstance("com.sun.star.frame.Desktop");

                //Open a new empty writer document
                unoidl.com.sun.star.frame.XComponentLoader xComponentLoader = (unoidl.com.sun.star.frame.XComponentLoader)xDesktop;
                PropertyValue[] arProps = new PropertyValue[0];
                unoidl.com.sun.star.lang.XComponent xComponent = xComponentLoader.loadComponentFromURL("private:factory/swriter", "_blank", 0, arProps);
                XTextDocument xTextDocument = (XTextDocument)xComponent;

                //Create a text object
                XText xText = xTextDocument.getText();

                XSimpleText xSimpleText = (XSimpleText)xText;

                //Insert Image
                //Create a cursor object
                XTextCursor xCursor = xSimpleText.createTextCursor();

                //Create a GraphicObject. 
                object objGraphicObject = ((unoidl.com.sun.star.lang.XMultiServiceFactory)xComponent).createInstance("com.sun.star.text.GraphicObject");

                XTextContent xGraphicObject = (XTextContent)objGraphicObject;

                //Set the size of the GraphicObject 
                unoidl.com.sun.star.awt.Size GraphicObjectSize = new unoidl.com.sun.star.awt.Size(15000, 3000);
                ((unoidl.com.sun.star.drawing.XShape)xGraphicObject).setSize(GraphicObjectSize);

                //Set anchortype 
                XPropertySet xPropertySetGraphicObject = (XPropertySet)xGraphicObject;
                xPropertySetGraphicObject.setPropertyValue("AnchorType", new uno.Any(typeof(TextContentAnchorType), TextContentAnchorType.AS_CHARACTER));
                //Set Left margin of image
                xPropertySetGraphicObject.setPropertyValue("LeftMargin", new uno.Any(1282));
                //Set Picture path: 
                //First Method with OOO notation for Windows Notation see PathConverter method 
                string path = "file:///" + Application.StartupPath + "\\Header.Jpg";
                xPropertySetGraphicObject.setPropertyValue("GraphicURL", new uno.Any(path));

                //insert the GraphicObject 
                xText.insertTextContent(xCursor, xGraphicObject, false);


                //Create a cursor object
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                string TRANSMITTALStr = "\r" + "TRANSMITTAL";
                XPropertySet xProperties_TRANSMITTALStrStr = (XPropertySet)xCursor;
                uno.Any charWidth;
                uno.Any charHeight;
                charWidth = xProperties_TRANSMITTALStrStr.getPropertyValue("CharScaleWidth");
                //charHeight = xProperties_TRANSMITTALStrStr.getPropertyValue("CharHeight")
                charHeight = new uno.Any(Convert.ToDouble(9.5));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial Black"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(13)));
                xText.insertString(xCursor, TRANSMITTALStr, false);
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", charHeight);
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                //**************
                //Insert Attention Text here
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(11)));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharWeight", new uno.Any(FontWeight.BOLD));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharUnderline", new uno.Any(FontUnderline.SINGLE));
                xText.insertString(xCursor, "ATTENSION:", false);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", charHeight);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharWeight", new uno.Any(FontWeight.NORMAL));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharUnderline", new uno.Any(FontUnderline.NONE));
                //*****

                //Insert Client Name
                xText.insertString(xCursor, grdContact.Rows[grdContact.CurrentRow.Index].Cells["ContactName"].Value.ToString() + "\t" + "\t" + "\t" + "\t" + "\t", false);
                //*********
                //Inset date string
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(11)));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharWeight", new uno.Any(FontWeight.BOLD));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharUnderline", new uno.Any(FontUnderline.SINGLE));
                xText.insertString(xCursor, "DATE:", false);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", charHeight);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharWeight", new uno.Any(FontWeight.NORMAL));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharUnderline", new uno.Any(FontUnderline.NONE));

                xText.insertString(xCursor, DateTime.Now.ToString("MM/dd/yyyy") + "\r", false);
                //*******
                //Insert company address
                string CompanyAddress = null;
                CompanyAddress = "\r" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyName"].Value.ToString() + "\r" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["Address"].Value.ToString() + "," + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["City"].Value.ToString() + "\r" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["State"].Value.ToString() + "," + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["Country"].Value.ToString() + "," + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["PostalCode"].Value.ToString();

                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", charHeight);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharWeight", new uno.Any(FontWeight.BOLD));
                xText.insertString(xCursor, CompanyAddress + "\r" + "\r" + "\r" + "\r", false);

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(11)));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharWeight", new uno.Any(FontWeight.BOLD));
                xText.insertString(xCursor, "RE:" + "\r", false);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", charHeight);
                xProperties_TRANSMITTALStrStr.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(3)));
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);

                //******************

                //Insert check box selection text here
                //Create instance of a check box add later
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial Black"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(9)));

                xText.insertString(xCursor, "__________________________________________________________________________________________________________" + "\r" + "__Urgent   __ For Review   __ Please Comment   __ Please Reply     __ Please Recycle" + "\r" + "__________________________________________________________________________________________________________" + "\r", false);

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xProperties_TRANSMITTALStrStr.setPropertyValue("ParaLeftMargin", new uno.Any(1480));
                xProperties_TRANSMITTALStrStr.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(2)));
                xText.insertString(xCursor, "·  Comments:  " + "\r", false);
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xProperties_TRANSMITTALStrStr.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(2)));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharHeight", charHeight);
                xProperties_TRANSMITTALStrStr.setPropertyValue("CharWeight", new uno.Any(FontWeight.NORMAL));
                //**************
                //Insert table of job discription
                //Create instance of a text table with 3 columns and 9 rows
                object objTextTable = ((unoidl.com.sun.star.lang.XMultiServiceFactory)xTextDocument).createInstance("com.sun.star.text.TextTable");
                XTextTable xTextTable = (XTextTable)objTextTable;
                XPropertySet Table_Properties = (XPropertySet)xTextTable;
                //Dim objetQproperties As IEnumerable(Of Property) = Table_Properties.getPropertySetInfo().getProperties().AsEnumerable()
                Table_Properties.setPropertyValue("LeftMargin", new uno.Any(Convert.ToInt32(1480)));
                TableColumnSeparator[] xTempColumnSep =
                {
                new TableColumnSeparator()
                {
                    Position = 1500,
                    IsVisible = false
                },
                new TableColumnSeparator()
                {
                    Position = 4000,
                    IsVisible = true
                }
            };
                Table_Properties.setPropertyValue("TableColumnSeparators", new uno.Any(typeof(TableColumnSeparator[]), xTempColumnSep));
                //Table_Properties.setPropertyValue("HoriOrient", New uno.Any(HoriOrientation.CENTER))
                //Table_Properties.setPropertyValue("Width", New uno.Any(Convert.ToInt32(9000)))

                xTextTable.initialize(9, 3);
                xText.insertTextContent(xCursor, xTextTable, false);

                //Get first row
                unoidl.com.sun.star.table.XTableRows xTableRows = xTextTable.getRows();
                uno.Any anyRow = ((unoidl.com.sun.star.container.XIndexAccess)xTableRows).getByIndex(0);

                //Set a different background color for the first row
                XPropertySet xPropertySetFirstRow = (XPropertySet)anyRow.Value;


                //Fill the first table row
                TransmittalTable_insertIntoCell("A1", "JOB #:", xTextTable);
                TransmittalTable_insertIntoCell("B1", "COPIES:", xTextTable);
                TransmittalTable_insertIntoCell("C1", "DESCRIPTION:", xTextTable);
                int I = 1;
                foreach (DataGridViewRow selectrow in grdJobNumber.Rows)
                {
                    if (I >= 9) //23-2-21 - Because rows in table are fixed - 9*3
                        break;
                    if (Convert.ToBoolean(selectrow.Cells[chkJobGrd.Name].Value) == true)
                    {
                        I = I + 1;
                        string CellNameJob = "A" + I.ToString();
                        string cellNameDes = "C" + I.ToString();
                        TransmittalTable_insertIntoCell(CellNameJob, selectrow.Cells["JobNumber"].Value.ToString(), xTextTable);
                        TransmittalTable_insertIntoCell(cellNameDes, selectrow.Cells["Description"].Value.ToString(), xTextTable);
                    }
                }
                //Create a paragraph break
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);

                xText.insertString(xCursor, "\r" + "\r" + "\r" + "Please call if the enclosed package is incomplete." + "\r" + "\r" + "___________" + "\r" + " Steve Valjato", false);

                //**************************
            }
            catch (unoidl.com.sun.star.configuration.InvalidBootstrapFileException bootStrapExp)
            {
                MessageBox.Show(bootStrapExp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (unoidl.com.sun.star.configuration.MissingBootstrapFileException bootstrapMissig)
            {
                MessageBox.Show(bootstrapMissig.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenOffice_WordFax()
        {
            try
            {
                XComponentContext xContext = Bootstrap.bootstrap();
                XMultiServiceFactory xFactory = (XMultiServiceFactory)xContext.getServiceManager();

                //Create the Desktop
                unoidl.com.sun.star.frame.XDesktop xDesktop = (unoidl.com.sun.star.frame.XDesktop)xFactory.createInstance("com.sun.star.frame.Desktop");

                //Open a new empty writer document
                unoidl.com.sun.star.frame.XComponentLoader xComponentLoader = (unoidl.com.sun.star.frame.XComponentLoader)xDesktop;
                PropertyValue[] arProps = new PropertyValue[0];
                unoidl.com.sun.star.lang.XComponent xComponent = xComponentLoader.loadComponentFromURL("private:factory/swriter", "_blank", 0, arProps);
                XTextDocument xTextDocument = (XTextDocument)xComponent;

                //Create a text object
                XText xText = xTextDocument.getText();

                XSimpleText xSimpleText = (XSimpleText)xText;

                //Insert Image
                //Create a cursor object
                XTextCursor xCursor = xSimpleText.createTextCursor();

                //Create a GraphicObject. 
                object objGraphicObject = ((unoidl.com.sun.star.lang.XMultiServiceFactory)xComponent).createInstance("com.sun.star.text.GraphicObject");
                XTextContent xGraphicObject = (XTextContent)objGraphicObject;

                //Set the size of the GraphicObject 
                unoidl.com.sun.star.awt.Size GraphicObjectSize = new unoidl.com.sun.star.awt.Size(15000, 3000);
                ((unoidl.com.sun.star.drawing.XShape)xGraphicObject).setSize(GraphicObjectSize);

                //Set anchortype 
                XPropertySet xPropertySetGraphicObject = (XPropertySet)xGraphicObject;
                xPropertySetGraphicObject.setPropertyValue("AnchorType", new uno.Any(typeof(TextContentAnchorType), TextContentAnchorType.AS_CHARACTER));
                //Set Left margin of image
                xPropertySetGraphicObject.setPropertyValue("LeftMargin", new uno.Any(1282));
                //Set Picture path: 
                //First Method with OOO notation for Windows Notation see PathConverter method 
                string path = "file:///" + Application.StartupPath + "\\Header.Jpg";
                xPropertySetGraphicObject.setPropertyValue("GraphicURL", new uno.Any(path));

                //insert the GraphicObject 
                xText.insertTextContent(xCursor, xGraphicObject, false);

                //Insert Today date
                //Create a cursor object
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                string DateStr = "Fax";
                XPropertySet xProperties_FaxStr = (XPropertySet)xCursor;
                uno.Any charWidth;
                uno.Any charHeight;
                charWidth = xProperties_FaxStr.getPropertyValue("CharScaleWidth");
                charHeight = xProperties_FaxStr.getPropertyValue("CharHeight");
                xProperties_FaxStr.setPropertyValue("CharFontName", new uno.Any("Arial Black"));
                xProperties_FaxStr.setPropertyValue("CharScaleWidth", new uno.Any(Convert.ToInt16(53)));
                xProperties_FaxStr.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(53)));
                xText.insertString(xCursor, DateStr, false);
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xProperties_FaxStr.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties_FaxStr.setPropertyValue("CharScaleWidth", charWidth);
                xProperties_FaxStr.setPropertyValue("CharHeight", charHeight);

                //Create instance of a text table with 4 columns and 4 rows
                object objTextTable = ((unoidl.com.sun.star.lang.XMultiServiceFactory)xTextDocument).createInstance("com.sun.star.text.TextTable");
                XTextTable xTextTable = (XTextTable)objTextTable;
                XPropertySet Table_Properties = (XPropertySet)xTextTable;
                //Dim objetQproperties As IEnumerable(Of Property) = Table_Properties.getPropertySetInfo().getProperties().AsEnumerable()
                //Table_Properties.setPropertyValue("LeftMargin", New uno.Any(Convert.ToInt32(1480)))
                TableColumnSeparator[] xTempColumnSep =
                {
                new TableColumnSeparator()
                {
                    Position = 1500,
                    IsVisible = false
                },
                new TableColumnSeparator()
                {
                    Position = 4000,
                    IsVisible = true
                },
                new TableColumnSeparator()
                {
                    Position = 1500,
                    IsVisible = true
                }
            };
                Table_Properties.setPropertyValue("TableColumnSeparators", new uno.Any(typeof(TableColumnSeparator[]), xTempColumnSep));
                Table_Properties.setPropertyValue("HoriOrient", new uno.Any(HoriOrientation.CENTER));
                Table_Properties.setPropertyValue("Width", new uno.Any(Convert.ToInt32(9000)));

                xTextTable.initialize(4, 4);
                xText.insertTextContent(xCursor, xTextTable, false);

                //Get first row
                unoidl.com.sun.star.table.XTableRows xTableRows = xTextTable.getRows();
                uno.Any anyRow = ((unoidl.com.sun.star.container.XIndexAccess)xTableRows).getByIndex(0);

                //Set a different background color for the first row
                XPropertySet xPropertySetFirstRow = (XPropertySet)anyRow.Value;

                //Fill the first table row
                insertIntoCell("A1", "To:", xTextTable);
                insertIntoCell("B1", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyName"].Value.ToString(), xTextTable);
                insertIntoCell("C1", "From:", xTextTable);
                insertIntoCell("D1", "", xTextTable);

                insertIntoCell("A2", "Fax:", xTextTable);
                insertIntoCell("B2", grdContact.Rows[grdContact.CurrentRow.Index].Cells["FaxNumber"].Value.ToString(), xTextTable);
                insertIntoCell("C2", "Pages:", xTextTable);
                insertIntoCell("D2", "8 (including this cover sheet)", xTextTable);

                insertIntoCell("A3", "Phone:", xTextTable);
                insertIntoCell("B3", grdContact.Rows[grdContact.CurrentRow.Index].Cells["WorkPhone"].Value.ToString(), xTextTable);
                insertIntoCell("C3", "Date:", xTextTable);
                insertIntoCell("D3", DateTime.Now.ToString("MM/dd/yyyy"), xTextTable);
                insertIntoCell("A4", "Re:", xTextTable);
                insertIntoCell("B4", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["Address"].Value.ToString() + "," + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["State"].Value.ToString(), xTextTable);
                insertIntoCell("C4", "CC:", xTextTable);
                insertIntoCell("D4", "", xTextTable);

                //Create a paragraph break
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);

                // xCursor = xSimpleText.createTextCursor()
                XPropertySet xProperties = (XPropertySet)xCursor;
                charWidth = xProperties.getPropertyValue("CharScaleWidth");
                charHeight = xProperties.getPropertyValue("CharHeight");
                xProperties.setPropertyValue("CharFontName", new uno.Any("Arial Black"));
                xProperties.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(9)));
                xProperties.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(3)));
                xText.insertString(xCursor, "__Urgent   __ For Review   __ Please Comment   __ Please Reply     __ Please Recycle" + "\r" + "___________________________________________________________________________________________", false);

                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
                xProperties.setPropertyValue("ParaLeftMargin", new uno.Any(1480));
                xProperties.setPropertyValue("ParaAdjust", new uno.Any(Convert.ToInt16(2)));
                xText.insertString(xCursor, "\r\n" + "Comments:  ", false);
                xProperties.setPropertyValue("CharFontName", new uno.Any("Arial"));
                xProperties.setPropertyValue("CharScaleWidth", charWidth);
                xProperties.setPropertyValue("CharHeight", new uno.Any(Convert.ToDouble(10)));
                xSimpleText.insertControlCharacter(xCursor, ControlCharacter.PARAGRAPH_BREAK, false);
            }
            catch (unoidl.com.sun.star.configuration.InvalidBootstrapFileException bootStrapExp)
            {
                MessageBox.Show(bootStrapExp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (unoidl.com.sun.star.configuration.MissingBootstrapFileException bootstrapMissig)
            {
                MessageBox.Show(bootstrapMissig.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MSOffice_FAX_US_Crane_and_Rigging()
        {
            try
            {
                if (grdContact.Rows.Count == 0)
                {
                    MessageBox.Show("First Select Contact Name");
                    return;
                }
                Word.Application WordFax = null;
                Word.Document WordDoc = null;
                WordFax = (Word.Application)System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Word.Application"));
                WordDoc = WordFax.Documents.Add();
                WordFax.Visible = true;
                WordFax.Activate();
                Word.Range HeaderRang = WordDoc.Paragraphs.Add().Range;
                HeaderRang.InlineShapes.AddPicture(Application.StartupPath + "\\Header.Jpg");
                //WordDoc.SaveAs(Application.StartupPath + "\Word.doc")
                Word.Range FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial Black";
                FAXtext.Font.Size = float.Parse( "54");
                FAXtext.Font.Bold = 1;
                FAXtext.InsertBefore("Fax");
                Word.Table insertTable = WordDoc.Tables.Add(WordDoc.Words.Last, 4, 4);
                insertTable.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto;
                //.PreferredWidth = 91.5
                insertTable.LeftPadding = 18;
                insertTable.AllowAutoFit = true;
                for (int i = 1; i <= 4; i++)
                {
                    insertTable.Cell(i, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    insertTable.Cell(i, 1).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 1).PreferredWidth = 12;
                    insertTable.Cell(i, 1).Range.Font.Name = "Arial Black";
                    insertTable.Cell(i, 1).Range.Font.Size = float.Parse("10");
                    insertTable.Cell(i, 3).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 3).PreferredWidth = 12;
                    insertTable.Cell(i, 3).Range.Font.Name = "Arial Black";
                    insertTable.Cell(i, 3).Range.Font.Size = float.Parse("10");
                    insertTable.Cell(i, 2).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 2).PreferredWidth = 40;
                    insertTable.Cell(i, 4).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 4).PreferredWidth = 40;
                }
                insertTable.Cell(1, 1).Range.Text = "To:";
                insertTable.Cell(1, 2).Range.Text = grdContact.Rows[grdContact.CurrentRow.Index].Cells["FirstName"].Value.ToString() + " " + grdContact.Rows[grdContact.CurrentRow.Index].Cells["LastName"].Value.ToString();
                insertTable.Cell(2, 1).Range.Text = "Fax:";
                insertTable.Cell(2, 2).Range.Text = grdContact.Rows[grdContact.CurrentRow.Index].Cells["FaxNumber"].Value.ToString();
                insertTable.Cell(3, 1).Range.Text = "Phone:";
                insertTable.Cell(3, 2).Range.Text = grdContact.Rows[grdContact.CurrentRow.Index].Cells["MobilePhone"].Value.ToString();
                insertTable.Cell(4, 1).Range.Text = "Re:";
                insertTable.Cell(1, 3).Range.Text = "From:";
                insertTable.Cell(1, 4).Range.Text = "Steve Valjato";
                insertTable.Cell(2, 3).Range.Text = "Pages:";
                insertTable.Cell(2, 4).Range.Text = "1 (including this cover sheet)";
                insertTable.Cell(3, 3).Range.Text = "Date:";
                insertTable.Cell(3, 4).Range.Text = DateTime.Now.ToString("D", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                insertTable.Cell(4, 3).Range.Text = "CC:";
                //.Range.Select()
                //.Tables.Item(1).Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter
                // WordDoc.Tables.Item(1).Select()
                WordDoc.Tables[1].Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
                //Dim par As Word.Paragraph = WordDoc.LastParagraph
                Word.FormField WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                WordcheckBox.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore("\r");
                FAXtext.InsertAfter("Urgent");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("For Review");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Please Comment");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Please Reply");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("For your use");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("As Requested");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r");
                FAXtext.InlineShapes.AddHorizontalLineStandard(WordDoc.Words.Last);
                FAXtext.InsertBefore("\r");
                FAXtext = WordDoc.Paragraphs.Add().Range;
                WordDoc.Paragraphs.Add(FAXtext).Range.ListFormat.ApplyBulletDefault(Word.WdBuiltinStyle.wdStyleListBullet2);
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyMed;
                //.ListFormat.ApplyBulletDefault(Word.WdBuiltinStyle.wdStyleListContinue2)
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("10");
                FAXtext.Font.Bold = 1;
                FAXtext.InsertBefore("Comments:");
                //.Select()
                //Dim SaveExportLocation As New SaveFileDialog
                //SaveExportLocation.Filter = "DOC|*.doc"
                //If SaveExportLocation.ShowDialog = DialogResult.OK Then
                //    WordFax.ChangeFileOpenDirectory(SaveExportLocation.FileName)
                //    WordDoc.Save
                //    WordDoc.Close()
                //    WordDoc = Nothing
                //    WordFax = Nothing
                //    Shell(SaveExportLocation.FileName, AppWinStyle.Hide)
                //End If
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r");
                string InsertStr = "Tom," + "\r" + "\r" + "As per our conversation, attached are the mobile crane invoices for the above referenced address.  These invoices are completely separate from any invoice item associated with the tower crane and tower crane assist crane.  As per the conference call with Mike McGuire, you should forward these to his attention for reimbursement.," + "\r" + "\r" + "Best Regards," + "\r" + "\r" + "Steve";
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9.5");
                FAXtext.Font.Bold = 0;
                FAXtext.InsertBefore(InsertStr);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VisibleCheckBoxCompany(bool value)
        {
            chkgrdCompany.Visible = value;
            grdCompany.Columns[chkCompanyGrd.Name].Visible = value;
            grdCompany.RowHeadersVisible = !value;

        }
        private void VisibleCheckBoxContact(bool value)
        {
            chkGrdContacts.Visible = value;
            grdContact.Columns[chkContacts.Name].Visible = value;
            grdContact.RowHeadersVisible = !value;
        }
        private void VisibleCheckBoxJobNumber(bool value)
        {
            chkGrdJobNumber.Visible = value;
            grdJobNumber.Columns[chkJobGrd.Name].Visible = value;
            grdJobNumber.RowHeadersVisible = !value;
        }
        private void VisibleCheckBoxTypical(bool value)
        {
            chkGrdTypical.Visible = value;
            grdListitem.Columns[chkTypicalGrid.Name].Visible = value;
            grdListitem.RowHeadersVisible = !value;
        }
        #endregion
    }
}