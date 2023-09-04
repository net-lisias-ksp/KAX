﻿/*
	This file is part of "KAX DLL"
	(C) 2018-2023 Lisias T : http://lisias.net <support@lisias.net>

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
using System.Collections.Generic;

namespace KAX
{
	public static class ModuleManagerSupport
	{
		public static IEnumerable<string> ModuleManagerAddToModList()
		{
			List<string> tags = new List<string>();

			tags.Add(Globals.Instance.UseFirespitterEngines ? "KAX-PREFER-FS" : "KAX-PREFER-STOCK");

			return tags.ToArray();
		}
	}
}
