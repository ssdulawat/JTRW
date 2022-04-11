using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.MasterTackListItem
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation(bool isFilter)
        {
            InitializeComponent();
            if (isFilter)
            {
                this.lblLabel.Text = "Sort by";
                this.Label1.Text = "File Name";
                this.txtInfo.Visible = true;
                this.cbInfo.Visible = true;
                this.cbInfo.Items.AddRange(new object[] { "Track Display Set", "Track Name", "Track Sub Name" });
            }
            else
            {
                //Me.lblLabel.Text = "Track Name"
                this.lblLabel.Text = "Invoice Rate";
                this.txtInfo.Visible = true;
                this.cbInfo.Visible = false;
                this.txtInfo.Location = this.cbInfo.Location;
                this.Label1.Visible = false;
                this.Button1.Visible = false;
                // Add any initialization after the InitializeComponent() call.
            }
        }
        public DialogResult Result { get; set; }


        public string Info
        {
            get
            {
                if (this.txtInfo.Visible)
                {
                    return this.txtInfo.Text.Trim();
                }
                else
                {
                    return this.cbInfo.Text.Trim();
                }
            }

        }
        public string FileName
        {
            get
            {
                return this.txtInfo.Text;
            }
        }

        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {
            this.Result = DialogResult.OK;
            this.Hide();
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            SaveFileDialog Export = new SaveFileDialog();
            Export.Filter = "Excel Format|*.xls";
            Export.Title = "Export Master List Item";
            Export.InitialDirectory = "N:";
            //saveFileInvoice.FileName = INDetailDT.Rows[0).Item("InvoiceNo").ToString + "j"
            if (Export.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            this.txtInfo.Text = Export.FileName;
        }

        private void txtInfo_Click(System.Object sender, System.EventArgs e)
        {
            this.Button1.PerformClick();
        }

        private void frmConfirmation_Load(System.Object sender, System.EventArgs e)
        {

        }
    }
}
