using System;
using API.Common;

namespace API.PostEndpoints
{
	public class GetByIdPostResponse : BaseResponse
	{
		

		public PostDto Post { get; set; }

		public GetByIdPostResponse(Guid correlationId) : base(correlationId)
		{ }

		public GetByIdPostResponse()
		{ }
	}
}
