
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ToolMelter.ModTiles;
using System.IO;
using System.Linq;

namespace ToolMelter.ModItems
{
	public class ItemScrapBag : ModItem
    {
		private List<Item> _items = new();
/*		public override string Texture => "ModLoader/StartBag";
*/		

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scrap Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.Blue;
			// Items.Add(ModContent.GetModItem(ModContent.ItemType<ItemCrucible>()).Item);
		}
		private void AddItem(Item item)
		{
			_items.Add(item);
		}

		private void ResetItems()
		{
			_items = new List<Item>();
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			foreach (Item item in _items)
			{
				player.QuickSpawnItem(item, item.stack);
			}
		}

		public override TagCompound Save()
		{
			return new TagCompound { ["items"] = _items };
		}

		public override void Load(TagCompound tag)
		{
			_items = tag.Get<List<Item>>("items");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.Add(new TooltipLine(Mod, "contentsTitle", "Contents: "));
			for (int i = 0; i < _items.Count; i++)
			{
				tooltips.Add(new TooltipLine(Mod, "contents" + i, _items[i].stack + " " + _items[i].Name));
			}
		}

		public override void AddRecipes()
		{
			for (int i = 0; i < Recipe.numRecipes; i++) 
			{
				Recipe recipe = Main.recipe[i];

				if 
				(
					recipe.createItem.damage > 0 || 
					recipe.createItem.pick > 0 || 
					recipe.createItem.axe > 0 ||
					recipe.createItem.hammer > 0 ||
					recipe.createItem.accessory ||
					recipe.createItem.headSlot != -1 ||
					recipe.createItem.bodySlot != -1 ||
					recipe.createItem.legSlot != -1
				)
				{
					foreach (Item ingredient in recipe.requiredItem)
					{
						AddItem(ingredient);
					}
					CreateRecipe()
						.AddTile<TileCrucible>()
						.AddIngredient(recipe.createItem.type, recipe.createItem.stack)
						.Register();
					
					ResetItems();
				}
			}
		}
    }
}
