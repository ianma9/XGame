using prmToolkit.NotificationPattern;

namespace XGame.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<Name>(this).IfNullOrInvalidLength(x => x.FirstName,3, 50, 
                "Between 3 and 50 characters!")
                .IfNullOrInvalidLength(x => x.LastName, 3, 50,
                "Between 3 and 50 characters!");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
