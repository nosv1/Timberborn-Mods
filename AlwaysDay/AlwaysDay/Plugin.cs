using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace AlwaysDay  { 

	[BepInPlugin("mo.timberborn.alwaysday", "Always Day", "1.0.0")]
	[BepInProcess("Timberborn.exe")]

	public class Plugin : BaseUnityPlugin {

		void Awake() {

			Statics.Logger = Logger;

			Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
			Logger.LogInfo($"Plugin mo.timberborn.alwaysday is loaded...");
			
		}

	}
}
