/* Name: Miguel Calderon

* Date: 12/14/18

* File Name: frmShowList

* Purpose:shows current list and can be refreshed

* Inputs:just shows database, but events can cause input

* Outputs: current database

* Error Checking: not really

* Assumptions: they want to see the database
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
    public partial class frmShowList : Form
    {
        const char SPACE = ' '; //a space
        const string AD = "Coca Cola"; // the ad, but pics would need changing

        bool ads; // bool for showing ads
        int count; // counts rotation of ad clicking
        public frmShowList()
        {
            InitializeComponent();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void frmShowList_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide(); // hide first pic
            pictureBox2.Hide(); // hide second pic
            pictureBox3.Hide(); // hide third pic
            pictureBox4.Hide(); // hide fourth pic
            btnRefreshed.Hide(); // hide end ad button
            grpBxAd.Hide();// hide ad question
            btnExit.Hide(); // hide escape mwahaha
     
            // prints current database at the time of loading
            lbxDat.Items.Add("Current Database:");
            lbxDat.Items.Add('\n') ;
             lbxDat.Items.Add("ISBN:   " + "Fullname " + "# Own/Loan ");
            frmParent.data.FirstPos(); // first pos
            while (!frmParent.data.EndofList())
            {      // repeats all elements in list and prints them
                  frmParent.item= frmParent.data.Retrieve();
                lbxDat.Items.Add(frmParent.item.ISBN + SPACE +
        frmParent.item.authorName + SPACE + frmParent.item.numOwned + SPACE
                + frmParent.item.numOnLoan);
                frmParent.data.NextPos(); // next pos


            } // end while
        } // end load

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ads = true ; // ads is true
            lbxDat.Hide(); // hide database
            btnRefresh.Hide(); // hide start of this event
            count = 1; // set count to 1
  MessageBox.Show("This REFRESH is brought to you by..." + AD,"Refreshing...",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Question);
            pictureBox1.Show(); // show first ad
            lbxDat.Items.Clear(); // clears the printed database
            // reprints current database
            lbxDat.Items.Add("Refreshed Database:");
            lbxDat.Items.Add('\n');
            lbxDat.Items.Add("ISBN:   " + "Fullname " + "# Own/Loan ");
            frmParent.data.FirstPos(); // first pos
            while (!frmParent.data.EndofList()) 
            {      // repeats all elements in list and print them
                frmParent.item = frmParent.data.Retrieve();
                lbxDat.Items.Add(frmParent.item.ISBN + SPACE +
 frmParent.item.authorName + SPACE + frmParent.item.numOwned + SPACE
                + frmParent.item.numOnLoan);
                frmParent.data.NextPos(); // next pos
            } // end while
        } // end refresh button

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnRefreshed_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide(); // hide ad 2
            grpBxAd.Hide(); // hide ad box
            lbxDat.Show(); // show new database
            btnRefreshed.Hide(); // hide end ad button
            btnRefresh.Show(); // show normal refresh
            btnExit.Show(); // show escapaaa
        } // end refreshed

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide(); // hide ad 2
            pictureBox3.Show(); // show ad 3
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide(); // hide ad 1
            pictureBox2.Show(); // show ad 2
           while(ads == false) // while first ads are done showing
            {
                grpBxAd.Show(); // show ad question

                if (rbLove.Checked) // if love is checked
                { // lets user know how thankful we are
        MessageBox.Show("This REFRESH was brought to you by..."
            + AD, "Refreshing...",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Question);
                    btnRefreshed.Show(); // show exit
                    ads = true; // end while
                } // end if checked
                else
                {
                    
                    ads = true; // end while
                    if (count < 11) // if you click 10x # of ads
                    {
              MessageBox.Show("No? Maybe a little later?", "Refreshing...",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Question);
                        count++; // count up
                    } // end if count
                    else
                    {
         MessageBox.Show("Fine...You'd be a good doctor", "Patients is Key",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Question);

                        btnRefreshed.Show(); // if they're patient show exit
                    } // end patience else
                } // end hate else            
            } // end while ads
        } // end picbox 1

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Hide(); // hide ad 3
            pictureBox4.Show(); // show ad 4
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Hide(); // hide ad 4
            pictureBox1.Show(); // show ad 1
           
            ads = false; // forces loop at ad 2
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // close form
        } // end exit

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    } // end main

} // end namespace
