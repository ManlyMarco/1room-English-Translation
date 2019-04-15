using System.Collections.Generic;
using System.Reflection.Emit;
using BepInEx;
using Harmony;

namespace Translation
{
    [BepInPlugin(GUID, "1room translation tweaks", "1.0")]
    public class TranslationTweaks : BaseUnityPlugin
    {
        private const string GUID = "marco.1roomTweaks";

        private void Awake()
        {
            HarmonyInstance.Create(GUID).PatchAll(typeof(TranslationTweaks));
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(PantTextFormatter), "Generate")]
        public static void MoanTranslationFix(ref string suffix)
        {
            // Remove untranslated っ at the end of lines
            suffix = suffix?.Replace("っ", string.Empty);
        }

        [HarmonyTranspiler]
        [HarmonyPatch(typeof(UtageCommand), "OpenItem")]
        public static IEnumerable<CodeInstruction> OpenItemTranslateHook(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.ToString() == "callvirt System.String get_Name()")
                {
                    instruction.opcode = OpCodes.Call;
                    instruction.operand = AccessTools.Method(typeof(TranslationTweaks), nameof(GetTranslatedItemName));
                }
                yield return instruction;
            }
        }

        private static readonly Dictionary<string, string> _itemNameTranslations = new Dictionary<string, string>
        {
            {"セクシーな下着","Sexy underwear" },
            {"清楚な下着","Neat underwear" },
            {"マイクロビキニ","Micro bikini" },
            {"透視メガネ","Perceptive glasses" },
            {"目隠し","Blindfold" }
        };

        public static string GetTranslatedItemName(GameItemData item)
        {
            if (_itemNameTranslations.TryGetValue(item.Name, out var translation))
                return translation;
            return item.Name;
        }
    }
}
