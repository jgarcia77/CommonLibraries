namespace Common.Objects.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class PasswordAttribute : RegularExpressionAttribute
    {
        public PasswordAttribute()
            : base(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,25}")
        { 
            
        }
    }//End: PasswordAttribute
}//End: Common.Objects.Attributes
