namespace Common.Helpers.Configuration
{
    using Common.Objects.Enumerators;
    using System;
    using System.Configuration;

    public static class ConfigHelper
    {
        public static string WebApiBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["WebApi.BaseUrl"];
            }
        }

        public static string DomainBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["Domain.BaseUrl"];
            }
        }

        public static string DomainName
        {
            get
            {
                return ConfigurationManager.AppSettings["Domain.Name"];
            }
        }

        public static string NoReplayEmailAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["Domain.NoReplayEmailAddress"];
            }
        }

        public static string RegistrationEncryptionKey
        {
            get
            {
                return ConfigurationManager.AppSettings["EncryptionKey.Registration"];
            }
        }

        public static double PasswordResetExpiration
        {
            get
            {
                return (double)Convert.ChangeType(ConfigurationManager.AppSettings["Authentication.PasswordResetExpiration"], typeof(double));
            }
        }

        public static double ConfirmationExpiration
        {
            get
            {
                return (double)Convert.ChangeType(ConfigurationManager.AppSettings["Authentication.ConfirmationExpiration"], typeof(double));
            }
        }

        public static DateTime MaxDateTime
        {
            get
            {
                return (DateTime)Convert.ChangeType(ConfigurationManager.AppSettings["Database.MaxDateTime"], typeof(DateTime));
            }
        }

        public static DateTime MinDateTime
        {
            get
            {
                return (DateTime)Convert.ChangeType(ConfigurationManager.AppSettings["Database.MinDateTime"], typeof(DateTime));
            }
        }

        public static TimeZones DefaultTimeZoneId
        {
            get
            {
                var defaultTimeZoneId = (int)Convert.ChangeType(ConfigurationManager.AppSettings["Default.TimeZoneId"], typeof(int));
                return (TimeZones)defaultTimeZoneId;
            }
        }
    }
}
