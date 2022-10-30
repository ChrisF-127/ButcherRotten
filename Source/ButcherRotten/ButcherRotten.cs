using HugsLib.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace ButcherRotten
{
    public class ButcherRotten : HugsLib.ModBase
    {
        public static SettingHandle<float> MeatModifier;
        public static SettingHandle<float> LeatherModifier;
        public static SettingHandle<float> OtherModifier;
        public static SettingHandle<float> VarianceModifier;

        public override void DefsLoaded()
		{
            MeatModifier = Settings.GetHandle(
                nameof(MeatModifier),
                "SY_BR.MeatModifier".Translate(),
                "SY_BR.MeatModifierDesc".Translate(new NamedArgument(0f.ToString(), "default")),
                0f,
                Validators.FloatRangeValidator(0f, 1f));

            LeatherModifier = Settings.GetHandle(
                nameof(LeatherModifier),
                "SY_BR.LeatherModifier".Translate(),
                "SY_BR.LeatherModifierDesc".Translate(new NamedArgument(0.2f.ToString(), "default")),
                0.2f,
                Validators.FloatRangeValidator(0f, 1f));

            OtherModifier = Settings.GetHandle(
                nameof(OtherModifier),
                "SY_BR.OtherModifier".Translate(),
                "SY_BR.OtherModifierDesc".Translate(new NamedArgument(0.1f.ToString(), "default")),
                0.1f,
                Validators.FloatRangeValidator(0f, 1f));

            VarianceModifier = Settings.GetHandle(
                nameof(VarianceModifier),
                "SY_BR.VarianceModifier".Translate(),
                "SY_BR.VarianceModifierDesc".Translate(new NamedArgument(0f.ToString(), "default")),
                0f,
                Validators.FloatRangeValidator(0f, 1f));
        }
    }
}
