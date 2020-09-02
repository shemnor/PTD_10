using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tekla.Structures;
using Tekla.Structures.DrawingInternal;
using TSDrg = Tekla.Structures.Drawing;
using TSM = Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Drawing;
using PS = PTD_10.Properties.Settings;
using Tekla.Structures.Model;
using System.Collections;
using RenderData;

namespace PTD_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = SystemIcons.Warning.ToBitmap();
            toolTip1.SetToolTip(pictureBox1, "Phase input is not numeric and phase will not be assigned");
            pictureBox2.Image = SystemIcons.Warning.ToBitmap();
            toolTip2.SetToolTip(pictureBox2, "Phase input is not numeric and phase will not be assigned");

            //read previous settings
            DataTable savedInp = new DataTable();
            savedInp.Columns.Add("control");
            savedInp.Columns.Add("value");

            //apply previous settings
            Helpers.ReadUserProperties(ref savedInp);
            foreach (DataRow row in savedInp.Rows)
            {
                Control control = this.Controls[row["control"].ToString()];
                if (control.GetType() == typeof(ComboBox))
                {
                    ComboBox cbox = control as ComboBox;
                    cbox.SelectedItem = row["value"].ToString();
                }
                else if (control.GetType() == typeof(TextBox))
                {
                    TextBox tbox = control as TextBox;
                    tbox.Text = row["value"].ToString();
                }
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            //read current settings
            DataTable userInp = ScrapeForm();
            //save current settings
            Helpers.ApplyUserProperties(userInp);

        }

        private DataTable ScrapeForm()
        {
            DataTable userInp = new DataTable();
            userInp.Columns.Add("control");
            userInp.Columns.Add("value");

            foreach (Control control in this.Controls)
            {
                Type controlType = control.GetType();
                if (controlType == typeof(TextBox))
                {
                    TextBox txbx = control as TextBox;
                    DataRow newRow = userInp.NewRow();
                    newRow["control"] = txbx.Name;
                    newRow["value"] = txbx.Text;
                    userInp.Rows.Add(newRow);

                }
                else if (controlType == typeof(ComboBox))
                {
                    ComboBox cbx = control as ComboBox;
                    DataRow newRow = userInp.NewRow();
                    newRow["control"] = cbx.Name;
                    try
                    {
                        newRow["value"] = cbx.SelectedItem.ToString();
                    }
                    catch (Exception ex)
                    {
                        newRow["value"] = "";
                    }

                    userInp.Rows.Add(newRow);
                }
            }
            return userInp;
        }

        private void txb_AddedPhase_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (!Int32.TryParse(txb_AddedPhase.Text, out number))
            {
                pictureBox1.Visible = true;
                toolTip1.Active = true;
            }
            else
            {
                pictureBox1.Visible = false;
                toolTip1.Active = false;
            }
        }
        private void txb_DeletedPhase_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (!Int32.TryParse(txb_AddedPhase.Text, out number))
            {
                pictureBox2.Visible = true;
                toolTip2.Active = true;
            }
            else
            {
                pictureBox2.Visible = false;
                toolTip2.Active = false;
            }
        }

        private void btn_Added_Click(object sender, EventArgs e)
        {
            //reset form
            lbl_info.Text = "";

            //check if TS is open
            Model Model = new Model();
            /*
            if (!Model.GetConnectionStatus())
            {
                lbl_info.Text = "Cannot detect Tekla Model";
                return;
            }
            */

            //get selected bars
            List<TSM.ModelObject> usrObjects = Helpers.getMdlObjectsFromSelection(typeof(Reinforcement),typeof(TSM.Beam));

            //check if any selected
            if (usrObjects == null)
            {
                lbl_info.Text = "No bars or couplers selected";
                return;
            }

            //change Reinforcement types
            foreach (TSM.ModelObject obj in usrObjects)
            {
                ApplyChangeManagementUDA(true, obj);
            }

            lbl_info.Text = "Bars and couplers marked as ADDED!";      
        }


        /// <summary>
        /// ***************** MODEL LOGIC *******************
        /// </summary>

        private void btn_Deleted_Click(object sender, EventArgs e)
        {
            //reset form
            lbl_info.Text = "";

            //check if TS is open
            Model Model = new Model();
            if (!Model.GetConnectionStatus())
            {
                lbl_info.Text = "Cannot detect Tekla Model";
                return;
            }

            //get selected bars and couplers
            List<TSM.ModelObject> usrObjects = Helpers.getMdlObjectsFromSelection(typeof(TSM.Reinforcement), typeof(TSM.Beam));

            //check if any selected
            if (usrObjects == null)
            {
                lbl_info.Text = "No bars or couplers selected";
                return;
            }

            //change Reinforcement types
            foreach (TSM.ModelObject obj in usrObjects)
            {
                ApplyChangeManagementUDA(false, obj);
            }

            lbl_info.Text = "Bars and couplers marked as DELETED!";
        }

        private void ApplyChangeManagementUDA(bool Added, TSM.ModelObject obj)
        {
            Phase objPhase;

            if (Added)
            {
                int number;
                if (Int32.TryParse(txb_AddedPhase.Text, out number))
                {
                    //set object phase
                    objPhase = new Phase(number);
                    obj.SetPhase(objPhase);

                    //get phase back with full information
                    obj.GetPhase(out objPhase);

                    //save info, trim and apply to object
                    string phaseName = objPhase.PhaseName;
                    phaseName = phaseName.Trim();
                    if (phaseName.LastIndexOf(" ") > 0)
                    {
                        phaseName = phaseName.Substring(0, phaseName.LastIndexOf(" ", phaseName.Length));
                    }
                    obj.SetUserProperty("SDLT_CH_REF", phaseName);
                }
                obj.SetUserProperty("SDLT_MOD_TYPE", 1);
            }
            else
            {
                int number;
                if (Int32.TryParse(txb_DeletedPhase.Text, out number))
                {
                    //set object phase
                    objPhase = new Phase(number);
                    obj.SetPhase(objPhase);

                    //get phase back with full information
                    obj.GetPhase(out objPhase);

                    //save info, trim and apply to object
                    string phaseName = objPhase.PhaseName;
                    phaseName = phaseName.Trim();
                    if (phaseName.LastIndexOf(" ") > 0)
                    {
                        phaseName = phaseName.Substring(0, phaseName.LastIndexOf(" ", phaseName.Length));
                    }
                    obj.SetUserProperty("SDLT_CH_REF", phaseName);
                }
                obj.SetUserProperty("SDLT_MOD_TYPE", 0);
            }

            obj.SetUserProperty("SDLT_CH_TYPE", cb_ChangeType.SelectedIndex - 1);
            obj.SetUserProperty("SDLT_CH_BY_ORG", cb_RaisedBy.SelectedIndex - 1);
            obj.SetUserProperty("SDLT_CH_MODEL_BY", "ATKINS");
            obj.SetUserProperty("SDLT_CH_DATE", DateTime.Today.Date.ToString("dd'.'MM'.'yyyy"));
            obj.SetUserProperty("SDLT_CH_REV", txb_ChangeRevision.Text);
        }




        /*
        enum Changetype
        {
            FCR = 0,
            DEN = 1,
            NCR = 2,
            RFI = 3
        }
        enum ModificationType
        {
            Deleted = 0,
            Added = 1
        }

        enum RaisedBy
        {
            BYLOR = 0,
            EDVANCE = 1,
            CNEPE = 2,
            NNB = 3,
            SET = 4
        }
        */
        private bool ValidateForm(bool added)
        {
            int number;
            bool addedsuccess = Int32.TryParse(txb_AddedPhase.Text, out number);
            bool deletedSuccess = Int32.TryParse(txb_DeletedPhase.Text, out number);

            if (added && !addedsuccess)
            {
                DialogResult result = MessageBox.Show("Added phase input is not numberic and phase will not be assigned, do you want to continue?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (!added && !deletedSuccess)
            {
                DialogResult result = MessageBox.Show("Deleted phase input is not numberic and phase will not be assigned, do you want to continue?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
