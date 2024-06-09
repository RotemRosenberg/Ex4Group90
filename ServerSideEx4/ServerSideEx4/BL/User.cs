namespace ServerSideEx4.BL
{
    public class User
    {
        int id;
        string name;
        string email;
        string password;
        bool isAdmin;
        bool isActive;

        public User()
        {
        }

        public User(string name, string email, string password, bool isAdmin, bool isActive)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            IsActive = isActive;

        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public static List<User> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadUsers();
        }
        public int Register()
        {
            DBservices dbs = new DBservices();
            return dbs.RegisterUser(this);
        }
    }
}
