using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ButcherRotten
{
    public class ButcherRotten : Mod
	{
		#region PROPERTIES
		public static ButcherRotten Instance { get; private set; }
		public static ButcherRottenSettings Settings { get; private set; }
		#endregion

		#region CONSTRUCTORS
		static ButcherRotten()
		{
			var harmony = new Harmony("sy.butcherrotten");
			harmony.PatchAll();
		}

		public ButcherRotten(ModContentPack content) : base(content)
		{
			Instance = this;

			LongEventHandler.ExecuteWhenFinished(Initialize);
		}
		#endregion

		#region OVERRIDES
		public override string SettingsCategory() =>
			"Butcher Rotten";

		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);

			Settings.DoSettingsWindowContents(inRect);
		}
		#endregion

		#region PRIVATE METHODS
		private void Initialize()
		{
			Settings = GetSettings<ButcherRottenSettings>();
		}
		#endregion
	}
}
