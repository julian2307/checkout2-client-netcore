namespace CheckoutApi.Integration.Models
{
    public class Customer
    {
        public string ExternalCustomerReference { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string FiscalCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string[] ExistingCards { get; set; }
        public bool Enabled { get; set; }
        public bool Trial { get; set; }
        public string Language { get; set; }
        public string CustomerReference { get; set; }

    }
}
