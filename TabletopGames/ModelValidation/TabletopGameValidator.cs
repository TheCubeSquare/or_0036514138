using FluentValidation;
using TabletopGames.Models;

namespace TabletopGames.ModelsValidation
{
    public class TabletopGameValidator : AbstractValidator<TabletopGame>
    {
        public TabletopGameValidator()
        {
            RuleFor(l => l.IdGame).NotEmpty().WithMessage("This field is required!")
                .GreaterThan(0).WithMessage("ID must be positive!");
            RuleFor(l => l.NameGame).NotEmpty().WithMessage("This field is required!")
                .Matches(@"(^[a-zA-Z]+(\s[a-zA-Z]+)*)").WithMessage("Only letters anad spaces allowed!");
            RuleFor(l => l.YearGame).NotEmpty().WithMessage("This field is required!")
                .GreaterThan(0).WithMessage("Invalid year!");
            RuleFor(l => l.MinPlayers).NotEmpty().WithMessage("This field is required!")
                .GreaterThan(0).WithMessage("Minimal number of players is at least one!");
            RuleFor(l => l.MaxPlayers).NotEmpty().WithMessage("This field is required!")
                .GreaterThan(0).WithMessage("Maximum number of players is at least one!");
            RuleFor(l => l.AverageRating).NotEmpty().WithMessage("This field is required!")
                .GreaterThanOrEqualTo(1).WithMessage("Rating too low!")
                .LessThanOrEqualTo(10).WithMessage("Rating too high!");
            RuleFor(l => l.AverageComplexity).NotEmpty().WithMessage("This field is required!")
                .GreaterThanOrEqualTo(1).WithMessage("Complexity too low!")
                .LessThanOrEqualTo(10).WithMessage("Complexity too high!");
            RuleFor(l => l.PlayTime).NotEmpty().WithMessage("This field is required!")
                .GreaterThanOrEqualTo(0).WithMessage("Play time cannot be negative!");
        }
    }
}
