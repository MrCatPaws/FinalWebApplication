using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ITTyping.Data;
using System;
using System.Linq;

namespace ITTyping.Models;

    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ITTypingContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<ITTypingContext>>()))
            {
                if (context.Typist.Any())
                {
                    return;
                }
                context.Typist.AddRange(
                    new Typist
                    {
                        UserName = "ConqueringTypingChampion",
                        Password = "password",
                        FirstName = "Leon",
                        LastName = "Special",
                        TypingPackage = "The-Typer-Viper-4-IT",
                        PriceDue = 50.00m,
                        LastPurchaseDate = DateTime.Parse("2010-01-01")
                    },
                    new Typist
                    {
                        UserName = "ShelbyTypist",
                        Password = "password",
                        FirstName = "Noel",
                        LastName = "Speed",
                        TypingPackage = "The-T-1000-Type-inator-4-it",
                        PriceDue = 75.00m,
                        LastPurchaseDate = DateTime.Parse("2021-02-01")
                    },
                    new Typist
                    {
                        UserName = "TheFlash",
                        Password = "password",
                        FirstName = "Coel",
                        LastName = "Hen",
                        TypingPackage = "The-Lite-est-Typist-4-IT",
                        PriceDue = 25.00m,
                        LastPurchaseDate = DateTime.Parse("2022-03-01")
                    },
                    new Typist
                    {
                        UserName = "PerformanceEnhancingRepeatViolator",
                        Password = "password",
                        FirstName = "Owain",
                        LastName = "Gwynedd",
                        TypingPackage = "Smoking-Fingers-4-IT",
                        PriceDue = 100.00m,
                        LastPurchaseDate = DateTime.Parse("2023-04-01")
                    }
                );
                context.SaveChanges();
            }
        }
    }
