using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Platform
                if (!context.Platforms.Any())
                {
                    context.Platforms.AddRange(new List<Platform>()
                    {
                        new Platform()
                        {
                            PlatformName = "IMax",
                            PlatformLogoURL = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            PlatformDescription = "Netflix, Inc. is an American subscription streaming service and production company"
                        },
                        new Platform()
                        {
                            PlatformName = "Movie House",
                            PlatformLogoURL = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            PlatformDescription = "Binge is a video streaming subscription service available in Australia, owned by Streamotion"
                        },
                        new Platform()
                        {
                            PlatformName = "Lake",
                            PlatformLogoURL = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            PlatformDescription = "Stan (stylized as Stan.) is an Australian over-the-top streaming service."
                        },
                        new Platform()
                        {
                            PlatformName = "State Cinemas",
                            PlatformLogoURL = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            PlatformDescription = "Amazon Prime Video is an American subscription video on-demand over-the-top streaming and rental service of Amazon"
                        }
                    });
                    context.SaveChanges();
                }

                // Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            ActorFullName = "Actor 1",
                            ActorProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            ActorBio = "Bio of Actor 1"
                        },
                        new Actor()
                        {
                            ActorFullName = "Actor 2",
                            ActorProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg",
                            ActorBio = "Bio of Actor 2"
                        },
                        new Actor()
                        {
                            ActorFullName = "Actor 3",
                            ActorProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg",
                            ActorBio = "Bio of Actor 3"
                        },
                        new Actor()
                        {
                            ActorFullName = "Actor 4",
                            ActorProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg",
                            ActorBio = "Bio of Actor 4"
                        },
                        new Actor()
                        {
                            ActorFullName = "Actor 5",
                            ActorProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg",
                            ActorBio = "Bio of Actor 5"
                        }
                    }) ;
                    context.SaveChanges();
                }

                // Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>() 
                    {
                        new Producer()
                        {
                            ProducerFullName = "Producer 1",
                            ProducerBio = "Bio of producer 1",
                            ProducerProfilePictureURL = ""
                        },
                        new Producer()
                        {
                            ProducerFullName = "Producer 2",
                            ProducerBio = "Bio of producer 2",
                            ProducerProfilePictureURL = ""
                        },
                        new Producer()
                        {
                            ProducerFullName = "Producer 2",
                            ProducerBio = "Bio of producer 2",
                            ProducerProfilePictureURL = ""
                        }
                    });
                    context.SaveChanges();
                }
                // Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            MovieTitle = "Life",
                            MovieDescription = "",
                            MoviePrice = 1.99,
                            MovieImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            PlatformId = 1,
                            ProducerId = 3,
                            MovieCategory = Enums.MovieCategory.Action
                        },
                        new Movie()
                        {
                            MovieTitle = "The Shawshank Redeption",
                            MovieDescription = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            MoviePrice = 0.99,
                            MovieImageURL = "",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            PlatformId = 1,
                            ProducerId = 3,
                            MovieCategory = Enums.MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            MovieTitle = "Ghost",
                            MovieDescription = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            MoviePrice = 2.99,
                            MovieImageURL = "",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            PlatformId = 1,
                            ProducerId = 2,
                            MovieCategory = Enums.MovieCategory.Crime
                        },
                        new Movie()
                        {
                            MovieTitle = "Race",
                            MovieDescription = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            MoviePrice = 2.99,
                            MovieImageURL = "",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            PlatformId = 1,
                            ProducerId = 2,
                            MovieCategory = Enums.MovieCategory.SciFi
                        }
                    });
                    context.SaveChanges();
                }
                // Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");

                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                
                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);

                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAppUser, "Coding@1234?");

                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

