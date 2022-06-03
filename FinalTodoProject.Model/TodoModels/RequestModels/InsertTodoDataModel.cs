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
}