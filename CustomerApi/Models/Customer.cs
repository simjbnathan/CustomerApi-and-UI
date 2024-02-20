namespace CustomerApi.Models
{
    // Customer.cs
    public class Customer
    {
        private int customerId;
        private string name;
        private string email;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public virtual void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {customerId}, Name: {name}, Email: {email}");
        }
    }

}
