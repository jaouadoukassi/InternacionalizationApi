using InternacionalAPI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternacionalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResources> _sharedResoureceLocalizer;

        public PostsController(IStringLocalizer<PostsController> stringLocalizer, IStringLocalizer<SharedResources> sharedResoureceLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResoureceLocalizer = sharedResoureceLocalizer;
        }

        [HttpGet]
        [Route("PostsControllerResource")]
        public IActionResult GetUsingPostsControllerResource()
        {
            // Find Text
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName
            });
        }

        [HttpGet]
        [Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? string.Empty;
            var todayIs = string.Format(_sharedResoureceLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());
            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                TodayIs = todayIs,
            });
        }


    }
}
