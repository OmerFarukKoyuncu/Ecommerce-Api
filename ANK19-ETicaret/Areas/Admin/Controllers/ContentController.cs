using BLL.DTO.ContentDtos;
using BLL.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANK19_ETicaret.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContentController : ControllerBase
    {
        private readonly IContentManager _contentManager;

        public ContentController(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContentDto>> GetContents()
        {
            var contents = _contentManager.GetAll();

            return Ok(contents);
        }

        [HttpGet]
        public ActionResult GetContentById(int id)
        {
            var content = _contentManager.GetById(id);

            return Ok(content);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetContentByName(string pageName)
        {
            var content = _contentManager.GetByName(pageName);

            return Ok(content);
        }

        [HttpPost]
        public ActionResult UpdateContent([FromBody] ContentDto content)
        {
            _contentManager.Update(content);

            return Ok();
        }



    }
}
