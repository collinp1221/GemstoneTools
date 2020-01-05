using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace GemstoneTools.Items
{
    public class RubyPickaxe : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruby Pickaxe");
        }

        public override void SetDefaults()
        {
            item.width = 100;
            item.height = 100;
            item.maxStack = 1;
            item.value = 27000;
            item.rare = 2;
            item.useStyle = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.damage = 14;
            item.knockBack = 3;
            item.melee = true;
            item.pick = 65; //Pickaxe Power
            item.useAnimation = 14;
            item.useTime = 14;
            item.UseSound = SoundID.Item1;
            // Set other item.X values here
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.Ruby, 12);
            recipe1.AddIngredient(ItemID.IronBar, 4);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Ruby, 12);
            recipe2.AddIngredient(ItemID.LeadBar, 4);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2(hitbox.X,hitbox.Y), .8f, 0, .2f); //Position, R,G,B
            int randInt = Main.rand.Next(0, 10);
            if(randInt > 8) //2 in 9 chance
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X + 20, hitbox.Y), 10, 10, mod.DustType("RubySparkle")); //Position(X,Y), X-Size, Y-Size, Dust Type
            }
            
        }
    }
}