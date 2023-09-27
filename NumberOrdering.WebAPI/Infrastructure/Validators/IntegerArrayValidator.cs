using System.ComponentModel.DataAnnotations;

namespace NumberOrdering.WebAPI.Infrastructure.Validators
{
    public class IntegerArrayValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not int[] array)
            {
                return false;
            }

            if (array.Length > 10 || array.Length == 0 || array.Any(x => x > 10))
            {
                return false;
            }

            return true;
        }
    }
}
