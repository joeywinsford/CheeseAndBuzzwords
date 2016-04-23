using System;
using System.Net;
using System.Web.Http;

namespace CheeseAndBuzzwords.API.Controllers
{
	[RoutePrefix("carts")]
	public class CartsController : ApiController
	{
		private readonly EventStore.EventStore _eventStream;

		public CartsController()
		{
			_eventStream = new EventStore.EventStore(new IPEndPoint(IPAddress.Loopback, 1113));
		}

		[HttpGet]
		public IHttpActionResult Get()
		{
			return Ok(new[] {"Cart1", "Cart2"});
		}

		[Route("new")]
		[HttpPost]
		public IHttpActionResult New()
		{
			try
			{
				var cartId = new CartId(Guid.NewGuid());
				var newCart = new Cart(cartId);
				newCart.Publish(_eventStream);

				return Created(new Uri(Request.RequestUri, cartId.Value.ToString()), "New cart created");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
