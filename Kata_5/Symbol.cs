using System.Collections.Generic;
using System.Text;

namespace Kata_5
{
	class Symbol
	{
		public char representation;
		public List<Symbol> dependencies = new List<Symbol>();

		public Symbol(char representation)
		{
			this.representation = representation;
		}

		public void AddDependency(Symbol dependency)
		{
			if (dependency != this && !dependencies.Contains(dependency)) dependencies.Add(dependency);
		}

		public override string ToString()
		{
			if (dependencies.Count == 0) return representation.ToString();
			else {
				StringBuilder sb = new StringBuilder();
				sb.Append(representation).Append(' ');
				var transientDependencies = new List<Symbol>();
				GetAllDependencies(transientDependencies);
				foreach (var dep in transientDependencies) {
					if (dep != this) sb.Append(dep.representation).Append(' ');
				}
				return sb.ToString();
			}
		}

		void GetAllDependencies(List<Symbol> symbolsFound)
		{
			foreach (var dep in dependencies) {
				if (!symbolsFound.Contains(dep)) {
					symbolsFound.Add(dep);
					dep.GetAllDependencies(symbolsFound);
				}
			}
		}
	}
}
