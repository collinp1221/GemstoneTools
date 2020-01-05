using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GemstoneTools.Projectiles
{
    public class TopazShard : ModProjectile
    {


		public override void SetDefaults()
        {
			//projectile.name = "Emerald Shard"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 14; //Set the hitbox width
			projectile.height = 18; //Set the hitbox height
			projectile.timeLeft = 180; //The amount of time the projectile is alive for
			projectile.penetrate = 5; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.ranged = true; //Tells the game whether it is a ranged projectile or not
			projectile.aiStyle = 0; //How the projectile works, this is no AI, it just goes a straight path


		}

		public override void AI()
        {

			//Rotate the projectile
			projectile.rotation += .25f;

			//Create a dust trail
			Dust.NewDust(projectile.position, projectile.width + 10, projectile.height + 10, mod.DustType("TopazSparkle"), projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);

			//Create light
			Lighting.AddLight(projectile.position, .8f, .5f, 0); //Position, R,G,B
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//Create a particle shower on hit
			for (int i = -5; i < 5; i++)
			{
				for (int j = -5; j < 5; j++)
				{
					Dust.NewDust(new Vector2(projectile.position.X + j, projectile.position.Y + i), 20, 20, mod.DustType("TopazSparkle"), 0, 0, 150, default(Color), 1.5f);
				}
			}
			int randInt = Main.rand.Next(1, 11); //70% chance to inflict shine 
			if (randInt <= 7)
				target.AddBuff(11, 300, true);
		}

		public override bool OnTileCollide(Vector2 velocityChange)
		{
			//Create a particle shower on tile collision
			for (int i = -5; i < 5; i++)
			{
				for (int j = -5; j < 5; j++)
				{
					Dust.NewDust(new Vector2(projectile.position.X + j, projectile.position.Y + i), 20, 20, mod.DustType("TopazSparkle"), 0, 0, 150, default(Color), 1.5f);
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
					Dust.NewDust(new Vector2(projectile.position.X + j, projectile.position.Y + i), 20, 20, mod.DustType("TopazSparkle"), 0, 0, 150, default(Color), 1.5f);
				}
			}
		}
	}
		
}
