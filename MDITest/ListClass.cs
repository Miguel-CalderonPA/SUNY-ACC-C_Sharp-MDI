/*
Author: das ist mich (Miguel Calderon)
Date: 3/29/2011 <- Packers won the super bowl a month prior
Modifications: 
Date Modified: Dec 2018

Purpose: This specification contains the basis for an unordered list class. 
It currently contains a maximum of 125 elements. It allows for list
insertions, deletions, and looks ups. It contains 13 public methods and 
3 private data members. A summary of the public methods appears below.
 
Assumptions:
	1) List can contain a maximum of 125 elements
  2) a)Client will supply  the definition for ItemRec.
     b)ItemRec will contain an integer field called key that will be used to 
       search the list(determine equality of elements)
     c) An example of an ItemRec appears below
          // Definition of List Element
            struct ItemRec
            {
                public int key;
               //other stuff ~ completed by client

          };
Summary of Methods
ListClass() -- initializes list object
ListClass(ListClass orig) - creates a deep copy of orig
IsEmpty()   -- indicates whether or not the list is empty
IsFull()    -- indicates whether or not the list is full
Insert(ItemType item)  -- Inserts the speicifed item at the end of the list
Find(ItemType item) -- Finds specified item (sets currPos) returns true if 
					  found false otherwise
Delete()    --Deletes the item specified by currPos
FirstPosition() -- moves currpos to the beginning of the list
NextPosition()  -- moves currPos to the next position in the list
EndOfList()     -- determines if currPos is at the end of the list
Retrieve()      -- returns the list element specified by currPos
GetLength()  -- provides the number of items in the list
 Clear()         -- Clear the list and restores it to its initial state	: 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nmspcItemRec;         // Client has access to the definition of ItemRec
using nmspcExceptions;                           // The list can be used for any type of item.
using System.IO;

namespace nmspcListClass

{
   public class ListClass
    {

        public const int MAX_ELEMENTS = 50;                            //maximum # of slots in the list



        //PRIVATE DATA MEMBERS
        protected ItemRec[] listArr = new ItemRec[MAX_ELEMENTS];
        int numItems;       // The # things in the list rn
        protected int currPos;        // The current position in the list

        //PUBLIC METHODS

        //Purpose:  Initializes a list object to an empty list
        //Pre:		List has been instantiated
        //Post:		list's length is 0 and currPos is 0;
        public ListClass()
        {
            listArr = new ItemRec[MAX_ELEMENTS];
            currPos = 0;
            numItems = 0;
        }


        //Purpose:	Create a deep copy of the list
        //Pre:		List has been instantiated and orig contains list to be copied
        //Post:		An identical, deep copy of the list has been created.
        public ListClass(ListClass orig)
        {
            listArr = new ItemRec[MAX_ELEMENTS];
            for (int i = 0; i < orig.numItems; i++)
            {
                listArr[i] = orig.listArr[i];
                currPos = orig.currPos;
                numItems = orig.numItems;
            }


        }



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //Purpose:	Indicates whether or not the list is empty
        //Pre:		List has been instantiated
        //Post:		Returns true if list is empty and false, otherwise
        public bool isEmpty()
        {
            if (numItems == 0)
            {
                return true;
            }
            else
                return false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



        //Purpose:	Indicates whether or not the list is full
        //Pre:		List has been instantiated
        //Post:		Returns true if list is full and false, otherwise
        public bool isFull()
        {
            if (numItems == MAX_ELEMENTS)
            {
                return true;
            }
            else
                return false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //Purpose:	Inserts item into the list
        //Pre:		List is not full
        //Post:		Item has been inserted at the end of the current list and length has 
        //          been modified
        //Exceptions Thrown:
        //          Throws duplicate key exception if key exists within list
        //          Throws out of memory exception if list is full
        public void Insert(ItemRec newItem)
        {
            if (!isFull())
            {
                // check to see if the key is already in the list:
                if (Find(newItem.ISBN))
                    throw new DuplicateKeyException("Key Value is already in the list");
                else
                {
                    listArr[numItems] = newItem;
                    numItems++;
                }
            }
            else
                throw new ListIsFullException("The list is full!");
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //Purpose:  Deletes an item from the list
        //Pre:		Method Find has been called to find the item to delete, and 
        //          that item is in the list. CurrPos now points at the item to be deleted.
        //Post:		The item denoted by currPos has been deleted from the list, length has
        //          been updated.
        public void Delete()
        {
            if (numItems > 0)
            {
                for (int i = currPos; i < numItems; i++)
                    listArr[i] = listArr[i + 1];

                numItems--;
            }
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



        //Purpose:  Moves to the beginning of the list
        //Pre:		List has been instantiated
        //Post:		currPos has been set to the first position in the list
        public void FirstPos()
        {
            currPos = 0;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //Purpose:	Moves to the next element in the list
        //Pre:		List has been instantiated
        //Post:		currPos has been moved to the next position in the list
        public void NextPos()
        {
            if (currPos < MAX_ELEMENTS - 1)
                currPos++;
            else
                throw new CurrPosOutofRangeException("End of list reached.");
            /*Error: Exceed the bounds*/
        }



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //Purpose:	Determines if currPos is at the end of the list
        //Pre:		List has been instantiated
        //Post:		Returns true if currPos is at the end of the list, and false, otherwise
        //          end-of-list denotes the first empty index in the list.
        public bool EndofList()
        {
            if (currPos == numItems)
                return true;
            else
                return false;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public bool Find(string target)
        {




            //Purpose:	Determines whether or not item is in the list
            //Pre:		item is assigned a value
            //Post:		If item is in the list then true is returned  and currPos contains
            //                the index of the item in the list, otherwise, 
            //                false is returned and currPos is at the first empty index in the list 
            //                unless the list is full when it will be set to the end of the list.
            //

            bool found = false;
            currPos = 0;

            while (currPos < numItems && !found)
            {
                if (target == listArr[currPos].ISBN)
                {
                    found = true;
                }
                else
                {
                    currPos++;
                }

            }


            return found;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //Purpose:	Returns the current item in the list(denoted by currPos)
        //Pre:		EndOfList is false
        //Post:		Returns the item at currPos
        public ItemRec Retrieve()
        {
            ItemRec t = listArr[currPos];
            // check the number of items
            if (numItems == 0)
                // error: retrieve from empty
                throw new RetrieveOnEmptyException("Nichts zu retrieve");
            else
            {
                if (!EndofList())
                    return (listArr[currPos]); // return found position
                else
                    return t; // return current
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //Purpose: provides the number of items in the list
        //Pre: List has been instantiated
        //Post: The number of items in the list has been returned
        public int GetLength()
        {
            return numItems; // returns pdm
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //Purpose: Clears the list
        //Pre: List has been instantiated
        //Post: List has been restored to its initial condition
        public void Clear()
        {
            numItems = 0;
            currPos = 0;
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //Purpose: combines two lists
        //Pre: List has been instantiated
        //Post: List has been restored to its initial condition
        public static ListClass operator +(/*in*/ListClass leftOp,
                        /*in*/ListClass rightOp)
        {
            ListClass union = new ListClass(leftOp);
            ItemRec item;
            string target;
            bool found;

            rightOp.FirstPos(); // first pos of rightop
            union.FirstPos(); // first pos of union

            while (!rightOp.EndofList()) // while your not at end of list
            {
                item = rightOp.Retrieve();
                target = item.ISBN;
                found = false;

                for (int uLength = 0; uLength < union.GetLength(); uLength++)
                {
                    if (union.Find(target) == true)
                    {
                        found = true;
                        uLength = union.GetLength();
                    }
                    union.NextPos();
                } // end for loop for rightop

                if (found == false)
                {
                    union.Insert(rightOp.Retrieve());
                } // end if for found
                rightOp.NextPos();
            } // end while
            return union;
        } // end union
          //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //Purpose: combines two lists
        //Pre: List has been instantiated
        //Post: List has been restored to its initial condition
        public static ListClass operator -(/*in*/ListClass leftOp,
                        /*in*/ListClass rightOp)
        {
            ListClass diff = new ListClass(leftOp);
            ItemRec item;
            string target;
            bool found;

            rightOp.FirstPos(); // first pos of rightop
            diff.FirstPos(); // first pos of diff

            while (!rightOp.EndofList()) // while your not at end of list
            {
                item = rightOp.Retrieve();
                target = item.ISBN;
                found = false;

                for (int uLength = 0; uLength < diff.GetLength(); uLength++)
                {
                    if (diff.Find(target))
                    {

                        uLength = diff.GetLength();
                        diff.Delete();
                    }
                    diff.NextPos();
                } // end for loop for rightop

                rightOp.NextPos();
            } // end while
            return diff;
        } // end diff


        //Purpose: compares two list to see if they're the same
        //Pre: List has been instantiated
        //Post: List has been restored to its initial condition
        public static bool operator ==(/*in*/ListClass leftOp,
                      /*in*/ListClass rightOp)
        {
            ItemRec item;
            string target;
            bool dupe;
            if (rightOp.GetLength() == leftOp.GetLength()) // test size
            {
                rightOp.FirstPos(); // first pos of rightop
                leftOp.FirstPos(); // first pos of leftop
                dupe = true; // assume true
                // while your not at end of list
                while (!rightOp.EndofList() && dupe == true)
                {// why is it going a second time
                    item = rightOp.Retrieve();
                    target = item.ISBN;
                    // goes through each element to compare until result
                    for (int lLength = 0; lLength < leftOp.GetLength(); lLength++)
                    {// checks to see if that item is in list
                        if (leftOp.Find(target) == false)
                        {// if not duplicate then dupe=false
                            dupe = false;
                            lLength = leftOp.GetLength();// ends loop
                        }
                        leftOp.NextPos(); // next pos in leftop
                    } // end for loop for rightop
                    rightOp.NextPos(); // next pos in rightop
                } // end while
            } // ends if (same size)
            else
            {
                dupe = false;
            }
            return dupe; // returns dupe
        } // end == operator

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //Purpose: compares two list to see if not the same by
        // taking == and notting it
        //Pre: List has been instantiated
        //Post: List has been restored to its initial condition
        public static bool operator !=(/*in*/ListClass leftOp,
                     /*in*/ListClass rightOp)
        {
            return !(leftOp == rightOp);
        } // end != operator
          //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    } // end list class

} // end namespace


