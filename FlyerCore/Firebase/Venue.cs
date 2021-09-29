using Flyer.Core.Logging;
using Flyer.Core.Models.Venues;
using Flyer.Core.Models.Venues.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Flyer.Core.Firebase
{
    public static class Venue
    {
        public static async Task<IReadOnlyDictionary<string, Models.Venue>> GetAllVenues()
        {
            Log.Trace($"Querying all venues for user {FirebaseSession.AuthInfo.User.DisplayName}");
            FirebaseSession.CheckSignedIn();
            var venues = await FirebaseSession.Client.Child("Venues/").OnceAsync<Models.Venue>();
            Log.Trace("Venue query complete.");
            return venues.ToDictionary(t => t.Key, t => t.Object);
        }

        public static async Task CreateVenue(string name, bool isPublic)
        {
            Log.Trace($"Creating new venue { name } " + (isPublic ? "(public)" : "(private)") + " ...");
            Log.Trace($"By User {FirebaseSession.AuthInfo.User.DisplayName}");
            FirebaseSession.CheckSignedIn();

            var venue = new Models.Venue()
            {
                Name = name,
                Description = "",
                IconURL = "",
                BannerURL = "",
                IsPublic = isPublic,
                Spaces = new List<VenueSpace>()
                {
                    new VenueSpace()
                    {
                        Name = "General",
                        Description = "General messages",
                        MessageTemplates = new List<MessageTemplate>(),
                        Messages = new List<SpaceMessage>()
                        {
                            new SpaceMessage()
                            {
                                Content = "This is the beginning of the General space. Welcome!",
                                CreatedBy = "System",
                                CreatedOn = DateTime.Now.ToString(),
                            }
                        }
                    }
                },
                Roles = new List<VenueRole>()
                {
                    new VenueRole()
                    {
                        Name = "Administrator",
                        Description = "Full venue control, cannot be deleted.",
                        Priority = 99,
                        Color = "Red",
                        IsAdmin = true,
                        Users = new List<string>() { FirebaseSession.AuthInfo.User.LocalId },
                    },
                    new VenueRole()
                    {
                        Name = "Everyone",
                        Description = "Most basic role, cannot be deleted.",
                        Priority = 0,
                        Color = "DarkBlue",
                        Users = new List<string>() { FirebaseSession.AuthInfo.User.LocalId },
                    }
                },
                UsersRequestingAccess = new List<string>(),
                Users = new List<string>() { FirebaseSession.AuthInfo.User.LocalId },
            };

            var newVenue = await FirebaseSession.Client.Child("Venues").PostAsync(JsonSerializer.Serialize(venue), false, TimeSpan.FromSeconds(10));

            Log.Trace($"New venue created ({newVenue.Key})");
        }

        public static async Task UpdateVenue(string venueUID, Models.Venue venue)
        {
            Log.Trace($"Updating venue {venue.Name} ({venueUID}) ...");
            Log.Trace($"By User {FirebaseSession.AuthInfo.User.DisplayName}");
            FirebaseSession.CheckSignedIn();
            string venueData = JsonSerializer.Serialize(venue);
            Log.Trace(venueData);
            await FirebaseSession.Client.Child($"Venues/{venueUID}").PutAsync(venueData, TimeSpan.FromSeconds(10));
            Log.Trace($"Venue Updated");
        }
    }
}
