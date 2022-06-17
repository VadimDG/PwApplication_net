using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TestWebApi.Dto
{
    public class UserValidators
    {
        public sealed class HumanReadableName : ValidationAttribute
        {
            protected override ValidationResult IsValid(object name, ValidationContext validationContext)
            {
                string pattern = "^[a-zA-Z]{1}[a-zA-Z0-9]+$";
                Regex rgx = new Regex(pattern);

                if (rgx.IsMatch(name.ToString()))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Only letters and numbers are allowed");
                }
            }

        }
    }
}
