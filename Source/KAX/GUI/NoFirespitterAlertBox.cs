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
using KSPe;

namespace KAX.GUI
{
	internal static class NoFirespitterAlertBox
	{
		private static readonly string MSG = @"Firespitter was not found!

Without Firespitter, KAX parts will not work as intended.";

		private static readonly string AMSG = @"download Firespitter from the Forum's page (KSP will close)";

		internal static void Show()
		{
			KSPe.Common.Dialogs.ShowStopperAlertBox.Show(
				MSG,
				AMSG,
				() => { Application.OpenURL("https://forum.kerbalspaceprogram.com/index.php?/topic/22583-*/"); Application.Quit(); }
			);
			Log.force("\"Houston, we have a Problem!\" about Firespitter was displayed");
		}
	}
}