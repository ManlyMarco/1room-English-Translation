# 1room English Translation
Full English transaltion for the game 1room -Runaway Girl- (1room -家出少女-) by Akari Blast! This translation covers all in-game text - all script and UI.

The translation does not modify any of the original game files. Instead it is using [BepInEx](https://github.com/BepInEx/BepInEx
), [AutoTranslator](https://github.com/bbepis/XUnity.AutoTranslator), [INIfier.Bepin](https://github.com/ManlyMarco/INIfier.Bepin) and a custom BepInEx plugin to translate the game "on the fly". This way only the actual translations can be distributed, and the translation is very likely to work correctly on different game versions.

[Official game website](http://cultparthia.com/1room/)

[Buy the game](https://www.dlsite.com/ecchi-eng/work/=/product_id/RE228027.html)

## How to install
1. Get the game. The translation was tested on v1.1.0 but it should work on newer versions without issues.
2. Get the latest release from the Releases tab above.
3. Extract the release to the root of your game. If you already have a BepInEx folder in your game directory, remove it before extracting the release.
4. Start the game. It should now be translated. You can open the options screen to confirm that the translation works.
5. Have fun!

## How to contribute
If you want to submit any improvements [fork the repository](https://help.github.com/articles/fork-a-repo/). Upload/make your changes to your fork and then [submit a pull request](https://help.github.com/articles/about-pull-requests/). Your pull request will be reviewed and accepted after a quality check. All help is greatly appreciated!

Translations are split into three parts:
1. The main part are the files inside the `Translation` folder, for most purposes this is the only folder you need to care about. They contain pairs of Japanese=English for most o the text in the game. Keep the Japanese part intact, only change the English part.
2. Files inside `Assets` folder are modifications to game asset files. Don't touch anything that isn't translated since it can break the game, only submit fixes to existing translations.
3. Item names in the plugin source code. If they need changing, make sure you change their translations in the `Translation` folder as well.

## Credits
- The Butler, DX5536, Helios7 - [Original translation project](https://f95zone.to/threads/1room-runaway-girl-the-butler-translation.18074/) and intial translations (around 25% of script and UI).
- ManlyMarco - Initial translation environment setup; Programming, testing, proofing and help with some translations.
- WataThaBradicus - Revising the original translation and translating everything else (the remaining 75%).

## Screenshots (possible spoilers!)
![preview0](https://user-images.githubusercontent.com/39247311/56170532-2fc1fa00-5fe2-11e9-8fa4-986307f311d6.PNG)
![preview1](https://user-images.githubusercontent.com/39247311/56170529-2f296380-5fe2-11e9-9941-63e5c198b97d.PNG)
![preview2](https://user-images.githubusercontent.com/39247311/56170530-2f296380-5fe2-11e9-8c6c-7065787010d9.PNG)
![preview3](https://user-images.githubusercontent.com/39247311/56170531-2f296380-5fe2-11e9-86be-bdc91b96032a.PNG)
