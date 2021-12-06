using HarmonyLib;
using System.Linq;
using Timberborn.StockKeeping; // publicized
using Timberborn.InventorySystem;
using Timberborn.Emptying; // publicized
using Timberborn.Goods;
using Timberborn.ConstructibleSystem;
using Timberborn.Warehouses;



namespace UndesireableStorage  { 

	[HarmonyPatch]
	class UndesireableStoragePatch {

        // when Constructible finishes
        [HarmonyPostfix]
        [HarmonyPatch(typeof(Constructible), "NotifyOnStateExited")]
        static void patch(ref Constructible __instance, ref bool ____initialized) {

            if (__instance.IsUnfinished && ____initialized) {

                if (
                    __instance.gameObject.TryGetComponent(out Stockpile stockpile) &&
                    __instance.gameObject.TryGetComponent(out ToggleableGoodDisallower disallower) && 
                    __instance.gameObject.TryGetComponent(out GoodDesirer desirer) &&
                    desirer.TryGetComponent(out Emptiable emptiable)
                ) { 

                    // disallowing all goods 
                    foreach (
                        StorableGoodAmount good in stockpile.Inventory.AllowedGoods.ToList()
                    ) {

                        disallower.Disallow(good.StorableGood.GoodSpecification);

                        //Statics.Logger.LogInfo($"{__instance.gameObject.name} - {__instance.gameObject.GetInstanceID()} disallowing {good.StorableGood.GoodSpecification.name}");
                    }

                    // setting to empty for visual cue
                    emptiable.OnEnterFinishedState(); // sets emptiable to enabled to allowing emptying to be toggled
                    emptiable.MarkForEmptyingWithStatus();

                    //Statics.Logger.LogInfo($"{__instance.gameObject.name} set to emptying");
                }
            }

        }

    }

}