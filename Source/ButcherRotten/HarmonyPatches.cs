using HarmonyLib;
using RimWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ButcherRotten
{
	[HarmonyPatch(typeof(GenRecipe), nameof(GenRecipe.MakeRecipeProducts))]
	static class GenRecipe_MakeRecipeProducts
	{
		[HarmonyPostfix]
		internal static void Postfix(ref IEnumerable<Thing> __result, RecipeDef recipeDef)
		{
			// only modify ButcherCorpseRotten recipes
			if (recipeDef == InternalRecipeDefOf.ButcherCorpseRotten)
			{
				var output = new List<Thing>();
				foreach (var thing in __result)
				{
					float modifier;

					// calculate variance
					float variance = ButcherRotten.VarianceModifier;
					variance = Rand.Range(-variance, variance);

					// get stackcount
					var stackCount = thing?.stackCount ?? 0;
					if (stackCount == 0)
						continue;

					// check thing categories for meat and leather
					var thingCategories = thing.def.thingCategories;
					if (thingCategories != null)
					{
						foreach (var category in thingCategories)
						{
							// meat
							if (category == ThingCategoryDefOf.MeatRaw)
							{
								modifier = ButcherRotten.MeatModifier;
								goto ADD_THING;
							}

							// leather
							if (category == ThingCategoryDefOf.Leathers)
							{
								modifier = ButcherRotten.LeatherModifier;
								goto ADD_THING;
							}
						}
					}

					// other products
					modifier = ButcherRotten.OtherModifier;
					
					ADD_THING:
					// calculate stack count
					stackCount = GenMath.RoundRandom(stackCount * modifier * (1f + variance));
					//Log.Message($"ButcherRotten: {thing} count {stackCount} / {thing.stackCount} modifier {modifier} variance {variance})");

					// add thing if stack count is greater than 0
					if (stackCount > 0)
					{
						thing.stackCount = stackCount;
						output.Add(thing);
					}
				}

				// output
				__result = output;
			}
		}
	}
}
