namespace Common.Requests.UserRquests
{
    public class AddDocumentToUserRequest
    {
        public int DocumentId { get; set; }
        public Guid UserId { get; set; }
    }
}
