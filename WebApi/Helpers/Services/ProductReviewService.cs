using WebApi.Helpers.Repositories;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class ProductReviewService
{
	private readonly ProductReviewRepository _productReviewRepository;

	public ProductReviewService(ProductReviewRepository productReviewRepository)
	{
		_productReviewRepository = productReviewRepository;
	}

	public async Task<bool> CreateReviewAsync(ProductReviewSchema schema)
	{
		var entity = await _productReviewRepository.AddAsync(schema);
		if(entity == null)
		{
			return false;
		}

		return true;
	}
}
