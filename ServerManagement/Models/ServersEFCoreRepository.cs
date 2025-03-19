using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ServerManagement.Components.Pages;
using ServerManagement.Data;

namespace ServerManagement.Models
{
    public class ServersEFCoreRepository : IServersEFCoreRepository
    {
        private IDbContextFactory<ServerManagementContext> _context;

        public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> context)
        {
            _context = context;
        }

        public void AddServer(Server server)
        {
            using var db = _context.CreateDbContext();
            db.Servers.Add(server);
            db.SaveChanges();
        }

        public List<Server> GetServers()
        {
            using var db = _context.CreateDbContext();
            var servers = db.Servers.ToList();
            return servers;
        }

        public List<Server> GetServersByCity(string city)
        {
            using var db = _context.CreateDbContext();
            var servers = db.Servers
            .Where(x => x.City != null &&
                   x.City.ToLower().IndexOf(city.ToLower()) >= 0)
                  .ToList();
            return servers;
        }

        public Server? GetServerById(int id)
        {
            using var db = _context.CreateDbContext();
            var server = db.Servers.Find(id);
            if (server == null)
            {
                return server;
            }
            return new Server();

        }

        public void UpdateServer(int serverId, Server server)
        {
            if (server == null) throw new ArgumentNullException(nameof(server));
            using var db = _context.CreateDbContext();
            var serverToUpdate = db.Servers.Find(serverId);
            if (serverToUpdate is not null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
                db.SaveChanges();
            }
        }
        public void DeleteServer(int serverId)
        {
            using var db = _context.CreateDbContext();
            var serverToDelete = db.Servers.Find(serverId);
            if (serverToDelete is not null)
            {
                db.Servers.Remove(serverToDelete);
                db.SaveChanges();
            }
        }

        public List<Server> SearchServers(string serverFilter)
        {
            using var db = _context.CreateDbContext();
            return db.Servers.Where(x =>
              x.Name != null &&
              x.Name.ToLower().IndexOf(serverFilter.ToLower()) > 0)
              .ToList();
        }


    }
}
