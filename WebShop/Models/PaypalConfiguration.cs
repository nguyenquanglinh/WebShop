using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace WebShop.Models
{
    public class PaypalConfiguration
    {
        public readonly static string ClientID;
        public readonly static string ClientSecret;
        static PaypalConfiguration()
        {
            var config = Getconfig();
            ClientID = config["clientID"];
            ClientSecret = config["clientSecret"];
        }

        public static Dictionary<string, string> Getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientID, ClientSecret, Getconfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext getAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = Getconfig();
            return apiContext;
        }
    }
}