using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public static class UiUtils
	{
		public const float X_UNIT = 1f;
		public const float Y_UNIT = 1f;
		public static readonly Vector3 ORIGIN = new Vector3(0f, 0f, 0f);
		public static readonly Vector3 ORIGIN_MIDDLE_CELL;

		static UiUtils()
		{
			ORIGIN_MIDDLE_CELL = new Vector3(
				ORIGIN.x + X_UNIT * 0.5f, ORIGIN.y + Y_UNIT * 0.5f, ORIGIN.z);
		}

		public static Vector3 GetWorldPositionFromCellPosition(Vector2Int cellPosition)
		{
			return new Vector3(
				ORIGIN_MIDDLE_CELL.x + X_UNIT * cellPosition.x,
				ORIGIN_MIDDLE_CELL.y + Y_UNIT * cellPosition.y,
				ORIGIN_MIDDLE_CELL.z);
		}
	}
}
