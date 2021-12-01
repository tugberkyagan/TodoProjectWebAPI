namespace FinalTodoProject.Model.SubTodoModels.RequestModels
{
    public class SubTodoDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EffectPercentage { get; set; }
        public int TodoId { get; set; }
        public bool IsDone { get; set; }
    }
}