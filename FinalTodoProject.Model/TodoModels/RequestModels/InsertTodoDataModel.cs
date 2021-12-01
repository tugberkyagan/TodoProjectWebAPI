using FluentValidation;

namespace FinalTodoProject.Model.TodoModels.RequestModels
{
    public class InsertTodoDataModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
        public int Progress { get; set; }
    }

    public class InsertTodoDataModelValidator : AbstractValidator<InsertTodoDataModel>
    {
        public InsertTodoDataModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title shouldn't be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description shouldn't be empty");
            RuleFor(x => x.IsDone).NotNull().WithMessage("IsDone shouldn't be null");
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId shouldn't be null");
            RuleFor(x => x.Progress).NotNull().WithMessage("Progress shouldn't be null");

        }
    }
}