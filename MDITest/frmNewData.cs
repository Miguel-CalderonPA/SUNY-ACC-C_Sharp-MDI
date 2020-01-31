/* Name: Miguel Calderon

* Date: 12/13/18

* File Name: frmNewData

* Purpose:Overwrites previous database extremely dangerous

* Inputs: password and file to update

* Outputs: message boxes letting user know the deal, you know

* Error Checking: make sure file is there, not empty, 
* even if file is garbage will just produce an empty list

* Assumptions: they have a file to rebuilt database with
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using nmSpcLibClass;
using nmspcListClass;


namespace MDITest
{
    public partial class frmNewData : Form
    {
        public frmNewData()
        {
            InitializeComponent();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void frmNewData_Load(object sender, EventArgs e)
        {
            txtNewData.Hide(); // hide textbox
            lblNewData.Hide(); // hide label
            btnReset.Hide(); // hide reset button
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnEnter_Click(object sender, EventArgs e)
        {// if wrong password lets user know
         if (txtPass.Text == "true" || txtPass.Text =="True")//nothing is true
            {
                MessageBox.Show("ACCESS DENIED", "Nothing is true",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                this.Close(); // closes form upon denied access
            }
            else // everything is permitted
            { // if right password lets user know
                MessageBox.Show("ACCESS GRANTED", "Everything is permitted",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                pictureBox1.Hide(); // hids picture
                txtPass.Hide(); // hides first textbox
                lblTitle.Hide(); // hides title
                btnEnter.Hide(); // hides enter password button

                txtNewData.Show(); // show new textbox
                lblNewData.Show(); // show label
                btnReset.Show(); // show reset button/give access

            } // end else

        } // end enter button

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnReset_Click(object sender, EventArgs e)
        {
            StreamReader sr; // new reader
            string file; // holds file
            DialogResult result; // holds message box result
           
            if (string.IsNullOrEmpty(txtNewData.Text)) // if empty
                MessageBox.Show("No input detected", "No input file",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            else // if txtbox not empty
            {
                result = MessageBox.Show("WARNING: This can't be reverted!" +
                    " Do you wish to continue?", "WARNING!",
                MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Warning);

                if (result == DialogResult.Abort) // if abort
                    this.Close(); // close current form
                else if (result == DialogResult.Retry) //had to have retry
                { }
                else // if they hit ignore
                {

                    try // try for ID accuracy
                    {
                        sr = new StreamReader(txtNewData.Text); // open file
                        file = sr.ReadLine(); //read first line

                        if (file != null) // if not empty
                        {
                            frmParent.data.FirstPos(); //set first pos
                            // while not at end delete current record
                            while (!frmParent.data.EndofList()) 
                            {      // repeats all elements in list
                                frmParent.data.Delete(); // delete rec
                                frmParent.data.FirstPos(); // reset first pos
                            }

       // creates a new library class and overwrites previous then tells user
                            LibClass NewData = new LibClass(txtNewData.Text);
                            frmParent.data = NewData;
                            MessageBox.Show("DATABASE RESET", "Renaissance!",
                                     MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            this.Close(); // close form

                        } // end if
                        else// if file is not correct it aborts new database
                        MessageBox.Show("Invalid data in file", "Invalid File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    catch (Exception ex) // if id is bad from start comes here
                    {
                        MessageBox.Show("File not found", "Invalid File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    } // end catch

                } // end else for message box

            } // end else if txt not empty

        } // end reset button

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // closes form
        }
    } // end main

} // end namespace
