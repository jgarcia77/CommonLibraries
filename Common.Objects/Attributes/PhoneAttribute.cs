namespace Common.Objects.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class PhoneAttribute : RegularExpressionAttribute
    {
        public PhoneAttribute()
            : base(@"^[2-9]\d{2}-\d{3}-\d{4}$")
        { }
    }
}
