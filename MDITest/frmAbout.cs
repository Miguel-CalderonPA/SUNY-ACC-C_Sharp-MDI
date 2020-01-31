/* Name: Miguel Calderon

* Date: 12/13/18

* File Name: frmAbout

* Purpose:shows about our great company

* Inputs: nope

* Outputs: nein

* Error Checking: ehh.

* Assumptions: Why does wilton have no food...others must be hungry
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDITest
{
    partial class frmAbout : Form
    {
        public frmAbout()
        {
            // changes in the default form box
            // no idea who this Microsoft guy is
            InitializeComponent();
            this.Text = String.Format("About {0}", "Library Books");
            this.labelProductName.Text = AssemblyProduct;
      this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
       this.labelCompanyName.Text = "Dustin dem Shelvs LLC.";// great company
            // great poem
            this.textBoxDescription.Text = "Books to the ceiling, " + '\n' +
                "Books to the sky, " + '\n' +
                "My piles of books are a mile high. " + '\n' +
                "How I love them! " + '\n' +
                "How I need them! " + '\n' +
                "I’ll have a long beard by the time I read them.";





        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return "3.14159265359...";
               // return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return "Shalom!"; //((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return "Dustin dem Shelvs LLC."; //((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close(); //closes form
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
