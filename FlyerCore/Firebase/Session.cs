using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Core.Firebase
{
    public static class Session
    {
        public static string WebAPIKey => "AIzaSyBrJ0WI83TDrrGE7e735vd4MWxIO5fskm4";
        public static string FirebaseUrl => "https://flyernotifications-default-rtdb.firebaseio.com/";


        private static FirebaseAuthLink _authInfo;
        public static FirebaseAuthLink AuthInfo {
            get => _authInfo;
            set
            {
                _authInfo = value;
                if (AuthInfo == null) return;
                Session.FireClient = new FirebaseClient(Session.FirebaseUrl, new FirebaseOptions{AuthTokenAsyncFactory = () => Task.FromResult(Session.AuthInfo.FirebaseToken)});
            }
        }

        public static FirebaseClient FireClient { get; set; }
        public static FirebaseAuthProvider AuthProvider => new(new FirebaseConfig(WebAPIKey));

        public static bool IsLoggedIn => AuthInfo != null;

        public static void ClearAll()
        {
            AuthInfo = null;
            FireClient = null;
        }
    }
}
