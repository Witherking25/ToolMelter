using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ToolMelter.ModItems
{
    class ItemCrucible : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Melts Down Old Tools");
			DisplayName.SetDefault("Crucible");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = TileType<ModTiles.TileCrucible>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.IronBar, 6)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
