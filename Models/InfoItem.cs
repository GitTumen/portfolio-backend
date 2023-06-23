namespace DotNetApi.Models
{
    public class InfoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Links { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
    public class InfoItemDTO
    {
        public long Id { get; set; }
        public string? Links { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
