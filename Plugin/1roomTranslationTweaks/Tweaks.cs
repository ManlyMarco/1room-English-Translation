using System.Collections.Generic;
using System.Reflection.Emit;
using BepInEx;
using Harmony;

namespace Translation
{
    [BepInPlugin(GUID, "1room translation tweaks", "1.0")]
    public class TranslationTweaks : BaseUnityPlugin
    {
        public const string GUID = "marco.1roomTranslationTweaks";

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
            {"セクシーな下着", "Sexy underwear"},
            {"清楚な下着", "Neat underwear"},
            {"マイクロビキニ", "Micro bikini"},
            {"透視メガネ", "Perceptive glasses"},
            {"目隠し", "Blindfold"},
            {"コンドーム", "Condom"},
            {"アフターピル", "After Pill"},
            {"コーヒー豆", "Coffee Beans"},
            {"カモミール", "Chamomile"},
            {"精力剤", "Energizing Drink"},
            {"ローション", "Lotion Bottle"},
            {"媚薬クリーム", "Aphrodisiac Cream"},
            {"ファッション雑誌", "Fashion Magazine"},
            {"アダルト雑誌", "Adult Magazine"},
            {"難しい技術書", "Difficult Skill Book"},
            {"簡単な技術書", "Simple Skill Book"},
            {"ビジネス書", "Business Book"},
            {"最新転職ガイド", "Job Change Guide"},
            {"パジャマ", "Pajamas"},
            {"涼しげな部屋着", "Cool Room Clothes"},
            {"体操着", "Gym Clothes"},
            {"よそ行きの私服", "Casual Clothing"},
            {"ピンクローター", "Pink Rotor"},
            {"バイブ", "Vibe"},
            {"心理学入門", "Intro to Psychology"},
            {"乙女の秘密", "Maidens Secret"},
            {"セミロング", "Hair Down"},
            {"二つ結び", "Low Twintails"},
            {"ポニーテール", "Ponytail"}
        };

        public static string GetTranslatedItemName(GameItemData item)
        {
            if (_itemNameTranslations.TryGetValue(item.Name, out var translation))
                return translation;
            return item.Name;
        }
    }
}
