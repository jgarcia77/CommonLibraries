namespace Common.Objects.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDataValidator
    {
        List<ValidationResult> Errors { get; set; }
    }

    public static class DataValidatorExtension
    {
        /// <summary>
        /// Data validation on all properties with attributes
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsValidModel(this IDataValidator instance)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(instance, null, null);
            if (!Validator.TryValidateObject(instance, context, validationResults, true))
            {
                if (instance.Errors == null)
                    instance.Errors = new List<ValidationResult>();

                instance.Errors.AddRange(validationResults);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if errors were encountered
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool HasErrors(this IDataValidator instance)
        {
            return (instance.Errors != null && instance.Errors.Count() > 0);
        }

        /// <summary>
        /// Returns a list of error messages
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static List<string> GetErrors(this IDataValidator instance)
        {
            var returnList = new List<string>();
            if (instance.HasErrors())
            {
                foreach (var error in instance.Errors)
                    returnList.Add(error.ErrorMessage);
            }
            return returnList;
        }

        /// <summary>
        /// This will add an entry to the ValidationResult list
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="error"></param>
        public static void AddError(this IDataValidator instance, string fieldName, string error)
        {
            if (instance.Errors == null)
                instance.Errors = new List<ValidationResult>();

            instance.Errors.Add(new ValidationResult(error, new List<string>() { fieldName }));
        }
    }
}
