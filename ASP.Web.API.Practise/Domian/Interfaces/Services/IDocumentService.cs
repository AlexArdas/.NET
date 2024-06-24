using Common.Requests.DocumentRequest;
using Common.Responses.DocumentRespons;

namespace Domain.Interfaces.Services
{
    public interface IDocumentService
    {
        GetDocumentResponse GetDocument(int documentId);
        IEnumerable<GetDocumentResponse> GetDocuments();
        void CreateDocument(CreateDocumentRequest createDocumentRequest);
        void UpdateDocument(UpdateDocumentRequest updateDocumentRequest);

    }
}
