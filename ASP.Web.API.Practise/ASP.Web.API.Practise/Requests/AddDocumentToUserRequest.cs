namespace ASP.Web.API.Practise.Requests
{
    public class AddDocumentToUserRequest
    {
        public int DocumentId { get; set; }
        public Guid UserId { get; set; }
    }
}
