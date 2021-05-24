using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Flyer.Core.Logging;

namespace Flyer.Core.Firebase
{
    public class User
    {
        // TODO: User Status change events and requests completion

        public static async Task SignUp(string publicName, string email, string password)
        {
            Log.Info($"Signing Up with {email} / {publicName} ...");
            Session.AuthInfo = await Session.AuthProvider.CreateUserWithEmailAndPasswordAsync(email, password, publicName, false);
            Log.Info("User Signed Up");
        }

        public static async Task SignIn(string email, string password)
        {
            Log.Info($"Signing In with {email} ...");
            Session.AuthInfo = await Session.AuthProvider.SignInWithEmailAndPasswordAsync(email, password);
            Log.Info("User Signed In");
        }

        public static void SignOut()
        {
            Log.Info($"Signing Out ...");
            Session.ClearAll();
            Log.Info($"User Signed Out");
        }

        public static async Task RequestForgotPassword(string email)
        {
            Log.Info($"Requesting password reset for {email} ...");
            await Session.AuthProvider.SendPasswordResetEmailAsync(email);
            Log.Info($"Password reset email sent");
        }

        public static bool IsEmailVerified => Session.AuthInfo.User.IsEmailVerified;

        public static async Task RequestVerifyEmail()
        {
            Log.Info($"Requesting email verification ...");
            if (!Session.IsLoggedIn) throw new InvalidOperationException("Login is required for this action");
            await Session.AuthProvider.SendEmailVerificationAsync(Session.AuthInfo.FirebaseToken);
            Log.Info($"Verification email sent");
        }

        public static async Task UpdateUserEmail(string currentPassword, string newEmail)
        {
            Log.Info($"Updating user email to {newEmail} ...");
            if (currentPassword == "") return;
            if (!Session.IsLoggedIn) throw new InvalidOperationException("Login is required for this action");
            await Session.AuthProvider.ChangeUserEmail(Session.AuthInfo.FirebaseToken, newEmail);
            Log.Info($"User email updated");
        }
        public static async Task UpdateUserPassword(string oldPassword, string newPassword)
        {
            Log.Info($"Updating user password ...");
            if (!Session.IsLoggedIn) throw new InvalidOperationException("Login is required for this action");
            // TODO: Verify if old password is correct
            if (oldPassword == newPassword) return;
            await Session.AuthProvider.ChangeUserPassword(Session.AuthInfo.FirebaseToken, newPassword);
            Log.Info($"User password updated");
        }

        public static async Task UpdateUserName(string newName)
        {
            Log.Info("Updating UserName ...");
            if (!Session.IsLoggedIn) throw new InvalidOperationException("Login is required for this action");
            await Session.AuthProvider.UpdateProfileAsync(Session.AuthInfo.FirebaseToken, newName, null);
            Log.Info("Username updated");
        }

        public static async Task UpdateUserImage()
        {
            Log.Info("Updating user image ...");
            if (!Session.IsLoggedIn) throw new InvalidOperationException("Login is required for this action");
            // TODO: upload new image and update image url
            string newImageUrl = "";
            await Session.AuthProvider.UpdateProfileAsync(Session.AuthInfo.FirebaseToken, null, newImageUrl);
            Log.Info("User image updated");
        }



        //var venue = new Models.Venue() { Name = "test Venue" };
        //var newVenueUID = await firebase
        //    .Child("Venues")
        //    .PostAsync(JsonSerializer.Serialize(venue), false);

        //var space = new Models.Space() { Name = "test space2" };
        //venue.Spaces = new List<Models.Space>() { space };

        //await firebase
        //    //.Child($"Venues/{newVenueUID.Key}")
        //    .Child($"Venues/-MaQa1ClgTF4z-u1SjWq")
        //    .PatchAsync(JsonSerializer.Serialize(venue));
    }
}
