
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

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
			Item.rare = ItemRarityID.Expert;
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
			foreach (var item in _items)
			{
				player.QuickSpawnItem(item, item.stack);
			}
		}
		
		

		public override void SaveData(TagCompound tag)
		{
			tag.Set("items", _items, true);
		}

		public override void LoadData(TagCompound tag)
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
					var modRecipe = CreateRecipe().AddIngredient(recipe.createItem.type, recipe.createItem.stack);
					foreach (var tile in recipe.requiredTile)
					{
						modRecipe.AddTile(tile);
					}
					modRecipe.Register();
					
					ResetItems();
				}
			}
		}
    }
}
