using Microsoft.AspNetCore.Mvc;
using PruebaCRUD.IRepository;
using PruebaCRUD.Models;
using PruebaCRUD.Contexts;
using PruebaCRUD.DTO;
using Microsoft.AspNetCore.Authorization;

namespace PruebaCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsController(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        [HttpGet("GetAuthors")]
        public IActionResult GetAllAuthors()
        {
            try
            {
                var authors = _authorsRepository.GetAllAuthors();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthors([FromBody] DeleteAuthorDTO request)
        {
            try
            {
                var authorID = request.AuthorID;
                var response = await _authorsRepository.DeleteAuthor(authorID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                //return StatusCode(500, $"Error al eliminar autor: {ex.Message}");
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("AddAuthor")]

        public async Task<IActionResult> AddAuthor([FromBody] AuthorDTO request)
        {
            try
            {
                var NewAuthor = await _authorsRepository.AddAuthor(request);
                return Ok(NewAuthor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromBody] Authors authorDto)
            {
            try
            {
                if (authorDto == null)
                {
                    return BadRequest("Author is null");
                }

                //var existingAuthor = await _authorsRepository.GetAuthorById(authorDto.AuthorID, null);
                //if (existingAuthor == null)
                //{
                //    return NotFound("Author not found");
                //}

                await _authorsRepository.UpdateAuthor(authorDto);
                return Ok("Author updated succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}

