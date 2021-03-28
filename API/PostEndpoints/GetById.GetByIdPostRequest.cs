using API.Common;

namespace API.PostEndpoints
{
	public class GetByIdPostRequest : BaseRequest
	{
		public int PostId { get; set; }
	}
}