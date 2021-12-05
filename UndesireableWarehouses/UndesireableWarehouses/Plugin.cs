using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace UndesireableStorage {

	[BepInPlugin("mo.timberborn.undesireable_storage", "Undesireable Storage", "1.0.0")]
	[BepInProcess("Timberborn.exe")]
	public class Plugin : BaseUnityPlugin {

		void Awake() {

			Statics.Logger = Logger;

			Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
			Logger.LogInfo($"Plugin mo.timberborn.undesireable_storage is loaded...");

		}

  }

}