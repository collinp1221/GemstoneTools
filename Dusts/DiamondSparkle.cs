using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace GemstoneTools.Dusts
{
	public class DiamondSparkle : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noGravity = true;
		}
	}
}