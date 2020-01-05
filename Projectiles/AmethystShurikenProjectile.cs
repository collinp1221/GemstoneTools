using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GemstoneTools.Projectiles
{
	public class AmethystShurikenProjectile : ModProjectile
	{

		public int tickCounter = 0;

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Amethyst Shuriken");
        }

		public override void SetDefaults()
		{
			projectile.width = 20; //Set the hitbox width
			projectile.height = 20; //Set the hitbox height
			projectile.timeLeft = 1000; //The amount of time the projectile is alive for
			projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = false; //Tells the game whether or not projectile will be affected by water
			projectile.ranged = true; //Tells the game whether it is a ranged projectile or not
			projectile.aiStyle = 2; //Preset Projectile AI. Ideally would want to modify this later
			projectile.maxPenetrate = 4; //Can pierce through 4 enemies before despawning
		}
		
		public override void AI()
		{
			tickCounter++;
			//Every 15 ticks (.25 seconds) create a particle effect centered on the projectile
			if(tickCounter >= 15)
            {
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("AmethystSparkle"), projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
				tickCounter = 0;
			}

			Lighting.AddLight(projectile.position, .2f, 0, .45f); //Position, R,G,B
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//Create a particle effect on hitting an NPC
			Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("AmethystSparkle"));

		}

		public override bool OnTileCollide(Vector2 velocityChange)
		{
			//Create a particle effect on collision with a tile
			Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("AmethystSparkle"));

			//Play a sound on tile collision
			Main.PlaySound(0);

			return true;
		}

		public override void Kill(int timeLeft)
		{
			//30% Chance to drop the shuriken on despawn (for consisitency)
			int randInt = Main.rand.Next(1, 11);
			if (randInt >= 8)
				Item.NewItem(projectile.getRect(), mod.ItemType("AmethystShuriken"));
		}
		
	}
}
