﻿using Gamechain.Domain.Entities.Aggregates.Cart;
using Gamechain.Domain.Entities.Aggregates.Feature;
using Gamechain.Domain.Entities.Aggregates.Game;
using Gamechain.Domain.Entities.Aggregates.Genre;
using Gamechain.Domain.Entities.Aggregates.Platform;
using Gamechain.Domain.Entities.Aggregates.Publisher;
using Gamechain.Domain.Entities.Aggregates.User;
using Gamechain.Domain.Entities.Aggregates.Wishlist;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Gamechain.Infrastructure.EntityFrameworkCore.Context
{
    public class GamechainDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCart> GameCart { get; set; }
        public DbSet<GameFeature> GameFeature { get; set; }
        public DbSet<GameGenre> GameGenre { get; set; }
        public DbSet<GamePlatform> GamePlatform { get; set; }
        public DbSet<GameWishlist> GameWishlist { get; set; }
        public DbSet<Genre> Genres { get; set; } 
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        public GamechainDbContext(DbContextOptions<GamechainDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SeedInitialData();

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
