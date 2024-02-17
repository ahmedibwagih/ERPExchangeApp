using System;

namespace Core
{
    public class AppSettings
    {
        

         public float ResturantDistance { get; set; }
         public float MinimumCostFreeMeal { get; set; }
        public Boolean RunBackground { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public Jwt Jwt { get; set; }
        public Attachments Attachment { get; set; }
        public EnvironmentSettings EnvironmentSettings { get; set; }
        public MailSettings MailSettings { get; set; }
        public SmsSettings SmsSettings { get; set; }
        public FireBasePrivateKey FireBasePrivateKey { get; set; }
        public DeliveryNotificationSettings DeliveryNotificationSettings { get; set; }
        public UrwaySetting UrwaySetting { get; set; }
        public distributionSetting distributionSetting { get; set; }
    }
    public class ConnectionStrings
    {
        public string Db { get; set; }
    }
    public class Attachments
    {
        public string Path { get; set; }
    }
    public class EnvironmentSettings
    {
        public bool EnableSwagger { get; set; }
    }
    public class Jwt
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
    }
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string TemplatePath { get; set; }
        public int Port { get; set; }

    }
    public class FireBasePrivateKey
    {
        public string type { get; set; }
        public string project_id { get; set; }
        public string private_key_id { get; set; }
        public string private_key { get; set; }
        public string client_email { get; set; }
        public string client_id { get; set; }
        public string auth_uri { get; set; }
        public string token_uri { get; set; }
        public string auth_provider_x509_cert_url { get; set; }
        public string client_x509_cert_url { get; set; }

    }

    public class SmsSettings
    {
        public string ApiLink { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string iso { get; set; }
        //public string sender { get; set; }
        public string api_id { get; set; }
        public string api_password { get; set; }
        public string sms_type { get; set; }
        public string encoding { get; set; }
        public string sender_id { get; set; }
        public string templateid { get; set; }
        public int ValidityPeriodInSeconds { get; set; }


    }
    public class DeliveryNotificationSettings
    {
        public int DeliveryDistance { get; set; }
        public int DeliveriesCountPerOrder { get; set; }
        public int ResendNotifcationEvery { get; set; }
    }

    public class UrwaySetting
    {
        public string Terminal { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }
        public string URL { get; set; }
        public string OrderbackURL { get; set; }
        public string ChargebackURL { get; set; }
        public string SpecialOrderbackURL { get; set; }
    }

    public class distributionSetting
    {
        public decimal VAT { get; set; }
        public decimal DeliveryFees { get; set; }
        public decimal AlaazPerc { get; set; }
       
    }


}
