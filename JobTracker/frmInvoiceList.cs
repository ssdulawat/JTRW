using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccessLayer.Model;


namespace JobTracker
{
    public partial class frmInvoiceList : Form
    {
        #region Declaration
        private int _CompnyID;
        private bool find = false;
        public int CompnyID
        {
            get
            {
                return _CompnyID;
            }
            set
            {
                _CompnyID = value;
            }
        }
        private int _jobId;
        public int JobId
        {
            get
            {
                return _jobId;
            }
            set
            {
                _jobId = value;
            }
        }
        #endregion  

        public frmInvoiceList()
        {
            InitializeComponent();
        }

        #region EVents
        private void frmInvoiceList_Load(System.Object sender, System.EventArgs e)
        {

            /*
                //InvoiceFileList.Path = GetDir
                InvoiceFileList.Items.Clear();
                //'fillLisiVewItem()
                bg.RunWorkerAsync();
                this.pbLoadInvoiceList.Maximum = 100;
                this.pbLoadInvoiceList.Value = 5;
            */

            try
            {
                InvoiceFileList.Items.Clear();

                backgroundWorker1.RunWorkerAsync();

                this.pbLoadInvoiceList.Maximum = 100;
                this.pbLoadInvoiceList.Value = 5;

                //bg.RunWorkerAsync()
                //Me.pbLoadInvoiceList.Maximum = 100
                //Me.pbLoadInvoiceList.Value = 5
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void InvoiceFileList_MouseDoubleClick(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //string fExt = string.Empty;
            //string filePath = InvoiceFileList.Path + "\\";
            //try
            //{
            //    if ((InvoiceFileList.FileName.LastIndexOf(".") + 1) != 0)
            //    {
            //        System.Diagnostics.Process.Start(filePath + InvoiceFileList.FileName);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    KryptonMessageBox.Show(ex.Message, "Message");
            //}



        }




        private void bg_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //this.fillLisiVewItem();
        }

        private void bg_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //this.pbLoadInvoiceList.Value = this.pbLoadInvoiceList.Maximum;
            //if (InvoiceFileList.Items == null || InvoiceFileList.Items.Count == 0)
            //{
            //    MessageBox.Show("No invoice found.");
            //}
        }

        private void bg_ProgressChanged(System.Object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //if (e.UserState == null)
            //{
            //    this.pbLoadInvoiceList.Maximum = e.ProgressPercentage;
            //}
            //else if (e.ProgressPercentage < this.pbLoadInvoiceList.Maximum)
            //{
            //    this.pbLoadInvoiceList.Value = this.pbLoadInvoiceList.Value + 1;
            //    FileInfo file = (FileInfo)e.UserState;

            //    if (file != null)
            //    {
            //        InvoiceFileList.Items.Add(file);
            //    }
            //}

        }

        #endregion

        #region Methods
        private void fillLisiVewItem()
        {
            try
            {
                string GetDir = "N:\\transfer\\PDF invoice";

                //MessageBox.Show("1");

                DirectoryInfo DirFile = new DirectoryInfo(GetDir);

                //MessageBox.Show("2");

                FileInfo[] GetFile = DirFile.GetFiles();

                //MessageBox.Show("3");

                this.bg.ReportProgress(GetFile.Length);

                //MessageBox.Show("4");

                DataTable FileDt = new DataTable();


                //FileDt = StMethod.GetListDT<string>("Select JobNumber from Joblist Where CompanyID=" + CompnyID);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    //MessageBox.Show("5");

                    //FileDt = StMethod.GetListDTNew<string>("Select JobNumber from Joblist Where CompanyID=" + CompnyID);

                    

                    FileDt = StMethod.GetListDTNew<InvoiceDetailNew>("Select JobNumber from Joblist Where CompanyID=" + CompnyID);


                    //FileDt = StMethod.GetListDTNew<InvoiceAging>("Select JobNumber from Joblist Where CompanyID=" + grdCompany.Rows[Rindex].Cells["CompanyID"].Value.ToString());

                }
                else
                {
                    //MessageBox.Show("6");

                    //FileDt = StMethod.GetListDT<string>("Select JobNumber from Joblist Where CompanyID=" + CompnyID);

                    FileDt = StMethod.GetListDT<InvoiceDetailNew>("Select JobNumber from Joblist Where CompanyID=" + CompnyID);

                }


                //string tempQUery= "Select JobNumber from Joblist Where CompanyID=" + CompnyID;

                //MessageBox.Show("tempQUery => " + FileDt.Rows.Count.ToString());
                //MessageBox.Show("CompnyID => " + CompnyID);
                //MessageBox.Show("FileDt rows =>" + FileDt.Rows.Count.ToString());



                //MessageBox.Show("7");

                int i = 0;
                foreach (DataRow Dr in FileDt.Rows)
                {
                    //MessageBox.Show("8");

                    foreach (FileInfo FI in GetFile)
                    {
                        //MessageBox.Show("9");

                        if (FI.Name.Contains(Dr["JobNumber"].ToString()))
                        {
                            //MessageBox.Show("10");
                            this.bg.ReportProgress(i, FI);
                            //MessageBox.Show("11");
                        }
                    }
                    i = i + 1;
                }

                //MessageBox.Show("15");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //MessageBox.Show(ex.Message + Environment.NewLine + "Please check 'N:\\transfer\\PDF invoice'.", "Error");

            }
        }
        #endregion

        private void bg_DoWork_1(object sender, DoWorkEventArgs e)
        {

            try
            {
                this.fillLisiVewItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //MessageBox.Show(ex.Message + Environment.NewLine + "Please check 'N:\\transfer\\PDF invoice'.", "Error");

            }

        }

        private void bg_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (e.UserState == null)
                {
                    this.pbLoadInvoiceList.Maximum = e.ProgressPercentage;
                }
                else if (e.ProgressPercentage < this.pbLoadInvoiceList.Maximum)
                {
                    this.pbLoadInvoiceList.Value = this.pbLoadInvoiceList.Value + 1;
                    FileInfo file = (FileInfo)e.UserState;

                    if (file != null)
                    {
                        InvoiceFileList.Items.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //MessageBox.Show(ex.Message + Environment.NewLine + "Please check 'N:\\transfer\\PDF invoice'.", "Error");

            }
        }

        private void bg_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.pbLoadInvoiceList.Value = this.pbLoadInvoiceList.Maximum;
                if (InvoiceFileList.Items == null || InvoiceFileList.Items.Count == 0)
                {
                    MessageBox.Show("No invoice found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //MessageBox.Show(ex.Message + Environment.NewLine + "Please check 'N:\\transfer\\PDF invoice'.", "Error");

            }
        }

        private void InvoiceFileList_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            string fExt = string.Empty;
            string filePath = InvoiceFileList.Path + "\\";

            //string GetDir = "N:\\transfer\\PDF invoice";

            filePath = "N:\\transfer\\PDF invoice\\";

            try
            {
                //MessageBox.Show(InvoiceFileList.Path.ToString());

                //MessageBox.Show(filePath.ToString());

                if ((InvoiceFileList.FileName.LastIndexOf(".") + 1) != 0)
                {

                    //string temps = filePath + InvoiceFileList.FileName;
                    //MessageBox.Show(temps);
                    System.Diagnostics.Process.Start(filePath + InvoiceFileList.FileName);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Me.fillLisiVewItem()
                this.fillLisiVewItem();  
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                //If e.UserState Is Nothing Then
                //    Me.pbLoadInvoiceList.Maximum = e.ProgressPercentage
                //ElseIf e.ProgressPercentage < Me.pbLoadInvoiceList.Maximum Then
                //    Me.pbLoadInvoiceList.Value = Me.pbLoadInvoiceList.Value + 1
                //    Dim file As FileInfo = CType(e.UserState, FileInfo)

                //    If file IsNot Nothing Then
                //        InvoiceFileList.Items.Add(file)
                //    End If
                //End If


                if (e.UserState == null)
                {
                    this.pbLoadInvoiceList.Maximum = e.ProgressPercentage;
                }
                else if (e.ProgressPercentage < this.pbLoadInvoiceList.Maximum)
                {
                    this.pbLoadInvoiceList.Value = this.pbLoadInvoiceList.Value + 1;
                    FileInfo file = (FileInfo)e.UserState;

                    if (file != null)
                    {
                        InvoiceFileList.Items.Add(file);
                    }
                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                try
                {
                    this.pbLoadInvoiceList.Value = this.pbLoadInvoiceList.Maximum;
                    if (InvoiceFileList.Items == null || InvoiceFileList.Items.Count == 0)
                    {
                        MessageBox.Show("No invoice found.");
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    //MessageBox.Show(ex.Message + Environment.NewLine + "Please check 'N:\\transfer\\PDF invoice'.", "Error");

                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
        }

        private void frmInvoiceList_Load_1(object sender, EventArgs e)
        {
            try
            {
                InvoiceFileList.Items.Clear();

                backgroundWorker1.RunWorkerAsync();

                this.pbLoadInvoiceList.Maximum = 100;
                this.pbLoadInvoiceList.Value = 5;

                //bg.RunWorkerAsync()
                //Me.pbLoadInvoiceList.Maximum = 100
                //Me.pbLoadInvoiceList.Value = 5
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
