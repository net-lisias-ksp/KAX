using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using UnityEngine;
using KSP.UI.Screens;
using RUI.Icons.Selectable;

namespace KAX
{

	[KSPAddon(KSPAddon.Startup.MainMenu, true)]
	public class BaseFilter : MonoBehaviour
	{
		private readonly List<AvailablePart> parts = new List<AvailablePart>();
		internal const string category = "Filter by function";
		private Icon icon;

		public void Awake()
		{
			this.icon = GenIcons(Constants.PLUGIN_ID);
//			GameEvents.onGUIEditorToolbarReady.Add(addSimpleMenufilter);
			GameEvents.onGUIEditorToolbarReady.Add(addAdvMenufilter);
		}

		public void addSimpleMenufilter()
		{
			parts.Clear();
			int count = PartLoader.LoadedPartsList.Count;
			for (int i = 0; i < count; ++i)
			{
				AvailablePart avPart = PartLoader.LoadedPartsList[i];
				if (!avPart.partPrefab) continue;
				if (avPart.manufacturer == Constants.MANUFACTURER_NAME)
				{
					parts.Add(avPart);
				}
			}

			if (parts.Count > 0)
				this.SubCategories();
		}

		//private bool EditorItemsFilter(AvailablePart avPart)
		//{
		//	return parts.Contains(avPart);
		//}

		private void SubCategories()
		{
			if (null == this.icon) return;
			PartCategorizer.Category filter = PartCategorizer.Instance.filters.Find(f => f.button.categorydisplayName == "#autoLOC_453547");//change for 1.3.1
//			PartCategorizer.AddCustomSubcategoryFilter(filter, Constants.PLUGIN_ID, Constants.PLUGIN_ID, icon, EditorItemsFilter);
			PartCategorizer.AddCustomSubcategoryFilter(filter, Constants.PLUGIN_ID, Constants.PLUGIN_ID, icon, p => parts.Contains(p));
		}

		private Icon GenIcons(string iconName)
		{
			Texture2D normIcon = this.GenIconTexture("normal");
			Texture2D selIcon = this.GenIconTexture("selected");

			return new Icon(iconName + "Icon", normIcon, selIcon);
		}

		private Texture2D GenIconTexture(string iconName)
		{
			Texture2D r = new Texture2D(64, 64, TextureFormat.RGBA32, false);
			string filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/PluginData", "KAX_" + iconName + ".png"); // icon to be present in same folder as dll
			r.LoadImage(File.ReadAllBytes(filename));
			return r;
		}


		private void addAdvMenufilter()
		{
			if (null == this.icon) return;

			try
			{
				PartCategorizer.Category filter = PartCategorizer.AddCustomFilter(Constants.PLUGIN_ID, Constants.MANUFACTURER_NAME, this.icon, Color.white);

				PartCategorizer.AddCustomSubcategoryFilter(filter, "AllParts", string.Format("All {0} Parts", Constants.MANUFACTURER_NAME), this.icon, o => o.manufacturer == Constants.MANUFACTURER_NAME && !o.title.Contains("(LEGACY)"));
				PartCategorizer.AddCustomSubcategoryFilter(filter, "CommandPods", "#autoLOC_453549", this.icon, o => o.manufacturer == Constants.MANUFACTURER_NAME && o.category.ToString() == "Pods" && !o.title.Contains("(LEGACY)"));
				PartCategorizer.AddCustomSubcategoryFilter(filter, "Tanks", "#autoLOC_453552", this.icon, p => p.manufacturer == Constants.MANUFACTURER_NAME && !p.title.Contains("(LEGACY)") && p.resourceInfos.Exists(q => q.resourceName == "LiquidFuel" || q.resourceName == "Oxidizer" || q.resourceName == "Monopropellant") );
				PartCategorizer.AddCustomSubcategoryFilter(filter, "Structural", "#autoLOC_453561", this.icon, o => o.manufacturer == Constants.MANUFACTURER_NAME && !o.title.Contains("(LEGACY)") && o.category.ToString() == "Structural" );
//				PartCategorizer.AddCustomSubcategoryFilter(filter, "Electrical", "#autoLOC_453579", this.icon, o => o.manufacturer == Constants.MANUFACTURER_NAME && !o.title.Contains("(LEGACY)") && o.category.ToString() == "Electrical" );
				PartCategorizer.AddCustomSubcategoryFilter(filter, "Engines", "#autoLOC_453555", this.icon, o => o.manufacturer == Constants.MANUFACTURER_NAME && !o.title.Contains("(LEGACY)") && o.moduleInfos.Exists(q => q.moduleName == "Engine") );
//				PartCategorizer.AddCustomSubcategoryFilter(filter, "Legacy", "#autoLOC_1900223", this.icon, o => o.manufacturer == Constants.MANUFACTURER_NAME && o.title.Contains("(LEGACY)"));			
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}


	}

}