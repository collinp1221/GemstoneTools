using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace GemstoneTools.Items
{
    public class AmethystPickaxe : ModItem
    {


        public override void SetStaticDefaults() 
        {
            //Tooltip.SetDefault("A pickaxe forged of pure amethyst. Holding it, you can feel a chill as its power flows through you.");
            DisplayName.SetDefault("Amethyst Pickaxe");
        }

        public override void SetDefaults()
        {
            item.width = 100;
            item.height = 100;
            item.maxStack = 1;
            item.value = 4000;
            item.rare = 1;
            item.useStyle = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.damage = 8;
            item.knockBack = 2;
            item.melee = true;
            item.pick = 55; //Pickaxe Power
            item.useAnimation = 19;
            item.useTime = 19;
            item.UseSound = SoundID.Item1;
            // Set other item.X values here
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.Amethyst, 12);
            recipe1.AddIngredient(ItemID.IronBar, 4);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Amethyst, 12);
            recipe2.AddIngredient(ItemID.LeadBar, 4);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2(hitbox.X, hitbox.Y), .4f, 0, .9f); //Position, R,G,B?
            int randInt = Main.rand.Next(0, 10);
            if (randInt > 8) //2 in 10 chance
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X + 20, hitbox.Y), 10, 10, mod.DustType("AmethystSparkle")); //Position(X,Y), X-Size, Y-Size, Dust Type
            }

        }

    }
}