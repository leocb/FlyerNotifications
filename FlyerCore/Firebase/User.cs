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
    public static class User
    {
        // TODO: User Status change events and requests completion

        public static async Task SignUp(string publicName, string email, string password)
        {
            Log.Trace($"Signing Up with {email} / {publicName} ...");
            FirebaseSession.AuthInfo = await FirebaseSession.AuthProvider.CreateUserWithEmailAndPasswordAsync(email, password, publicName, false);
            await RequestVerifyEmail();
            Log.Trace("User Signed Up");
        }

        public static async Task SignIn(string email, string password)
        {
            Log.Trace($"Signing In with {email} ...");
            FirebaseSession.AuthInfo = await FirebaseSession.AuthProvider.SignInWithEmailAndPasswordAsync(email, password);
            Log.Trace($"User Signed In ({FirebaseSession.AuthInfo.User.LocalId})");
        }

        public static void SignOut()
        {
            Log.Trace($"Signing Out ...");
            FirebaseSession.ClearAll();
            Log.Trace($"User Signed Out");
        }

        public static async Task RequestForgotPassword(string email)
        {
            Log.Trace($"Requesting password reset for {email} ...");
            await FirebaseSession.AuthProvider.SendPasswordResetEmailAsync(email);
            Log.Trace($"Password reset email sent");
        }

        public static async Task RefreshUserData()
        {
            Log.Trace("Refreshing user details ...");
            FirebaseSession.CheckSignedIn();
            await FirebaseSession.AuthInfo.RefreshUserDetails();
            Log.Trace("User details updated");
        }

        public static bool IsEmailVerified
        {
            get
            {
                FirebaseSession.CheckSignedIn();
                return FirebaseSession.AuthInfo.User.IsEmailVerified;
            }
        }

        public static async Task RequestVerifyEmail()
        {
            Log.Trace($"Requesting email verification ...");
            FirebaseSession.CheckSignedIn();
            await FirebaseSession.AuthProvider.SendEmailVerificationAsync(FirebaseSession.AuthInfo.FirebaseToken);
            Log.Trace($"Verification email sent");
        }

        public static async Task UpdateUserEmail(string currentPassword, string newEmail)
        {
            Log.Trace($"Updating user email to {newEmail} ...");
            FirebaseSession.CheckSignedIn();
            if (currentPassword == "") return;
            await FirebaseSession.AuthProvider.ChangeUserEmail(FirebaseSession.AuthInfo.FirebaseToken, newEmail);
            await RequestVerifyEmail();
            Log.Trace($"User email updated");
        }
        public static async Task UpdateUserPassword(string oldPassword, string newPassword)
        {
            Log.Trace($"Updating user password ...");
            FirebaseSession.CheckSignedIn();
#warning TODO: Verify if old password is correct
            await FirebaseSession.AuthProvider.ChangeUserPassword(FirebaseSession.AuthInfo.FirebaseToken, newPassword);
            Log.Trace($"User password updated");
        }

        public static async Task UpdateUserName(string newName)
        {
            Log.Trace("Updating UserName ...");
            FirebaseSession.CheckSignedIn();
            await FirebaseSession.AuthProvider.UpdateProfileAsync(FirebaseSession.AuthInfo.FirebaseToken, newName, null);
            Log.Trace("Username updated");
        }

        public static async Task UpdateUserImage()
        {
            Log.Trace("Updating user image ...");
            FirebaseSession.CheckSignedIn();
#warning TODO: upload new image and update image url
            string newImageUrl = "";
            await FirebaseSession.AuthProvider.UpdateProfileAsync(FirebaseSession.AuthInfo.FirebaseToken, null, newImageUrl);
            Log.Trace("User image updated");
        }
    }
}
