/* Name: Miguel Calderon

* Date: 12/11/18

* File Name: Item Rec

* Purpose:stores item

* Inputs: nothing it is called

* Outputs: nothing its a shell

* Error Checking: none needed

* Assumptions: it will be used
*/
namespace nmspcItemRec
{

    public struct ItemRec
    {
        public string ISBN; // stores id
        public string authorName; // name
        public byte numOwned; //number owned
        public byte numOnLoan; // number loaned
    }; // end item

} // end namespace