namespace TodoAPP.Models
{
    public class TodoModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}