using Domian.Entities;

namespace Domian.Interfaces.Services
{
    public interface IDocumentService
    {
        Document GetDocument(int documentId);
        List<Document> GetDocuments();
        void CreateDocument(Document document);
        void UpdateDocument(Document document);

    }
}
