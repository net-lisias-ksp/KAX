/*
	This file is part of "KAX DLL"
		© 2018-2022 Lisias T : http://lisias.net <support@lisias.net>

	"KAX DLL" is double licensed, as follows:
		* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	"KAX DLL" is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with "KAX DLL". If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with "KAX DLL". If not, see <https://www.gnu.org/licenses/>.

*/
using System;
using System.IO;
using KSPe;

namespace KAX
{
	public class Globals
	{
		private static Globals INSTANCE = null;

		public static Globals Instance => INSTANCE ?? (INSTANCE = new Globals());

		public readonly string CategoryFilter;
		public readonly bool UseFirespitterEngines;

		private Globals()
		{
			this.CategoryFilter = "NONE";
			this.UseFirespitterEngines = false;

			int tries = 2;
			while (tries > 0) try
			{
				ConfigNodeWithSteroids cn = LoadUser();
				try
				{ 
					this.CategoryFilter = cn.GetValue<string>("CategoryFilter"); --tries;
					this.UseFirespitterEngines = cn.GetValue<bool>("UseFirespitterEngines"); --tries;
				}
				catch (Exception)
				{
					this.RebuildUser();
					--tries;
				}
			}
			catch (Exception e)
			{
				tries = 0;
				Log.error(e, this);
			}
		}

		private ConfigNodeWithSteroids LoadUser()
		{
			string userfn = KSPUtil.ApplicationRootPath + "./PluginData/KAX/user.cfg";

			Directory.CreateDirectory(Path.GetDirectoryName(userfn));
			if (!File.Exists(userfn))
			{
				ConfigNode DEFAULT = ConfigNode.Load(KSPUtil.ApplicationRootPath + "./GameData/KAX/Plugins/PluginData/default.cfg");
				ConfigNode t = DEFAULT.GetNode("KAX");
				t.Save(userfn);
			}

			ConfigNodeWithSteroids cn = ConfigNodeWithSteroids.from(ConfigNode.Load(userfn));
			return cn;
		}

		private void RebuildUser()
		{
			string userfn = KSPUtil.ApplicationRootPath + "./PluginData/KAX/user.cfg";

			Directory.CreateDirectory(Path.GetDirectoryName(userfn));
			if (File.Exists(userfn)) File.Delete(userfn);
		}
	}
}
