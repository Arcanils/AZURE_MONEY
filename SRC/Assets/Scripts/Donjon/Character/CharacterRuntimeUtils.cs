using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon.Character
{
	public static class CharacterRuntimeUtils
	{
		public static Vector2Int GetPositionWithDir(EDirection dir)
		{
			var iDir = (int)dir;
			var x = 0;
			var y = 0;

			if (MatchEnumMask(iDir, (int)EDirection.Bottom))
				--y;
			if (MatchEnumMask(iDir, (int)EDirection.Top))
				++y;
			if (MatchEnumMask(iDir, (int)EDirection.Left))
				--x;
			if (MatchEnumMask(iDir, (int)EDirection.Right))
				++x;

			//Debug.LogFormat("GetPositionWithDir {0} => x:{1} y:{2}", dir, x, y);
			return new Vector2Int(x, y);
		}

		public static bool MatchEnumMask(int enumValue, int enumValueToTest)
		{
			return (enumValue & enumValueToTest) != 0;
		}

		public static Vector2Int GetPositionWithDir(Vector2Int basePos, EDirection dir)
		{
			return GetPositionWithDir(dir) + basePos;
		}
	}
}
