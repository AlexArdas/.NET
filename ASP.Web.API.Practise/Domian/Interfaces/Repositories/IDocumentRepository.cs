using Common.Responses.DocumentRespons;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        GetDocumentResponse GetDocumentResponse(int documentId);
        IEnumerable<GetDocumentResponse> GetDocuments();
        void CreateDocument(Document document);
        void UpdateDocument(Document document);
        bool DoesDocumentExists(int documentId);
        Document GetDocument(int documentId);
    }
}
