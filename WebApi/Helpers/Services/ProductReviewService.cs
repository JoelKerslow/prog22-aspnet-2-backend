using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
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

	public async Task<ICollection<ProductReviewDto>> GetAllAsync(int ProductId)
	{
		var result = await _productReviewRepository.GetAllAsync(ProductId);
		var DtosList = new List<ProductReviewDto>();
		
		foreach (var item in result)
		{
			var Dto = new ProductReviewDto();
			Dto.Id = item.Id;
			Dto.Rating = item.Rating;
			Dto.Comment = item.Comment;
			Dto.CustomerId = item.CustomerId;
			Dto.ProductId = item.ProductId;
			Dto.CustomerFirstName = item.Customer.FirstName;
			Dto.CustomerLastName = item.Customer.LastName;

			DtosList.Add(Dto);
		}
		return DtosList;
    }
}
