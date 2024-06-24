namespace Common.Requests.DocumentRequest
{
    public class UpdateDocumentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
