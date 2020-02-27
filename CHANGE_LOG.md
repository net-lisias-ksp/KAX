# KAX :: Change Log

* 2020-0227: 2.8.0.4 (Lisias) for KSP >= 1.3
	+ Fixing a warning related to a redundant pass specifier on the patch for FAR.
	+ Fixing a pretty stupid mistake on the `.version` that was there since the beggining of time!
		- Thanks to [ssd21456](https://forum.kerbalspaceprogram.com/index.php?/profile/146209-ssd21345/) for the [heads up](https://forum.kerbalspaceprogram.com/index.php?/topic/180268-131/&do=findComment&comment=3748095)! 
* 2020-0225: 2.8.0.3 (Lisias) for KSP >= 1.3
	* **Dropped**
* 2019-1006: 2.8.0.2 (Lisias) for KSP >= 1.3
	+ Embedding KSPe.Light services for KAX 
		- KAX is now works also on KSP 1.3! #HURRAY
	+ TweakScale support is now native to KAX
		- Patches were built to be compatible from TweakScale 2.7.3 to the future 2.5.0.
		- Vintage Propelators patches were updated.
		- Vintage Propelator Super Sport is now scalable.	
* 2019-0518: 2.8.0.1 (Lisias) for KSP >= 1.4
	+ Added missing `bulkheadProfiles` to a part.
		- Thanks, [steve_v](https://forum.kerbalspaceprogram.com/index.php?/topic/180268-141-kerbal-aircraft-expansion-kaxl-—-under-new-management-—-v2800-2019-0110/&do=findComment&comment=3601219) 
	+ Added a Workaround Patch for handling parts with missing `bulkheadProfiles` to the Extras.
	+ Some Legal Mambo Jambo updating.
* 2019-0110: 2.8.0.0 (Lisias) **Under New Management**  for KSP >= 1.4
	+ KAX/L is KAX under Lisias' Management! :)
	+ Enhanced (and disableable) Menu for the SPH/VAB Parts Menu
		- With new Icons! :) 
	+ Fixed Sounds for the Radial, Sport and Turbo Propeller Engines
		- Thanks to Citizen247 for the patches. 
	+ `bulkheadProfiles` added to every part.
		- KSP 1.6.0 is happy now.
	+ Changes on the sample crafts.
		- Fixed `KAX Horizon` to be loadable without SM_Stryker 
		- Fixed KAX Choppah (added the engine back)
		- Added some new crafts - KAX and FS only.
		- All crafts are KSP 1.4.1 and up compatible.
	+ Changes on the File Hierarchy
		- Moved sample crafts to a proper place
		- Some vessel's filenames renamed to a more readable format.
		- Dependencies **ARE NOT** embedded anymore.
		- Cleaning up ZIPs from the main distribution files.
		- Resources file moved out from GameData and added to an Extras directory to be manually added by the user. Firespitter is now a hard dependency for the parts, so there's no need for it anymore.
	+ Added [INSTALL.md](https://github.com/net-lisias-ksp/KAX/blob/master/INSTALL.md) with instructions for manual installation
* 2018-0728: 2.7.2.1 (Lisias) for KSP 1.4.x
	+ Sync'ed with the last changes from upstream
* 2018-0614: 2.7.1.1 (Lisias) for KSP 1.4.x
	+ Added KSP-AVC Support
	+ Created Archive with historical versions
	+ Commited historical releases into GIT
	+ Compiled against KSP 1.4.1 Libraries
	+ (Really, only bureaucratic things)
* 2017-1026: 2.7.1 (smce) for KSP 1.3.1
	+ Restores placeholder IVA issue 1 in medium cockpit, until correct IVA completed
	+ Increased node sizes on 2 meter parts 
* 2017-1024: 2.7.0 (smce) for KSP 1.3.1
	+ Features custom parts category
	+ Even more stockalike textures
	+ New vintage propeller engines 
* 2016-1220: 2.6.4 (Keptin) for KSP 1.2.2
	+ Compatibility Patch for KSP 1.2.2 
* 2016-0520: 2.6.3 (Keptin) for KSP 1.1.2
	+ Fixed audio FX for parts to conform to new FX config (Big thanks to Alshain for his work!) 
* 2016-0520: 2.6.2 (Keptin) for KSP 1.1.2
	+ Updated Firespitter.dll for KSP 1.1.2 compatibility
	+ Removed Heavy Gear
	+ Known Issues:
		- Audio FX only emits from right speaker due to running on legacy audio config
* 2015-1120: 2.6.1 (Keptin) for KSP 1.0.5
	+ Reduced volume SFX of Main Rotor & Tail Rotor
	+ Added stagepriorityflow to Main Rotor for proper fuel flow
* 2015-0619: 2.5.2 (Keptin) for KSP 1.0.4
	+ Heli Rotor now has torque
	+ Minor fixes for Rotor and Tail Rotor
	+ Updated Firespitter.dll 
* 2015-0517: 2.5.1 (Keptin) for KSP 1.0.2
	+ Balance work on Turbo, Radial, and Sport engines
	+ Engines will now draw fuel evenly from all tanks
	+ Updated packaged Firespitter.dll to 7.0.5613.30088
	+ Moved Radial and Sport engines to Aviation tech tree
	+ Reduced price on Radial and Sport engines 
* 2015-0513: 2.5 (Keptin) for KSP 1.0.2
	+ Added A7 Aerosport 2-bladed prop
	+ Fixed sound pitch for all engines
	+ Added KAX Horizon and KAX Bungalow example craft
	+ Textures converted to .dds 
* 2015-0107: 2.3.4 (Keptin) for KSP 0.90
	+ Maintaining mods between major KSP updates takes work; lots of little things break and need fixing. I'm happy to announce that KAX now has fewer bugs than ever, making KSP 0.90 the best supported version to date! Yay!
	+ Updated Firespitter.dll with RadarManFromTheMoon's rotor thrust switching fix
	+ Kuey Tail Rotor now properly switches thrust with user input
	+ Fixed KAX Agents .cfg
* 2014-1207: 2.3 (Keptin) for KSP 0.25
	+ Compatibility patch for KSP 0.25.0
	+ Updated Firespitter.dll to v7.0.5398.27328
	+ Updated example crafts
	+ Fixed Kuey Tail Rotor animation 
* 2014-0722: 2.2.2 (Keptin) for KSP 0.24
	+ 0.24 HOTFIX, Note: Not all features have been reimplemented
	+ Updated Firespitter.dll to v7.0.5313.17967
	+ Fixed Kuey Main Rotor
	+ Adjusted thrust on Kuey Main Rotor to account for changes in Firespitter aero model 
* 2014-0624: 2.2.1 (keptin) for KSP 0.23.5
	+ No changelog provided


