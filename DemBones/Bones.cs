namespace DemBones.Randomizer
{
	using System.Collections.Generic;
	using System.Linq;

	public class Bones : List<int>
	{
		public static implicit operator int(Bones r)
		{
			return r.Sum();
		}

		public override string ToString()
		{
			return this.Sum().ToString();
		}

		//public static explicit operator int(Bones r)
		//{
		//	return r.Sum();
		//}
		public int AsIndexer()
		{
			return this.Select(b => b - 1).Sum();
		}
	}
}