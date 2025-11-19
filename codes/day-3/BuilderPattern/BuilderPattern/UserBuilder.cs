namespace BuilderPattern
{
    public class UserBuilder : IBuilder
    {
        private readonly User _user = new();

        public User Build()
        {
            return _user;
        }

        public IBuilder SetAddress(string address)
        {
            _user.Address = address;
            return this;
        }

        public IBuilder SetEmail(string email)
        {
            _user.Email = email;
            return this;
        }

        public IBuilder SetName(string name)
        {
            _user.Name = name;
            return this;
        }

        public IBuilder SetRole(string role)
        {
            _user.Role = role;
            return this;
        }
    }
}
