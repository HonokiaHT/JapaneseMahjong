﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 日本麻将;

namespace 默认规则.Yakus {
	public sealed class 二杯口 : Yaku {
		public override int OrderIndex => 23;

		public override YakuType Type => YakuType.门前清;

		protected override bool FilterTest(int junkoCount, int pungCount) {
			return junkoCount == 4;
		}

		protected override bool FilterTest(int[] kindCountsFromTiles, int[] kindCounts, int[] kindCountsWithoutPair) {
			return kindCountsWithoutPair[0] % 2 + kindCountsWithoutPair[1] % 2 + kindCountsWithoutPair[2] % 2 == 0;
		}

		protected override bool Test(ICollection<YakuValue> result, ITiles tiles, IGroups groups, YakuEnvironment env) {
			int[,] counts = new int[3, 7];
			foreach (var g in groups.JunkoList) {
				counts[g.Key.SortedLevel, (g.Key as NumberTile).Number - 1]++;
			}
			int count = 0;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 7; j++) {
					if (counts[i, j] % 2 == 0) {
						count += counts[i, j];
						if (count == 4) {
							result.Add(YakuValue.FromFanValue(this, "二杯口", 3));
							return true;
						}
					}
				}

			return false;
		}
	}
}
