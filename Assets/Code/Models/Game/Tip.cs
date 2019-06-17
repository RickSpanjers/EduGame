using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Models.Game
{
	[Serializable]
	public class Tip
	{
		public int id { get; set; }
		public string tip { get; set; }
		public bool used { get; set; } = false;

		public Tip(string tip) {
			this.tip = tip;

		}
	}
}
