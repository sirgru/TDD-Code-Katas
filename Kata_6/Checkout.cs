using System.Collections.Generic;

namespace Kata_6
{
	public class Checkout
	{
		public Pricing pricing;

		private Dictionary<char, int> _itemToCount = new Dictionary<char, int>();

		public Checkout(Pricing pricing)
		{
			this.pricing = pricing;
		}

		public float GetTotal(string items)
		{
			_itemToCount.Clear();
			for (int i = 0; i < items.Length; i++) {
				if (!_itemToCount.ContainsKey(items[i])) _itemToCount.Add(items[i], 1);
				else _itemToCount[items[i]] = _itemToCount[items[i]] + 1;
			}

			float total = 0;
			foreach (var item in _itemToCount) {
				total += pricing.GetPriceForItem(item.Key, item.Value);
			}
			return total;
		}
	}
}
