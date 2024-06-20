using Domian.Interfaces.Repositories;
using Domian.Models;

namespace Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private List<Document> Documents = new()
        {
            new Document { Id = 1, Name = "Документ1", UserId = null},
            new Document { Id = 2, Name = "Документ2", UserId = null},
            new Document { Id = 3, Name = "Документ3", UserId = null},
            new Document { Id = 4, Name = "Документ4", UserId = null},
        };

        public Document GetDocument(int documentId)
        {
            return Documents.FirstOrDefault(d => d.Id == documentId);
        }
        public List<Document> GetDocuments()
        {
            return Documents;
        }

        public void CreateDocument(Document document)
        {
            Documents.Add(document);
        }

        public void UpdateDocument(Document document)
        {
            var documentDb = Documents.FirstOrDefault(d => d.Id == document.Id);

            if (documentDb is not null)
            {
                documentDb.Name = document.Name;
                documentDb.UserId = document.UserId;
            }

            Documents.Remove(document);
            Documents.Add(documentDb);
        }

        public bool DoesDocumentExists(int documentId)
        {
            return Documents.Any(d => d.Id == documentId);
        }
    }
}
