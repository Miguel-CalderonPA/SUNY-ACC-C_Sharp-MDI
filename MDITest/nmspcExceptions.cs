using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nmspcItemRec;

namespace nmspcExceptions
{
    class RetrieveOnEmptyException : Exception
    {
        public RetrieveOnEmptyException(/*in*/ string mess)
            :base(mess)
        {
            
        }
        public override string ToString()
        {
            return Message.ToString();                                 //base.ToString();
        }
    }





    class ListIsFullException : Exception
    {
        public ListIsFullException(/*in*/ string mess)
            : base(mess)
        {

        }
        public override string ToString()
        {
            return Message.ToString();                                 //base.ToString();
        }
    }


    class DuplicateKeyException : Exception
    {
        public DuplicateKeyException(/*in*/ string mess)
            : base(mess)
        {

        }
        public override string ToString()
        {
            return Message.ToString();                                 //base.ToString();
        }
    }


    class CurrPosOutofRangeException : Exception
    {
        public CurrPosOutofRangeException(/*in*/ string mess)
            : base(mess)
        {

        }
        public override string ToString()
        {
            return Message.ToString();                                 //base.ToString();
        }
    }




}
