using Dungeon;
using Dungeon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public UiCharacter UiPlayer;
    private Point m_currentPos;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow))
			MovePlayer(EDirection.Bottom);
		if (Input.GetKeyDown(KeyCode.UpArrow))
			MovePlayer(EDirection.Top);
		if (Input.GetKeyDown(KeyCode.RightArrow))
			MovePlayer(EDirection.Right);
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			MovePlayer(EDirection.Left);
	}

	private void MovePlayer(EDirection dir)
	{
		Debug.LogFormat("Move Player dir:{0} from {1}", dir, m_currentPos);
		var cell = FloorManager.GetCell(m_currentPos, dir);
		if (cell == null)
			return;
		m_currentPos = cell.Position;
		UiPlayer.UpdatePos(m_currentPos);
	}
}
