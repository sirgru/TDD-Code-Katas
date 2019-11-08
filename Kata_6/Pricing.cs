using System;
using System.Collections.Generic;

namespace Kata_6
{
	public class Pricing
	{
		private Dictionary<char, ItemPricing> _pricingScheme = new Dictionary<char, ItemPricing>();

		public void AddItem(char item, float singleItemPrice)
		{
			AddItemWithSpecialPricing(item, singleItemPrice, 0, 0);
		}

		public void AddItemWithSpecialPricing(char item, float singlePrice, int quantityForSpecialPrice, float specialPrice)
		{
			if (_pricingScheme.ContainsKey(item)) throw new ArgumentException("Price already defined for item: " + item);

			_pricingScheme.Add(item, new ItemPricing(singlePrice, quantityForSpecialPrice, specialPrice));
		}

		public float GetPriceForItem(char item, int quantity)
		{
			if (!_pricingScheme.TryGetValue(item, out ItemPricing itemPricing)) {
				throw new ArgumentException("Trying to get pricing for item without defined price.");
			}
			return itemPricing.GetPricingForQuantity(quantity);
		}
	}
}
