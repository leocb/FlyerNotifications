using Flyer.Core.Logging;
using Flyer.Core.Models;
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
                Icon = "",
                IsEnabled = true,
                IsPublic = isPublic,
                Spaces = new List<Space>()
                {
                    new Space()
                    {
                        Name = "General",
                        Description = "General messages",
                        Icon = "",
                        IsEnabled = true,
                        IsPublic = true,
                        MessageTemplates = new List<MessageTemplate>(),
                        Messages = new List<Message>()
                        {
                            new Message()
                            {
                                Content = "This is the beginning of the General space. Welcome!",
                                CreatedBy = "System",
                                CreatedOn = DateTime.Now.ToString(),
                                TemplateGUID = ""
                            }
                        }
                    }
                },
                Members = new List<Member>()
                {
                    new Member()
                    {
                        UserGUID = FirebaseSession.AuthInfo.User.LocalId,
                        IsAdmin = true,
                        AllowedSpaces = new List<string>(){"General"}
                    }
                }
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
