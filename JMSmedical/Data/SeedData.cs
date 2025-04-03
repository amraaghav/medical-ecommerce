using Microsoft.EntityFrameworkCore;
using JMSmedical.Models;

namespace JMSmedical.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // जाँचें कि क्या पहले से कोई सर्विस मौजूद है
                if (context.Services.Any())
                {
                    return;   // DB को सीड किया जा चुका है
                }

                context.Services.AddRange(
                    new Service
                    {
                        Title = "Web Development",
                        Description = "Creating modern and responsive websites tailored to your business needs using the latest technologies.",
                        IconClass = "fa-solid fa-laptop-code" // Font Awesome आइकन क्लास
                    },
                    new Service
                    {
                        Title = "Mobile Apps",
                        Description = "Building native or cross-platform mobile applications for iOS and Android devices.",
                        IconClass = "fa-solid fa-mobile-screen-button"
                    },
                    new Service
                    {
                        Title = "Cloud Solutions",
                        Description = "Helping businesses migrate and manage their infrastructure on the cloud (AWS, Azure, GCP).",
                        IconClass = "fa-solid fa-cloud"
                    },
                    new Service
                    {
                         Title = "UI/UX Design",
                         Description = "Designing intuitive and engaging user interfaces for better user experience.",
                         IconClass = "fa-solid fa-palette"
                    },
                    new Service
                    {
                         Title = "Consulting",
                         Description = "Providing expert advice to help you make informed decisions about your technology strategy.",
                         IconClass = "fa-solid fa-users-gear"
                    },
                    new Service
                    {
                         Title = "Support & Maintenance",
                         Description = "Offering ongoing support and maintenance services to keep your applications running smoothly.",
                         IconClass = "fa-solid fa-headset"
                    }
                );
                context.SaveChanges(); // डेटाबेस में सेव करें
            }
        }
    }
}