using WebApi.Helpers.Repositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
	public class PromoCodeService
	{
		private readonly PromoCodeRepository _promoCodeRepo;

		public PromoCodeService(PromoCodeRepository promoCodeRepo)
		{
			_promoCodeRepo = promoCodeRepo;
		}

		public async Task<PromoCodeEntity> ValidatePromoCode(string code)
		{
			var promoCode = await _promoCodeRepo.GetAsync(x => x.Code == code);

			if (promoCode == null)
				return null!;

			if (!promoCode.IsValid || promoCode.StartDate > DateTime.Now || promoCode.EndDate < DateTime.Now)
				return null!;

			return promoCode;
		}
	}
}
