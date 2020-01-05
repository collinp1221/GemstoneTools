using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GemstoneTools.Projectiles
{
    public class AmethystShard : ModProjectile
    {

		public int xVelocityChecker = 0;
		public int yVelocityChecker = 0;

		public override void SetDefaults()
        {
			//projectile.name = "Emerald Shard"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 14; //Set the hitbox width
			projectile.height = 18; //Set the hitbox height
			projectile.timeLeft = 720; //The amount of time the projectile is alive for
			projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.ranged = true; //Tells the game whether it is a ranged projectile or not
			projectile.aiStyle = 0; //How the projectile works, this is no AI, it just goes a straight path
		}

		public override void AI()
		{
			//First frame upon spawning, half the x and y velocity
			if (xVelocityChecker == 0)
            {
				projectile.velocity.X = projectile.velocity.X * .5f;
				xVelocityChecker = 1;
			}
			if (yVelocityChecker == 0)
			{
				projectile.velocity.Y = projectile.velocity.Y * .5f;
				yVelocityChecker = 1;
			}

			//projectile.velocity.Y = projectile.velocity.Y * 0.995f;
			projectile.rotation += .25f; //Rotate as it moves

			//Create a dust trail
			Dust.NewDust(projectile.position, projectile.width + 10, projectile.height + 10, mod.DustType("AmethystSparkle"), projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);

			//Create light
			Lighting.AddLight(projectile.position, .4f, 0, .9f); //Position, R,G,B
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//Create a particle shower on hit 
			for (int i = -5; i < 5; i++)
			{
				for (int j = -5; j < 5; j++)
				{
					Dust.NewDust(new Vector2(projectile.position.X + j, projectile.position.Y + i), 20, 20, mod.DustType("AmethystSparkle"), 0, 0, 150, default(Color), 1.5f);
				}
			}
			int randInt = Main.rand.Next(1, 11);
			if (randInt <= 3) // 30% chance to inflict confusion
				target.AddBuff(31, 600, true);
		}

		public override bool OnTileCollide(Vector2 velocityChange)
		{
			//Create a particle shower on tile collision
			for (int i = -5; i < 5; i++)
			{
				for (int j = -5; j < 5; j++)
				{
					Dust.NewDust(new Vector2(projectile.position.X + j, projectile.position.Y + i), 20, 20, mod.DustType("AmethystSparkle"), 0, 0, 150, default(Color), 1.5f);
				}
			}

			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = -5; i < 5; i++)
			{
				for (int j = -5; j < 5; j++)
				{
					Dust.NewDust(new Vector2(projectile.position.X + j, projectile.position.Y + i), 20, 20, mod.DustType("AmethystSparkle"), 0, 0, 150, default(Color), 1.5f);
				}
			}
		}
	}
		
}
