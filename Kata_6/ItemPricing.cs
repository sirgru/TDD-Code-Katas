using System;

namespace Kata_6
{
	class ItemPricing
	{
		private float    _singlePrice;
		private int      _quantityForSpecialPrice;
		private float    _specialPrice;

		public ItemPricing(float singlePrice, int quantityForSpecialPrice, float specialPrice)
		{
			_singlePrice = singlePrice;
			_quantityForSpecialPrice = quantityForSpecialPrice;
			_specialPrice = specialPrice;
		}

		public float GetPricingForQuantity(int quantity)
		{
			if (quantity < 1) throw new ArgumentException("Quantity can not be less than 1.");

			if (quantity > _quantityForSpecialPrice && _quantityForSpecialPrice > 0) {
				return _specialPrice + GetPricingForQuantity(quantity - _quantityForSpecialPrice);
			}
			else if (quantity == _quantityForSpecialPrice) {
				return _specialPrice;
			}
			else {
				return quantity * _singlePrice;
			}
		}
	}
}
