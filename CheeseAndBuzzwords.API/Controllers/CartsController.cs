using System.Web.Http;

namespace CheeseAndBuzzwords.API.Controllers
{
	[RoutePrefix("carts")]
	public class CartsController : ApiController
	{
		[HttpGet]
		public IHttpActionResult Get()
		{
			return Ok(new[] {"Cart1", "Cart2"});
		}
	}
}
