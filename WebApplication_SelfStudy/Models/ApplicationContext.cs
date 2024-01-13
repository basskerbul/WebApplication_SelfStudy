using Microsoft.EntityFrameworkCore;

namespace WebApplication_SelfStudy.Models
{
    /// <summary>
    /// В любом приложении, работающим с БД через Entity Framework, 
    /// нам нужен будет контекст (класс производный от DbContext). 
    /// В данном случае таким контекстом является класс ApplicationContext.
    /// </summary>
    public class ApplicationContext: DbContext //определяет контекст данных, используемый для взаимодействия с базой данных
    {
        public DbSet<User> Users { get; set; } //набор объектов, которые хранятся в базе данных

        /// <summary>
        /// Database.EnsureCreated() при создании контекста автоматически 
        /// проверит наличие базы данных и, если она отсуствует, создаст ее.
        /// </summary>
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        //для настройки подключения нам надо переопределить метод OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //DbContextOptionsBuilder: устанавливает параметры подключения
        {
            //с помощью метода UseSqlServer позволяет настроить строку подключения для соединения с MS SQL Server
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
            // в качестве сервера будет использоваться движок localdb, который предназначен специально для разработки,
            // ("Server=(localdb)\\mssqllocaldb"), а файл базы данных будет называться helloappdb ("Database=helloappdb").
        }
    }
}
