using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {

        #region Fields
        private readonly IStudentService _studentService;

        #endregion

        #region Constructors
        public AddStudentValidator(IStudentService studentService

            )
        {
            _studentService = studentService;

            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name Must not be Empty")
                 .NotNull().WithMessage("Name Must not be null")
                 .MaximumLength(100).WithMessage("Name Must not be MaximumLength");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{propert}  Must not be Empty")
                .NotNull().WithMessage("{propert}  Must not be Empty")
                .MaximumLength(100).WithMessage("{propert}  Must not be Empty");

            RuleFor(x => x.DepartmementId)
                 .NotEmpty().WithMessage("{propert} Must not be Empty")
                 .NotNull().WithMessage("{propert}  Must not be Empty");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameEnExist(Key))
                .WithMessage("Name Exist");






        }


        #endregion

    }
}
