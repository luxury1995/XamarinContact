using ContactApp.Enum;

namespace ContactApp.EventArg
{
    public class AddressCellArgs : System.EventArgs
    {
        public string EmailAdress { get; set; }
        public EnumEvent EnumEvent { get; set; }
        public AddressCellArgs(string emailAdress, EnumEvent enumEvent)
        {
            EmailAdress = emailAdress;
            EnumEvent = enumEvent;
        }
    }
}
