namespace Common.Helpers.Net
{
    using System;
    using System.Configuration;
    using System.IO;

    public static class EmailReference
    {
        public static string RootPath
        {
            get
            {

                if (ConfigurationManager.AppSettings["Emails.RootPath"] != null)
                {
                    return ConfigurationManager.AppSettings["Emails.RootPath"];
                }

                return string.Empty;
            }
        }

        public static class HTML
        {
            public static class Templates
            {
                private static string FolderName = @"HTML\Templates\";

                public static string Main
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "Main.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }
            }

            public static class Contents
            {
                private static string FolderName = @"HTML\Contents\";

                public static string Registration
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "Registration.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }

                public static string RegistrationConfirmation
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "RegistrationConfirmation.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }

                public static string ForgotPassword
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "ForgotPassword.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }

                public static string ResetPassword
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "ResetPassword.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }

                public static string ChangePassword
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "ChangePassword.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }

                public static string EmailChange
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "EmailChange.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }

                public static string EmailChangeConfirmation
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "EmailChangeConfirmation.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }

                public static string BoardAccessApproval
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "BoardAccessApproval.html");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }
            }

        }

        public static class Text
        {
            public static class Templates
            {
                private static string FolderName = @"Text\Templates\";

                public static string Main
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "Main.txt");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }
            }

            public static class Contents
            {
                private static string FolderName = @"Text\Contents\";

                public static string Registration
                {
                    get
                    {
                        var fileName = string.Concat(FolderName, "Registration.txt");
                        var returnValue = Path.Combine(EmailReference.RootPath, fileName);
                        return returnValue;
                    }
                }
            }
        }
    }
}