using ContactApp.Enum;

namespace ContactApp.EventArg
{
    public class PhoneCellArgs : System.EventArgs
    {
        public string PhoneNumber { get; private set; }
        public EnumEvent EnumEvent { get; private set; }
        public PhoneCellArgs(string phoneNumber, EnumEvent enumEvent)
        {
            PhoneNumber = phoneNumber;
            EnumEvent = enumEvent;
        }
    }
}
