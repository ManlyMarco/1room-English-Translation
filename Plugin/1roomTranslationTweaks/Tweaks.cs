using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using BepInEx;
using BepInEx.Logging;
using Harmony;

namespace Translation
{
    [BepInPlugin(GUID, "1room translation tweaks", "1.0")]
    public class TranslationTweaks : BaseUnityPlugin
    {
        public const string GUID = "marco.1roomTranslationTweaks";

        private void Awake()
        {
            var translationsPath = Path.Combine(Paths.PluginPath, "Translation/GameItemTranslations.txt");
            if (!File.Exists(translationsPath))
            {
                Logger.Log(LogLevel.Error, "Could not find item translation file: " + translationsPath);
                return;
            }

            var translations = File.ReadAllLines(translationsPath)
                .Where(x => !string.IsNullOrEmpty(x?.Trim()))
                .Select(x => x.Split(new[] { '=' }, 2, StringSplitOptions.None))
                .GroupBy(x => x.Length);

            foreach (var translationGroup in translations)
            {
                if (translationGroup.Key == 2)
                {
                    _itemNameTranslations = translationGroup.ToDictionary(x => x[0], x => x[1]);
                }
                else
                {
                    foreach (var line in translationGroup)
                        Logger.Log(LogLevel.Warning, "Invalid line in GameItemTranslations.txt: " + string.Join("=", line));
                }
            }

            if (_itemNameTranslations == null || _itemNameTranslations.Count == 0)
            {
                Logger.Log(LogLevel.Error, "No translations were found in item translation file: " + translationsPath);
                return;
            }

            HarmonyInstance.Create(GUID).PatchAll(typeof(TranslationTweaks));
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PantTextFormatter), "Generate")]
        public static void MoanTranslationFix(ref string __result)
        {
            // Remove untranslated っ at the end of lines
            __result = __result?.Replace("っ", string.Empty);
        }

        [HarmonyTranspiler]
        [HarmonyPatch(typeof(UtageCommand), "OpenItem")]
        public static IEnumerable<CodeInstruction> OpenItemTranslateHook(IEnumerable<CodeInstruction> instructions)
        {
            return HookObjectGetName(instructions);
        }

        [HarmonyTranspiler]
        [HarmonyPatch(typeof(UtageCommand), "ObtainTrophy")]
        public static IEnumerable<CodeInstruction> ObtainTrophyTranslateHook(IEnumerable<CodeInstruction> instructions)
        {
            return HookObjectGetName(instructions);
        }

        [HarmonyTranspiler]
        [HarmonyPatch(typeof(UtageCommand), "GainItem")]
        public static IEnumerable<CodeInstruction> GainItemHook(IEnumerable<CodeInstruction> instructions)
        {
            return HookObjectGetName(instructions);
        }

        private static IEnumerable<CodeInstruction> HookObjectGetName(IEnumerable<CodeInstruction> instructions)
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

        private static Dictionary<string, string> _itemNameTranslations;

        public static string GetTranslatedItemName(GameItemData item)
        {
            Logger.Log(LogLevel.Debug, $"Looking for translation for item: {item.Name}");
            if (_itemNameTranslations.TryGetValue(item.Name, out var translation))
            {
                Logger.Log(LogLevel.Debug, $"Found translation: {translation}");
                return translation;
            }

            return item.Name;
        }
    }
}
