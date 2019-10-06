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
			this.icon = GenIcons("KAX");
			if (Versioning.version_major >= 1 && Versioning.version_minor >= 3)
			{ 
				string userfn = KSPUtil.ApplicationRootPath + "./PluginData/KAX/user.cfg";
				Directory.CreateDirectory(Path.GetDirectoryName(userfn));
				if (!File.Exists(userfn))
				{
					ConfigNode DEFAULT = ConfigNode.Load(KSPUtil.ApplicationRootPath + "./GameData/KAX/PluginData/default.cfg");
					string v = DEFAULT.GetNode("KAX").GetValue("CategoryFilter");
					ConfigNode t = new ConfigNode();
					t.AddNode("KAX").SetValue("CategoryFilter", v, true);
					t.Save(userfn);
				}

				{
					ConfigNode user = ConfigNode.Load(userfn);
					string CategoryFilter = user.GetNode("KAX").GetValue("CategoryFilter");
					switch (CategoryFilter)
					{
						case "OLD":
							GameEvents.onGUIEditorToolbarReady.Add(AddSimpleMenufilter);
							break;
						case "NEW":
							GameEvents.onGUIEditorToolbarReady.Add(AddAdvMenufilter);
							break;
						case "NONE":
							break;
						default:
							Debug.LogWarningFormat("CategoryFilter [{0}] unrecognized on user settings file!", CategoryFilter);
							break;
					}
				}
			}
		}

		public void AddSimpleMenufilter()
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
			PartCategorizer.Category filter = PartCategorizer.Instance.filters.Find(f => f.button.categorydisplayName == "#autoLOC_453547");//change for 1.3.1
//			PartCategorizer.AddCustomSubcategoryFilter(filter, Constants.PLUGIN_ID, Constants.PLUGIN_ID, this.icon, EditorItemsFilter);
			PartCategorizer.AddCustomSubcategoryFilter(filter, Constants.PLUGIN_ID, Constants.PLUGIN_ID, this.icon, p => parts.Contains(p));
		}

		private Icon GenIcons(string iconName)
		{
			try
			{
				Texture2D normIcon = this.GenIconTexture(iconName + "_Unselected");
				Texture2D selIcon = this.GenIconTexture(iconName + "_Selected");
	
				return new Icon(iconName + "Icon", normIcon, selIcon);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				return this.icon;
			}
		}

		private Texture2D GenIconTexture(string iconName)
		{
			string filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/PluginData", iconName + ".png"); // icon to be present in same folder as dll
			return KSPe.Util.Image.Texture2D.LoadFromFile(filename);
		}

		private void GenFilter(PartCategorizer.Category filter, string subFilterName, string subFilterdisplayName, string iconName, Func<AvailablePart, bool> exclusionFilter)
		{
			try
			{
				Icon icon = GenIcons(iconName);
				PartCategorizer.AddCustomSubcategoryFilter(filter, subFilterName, subFilterdisplayName, icon, exclusionFilter);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}

		}
		
		private void AddAdvMenufilter()
		{
			// TODO Better add'on Icons!
			PartCategorizer.Category filter = PartCategorizer.AddCustomFilter(Constants.PLUGIN_ID, Constants.MANUFACTURER_NAME, GenIcons("KAX"), Color.white);

			// TODO Better "All Parts" icons. Localization for it too!
			GenFilter(filter, "AllParts", string.Format("All {0} Parts", Constants.MANUFACTURER_NAME), "KAX", o => o.manufacturer == Constants.MANUFACTURER_NAME && !o.title.Contains("(LEGACY)"));
			GenFilter(filter, "CommandPods", "#autoLOC_453549", "Pods", o => o.manufacturer == Constants.MANUFACTURER_NAME && o.category.ToString() == "Pods" && !o.title.Contains("(LEGACY)"));
			GenFilter(filter, "Tanks", "#autoLOC_453552", "Tanks", p => p.manufacturer == Constants.MANUFACTURER_NAME && !p.title.Contains("(LEGACY)") && p.resourceInfos.Exists(q => q.resourceName == "LiquidFuel" || q.resourceName == "Oxidizer" || q.resourceName == "Monopropellant") );
			GenFilter(filter, "Structural", "#autoLOC_453561", "Structural", o => o.manufacturer == Constants.MANUFACTURER_NAME && !o.title.Contains("(LEGACY)") && o.category.ToString() == "Structural" );
//			GenFilter(filter, "Electrical", "#autoLOC_453579", this.icon, o => o.manufacturer == Constants.MANUFACTURER_NAME && !o.title.Contains("(LEGACY)") && o.category.ToString() == "Electrical" );
			GenFilter(filter, "Engines", "#autoLOC_453555", "Engines", o => o.manufacturer == Constants.MANUFACTURER_NAME && !o.title.Contains("(LEGACY)") && o.moduleInfos.Exists(q => q.moduleName == "Engine") );
//			GenFilter(filter, "Legacy", "#autoLOC_1900223", this.icon, o => o.manufacturer == Constants.MANUFACTURER_NAME && o.title.Contains("(LEGACY)"));			
		}

	}

}