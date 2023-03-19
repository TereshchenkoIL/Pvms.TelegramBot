using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pvms.DAL;
using Pvms.DAL.Entities;

namespace DataSeeder
{
    class Program : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            string connectionString = DalConstants.ConnectionString;

            DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            using (DataContext context = p.CreateDbContext(null))
            {
                context.Database.Migrate();

                context.SpecializationInfos.AddRange
                (
                    new SpecializationInfo
                    {
                        Code = "B121",
                        Info = "Запрошуємо на день відкритих дверей для бакалаврату спеціальності 121 18.03.2023 о 13:00"
                    },
                    new SpecializationInfo
                    {
                        Code = "B122",
                        Info = "Запрошуємо на день відкритих дверей для бакалаврату спеціальності 122 18.03.2023 о 13:00"
                    },
                    new SpecializationInfo
                    {
                        Code = "B123",
                        Info = "Запрошуємо на день відкритих дверей для бакалаврату спеціальності 123 18.03.2023 о 13:00"
                    },
                    new SpecializationInfo
                    {
                        Code = "M121",
                        Info = "Запрошуємо на день відкритих дверей для магістратури спеціальності 121 18.03.2023 о 13:00"
                    },
                    new SpecializationInfo
                    {
                        Code = "M122",
                        Info = "Запрошуємо на день відкритих дверей для магістратури спеціальності 122 18.03.2023 о 13:00"
                    },
                    new SpecializationInfo
                    {
                        Code = "M123",
                        Info = "Запрошуємо на день відкритих дверей для магістратури спеціальності 123 18.03.2023 о 13:00"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}