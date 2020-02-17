/* Name: Miguel Calderon

* Date: 12/13/18

* File Name: frmNewRec

* Purpose:Add a book to the database

* Inputs: book id, author, # of copies

* Outputs: added book into database

* Error Checking: checks id extensivly (including if duplicate)
* and copies because copies can't be below 1 and 
* greater than 255 (stored as a byte)

* Assumptions: They're entering in a real book, could be false
* no way to know
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

namespace MDITest
{
    public partial class frmNewRec : Form
    {
        const char DASHY = '-'; // it kinda looks like a face
        public frmNewRec()
        {
            InitializeComponent();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Clear(); // clears id box
            txtName.Clear(); // clears author box
            txtCopies.Clear(); // clears copy box
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // closes current form
        } 

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string id; // holds ISBN
            int dashLoc, cops ; // holds dash location
            bool isIdBad=false; // id accurate?
            bool isCopNumYeet = true; // is copies accurate? yeet=good btw
            char let; // holds let
            if (string.IsNullOrEmpty(txtID.Text) || // is Id empty
                string.IsNullOrEmpty(txtName.Text) ||// is name empty
                string.IsNullOrEmpty(txtCopies.Text)) // is copies empty
                MessageBox.Show("Please fill in all data", "Null data error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            else
            {
                id = txtID.Text; // get id
                if (id.Length == 7) // check id length
                {

                    try
                    {
                     dashLoc = id.IndexOf(DASHY); // try to find dash
                        // takes out dash for testing
                   id = id.Substring(0, dashLoc) + id.Substring(dashLoc+1);

                        for (int i = 0; i < id.Length; i++)
                        {// runs through chars to make sure they're numbers
                            let = Convert.ToChar(id.Substring(i, 1));
                            isIdBad = !char.IsDigit(let);

                            // if id is bad ends here otherwise continue
                            if (isIdBad == true)
                            {
                             MessageBox.Show(let + " is not a number", 
                                 "Invalid data",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                             i = 7;
                            } // end if

                        } // end for chars

                        // if duplicate don't add
                        if(true==frmParent.data.Find(txtID.Text))
                        {
                            isIdBad = true; // lets user know if dup
                      MessageBox.Show(txtID.Text+" is already in database",
                                 "Invalid data",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                        } // end if for found or not

                    } // end id try
                    catch (Exception ex)
                    {
                        isIdBad = true; // lets user know if invalid
                     MessageBox.Show("Invald ID, are you forgetting the '-'"
                            ,"Input error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    } // end id catch

                    try
                    {// checks copies to make sure its a real number
                        cops=Convert.ToInt32(txtCopies.Text);
                        // if less than 0 or greater than
                        if (cops < 0 || cops > 255)
                        {
                            // lets user know if too big/small
                            MessageBox.Show(txtCopies.Text +
                               " is out of range", "Invalid data",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                            isCopNumYeet = false; // set false
                        } // end if for range

                    } //checks for num
                    catch(Exception ex) // if not num error
                     {
                            MessageBox.Show(txtCopies.Text +
                                " is not a number", "Invalid data",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                            isCopNumYeet = false; // not yeet 
                     } // end catch for copies

                    // if any errors don't add
                    if (isCopNumYeet == true && isIdBad == false)
                    { // stores information in a record                    
                        frmParent.item.ISBN = txtID.Text;
                        frmParent.item.authorName= txtName.Text;
                        frmParent.item.numOwned =
                            (byte)Convert.ToInt32(txtCopies.Text);
                        frmParent.item.numOnLoan = 0;

                        // inserts record into the database
                        frmParent.data.Insert(frmParent.item);
                        // lets user know if successful
                      MessageBox.Show(txtCopies.Text+" Copies of "+txtID.Text
                        +" by: " + txtName.Text+" was added", "Success!",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    } // ends if any errors
                                                            
             } // end is id 7
                else//lets user know if in valid id from start(short circuit)
                    MessageBox.Show("Invald ID",  "Input error",
                                               MessageBoxButtons.OK,
                                               MessageBoxIcon.Error);
            } // end non empty else

        } // end button

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    } // end main

} // end namspace
