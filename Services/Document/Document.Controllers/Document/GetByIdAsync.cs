namespace EncyclopediaGalactica.Services.Document.Controllers.Document;

using System.Net.Mime;
using Contracts.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public partial class DocumentController
{
    [HttpGet]
    [Route("getbyid/{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentGraphqlInput>> GetByIdAsync(
        long id)
    {
        return await _sourceFormatsService
            .DocumentService
            .GetByIdAsync(id)
            .ConfigureAwait(false);
    }
}