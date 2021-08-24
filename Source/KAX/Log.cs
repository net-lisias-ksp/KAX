/*
	This file is part of "KAX DLL"
	(C) 2018-2021 Lisias T : http://lisias.net <support@lisias.net>

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
using KSPe.Util.Log;
using System.Diagnostics;

#if DEBUG
using System.Collections.Generic;
#endif

namespace KAX
{
	internal static class Log
	{
		private static readonly Logger log = Logger.CreateForType<BaseFilter>();

		internal static KSPe.Util.Log.Level level => log.level;

		internal static void force (string msg, params object [] @params)
		{
			log.force (msg, @params);
		}

		internal static void info(string msg, params object[] @params)
		{
			log.info(msg, @params);
		}

		internal static void warn(string msg, params object[] @params)
		{
			log.warn(msg, @params);
		}

		internal static void detail(string msg, params object[] @params)
		{
			log.detail(msg, @params);
		}

		internal static void trace(string msg, params object[] @params)
		{
			log.trace(msg, @params);
		}

		internal static void stackdump(string msg, params object[] @params)
		{
			Log.detail(msg, @params);
			System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
			Log.trace("Called by {0}", t);
		}

		internal static void error(Exception e, object offended)
		{
			log.error(offended, e);
		}

		internal static void error(string msg, params object[] @params)
		{
			log.error(msg, @params);
		}

		[ConditionalAttribute("DEBUG")]
		internal static void dbg(string msg, params object[] @params)
		{
			log.trace(msg, @params);
		}

		#if DEBUG
		private static readonly HashSet<string> DBG_SET = new HashSet<string>();
		#endif

		[ConditionalAttribute("DEBUG")]
		internal static void dbgOnce(string msg, params object[] @params)
		{
			string new_msg = string.Format(msg, @params);
			#if DEBUG
			if (DBG_SET.Contains(new_msg)) return;
			DBG_SET.Add(new_msg);
			#endif
			log.trace(new_msg);
		}
	}
}
