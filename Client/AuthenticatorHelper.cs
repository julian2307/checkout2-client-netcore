using System;

namespace CheckoutApi.Integration.Client
{
    public class Authenticator
    {
        protected string MerchantCode;

        protected string MerchantSecret;

        public Authenticator(string merchantCode, string merchantSecret)
        {
            MerchantCode = merchantCode;
            MerchantSecret = merchantSecret;
        }

        public string GetAuthToken()
        {
            string date = GetTransactionDate();
            string hash = BuildHash(date);

            return string.Format("code=\"%s\" date=\"%s\" hash=\"%s\"", MerchantCode, date, hash);
        }

        protected string BuildHash(string date)
        {
            string hash = "";
            string hashString = MerchantCode.Length + MerchantCode + date.Length + date;
            try
            {
                hash = Crypto.MakeHash(hashString);
            }catch(Exception e)
            {
                hash = "";
            }

            return hash;
        }

        protected string GetTransactionDate()
        {
            DateTime date = new DateTime();
            return date.ToString("YYYY-MM-DD HH:MM:SS");
        }
    }
}
