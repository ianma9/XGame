using prmToolkit.NotificationPattern;

namespace XGame.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email()
        {

        }
        public Email(string address)
        {
            Address = address;
            new AddNotifications<Email>(this).IfNotEmail(x => x.Address);
        }
        public string Address { get; private set; }
    }
}
