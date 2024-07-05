# KAX :: Changes

* 2024-0704: 2.8.1.1 (Lisias) for KSP >= 1.3
	+ Fixes a pretty stupid mistake I let pass trough related to duplicated textures in different formats.
	+ Closes issues:
		- [#18](https://github.com/net-lisias-ksp/KAX/issues/18) There're DXT3 textures on the distribution (errata: on the fillesystem - errata's errata: is really on the distribution), but KSP likes DXT1 and DXT5 only
* 2021-0824: 2.8.1.0 (Lisias) for KSP >= 1.3
	+ Officialise support for KSP >= 1.8 (up to 1.12.2 at least)
	+ Adds new part: Radial Engine Long Cowl (D-45)
		- Thanks, [SpannerMonkey](https://forum.kerbalspaceprogram.com/index.php?/profile/50907-spannermonkeysmce/) and [TheKurgan](https://forum.kerbalspaceprogram.com/index.php?/profile/164104-thekurgan/)!
	+ Some rebalancing on the engines
	+ Some care on the Localisation
	+ Some new Sample Crafts
	+ Adds support for KIS and Stock Inventory
	+ Startup checks
		- Hopefully preventing less than careful reviewers from misrepresent KAX functionalities. 
	+ Closes issues:
		- [#14](https://github.com/net-lisias-ksp/KAX/issues/14) Check for dependencies on Startup
		- [#10](https://github.com/net-lisias-ksp/KAX/issues/10) Implement support for KIS
		- [#9](https://github.com/net-lisias-ksp/KAX/issues/9) Support KSP 1.11 Cargo Settings
		- [#6](https://github.com/net-lisias-ksp/KAX/issues/6) CKAN Compatibility issue with 1.8.0 2686  
