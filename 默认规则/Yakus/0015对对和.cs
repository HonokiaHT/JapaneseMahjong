﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 日本麻将;

namespace 默认规则.Yakus {
	public sealed class 对对和 : Yaku {
		public override int OrderIndex => 15;

		public override YakuType Type => YakuType.None;

		protected override bool FilterTest(int junkoCount, int pungCount) {
			return pungCount == 4;
		}

		protected override bool Test(ICollection<YakuValue> result, ITiles tiles, IGroups groups, YakuEnvironment env) {
			// 当役满发生时，该役会被移除
			result.Add(YakuValue.FromFanValue(this, "对对和", 2));
			return true;
		}
	}
}
