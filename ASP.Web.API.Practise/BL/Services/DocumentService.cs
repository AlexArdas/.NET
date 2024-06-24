using Common.Requests.DocumentRequest;
using Common.Responses.DocumentRespons;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace BL.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public GetDocumentResponse GetDocument(int documentId)
        {
            return _documentRepository.GetDocumentResponse(documentId);
        }

        public IEnumerable<GetDocumentResponse> GetDocuments()
        {
            return _documentRepository.GetDocuments();
        }

        public void CreateDocument(CreateDocumentRequest createDocumentRequest)
        {
            var document = new Document
            {
                Name = createDocumentRequest.Name,
                UserId = createDocumentRequest.UserId
            };

            _documentRepository.CreateDocument(document);
        }

        public void UpdateDocument(UpdateDocumentRequest updateDocumentRequest)
        {
            var document = new Document
            {
                Id = updateDocumentRequest.Id,
                Name = updateDocumentRequest.Name,
                UserId = updateDocumentRequest.UserId
            };

            _documentRepository.UpdateDocument(document);
        }
    }
}
