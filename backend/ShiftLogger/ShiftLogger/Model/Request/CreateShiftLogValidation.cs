using FluentValidation;

namespace ShiftLogger.Model.Request
{
    public class CreateShiftLogValidation : AbstractValidator<CreateShiftLogRequest>
    {
        public CreateShiftLogValidation()
        {
            RuleFor(c => c.Area).NotEmpty().NotEqual(AreaEnum.None);
            RuleFor(c => c.Machine).NotEmpty();
            RuleFor(c => c.Operator).NotEmpty();
            RuleFor(c => c.Comment).NotEmpty();
            RuleFor(c => c.EventDate).NotEmpty();
        }
    }
}