/* Name: Miguel Calderon

* Date: 12/11/18

* File Name: ListClassWLib

* Purpose:This specification contains the basis for an unordered child of. 
ListClass. It currently contains a maximum of 50 elements. It has access to 
ListClass functions and PDMs. It contains 8 public methods and 
1 private data member. 

A summary of the public methods appears below:
Two Constructos : A default and non-default
StoreData(): Stores starting database
2 LibStatus(): updates database and prints reports (an overide for default)
ErrorChecker(): checks incoming file for all errors
2 PrintCurrentData(): One prints for next day, other for today only

* Inputs: A file can be assigned, but has built in default names

* Outputs: Multiple reports with information about stored info plus errors

* Error Checking: Has entire function dedicated to errors

* Assumptions: American Currency of Dollars (DOLLAH) and Listclass assumptions
*/
using System;
using System.Collections.Generic;
using System.Linq;              
using System.Text;
using System.Threading.Tasks;
using nmspcItemRec;
using nmspcListClass;
using System.IO;
using System.Windows.Forms;

namespace nmSpcLibClass
{
  public class LibClass : ListClass
    {
        // set contants
        const string EOF = null; // null
        const byte ZERO = 0; // byte zero
        const int ONE = 1; // int one
        const byte OREO = 1; // a bite of one
        const byte WEEK = 7; // byte seven
        const char DOLLAH = '$'; // \$_$/
        const decimal OD = .10m; // Two sense 5 times
        const char SPACE = ' '; // space
        const char DASH = '-'; // a dash
        const char NEWLINE = '\n'; // new line
        const char COMMA = ','; // comma
        const string DATABASE = "Books.in"; // inputfile for database
        const string UPDATED = "Books.out";// output file for updated database
        const string TODAY = "Today.out"; // outputs todays changes
        const string UPDATES = "InOut.dat";// inputfile for updated database
        const string REPORTS = "LoanReturn.out";// output file for reports

        int numBooks; // num books


        //PUBLIC METHODS

        public LibClass()
        {
            /*
            Purpose:  default lib class based on constant
            Pre:		ListClass has been inherited
            Post:   uses default file to store data
            */
            StoreData(DATABASE);// stores data in main list      
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public LibClass(string inputFile)
        {
            /*
            Purpose: non-default lib class based on file given
            Pre:	listclass has been inherited
            Post: uses file given by user to store data
            */
            StoreData(inputFile); // stores data in main list
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void StoreData(string inputFile)
        {
            /*
             *Purpose: Stores data into records
             *Pre: needs the file books to a record
             *Post: fills a list of structs (records)
             */

            // variables
            StreamReader sr; // reader
            string info, fName, lName; // holds lines of record info, and names
            int spcLoc;
            int pos = 0;
            numBooks = 0; //intialize pdm counter
            sr = new StreamReader(inputFile); // opens file
            info = sr.ReadLine(); // read next line of file         
            while (info != EOF) // while not end of file
            {
                ItemRec BookRec = new ItemRec(); // creates new record

                spcLoc = info.IndexOf(SPACE); // gets space location
                BookRec.ISBN = info.Substring(pos, spcLoc); // gets book id
                info = info.Remove(pos, spcLoc + ONE); // whittles down info

                spcLoc = info.IndexOf(SPACE);// gets space location
                fName = info.Substring(pos, spcLoc); // get first name
                info = info.Remove(pos, spcLoc + ONE);// whittles down info

                spcLoc = info.IndexOf(SPACE);// gets space location
                lName = info.Substring(pos, spcLoc); // get last name
                info = info.Remove(pos, spcLoc + ONE);// whittles down info

                BookRec.authorName = fName + SPACE + lName; // finds name
                spcLoc = info.IndexOf(SPACE);// gets space location

                // gets # of owned books
                BookRec.numOwned = Convert.ToByte(info.Substring(pos, spcLoc));
                info = info.Remove(pos, spcLoc + ONE);// whittles down info

                // gets # of loaned books
                BookRec.numOnLoan = Convert.ToByte(info.Substring(pos));

                this.Insert(BookRec); // inserts to main list
                numBooks++; // adds to num books
                info = sr.ReadLine(); // read next line of file     
            } // end while
        } // end store data

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void LibStatus()
        {
            LibStatus(UPDATES);
        }
            public void LibStatus(string updateFile)
        {
            /*
             *Purpose: updates database
             *Pre: needs to be called and a database to manage
             *Post: an updated database, along with lists of returned, loaned
             * nonChanged and overdue books
             */
            // variables
            StreamReader sr; // reader
            StreamWriter sw; // writer
            string info, let, fName, lName; // string variables
            int spcLoc,changes=0, pos = 0; // int variables
            byte errorLine = 1, ODs = 0, numDays; // byte variables
            decimal price; // decimal variable
            bool PraiseBe = true; // bool variable
            ItemRec BookRec = new ItemRec(); // creates new record to store
            //intialize lists plus one parallel array
     ListClass returnList = new ListClass(), loanedList = new ListClass(),
            nonLRList = new ListClass(), ODBook = new ListClass();
            decimal[] ODPrice = new decimal[numBooks];

            sr = new StreamReader(updateFile); // opens file
            info = sr.ReadLine(); // read next line of file     
            // while not end of file and no errors
            while (info != EOF && PraiseBe == true) 
            {
                if (ErrorChecker(info, errorLine) == !PraiseBe) // if not errors
                {
                    spcLoc = info.IndexOf(SPACE); // finds space location
                    BookRec.ISBN = info.Substring(pos, spcLoc); // sets ID
                    this.Find(BookRec.ISBN); // gets record and sets currPos

                    info = info.Remove(pos, spcLoc + ONE); // wittleing info
                    spcLoc = info.IndexOf(SPACE); // finds space location
                    if (spcLoc == -1) // if no more data
                        let = info; // set whats left
                    else
                        let = info.Substring(ZERO, ONE); // grab needed let

                    changes++;
                    if (let == "L" || let == "l") // if loaned
                    {// adds one to loaned if loaned out
                        this.listArr[currPos].numOnLoan =
                            (byte)(this.listArr[currPos].numOnLoan + OREO);
                       // this.Insert(BookRec); // adds it back to main list
                        // if not in list already add it
                        if (loanedList.Find(this.listArr[currPos].ISBN)==false)
                            loanedList.Insert(this.listArr[currPos]);
                    } // end if

                    else if (let == "R" || let == "r") // if returned
                    {// subtracts one from loaned if returned
                        this.listArr[currPos].numOnLoan =
                            (byte)(this.listArr[currPos].numOnLoan - OREO);
                       // this.Insert(BookRec); // adds it back to main list
                        // if not in list already add it
                        if (returnList.Find(this.listArr[currPos].ISBN)==false)
                            returnList.Insert(this.listArr[currPos]);
                    } // end else if

                    spcLoc = info.IndexOf(SPACE);// finds space location
                    if (spcLoc == -1) // if end
                        numDays = ZERO; // add whats left
                    else
                    { // whittle info and grab days its been loaned
                        info = info.Remove(pos, spcLoc + ONE);
                        numDays = Convert.ToByte(info.Substring(pos));

                        if (numDays > WEEK) // if numdays is overdue
                        {
                            price = numDays * OD; // multiply price by days
                            // if not on list already add it
                            if (ODBook.Find(this.listArr[currPos].ISBN)==false)
                            {
                                ODBook.Insert(this.listArr[currPos]);
                                ODPrice[ODs] = price; // adds price
                                ODs++; // price postion to keep parallel
                            }
                        } // end 

                    } // end else   
                   
                } // end checker
               
                 errorLine++; // count line
                info = sr.ReadLine(); // read next line of file     
            } // end while
            sr.Close(); // closes reader
            sw = new StreamWriter(REPORTS); // open output file

            //~~~~~~~~~~~~~~~~~

            // 1st report runs through returned list and prints each
            sw.WriteLine("1st Report: Returned");
            sw.WriteLine(" ISBN: " +
           String.Format("   {0,-20}", "Lastname, Firstname")
             + SPACE + "# in Library");
            returnList.FirstPos(); // sets first position
            for (int book = 0; book < returnList.GetLength(); book++)
            {
                BookRec = returnList.Retrieve(); // gets record
                spcLoc = BookRec.authorName.IndexOf(SPACE);// gets space loc
            // gets first name then last name and prints need information
                fName = BookRec.authorName.Substring(pos, spcLoc); 
                lName = BookRec.authorName.Substring(spcLoc + ONE) + COMMA;
                sw.WriteLine(BookRec.ISBN + 
              String.Format("   {0,-20}", (lName + SPACE + fName))
              + SPACE + (BookRec.numOwned - BookRec.numOnLoan).ToString());
                returnList.NextPos(); // next position
            } // end returned list
            sw.WriteLine(); // space

            //~~~~~~~~~~~~~~~~~

            // 2nd report runs through loaned list and prints each
            sw.WriteLine("2nd Report: Loaned");
sw.WriteLine(" ISBN: " + String.Format("   {0,-20}", "Lastname, Firstname")
             + SPACE + "# in Library");
            loanedList.FirstPos(); // sets first position
            for (int book = 0; book < loanedList.GetLength(); book++)
            {
                BookRec = loanedList.Retrieve();// gets record
                spcLoc = BookRec.authorName.IndexOf(SPACE);// gets space loc
                // gets first name then last name and prints need information
                fName = BookRec.authorName.Substring(pos, spcLoc);
                lName = BookRec.authorName.Substring(spcLoc + ONE) + COMMA;
                sw.WriteLine(BookRec.ISBN +
              String.Format("   {0,-20}", (lName + SPACE + fName))
              + SPACE + (BookRec.numOwned - BookRec.numOnLoan).ToString());
                loanedList.NextPos(); // goes to next position
            } // end loaned list
            sw.WriteLine(); // space

            //~~~~~~~~~~~~~~~~~

            // 3rd report runs through unchanged list and prints each
            sw.WriteLine("3rd Report: Unchanged");
            nonLRList = this - loanedList; // subtracts l list elements
            nonLRList = nonLRList - returnList; // subtracts r list elements
            sw.WriteLine(" ISBN: " + 
          String.Format("   {0,-20}", "Lastname, Firstname")
             + SPACE + "# in Library");
            nonLRList.FirstPos(); // sets first position
            for (int book = 0; book < nonLRList.GetLength(); book++)
            {
                BookRec = nonLRList.Retrieve();// gets record
                spcLoc = BookRec.authorName.IndexOf(SPACE);// gets space loc
                // gets first name then last name and prints need information
                fName = BookRec.authorName.Substring(pos, spcLoc);
                lName = BookRec.authorName.Substring(spcLoc + ONE) + COMMA;
                sw.WriteLine(BookRec.ISBN + 
              String.Format("   {0,-20}", (lName + SPACE + fName))
              + SPACE + (BookRec.numOwned - BookRec.numOnLoan).ToString());
                nonLRList.NextPos(); // goes to next position
            } // ends unchanged list
            sw.WriteLine(); // space

            //~~~~~~~~~~~~~~~~~

            // 4th report runs through OD list and array and prints each
            sw.WriteLine("4th Report: Overdue");
            sw.WriteLine(" ISBN: " +
           String.Format("   {0,-20}", "Lastname, Firstname")
             + SPACE + "# in Library" + " Money Owed:");
            ODBook.FirstPos(); // sets first position
            for (int book = 0; book < ODBook.GetLength(); book++)
            {
                BookRec = ODBook.Retrieve();// gets record
                spcLoc = BookRec.authorName.IndexOf(SPACE);// gets space loc
              // gets first name then last name and prints need information
                fName = BookRec.authorName.Substring(pos, spcLoc);
                lName = BookRec.authorName.Substring(spcLoc + ONE) + COMMA;
                sw.WriteLine(BookRec.ISBN + 
               String.Format("   {0,-20}", (lName + SPACE + fName))
              + SPACE + (BookRec.numOwned - BookRec.numOnLoan).ToString() + 
              String.Format("{0,17}", (ODPrice[book].ToString("c"))));
                ODBook.NextPos(); // goes to next position
            } // end overdue list report

            sw.Close(); // close file writer
            PrintCurrentData(changes); // prints updated database

        } // end lib status

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private bool ErrorChecker(string info, int errorLine)
        {
            /*
            *Purpose: checks input file for errors
            *Pre: needs line to check
            *Post: a rigorous test for errors
            */
            // variables
       
            bool error = true; // sets error to true
            int pos = 0, spcLoc; //intialize int variables
            string target; // intialize string variable
            ItemRec ValidRec = new ItemRec(); // storing record to check

            spcLoc = info.IndexOf(SPACE); // finds position of space
            target = info.Substring(pos, spcLoc); // finds target
            info = info.Remove(pos, spcLoc + ONE); // deletes checked info
            // checks for valid id
            if (target.Length != 7) // if not equal 7 its incorrect
            {
                MessageBox.Show("Incorrect Length of ISBN, How is ISBN " + target.Length + 
               " long? Line " + errorLine, "Invalid Record",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);


               /* Console.WriteLine(String.Format("{0,-55}",
               "Incorrect Length of ISBN, How is ISBN " + target.Length + 
               " long") + "Line " + errorLine);*/
                return error; // ends function with error
            }
            else
            {
                // checks if exist
                if (this.Find(target) == false)
                {

                    MessageBox.Show("Book not found," +
               " We don't even own this book. Line " + errorLine, "Invalid Record",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);



                    /*  Console.WriteLine(String.Format("{0,-55}", "Book not found," +
                 " where did you get this knowledge?,") + "Line " + errorLine);*/
                    return error;  // ends function with error
                }
                else
                {
                    // checks for valid label
                    spcLoc = info.IndexOf(SPACE); // finds space location
                    if (spcLoc == -1) // if no more data just take whats left
                        target = info; // gets target
                    else // if more data take up to certain point
                        target = info.Substring(ZERO, ONE);

                    switch (target) // swtich based on target
                    {
                        case "L": break;
                        case "l": break;
                        case "R": break;
                        case "r": break;
                        default:
                            MessageBox.Show("Book has invalid label " + target+ ',' + " Line "
                       + errorLine, "Invalid Record",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);


                            /*Console.WriteLine(String.Format("{0,-55}",
                    "I have no idea why you typed " + target+ ',') + "Line "
                       + errorLine);*/
                            return error; // if not L,l,R,r. error
                    } // end switch

                    ValidRec = this.Retrieve(); // gets rec
                    // checks
                    if (target == "L" || target == "l")
                    {// adds one to loan if loaned out
                    ValidRec.numOnLoan = (byte)(ValidRec.numOnLoan + OREO);
                        // checks if they're books to be loaned
                        if (ValidRec.numOnLoan > ValidRec.numOwned)
                        {
                            MessageBox.Show("Not enough copies!, " +
                       " We have more on loan than total owned, Line " + errorLine, "Invalid Record",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);



                            /*Console.WriteLine(String.Format("{0,-55}",
                           "Not enough copies!," +
                       " we're stealing knowledge!,")+ "Line "+ errorLine);*/
                            return error;
                        }
                    } // end if
                    // checks if book is being returned
                    else if (target == "R" || target == "r")
                    {// subtracts one from loaned if returned
                    ValidRec.numOnLoan = (byte)(ValidRec.numOnLoan - OREO);
                        // if loan is less than 0 it's error
                      if (ValidRec.numOnLoan == 255) //bytes go from 0-1=255
                        {
                            MessageBox.Show("No copies on were on loan to begin with. How did we get another? , Line "
                                + errorLine, "Invalid Record",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);



                            /* Console.WriteLine(String.Format("{0,-55}",
                        "No copies on loan, who's stealing knowledge?!,") +
                            "Line " + errorLine);*/
                            return error; // wasn't going to replace entire code
                        }
                    } // end else if

                } // end found else

            } // end length else

            // if all goes well there are no errors
            error = false; //only sets error to false after rigorious testing
            return error; // returns no error
        } // end checker

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void PrintCurrentData()
        {
            /*
             *Purpose: Prints Changed database for tomorrow's use
             *Pre: needs a database to print
             *Post: prints database
             */        
            ItemRec BookRec = new ItemRec(); // creates new record to store
            StreamWriter sw; // intialize writer
     sw = new StreamWriter(UPDATED); // opens up writer for updated database
            // runs through main list and prints each
         
            this.FirstPos();
            for (int book = 0; book < this.GetLength(); book++)
            {
                BookRec = this.Retrieve();// gets record              
               sw.WriteLine(BookRec.ISBN + SPACE + BookRec.authorName + SPACE
       + BookRec.numOwned.ToString() + SPACE + BookRec.numOnLoan.ToString());
                this.NextPos(); // goes to next position
            } // ends main list
            sw.Close(); // end writer
        } // end PrintCurrData
          //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void PrintCurrentData(int changes)
        {
            /*
            *Purpose: Prints Changed database for today report
             *Pre: needs a database to print
             *Post: prints database that outlines today only
             */
            ItemRec BookRec = new ItemRec(); // creates new record to store
            StreamWriter sw; // intialize writer
            sw = new StreamWriter(TODAY); // opens up writer for updated database
            // runs through main list and prints each
            sw.WriteLine("Updated Database: " + numBooks.ToString()
                + " Books with " + changes + " changes today");
            sw.WriteLine();
            sw.WriteLine("ISBN:   " + "Fullname " + "# Own/Loan ");
            this.FirstPos();
            for (int book = 0; book < this.GetLength(); book++)
            {
                BookRec = this.Retrieve();// gets record              
                sw.WriteLine(BookRec.ISBN + SPACE + BookRec.authorName + SPACE
        + BookRec.numOwned.ToString() + SPACE + BookRec.numOnLoan.ToString());
                this.NextPos(); // goes to next position
            } // ends main list
            sw.Close(); // end writer
        } // end PrintCurrData
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    } // end LibClass
} // end namespace