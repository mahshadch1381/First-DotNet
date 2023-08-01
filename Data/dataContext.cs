
using Microsoft.EntityFrameworkCore;
using testing_easy_db.Models;

namespace testing_easy_db.Data
{
    public class dataContext : DbContext
    {
        
        public dataContext(DbContextOptions<dataContext> options)
        {
           
        }
        public DbSet<bank> banks { get; set; }
        public DbSet<Client> Clients { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Data Source=ACADEMY11\\SQLEXPRESS;Initial Catalog=testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
        }
        public void InsertWithIdentityOn(bank entity)
        {
            /* string tableName = "banks"; 


             Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} ON");

             banks.Add(entity);
             SaveChanges();

             Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} OFF");*/
            var newEntity = new bank
            {
              
                Name = entity.Name,
                LastName = entity.LastName,
                Amount = entity.Amount,
                // Other properties...
            };

            banks.Add(newEntity);
            SaveChanges();
        }
        public void InsertWithIdentityOn_client(Client entity)
        {
            /* string tableName = "banks"; 


             Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} ON");

             banks.Add(entity);
             SaveChanges();

             Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} OFF");*/
            var newEntity = new Client
            {

                Name = entity.Name,
                LastName = entity.LastName,
                 age= entity.age,
                // Other properties...
            };

            Clients.Add(newEntity);
            SaveChanges();
        }
    }
}
