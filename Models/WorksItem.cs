namespace DotNetApi.Models
{
    public class WorksItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long Cost { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
    public class WorksItemDTO
    {
        public long Id { get; set; }
        public long Cost { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
