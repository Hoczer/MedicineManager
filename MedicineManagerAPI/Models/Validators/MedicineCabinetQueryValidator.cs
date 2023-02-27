using MedicineManagerAPI.Entities;
using FluentValidation;
using System.Linq;

namespace MedicineManagerAPI.Models.Validators
{
    public class MedicineCabinetQueryValidator : AbstractValidator<MedicineCabinetQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };

        private string[] allowedSortByColumnNames =
            {nameof(MedicineCabinet.MedName), nameof(MedicineCabinet.MedExpirationDate), nameof(MedicineCabinet.MedDescription),};
        public MedicineCabinetQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
                }
            });

            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
