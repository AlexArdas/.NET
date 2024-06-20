using Domian.Interfaces.Services;
using Domian.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Web.API.Practise.Controllers
{
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost("document")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateDocument([FromBody] Document document)
        {
            _documentService.CreateDocument(document);
            return Ok();
        }

        [HttpPut("document")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateDocument([FromBody] Document document)
        {
            _documentService.UpdateDocument(document);
            return Ok();
        }

        [HttpGet("document")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetDocument([FromQuery] int documentId)
        {
            var document = _documentService.GetDocument(documentId);
            return Ok(document);
        }

        [HttpGet("documents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetDocuments()
        {
            var documents = _documentService.GetDocuments();
            return Ok(documents);
        }

        [HttpGet("document/{documentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetDocumentFromRoute([FromRoute] int documentId)
        {
            var document = _documentService.GetDocument(documentId);
            return Ok(document);
        }
    }
}

