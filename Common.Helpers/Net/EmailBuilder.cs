namespace Common.Helpers.Net
{
    using System;

    using System.IO;

    using System.Text;

    public class EmailBuilder
    {
        private string Template;
        private string Content;

        public EmailBuilder(string template, string content)
        {
            if (!File.Exists(template))
            {
                throw new FileNotFoundException(string.Concat(template, " was not found"));
            }

            if (!File.Exists(content))
            {
                throw new FileNotFoundException(string.Concat(content, " was not found"));
            }

            this.Template = template;
            this.Content = content;
        }//End: EmailBuilder


        /// <summary>
        /// Build the email body with values from model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public string BuildBody<T>(T model)
        {
            if (model == null)
            {
                throw new ArgumentException("Model was not provided");
            }

            var template = this.GetFileContent(this.Template);
            var content = this.GetFileContent(this.Content);

            this.MergeFileContent<T>(template, model);
            this.MergeFileContent<T>(content, model);

            template.Replace("{{ContentPlaceHolder}}", content.ToString());

            return template.ToString();
        }//End: BuildBody<T>


        /// <summary>
        /// Get file contents
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private StringBuilder GetFileContent(string file)
        {
            var reader = new StreamReader(file);
            var returnObject = new StringBuilder(reader.ReadToEnd());

            reader.Dispose();

            return returnObject;
        }//End: GetFileContent


        /// <summary>
        /// Merges file contents with model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileContent"></param>
        /// <param name="model"></param>
        private void MergeFileContent<T>(StringBuilder fileContent, T model)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var searchValue = string.Concat("{{", property.Name, "}}");
                var propertyValue = property.GetValue(model) != null
                                    ? property.GetValue(model).ToString()
                                    : string.Empty;

                if (!string.IsNullOrEmpty(propertyValue))
                {
                    fileContent.Replace(searchValue, propertyValue);
                }
            }
        }//End: MergeFileContent

    }//End: EmailBuilder

}//End: Common.Helpers.Net
