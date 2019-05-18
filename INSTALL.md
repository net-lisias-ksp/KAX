# KAX /L : Under New Management

Kerbal Aircraft Expansion /L - Under Lisias Management,

**FOREVER** _THE_ pack of select vanilla-inspired parts for your aircrafting needs!


## Installation Instructions

To install, place the GameData folder inside your Kerbal Space Program folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**, including any other fork:
	+ Delete `<KSP_ROOT>/GameData/KAX`
* Extract the package's `GameData/KAX` folder into your KSP's as follows:
	+ `<PACKAGE>/GameData/KAX` --> `<KSP_ROOT>/GameData/KAX`
* **Optionally** extract the package's KAX Examples's `Ships` folder into your KSP's as follows:
	+ `<PACKAGE>/Ships` --> `<KSP_ROOT>/Ships`
	+ You may safely overwrite any files as only KAX ships are distributed, and you probably want updated crafts for your game.
* **Selectively** you can extract the `Extras` content into your `GameData` directory. Read below for details. Avoid extracting this if you don't know what you are doing. :)

The following file layout must be present after installation:

```
<KSP_ROOT>
	[GameData]
		[KAX]
			[Agencies]
				Agents.cfg
				...
			[Localization]
				KAX__EN-US_localization.cfg
				...
			[Parts]
				[KAX_VintagePropelator]
				[KAX_electricProp]
				...
				[Spaces]
				Parts pre texture update.zip	
			[Patches]
				KAX2_DCK_MM.cfg
				...
			[PluginData]
				KAX_normal.png
				KAX_selected.png
			[Sounds]
				sound_NoirRunning.wav
				...
			CHANGE_LOG.md
			KAX.dll
			KAX.version
			LICENSE
			NOTICE
			README.md
			Resources.cfg
		ModuleManager.dll
		...
	[Ships]
		[SPH]
			KAX -Peanut.craft
			...
	KSP.log
	PartDatabase.cfg
	...
```

### Extras Content

* Patches : Optional Module Manager patches
	+ EDITOR_160.cfg : Patch to add a dummmy `bulkheadProfiles` entry on parts without it, to allow these parts to be used in KSP 1.6 and newer.
* Resources : Optional Resources file
	+ Resources.cfg : To be used by the ones that by some unreachable reason don't want to install Firespitter. Needed by the Electric Engines.

### Dependencies

* [Firespitter](https://github.com/snjo/Firespitter/releases)
	+ Hard Dependency - parts will not work without it. 
	+ Not Included
* [Module Manager](https://forum.kerbalspaceprogram.com/index.php?/topic/50533-*) 3.0.7 or later
	+ Soft dependency - it's possible to play without it, besides having less features available.
	+ Not Included

