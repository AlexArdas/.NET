using Domian.Interfaces.Repositories;
using Domian.Interfaces.Services;
using Domian.Models;

namespace BL.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public Document GetDocument(int documentId)
        {
            return _documentRepository.GetDocument(documentId);
        }

        public List<Document> GetDocuments()
        {
            return _documentRepository.GetDocuments();
        }

        public void CreateDocument(Document document)
        {
            _documentRepository.CreateDocument(document);
        }

        public void UpdateDocument(Document document)
        {
            _documentRepository.UpdateDocument(document);
        }
    }
}
