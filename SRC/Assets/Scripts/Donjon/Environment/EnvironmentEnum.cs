using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public enum ECellType
	{
		Floor,
		Wall,
		Void,
	}

	[System.Flags]
	public enum EDirection
	{
		Top = 1,
		Bottom = 2,
		Left = 4,
		Right = 8,
	}

	public enum ECharacterSide
	{
		Ally,
		Enemy,
		Neutral,
	}
}
