namespace Api_CURDtoSQL.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}
