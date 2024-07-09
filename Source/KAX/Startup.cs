/*
	This file is part of "KAX DLL"
		© 2018-2024 Lisias T : http://lisias.net <support@lisias.net>

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

using UnityEngine;

namespace KAX
{
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	internal class Startup : MonoBehaviour
	{
		private void Start()
		{
			Log.force("Version {0}", Version.Text);

			try
			{
				KSPe.Util.Compatibility.Check<Startup>(typeof(Version), typeof(Configuration));
				KSPe.Util.Installation.Check<Startup>();

				{
					Type calledType = Type.GetType("Firespitter.engine.FSengineWrapper, Firespitter", false, false);
					if (null == calledType)
					{
						GUI.NoFirespitterAlertBox.Show();
						return;
					}
				}
			}
			catch (KSPe.Util.InstallmentException e)
			{
				Log.error(e.ToShortMessage());
				KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
			}
		}
	}
}
