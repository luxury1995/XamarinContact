using System;
using Contacts;
using ContactsUI;

namespace ContactApp.iOS
{
    public class ContactPickerDelegate : CNContactPickerDelegate
    {
        #region Contructor
        public ContactPickerDelegate()
        {

        }
        public ContactPickerDelegate(IntPtr handle) : base(handle)
        {

        }
        #endregion
        #region overide method
        public override void ContactPickerDidCancel(CNContactPickerViewController picker)
        {
            base.ContactPickerDidCancel(picker);
            RaiseSelectedCancel();
        }
        public override void DidSelectContact(CNContactPickerViewController picker, Contacts.CNContact contact)
        {
            base.DidSelectContact(picker, contact);
        }
        public override void DidSelectContactProperty(CNContactPickerViewController picker, Contacts.CNContactProperty contactProperty)
        {
            base.DidSelectContactProperty(picker, contactProperty);
        }

        #endregion

        #region event
        public delegate void SelectCanceledDelegate();
        public event SelectCanceledDelegate selectcanceled;
        internal void RaiseSelectedCancel(){
            if(this.selectcanceled !=null){
                this.selectcanceled();
            }
        }

        public delegate void ContactSelectedDelegate(CNContact contact);
        public event ContactSelectedDelegate ContactSelected;

        internal void RaiseContactSelected(CNContact contact)
        {
            if (this.ContactSelected != null) this.ContactSelected(contact);
        }

        public delegate void ContactPropertySelectedDelegate(CNContactProperty property);
        public event ContactPropertySelectedDelegate ContactPropertySelected;

        internal void RaiseContactPropertySelected(CNContactProperty property)
        {
            if (this.ContactPropertySelected != null) this.ContactPropertySelected(property);
        }
        #endregion


    }

}
