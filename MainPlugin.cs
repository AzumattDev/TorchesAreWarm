using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace TorchesAreWarm
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class TorchesAreWarmPlugin : BaseUnityPlugin

    {
        internal const string ModName = "TorchesAreWarm";
        internal const string ModVersion = "1.0.1";
        internal const string Author = "Azumatt";
        private const string ModGUID = Author + "." + ModName;
        private readonly Harmony _harmony = new(ModGUID);
        public static readonly ManualLogSource TorchesAreWarmLogger = BepInEx.Logging.Logger.CreateLogSource(ModName);

        private void Awake()
        {
            _harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(PlayerCharacter), nameof(PlayerCharacter.CS))]
    static class PlayerCharacterCSPatch
    {
        static void Postfix(PlayerCharacter __instance)
        {
            if (Global.code.Player.weaponInHand == null) return;
            if (Global.code.Player.weaponInHand._item.name == "B3_Torch")
            {
                Global.code.Player.FireSourceHeat += 50;
            }
        }
    }
}