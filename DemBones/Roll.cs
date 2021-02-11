namespace Floatingman.Geographic.Utility.Randomizer
{
	using System;

	public static class Roll
	{
		private const int DefaultNumberOfDice = 2;
		private const int DefaultNumberOfSides = 6;
		private static readonly Random Bones;

		//protected static void OnBonesRolled(BonesRolledEventArgs e)
		//{
		//	if (BonesRolled != null) BonesRolled(null, e);
		//}

		static Roll()
		{
			Bones = new Random();
		}

		public static event EventHandler<BonesRolledEventArgs> BonesRolled = delegate { };

		public static Bones DemBones(string reason)
		{
			return DemBones(DefaultNumberOfDice, DefaultNumberOfSides, reason);
		}

		public static Bones DemBones(int numberOfDice, int sides, string reason)
		{
			Bones bones = new Bones();
			for (int i = 1; i <= numberOfDice; i++)
			{
				bones.Add(Bones.Next(1, sides + 1));
			}

			BonesRolled(null, new BonesRolledEventArgs
			{
				Bones = bones,
				Reason = reason,
			});
			return bones;
		}

		public static Bones DemBones<TSides>(int numberOfDice, string reason)
			where TSides : IDie, new()
		{
			return DemBones(numberOfDice, new TSides().Sides, reason);
		}

		public static Bones DemBones<TSides>(string reason)
			where TSides : IDie, new()
		{
			return DemBones(1, new TSides().Sides, reason);
		}
	}
}