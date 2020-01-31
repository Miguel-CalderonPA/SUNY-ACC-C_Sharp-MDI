using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nmspcExceptions;
using nmspcItemRec;
using nmspcListClass;
using nmSpcLibClass;
using System.IO;

namespace MDITest
{

    public partial class frmParent : Form
    {
        public static ListClass l1 = new ListClass();//temp list for all forms
        public static LibClass data = new LibClass();// temp lib list for all
        public static ItemRec item = new ItemRec(); // temp holder of item

        public frmParent()
        {
            InitializeComponent();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            frmAbout ab1 = new frmAbout();// creates a new instance:         
            ab1.MdiParent = this;  // set the parent:           
            ab1.Show();// show child
        } // end about click

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // closes parent
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade); // set layout cascade
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

   private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical); // set layout vertical
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

   private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal); // set layout horizontal
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons); // set layout arrange 
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // closes the active child if there is one:
            if(ActiveMdiChild!=null)
            ActiveMdiChild.Close(); // close current child
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while(ActiveMdiChild != null) // runs through all children
                ActiveMdiChild.Close();// close child
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {//update file
            frmUpdate_Print add1 = new frmUpdate_Print(); // create instance
            add1.MdiParent = this; // set parent
            add1.Show(); // set child
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

     private void showListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowList show1 = new frmShowList(); // create instance
            show1.MdiParent = this; // set parent
            show1.Show(); // set child
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

   private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewData new1 = new frmNewData(); // create instance
            new1.MdiParent = this; // set parent
            new1.Show(); // show child
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

private void sentToOutputFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParent.data.PrintCurrentData(); // print database to file
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

  private void newRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewRec rec1 = new frmNewRec(); // create instance
            rec1.MdiParent = this; // sets parent
            rec1.Show(); // show child
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

  private void directionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDirect dir1 = new frmDirect(); // creates instance
            dir1.MdiParent = this; // sets parent
            dir1.Show(); // show child
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void frmParent_Load(object sender, EventArgs e)
        { // simply joke of the day  messages boxes
       MessageBox.Show(" 11111111: Are you ill?\n 11111110: No, just feeling a bit off.",
                "Daily Joke", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
     /* Made for a specific person
  MessageBox.Show("They're pretty good, but they don't have the gig just yet",
               "Joke of the Day", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
      MessageBox.Show("You can laugh, it's okay",
              "Joke of the Day", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
      MessageBox.Show("Still thinking about it huh?",
              "Joke of the Day", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
      MessageBox.Show("That's okay, I didn't get it at first either",
             "Joke of the Day", MessageBoxButtons.OK,
             MessageBoxIcon.Information); */
        } // end parent form
    } // end form
} // end namespace
