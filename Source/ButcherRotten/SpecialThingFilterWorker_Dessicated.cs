using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace ButcherRotten
{
	public class SpecialThingFilterWorker_Dessicated : SpecialThingFilterWorker
	{
		public override bool Matches(Thing t)
		{
			var compRottable = t.TryGetComp<CompRottable>();
			if (compRottable == null || compRottable.PropsRot.rotDestroys)
				return false;
			return compRottable.Stage == RotStage.Dessicated;
		}

		public override bool CanEverMatch(ThingDef def)
		{
			var compProperties = def.GetCompProperties<CompProperties_Rottable>();
			if (compProperties != null)
				return !compProperties.rotDestroys;
			return false;
		}
	}
}
