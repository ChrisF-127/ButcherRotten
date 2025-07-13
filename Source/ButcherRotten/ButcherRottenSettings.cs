using SyControlsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ButcherRotten
{
	public class ButcherRottenSettings : ModSettings
	{
		#region CONSTANTS
		public const int Default_MeatModifier = 0;
		public const int Default_LeatherModifier = 0;
		public const int Default_OtherModifier = 0;
		public const int Default_VarianceModifier = 0;
		#endregion

		#region PROPERTIES
		public int MeatModifier { get; set; } = Default_MeatModifier;
		public int LeatherModifier { get; set; } = Default_LeatherModifier;
		public int OtherModifier { get; set; } = Default_OtherModifier;
		public int VarianceModifier { get; set; } = Default_VarianceModifier;
		#endregion

		#region PUBLIC METHODS
		public void DoSettingsWindowContents(Rect inRect)
		{
			var width = inRect.width;
			var offsetY = 0.0f;

			ControlsBuilder.Begin(inRect);
			try
			{
				MeatModifier = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_BR.MeatModifier".Translate(),
					"SY_BR.MeatModifierDesc".Translate(new NamedArgument(0.ToString(), "default")),
					MeatModifier,
					Default_MeatModifier,
					nameof(MeatModifier),
					0,
					100,
					unit: "%");
				LeatherModifier = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_BR.LeatherModifier".Translate(),
					"SY_BR.MeatModifierDesc".Translate(new NamedArgument(0.ToString(), "default")),
					LeatherModifier,
					Default_LeatherModifier,
					nameof(LeatherModifier),
					0,
					100,
					unit: "%");
				OtherModifier = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_BR.OtherModifier".Translate(),
					"SY_BR.OtherModifierDesc".Translate(new NamedArgument(0.ToString(), "default")),
					OtherModifier,
					Default_OtherModifier,
					nameof(OtherModifier),
					0,
					100,
					unit: "%");
				VarianceModifier = ControlsBuilder.CreateNumeric(
					ref offsetY,
					width,
					"SY_BR.VarianceModifier".Translate(),
					"SY_BR.VarianceModifierDesc".Translate(new NamedArgument(0.ToString(), "default")),
					VarianceModifier,
					Default_VarianceModifier,
					nameof(VarianceModifier),
					0,
					100,
					unit: "%");
			}
			finally
			{
				ControlsBuilder.End(offsetY);
			}
		}
		#endregion

		#region OVERRIDES
		public override void ExposeData()
		{
			base.ExposeData();

			int intValue;

			intValue = MeatModifier;
			Scribe_Values.Look(ref intValue, nameof(MeatModifier), Default_MeatModifier);
			MeatModifier = intValue;

			intValue = LeatherModifier;
			Scribe_Values.Look(ref intValue, nameof(LeatherModifier), Default_LeatherModifier);
			LeatherModifier = intValue;

			intValue = OtherModifier;
			Scribe_Values.Look(ref intValue, nameof(OtherModifier), Default_OtherModifier);
			OtherModifier = intValue;

			intValue = VarianceModifier;
			Scribe_Values.Look(ref intValue, nameof(VarianceModifier), Default_VarianceModifier);
			VarianceModifier = intValue;
		}
		#endregion
	}
}
