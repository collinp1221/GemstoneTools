using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace GemstoneTools.Items
{
    public class GemstoneFlash : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gemstone Flash");
        }

        public override void SetDefaults()
        {
            item.width = 100;
            item.height = 100;
            item.maxStack = 1;
            item.value = 1;  //TODO CHANGE THIS
            item.rare = 2;
            item.useStyle = 5;
            item.useTurn = false;
            item.autoReuse = true;
            item.damage = 37;
            item.knockBack = 3.5f;
            item.magic = true; //Magic Weapon
            item.mana = 5; //Consumes 5 mana per use (Probably change)
            item.useAnimation = 20;
            item.useTime = 20;
            item.UseSound = SoundID.Item8;
            item.shoot = mod.ProjectileType("EmeraldShard"); //Projectile type
            item.shootSpeed = 8.5f; //Shoot speed
            item.noMelee = true;
        }

        public override void OnConsumeMana(Player player, int manaConsumed)
        {
            
            //Random Gemstone Selection
            int randInt = Main.rand.Next(1, 7); //Random integer generation. Second int is not included in range
            if(randInt == 1)
                item.shoot = mod.ProjectileType("AmethystShard");
            if(randInt == 2)
                item.shoot = mod.ProjectileType("TopazShard");
            if(randInt == 3)
                item.shoot = mod.ProjectileType("SapphireShard");
            if(randInt == 4)
                item.shoot = mod.ProjectileType("EmeraldShard");
            if(randInt == 5)
                item.shoot = mod.ProjectileType("RubyShard");
            if(randInt == 6)
                item.shoot = mod.ProjectileType("DiamondShard");
        }
        

    }
}