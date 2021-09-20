using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Core.Firebase
{
    internal class FirebaseSession
    {
        internal static readonly FlyerSessionException SessionNotAvailableException = new FlyerSessionException("User session not available.");

        internal static string WebAPIKey => "AIzaSyBrJ0WI83TDrrGE7e735vd4MWxIO5fskm4";
        internal static string FirebaseUrl => "https://flyernotifications-default-rtdb.firebaseio.com/";


        private static FirebaseAuthLink _authInfo;
        internal static FirebaseAuthLink AuthInfo {
            get => _authInfo;
            set
            {
                _authInfo = value;
                if (AuthInfo == null) return;
                Client = new FirebaseClient(FirebaseUrl, new FirebaseOptions{AuthTokenAsyncFactory = () => Task.FromResult(FirebaseSession.AuthInfo.FirebaseToken)});
            }
        }

        internal static FirebaseClient Client { get; set; }

        internal static FirebaseAuthProvider AuthProvider => new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));

        internal static bool IsSignedIn => AuthInfo != null;
        internal static void CheckSignedIn()
        {
            if (!IsSignedIn || AuthInfo.IsExpired()) throw SessionNotAvailableException;
        }


        internal static void ClearAll()
        {
            AuthInfo = null;
            Client = null;
        }
    }


    [Serializable]
    public class FlyerSessionException : Exception
    {
        public FlyerSessionException() : base() { }
        public FlyerSessionException(string message) : base(message) { }
        public FlyerSessionException(string message, Exception inner) : base(message, inner) { }
        protected FlyerSessionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
