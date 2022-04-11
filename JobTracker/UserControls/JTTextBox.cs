using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.UserControls
{
    public partial class JTTextBox : UserControl
    {
        #region Globle variable
        private string txtLableValue;
        /// <summary>
        /// TxtJT text change event.
        /// </summary>
        /// <remarks></remarks>
        public delegate void TxtJTTextChangeEventHandler();
        public event TxtJTTextChangeEventHandler TxtJTTextChange;
        #endregion
        #region Properties
        /// <summary>
        /// Set TextBox Lable
        /// </summary>
        /// <value>String</value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string TextBoxLable
        {
            get
            {
                return txtLableValue;
            }
            set
            {
                //txtJT.Text = value
                txtLableValue = value;
            }
        }

        /// <summary>
        /// Set TextBox Lable font color on lost focus and get focus
        /// </summary>
        /// <value>Boolean</value>
        /// <remarks> On true font color is become gray and on false font color become black</remarks>
        public bool TextBoxLableFontcolor
        {
            set
            {
                if (value == true)
                {
                    txtJT.ForeColor = SystemColors.GrayText;
                }
                else
                {
                    txtJT.ForeColor = SystemColors.WindowText;
                }
            }
        }

        /// <summary>
        /// Text Box Lable font size
        /// </summary>
        /// <value>Single</value>
        /// <remarks></remarks>
        public float TextBoxLableFontSize
        {
            set
            {
                Font txtFont = new Font("Calibri", value);
                txtJT.Font = txtFont;
            }
        }
        #endregion

        public JTTextBox()
        {
            InitializeComponent();
        }
        private void txtJT_Click(System.Object sender, System.EventArgs e)
        {
            if (txtJT.Text.Trim() == TextBoxLable)
            {
                txtJT.Text = string.Empty;
                TextBoxLableFontcolor = false;
            }
        }
        private void txtJT_getFocus()
        {
            if (string.IsNullOrEmpty(txtJT.Text.Trim()) || txtJT.Text.Trim() == TextBoxLable)
            {
                txtJT.Text = TextBoxLable;
                TextBoxLableFontcolor = false;
            }
        }
        private void txt_lostFocus()
        {
            if (string.IsNullOrEmpty(txtJT.Text.Trim()) || txtJT.Text.Trim() == TextBoxLable)
            {
                txtJT.Text = TextBoxLable;
                TextBoxLableFontcolor = true;
            }
        }

        private void JTTextBox_Load(System.Object sender, System.EventArgs e)
        {
            //txtJT.LostFocus += txt_lostFocus;
            //txtJT.GotFocus += txtJT_getFocus;
            TextBoxLableFontcolor = true;
            txtJT.Text = TextBoxLable;
        }

        private void txtJT_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (TxtJTTextChange != null)
                TxtJTTextChange();
        }        
    }
}
