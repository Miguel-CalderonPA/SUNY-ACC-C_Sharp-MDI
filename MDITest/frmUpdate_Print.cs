/* Name: Miguel Calderon

* Date: 12/13/18

* File Name: frmUpdate_Print

* Purpose:updates the databases, originally printed too, but removed and 
* placed somewhere else

* Inputs: already default file to use, but can be used with custom file

* Outputs: updated database

* Error Checking: make sure file they give is not empty and tangible

* Assumptions: Penguins fly, but not in air
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
using nmspcItemRec;
using System.IO;

namespace MDITest
{
    public partial class frmUpdate_Print : Form
    {
        const string fileName = "Today.out"; // default input file
        public frmUpdate_Print()
        {
            InitializeComponent();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            StreamReader sr; // reads file
            string file,line; // holds file and line
            file = txtFile.Text; // assign file
            if (!string.IsNullOrEmpty(file)) // checks if empty
            {

                try
                {
                    sr = new StreamReader(file);
                    line= sr.ReadLine();

                    if (line != null)
                    {
                        sr.Close();// closes reader                   
                        frmParent.data.LibStatus(file);
                        btn_Import.Hide(); // hides import button
                        txtFile.Hide(); // hides import textbox
                        btnView.Show(); // shows view button                     
                    } // end if

                } // end try
                catch
                {
                    MessageBox.Show("file: " + file + " was not found", "File Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }// end catch for file found                          
                
            } // end if for file empty
            else
            {
                MessageBox.Show(file + "File empty", "Input Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
            }// end else for empty

        // hides import update button (used to be named "add")
            btnUpdate.Hide(); 

        } // end add

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void frmUpdate_Print_Load(object sender, EventArgs e)
        {
            txtFile.Hide(); // hides import file textbox upon load
            btnUpdate.Hide(); // hides update button for imports
            btnView.Hide(); // hids view
          //  btnExit.Hide(); // hides exit until compleletion
            lblCurr.Hide(); // hides title of show
            lbxLib.Hide(); // hides listbox full of data
        } // end load

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btn_OptUp_Click(object sender, EventArgs e)
        {
            frmParent.data.LibStatus(); // sends to lib class for update
            btn_Import.Hide(); // hide import button
            txtFile.Hide(); // hides text box
            btnView.Show(); // show view button       
        } // end default button

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btn_Import_Click(object sender, EventArgs e)
        {
            txtFile.Show(); // shows text box
            btnUpdate.Show();
            btn_OptUp.Hide(); //hides default button (renamed from "Update")       
        } // end import button

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnView_Click(object sender, EventArgs e)
        {
            string file; // holds file
            StreamReader sr; // reads file
             btn_OptUp.Hide(); // hides default button (renamed from "Update")
            lbxLib.Items.Clear();// clear list box for multi-use
            sr = new StreamReader(fileName);// opens reader
            file = sr.ReadLine(); // reads first line

            while (file != null) // reads through file
            {
            lbxLib.Items.Add(file); // file listbox
            file = sr.ReadLine(); // read next line
           }// end while

            sr.Close(); // close reader
            btnView.Hide(); // hide view
            lblDef.Hide(); // hide other label
            btnExit.Show(); // show exit button
            lblCurr.Show(); // show title
            lbxLib.Show(); // show listbox
          
        } // end view button

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("See you tomorrow!?", "Goodbye",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Question);
            this.Close(); // closes form
        } // end exit button

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    } // end main

} // end namespace



