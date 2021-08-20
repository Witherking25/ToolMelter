using System.Collections.Generic;
using System.Linq;
using System.Resources;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ToolMelter.ModItems;
using ToolMelter.ModTiles;
using static Terraria.ModLoader.ModContent;

namespace ToolMelter
{
	public class ToolMelter : Mod
	{
		public override void Load()
		{
			base.Load();
		}
		// public override void Load()
		// {
		// 	base.Load();
		// 	RecipeBag recipe = new RecipeBag(this);
		// 	List<Recipe> recipes = new List<Recipe>();
		// 	RecipeFinder finder = new RecipeFinder();
		// 	finder.AddTile(TileID.Anvils);
		// 	recipes = finder.SearchRecipes();
		// 	ItemScrapBag bag;
		// 	for (int i = 0; i >= recipes.Count; i++)
		// 	{
		// 		recipe = new RecipeBag(this);
		// 		recipe.AddIngredient(recipes.ElementAt(i).createItem.type);
		// 		recipe.AddTile(TileType<TileCrucible>());
		// 		bag = new ItemScrapBag();
		// 		if (GetItem("ScrapBag" + recipes.ElementAt(i).createItem.Name) == null)
		// 		{
		// 			AddItem("ScrapBag" + recipes.ElementAt(i).createItem.Name, bag);
		// 			Main.itemTexture[GetItem("ScrapBag" + recipes.ElementAt(i).createItem.Name).item.type] = GetTexture("ModItems/ItemScrapBag");
		// 		}
		// 		bag = (ItemScrapBag)GetItem("ScrapBag" + recipes.ElementAt(i).createItem.Name);
		// 		for (int ii = 0; ii >= recipes.ElementAt(i).requiredItem.Count(); ii++)
		// 		{
		// 			if (recipes.ElementAt(i).requiredItem.ElementAt(ii).stack != 0)
		// 			{
		// 				bag.AddItem(recipes.ElementAt(i).requiredItem.ElementAt(ii));
		// 			}
		// 		}
		//
		// 		Logger.Debug(bag.items);
		// 		recipe.SetResult(bag);
		// 		Logger.Debug(recipe.createItem);
		// 		recipe.AddRecipe();
		// 		bag.Save();
		// 		bag.items.Clear();
		// 	}
		// }

		public override void AddRecipes()
		{
			
		}
	}
}