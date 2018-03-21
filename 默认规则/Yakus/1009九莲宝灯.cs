﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 日本麻将;

namespace 默认规则.Yakus {
	public sealed class 九莲宝灯 : Yaku {
		public override int OrderIndex => 1009;

		public override YakuType Type => YakuType.役满 | YakuType.门前清;

		protected override bool FilterTest(int junkoCount, int pungCount) {
			return junkoCount >= 2 && pungCount >= 1;
		}

		protected override bool FilterTest(int[] kindCountsFromTiles, int[] kindCounts, int[] kindCountsWithoutPair) {
			if (kindCounts[3] > 0) return false;
			int sum = kindCounts[0] + kindCounts[1] + kindCounts[2];
			return kindCounts[0] == sum || kindCounts[1] == sum || kindCounts[2] == sum;
		}

		protected override bool Test(ICollection<YakuValue> result, ITiles tiles, IGroups groups, YakuEnvironment env) {
			int[] counts = { -3, -1, -1, -1, -1, -1, -1, -1, -3 };
			for (int i = 0; i < tiles.Count; i++) {
				counts[(tiles[i].BaseTile as NumberTile).Number - 1]++;
			}
			int val = 0;
			for (int i = 0; i < 9; i++) val |= counts[i];

			if (val != 1) return false;
			int extraNumber = Array.IndexOf(counts, 1) + 1;
			var extraTile = tiles.Added.BaseTile as NumberTile;
			if (extraTile.Number == extraNumber) {
				result.Add(YakuValue.FromFullYaku(this, "纯正九莲宝灯", 1));
			} else {
				result.Add(YakuValue.FromFullYaku(this, "九莲宝灯", 1));
			}
			return true;
		}
	}
}
