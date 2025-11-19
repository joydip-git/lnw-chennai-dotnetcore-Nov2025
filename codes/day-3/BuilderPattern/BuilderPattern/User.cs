namespace BuilderPattern
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Role: {Role}, Address: {Address}";
        }
    }
}
