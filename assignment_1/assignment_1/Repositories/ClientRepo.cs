using assignment_1.Data;
using assignment_1.Models;
using System.Linq;

namespace assignment_1.Repositories
{
    public class ClientRepo
    {
        private readonly ApplicationDbContext _context;

        public ClientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Client FindOne(int clientID)
        {
            return _context.Clients
                .Where(c => c.ClientID == clientID)
                .FirstOrDefault();
        }

        public Client FindExisting(string email, string firstName, string lastName)
        {
            return _context.Clients
                .Where(c => c.Email == email && c.FirstName == firstName && c.LastName == lastName)
                .FirstOrDefault();
        }

        public Client Create(string email, string firstName, string lastName)
        {
            Client existingClient = FindExisting(email, firstName, lastName);
            if (existingClient != null) return existingClient;
            if (email.Trim().Length < 5 || firstName.Trim().Length < 1 || lastName.Trim().Length < 1) return null;

            var client = new Client { Email = email, FirstName = firstName, LastName = lastName };
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client;
        }

        public bool Update(int clientID, string firstName, string lastName)
        {
            Client client = FindOne(clientID);
            if (client == null) return false;
            if (firstName.Trim().Length < 1 || lastName.Trim().Length < 1) return false;

            client.FirstName = firstName;
            client.LastName = lastName;
            _context.SaveChanges();
            return true;
        }
    }
}
