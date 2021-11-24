using HarmonyLib;
using Timberborn.SkySystem;
using UnityEngine;

namespace AlwaysDay  { 

	[HarmonyPatch]
	class AlwaysDayPatch {

		[HarmonyPostfix]
		[HarmonyPatch(typeof(Sun), "Transition")]
			static void overrideTargetColors(ref LightColors ____targetColors, ref DayNightColors ____currentColors) {

			____targetColors = ____currentColors.DayColors;  // overrides the setting to .NightColors

		}

		[HarmonyPrefix]
		[HarmonyPatch(typeof(Sun), "UpdateColors")]
		static void overrideSunIntensity(ref Light ____sun) {
			____sun.intensity = 2;  // overrides the transition from 2.0 to 1.0
		}

	}

}