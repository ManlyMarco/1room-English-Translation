# 1room English Translation
Full English translation for the game 1room -Runaway Girl- (1room -家出少女-) by Akari Blast! This translation covers all in-game text - all script and UI.

The translation does not modify any of the original game files. Instead it is using [BepInEx](https://github.com/BepInEx/BepInEx
), [AutoTranslator](https://github.com/bbepis/XUnity.AutoTranslator), [INIfier.Bepin](https://github.com/ManlyMarco/INIfier.Bepin) and a custom BepInEx plugin to translate the game "on the fly". This way only the actual translations can be distributed, and the translation is very likely to work correctly on different game versions.

[Official game website](http://cultparthia.com/1room/)

[Buy the game](https://www.dlsite.com/ecchi-eng/work/=/product_id/RE228027.html)

![preview](https://user-images.githubusercontent.com/39247311/56252982-c3ff9000-60ba-11e9-8063-705a15fc25a6.PNG)

## How to install
1. Get the game. The translation was tested on v1.1.0 but it should work on newer versions without issues.
2. Get the latest release from the Releases tab above.
3. Extract the release to the root of your game. If you already have a BepInEx folder in your game directory, remove it before extracting the release.
4. Start the game. It should now be translated. You can open the options screen to confirm that the translation works.
5. Have fun!

## How to contribute
If you want to submit any improvements [fork the repository](https://help.github.com/articles/fork-a-repo/). Upload/make your changes to your fork and then [submit a pull request](https://help.github.com/articles/about-pull-requests/). Your pull request will be reviewed and accepted after a quality check. All help is greatly appreciated!

Translations are split into three parts:
1. The main part are the files inside the `Translation` folder, for most purposes this is the only folder you need to care about. They contain pairs of Japanese=English for most o the text in the game. Keep the Japanese part intact, only change the English part. After you edit the files you can press Alt+R to see the changes in the game (no need to restart).
2. Files inside `Assets` folder are modifications to game asset files. Don't touch anything that isn't translated since it can break the game, only submit fixes to existing translations.
3. `Translation/GameItemTranslations.txt` contains item names for use by the plugin to translate some of the special screens. They are used for general translations as well.

## Credits
- The Butler, DX5536, Helios7 - [Original translation project](https://f95zone.to/threads/1room-runaway-girl-the-butler-translation.18074/) and intial translations (around 25% of script and UI).
- [ManlyMarco](https://www.patreon.com/manlymarco) - Packaging, programming, testing, proofing and help with some translations.
- WataThaBradicus - Revising the original translation and translating everything else (the remaining 75%).
