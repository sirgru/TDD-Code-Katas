using System.Collections.Generic;

namespace Kata_6
{
	public class IncrementalCheckout
	{
		private Pricing _pricing;

		private Dictionary<char, int> _itemToCount = new Dictionary<char, int>();

		public IncrementalCheckout(Pricing pricing)
		{
			_pricing = pricing;
		}

		public void Scan(char item)
		{
			if (!_itemToCount.ContainsKey(item)) _itemToCount.Add(item, 1);
			else _itemToCount[item] = _itemToCount[item] + 1;
		}

		public float GetTotal()
		{
			float total = 0;
			foreach (var item in _itemToCount) {
				total += _pricing.GetPriceForItem(item.Key, item.Value);
			}
			return total;
		}
	}
}
