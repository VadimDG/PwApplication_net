using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Data.Models
{
    public class User : BaseModel<int>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public static class UserModelBuilderExtention
    {
        public static string TABLE_NAME = "Users";

        public static void DescribeUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(f => {
                f.Property(p => p.Name).IsRequired(true);
                f.Property(p => p.Password).IsRequired(true);
                f.Property(p => p.Email).IsRequired(true);
            });

            modelBuilder.Entity<User>().ToTable(TABLE_NAME);
        }
    }
}
