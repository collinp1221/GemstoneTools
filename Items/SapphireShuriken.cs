using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace GemstoneTools.Items
{
    public class SapphireShuriken : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sapphire Shuriken");
        }

        public override void SetDefaults()
        {
            item.width = 100;
            item.height = 100;
            item.maxStack = 999;
            item.value = 1; 
            item.rare = 1;
            item.useStyle = 1;
            item.useTurn = true;
            item.damage = 37;
            item.knockBack = 3.5f;
            item.thrown = true; //Throwing Weapon
            item.useAnimation = 15;
            item.useTime = 15;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("SapphireShurikenProjectile"); //Projectile type
            item.shootSpeed = 9f; //Shoot speed
            item.noMelee = true;
            item.consumable = true; //Makes this a consumable item
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.Sapphire, 1);
            recipe1.AddIngredient(ItemID.Shuriken, 50);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.SetResult(this, 50);
            recipe1.AddRecipe();
        }
    }
}