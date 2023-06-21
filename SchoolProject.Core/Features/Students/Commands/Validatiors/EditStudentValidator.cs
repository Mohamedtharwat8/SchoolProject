using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Constructors
        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameEn)
                 .NotEmpty().WithMessage("NotEmpty Must not be Empty")
                 .NotNull().WithMessage("NotNull Must not be Empty")
                 .MaximumLength(100).WithMessage("MaximumLength Must not be Empty");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("NotEmptyMust not be Empty")
                .NotNull().WithMessage("NotNull Must not be Empty")
                .MaximumLength(100).WithMessage("MaximumLength Must not be Empty");
        }

        public void ApplyCustomValidationsRules()
        {

            RuleFor(x => x.NameEn)
                .MustAsync(async (model, Key, CancellationToken)
                => !await _studentService.IsNameEnExistExcludeSelf(Key, model.Id))
                .WithMessage("NameEn Must not be Empty");
        }

        #endregion
    }
}
