using BlockBaster.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Country> Countries  { get; set; }
        public DbSet<Genre> Genres  { get; set; }
        public DbSet<Movie> Movies  { get; set; }
        public DbSet<MovieCountry> MovieCountries { get; set; }
        public DbSet<MovieGenre> MovieGenres  { get; set; }
        public DbSet<Producer> Producers  { get; set; }
        public DbSet< ProducerMovie> ProducerMovies  { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Scriptwriter> Scriptwriters  { get; set; }
        public DbSet<ScriptwriterMovie> ScriptwriterMovies  { get; set; }
        public new DbSet<User> Users { get; set; }
        public  DbSet<UserMovie> UserMovies { get; set; }
        //public override DbSet<IdentityRole> Roles { get; set; }
        // public new DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "user",
                NormalizedName = "USER"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "1",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "my@gmail.com",
                NormalizedEmail = "MY@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "password"),
                SecurityStamp = string.Empty
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "2",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "2"
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Name = "Чёрный Адам",
                Date = new DateTime(2022,10,19),
                Path = "BlackAdam.mp4",
                Description = "Старые легенды гласят, что много тысяч лет назад на Ближнем Востоке существовало государство Кандак," +
                " где была выкована корона Саббака, способная подарить безграничную власть и могущество своему хозяину. В наши дни в Кандаке," +
                " где теперь господствует международная преступная организация «Интерганг», археолог Адрианна Томаз находит в гробнице ту самую" +
                " корону и с помощью заклинания освобождает из заточения таинственного Черного Адама – супергероя на грани добра и зла." +
                " Члены Общества Справедливости Америки пытаются усмирить безудержный гнев древнего сверхчеловека и направить его мощь на борьбу" +
                " со злом, не менее сильным и разрушительным, чем он сам. ",
                Time = "125 мин"
            });

            modelBuilder.Entity<Actor>().HasData(new Actor
            {
                Id=1,
                Name = "Дуэйн Джонсон",
                Date = new DateTime(1972,08,2),
                Path = "Rock.png"
            });
            
            modelBuilder.Entity<Actor>().HasData(new Actor
            {
                Id = 2,
                Name = "Элдис Ходж",
                Date = new DateTime(1986, 09, 20),
                Path = "Aldis Hodge.png"
            });

            modelBuilder.Entity<ActorMovie>().HasData(new ActorMovie
            {
                Id = 1,
                ActorId = 1,
                MovieId = 1
            });

            modelBuilder.Entity<ActorMovie>().HasData(new ActorMovie
            {
                Id = 2,
                ActorId = 2,
                MovieId = 1
            });

            modelBuilder.Entity<Country>().HasData(new Country
            {
                Id = 1,
                Name = "США"
            });
            modelBuilder.Entity<Country>().HasData(new Country
            {
                Id = 2,
                Name = "Канада"
            });

            modelBuilder.Entity<MovieCountry>().HasData(new MovieCountry
            {
                Id = 1,
                CountryId = 1,
                MovieId = 1
            });

            modelBuilder.Entity<MovieCountry>().HasData(new MovieCountry
            {
                Id = 2,
                CountryId = 2,
                MovieId = 1
            });

            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 1,
                Name = "Фэнтези"
            });

            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 2,
                Name = "Боевик"
            });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre
            {
                Id = 1,
                GenreId = 1,
                MovieId= 1
            });

            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre
            {
                Id = 2,
                GenreId = 2,
                MovieId = 1
            });

            modelBuilder.Entity<Producer>().HasData(new Producer
            {
                Id = 1,
                Name = "Жауме Кольет - Серра",
                Date = new DateTime(1974,06,23),
                Path = "Jaume Collet-Serra.png"
            });

            modelBuilder.Entity<ProducerMovie>().HasData(new ProducerMovie
            {
                Id = 1,
                ProducerId = 1,
                MovieId = 1
            });

            
            modelBuilder.Entity<Scriptwriter>().HasData(new Scriptwriter
            {
                Id = 1,
                Name = "Адам Штикель",
                Date= new DateTime(1978,01,9),
                Path = "Adam Sztykiel.png"
            });

            modelBuilder.Entity<ScriptwriterMovie>().HasData(new ScriptwriterMovie
            {
                Id = 1,
                ScriptwriterId = 1,
                MovieId = 1
            });

            modelBuilder.Entity<Subscription>().HasData(new Subscription
            {
                Id = 1,
                DateBegin = new DateTime(2022,12,05),
                DateEnd = new DateTime(2023,01,05)
            });
        }
    }
}
