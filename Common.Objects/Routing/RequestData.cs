namespace Common.Objects.Routing
{
    using Common.Objects.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class RequestData : IDataValidator
    {
        #region IDataValidator
        public List<ValidationResult> ValidationResultsList { get; set; }
        #endregion IDataValidator
    }
}
