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

        public static string WebApiRootFullPath
        {
            get
            {
                return ConfigurationManager.AppSettings["WebApi.RootFullPath"];
            }
        }

        public static string UploadsRootPath
        {
            get
            {
                return ConfigurationManager.AppSettings["Uploads.RootPath"];
            }
        }

        public static string UploadsImageBufferSource
        {
            get
            {
                var uploadsImageBufferDirectory =
                    ConfigurationManager.AppSettings["Uploads.Image.BufferDirectory"].Replace(@"\", @"/");

                var returnValue =
                    string.Concat(ConfigHelper.DomainBaseUrl, UploadsRootPath.Replace(@"\", @"/"), uploadsImageBufferDirectory);

                return returnValue;
            }
        }

        public static string UploadsImageBufferDirectory
        {
            get
            {
                var uploadsImageBufferDirectory = ConfigurationManager.AppSettings["Uploads.Image.BufferDirectory"];
                var returnValue = string.Concat(UploadsRootPath, uploadsImageBufferDirectory);
                return returnValue;
            }
        }

        public static string UploadsImageStageSource
        {
            get
            {
                var uploadsImageStageDirectory =
                    ConfigurationManager.AppSettings["Uploads.Image.StageDirectory"].Replace(@"\", @"/");

                var returnValue =
                    string.Concat(ConfigHelper.DomainBaseUrl, UploadsRootPath.Replace(@"\", @"/"), uploadsImageStageDirectory);

                return returnValue;
            }
        }

        public static string UploadsImageStageDirectory
        {
            get
            {
                var uploadsImageStageDirectory = ConfigurationManager.AppSettings["Uploads.Image.StageDirectory"];
                var returnValue = string.Concat(UploadsRootPath, uploadsImageStageDirectory);
                return returnValue;
            }
        }

        public static string UploadsImageLiveSource
        {
            get
            {
                var uploadsImageLiveDirectory =
                    ConfigurationManager.AppSettings["Uploads.Image.LiveDirectory"].Replace(@"\", @"/");

                var returnValue =
                    string.Concat(ConfigHelper.DomainBaseUrl, UploadsRootPath.Replace(@"\", @"/"), uploadsImageLiveDirectory);

                return returnValue;
            }
        }

        public static string UploadsImageLiveDirectory
        {
            get
            {
                var uploadsImageLiveDirectory = ConfigurationManager.AppSettings["Uploads.Image.LiveDirectory"];
                var returnValue = string.Concat(UploadsRootPath, uploadsImageLiveDirectory);
                return returnValue;
            }
        }

        public static string DefaultAvatar
        {
            get
            {
                var defaultAvatar = ConfigurationManager.AppSettings["DefaultAvatar"];
                var returnValue = string.Concat(UploadsImageLiveDirectory, defaultAvatar);
                return returnValue;
            }
        }

        public static int UploadsImageMinSize
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["Uploads.Image.MinSize"]);
            }
        }

        public static int UploadsImageMaxSize
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["Uploads.Image.MaxSize"]);
            }
        }

        public static int UploadsImageMaxWidth
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["Uploads.Image.MaxWidth"]);
            }
        }

        public static int UploadsImageMaxHeight
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["Uploads.Image.MaxHeight"]);
            }
        }

        public static int InfiniteScrollMaxSearchResultsLess
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["InfiniteScroll.MaxSearchResultsLess"]);
            }
        }

        public static int InfiniteScrollMaxSearchResultsDisplay
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["InfiniteScroll.MaxSearchResultsDisplay"]);
            }
        }
    }
}
