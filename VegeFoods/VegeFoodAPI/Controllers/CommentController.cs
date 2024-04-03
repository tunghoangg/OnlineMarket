using AutoMapper;
using AutoMapper.Configuration.Conventions;
using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using VegeFoodAPI.DTO;

namespace VegeFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
         public CommentController(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("{page}")]
        public async Task<ActionResult<CommentResponse>> GetComments(int page)
        {
            var pageResults = 3f;
            var comments = _repository.GetComments();
            var pageCount = (int)Math.Ceiling(comments.Count() / pageResults);

            var commentsOnPage = comments
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList(); 

            var response = new CommentResponse
            {
                Comments = commentsOnPage,
                CurrentPage = page,
                Pages = pageCount
            };

            return Ok(response);
        }
        [HttpPost("Create")]
        public ActionResult CreateComments(CommentDTO commentDTO,int ProductId, int AccountId)
        {
             var comment = _mapper.Map<Comment>(commentDTO);
            comment.ProductId = ProductId;
            comment.AccountId = AccountId;
            _repository.SaveComment(comment);
            return Ok();

        }
        [HttpPut("Edit/{id}")]
        public ActionResult UpdateComments(int id,CommentDTO commentDTO)
        {
            var cTmp = _repository.GetCommentById(id);
            var comment = _mapper.Map<Comment>(commentDTO);
            comment.CommentId = cTmp.CommentId;
            if (cTmp == null || comment == null)
            {
                return NotFound();
            }
            cTmp.CommentText = comment.CommentText;
            cTmp.Rating = comment.Rating;
            _repository.UpdaterComment(cTmp);
            return NoContent();
        }
        [HttpGet("GetMyComment/{id:int}")]
        public IActionResult SearchCommentByUserId(int id)
        {
            var comment = _repository.GetCommentByUserId(id);
            if (comment == null)
            {
                // Return a 404 Not Found response if the product is not found
                return NotFound();
            }

            // Return a 200 OK response with the product if it's found
            return Ok(comment);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var c = _repository.GetCommentById(id);
            if (c == null)
            {
                return NotFound();
            }
            _repository.DeleteComment(c);
            return NoContent();
        }
    }
}
