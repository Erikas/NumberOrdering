using System.ComponentModel.DataAnnotations;

namespace NumberOrdering.WebAPI.Infrastructure.Validators
{
    public class IntegerArrayValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not IEnumerable<int> collection)
            {
                return false;
            }

            var numberOfElements = collection.Count();

            if (numberOfElements > 10 || numberOfElements == 0 || collection.Any(x => x > 10))
            {
                return false;
            }

            return true;
        }
    }
}
