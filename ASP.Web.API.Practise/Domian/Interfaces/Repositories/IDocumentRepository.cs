using Domian.Models;

namespace Domian.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        Document GetDocument(int documentId);
        List<Document> GetDocuments();
        void CreateDocument(Document document);
        void UpdateDocument(Document document);
        bool DoesDocumentExists(int documentId);
    }
}
