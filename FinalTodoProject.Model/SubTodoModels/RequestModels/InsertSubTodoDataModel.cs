namespace FinalTodoProject.Model.SubTodoModels.RequestModels
{
    public class InsertSubTodoDataModel
    {
        public string Title { get; set; }
        public int EffectPercentage { get; set; }
        public int TodoId { get; set; } 
        public bool IsDone { get; set; }
    }
}