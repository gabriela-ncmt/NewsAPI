using API.Entities.ViewsModels;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        private readonly NewsService _newsService;

        public NewsController(ILogger<NewsController> logger, NewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [HttpGet(Name ="GetNews")]
        public ActionResult<List<NewsViewModel>> Get() => _newsService.Get();

        [HttpPost]
        public ActionResult<NewsViewModel> Create(NewsViewModel news) 
        {
            var result = _newsService.Create(news);
            return CreatedAtRoute("GetNews", new { id = result.Id.ToString() }, result);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<NewsViewModel> Update(string id, NewsViewModel newsIn) 
        {
            var news = _newsService.Get(id);
            if(news is null)
                return NotFound();

            _newsService.Update(id, newsIn);
            return CreatedAtRoute("GetNews", new { id = id }, newsIn);

        }


        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            var news = _newsService.Get(id);
            if (news is null)
                return NotFound();

            _newsService.Remove(id);
            return Ok("News successfully deleted!");
        }

    }
}
