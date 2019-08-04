using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Donjon
{
	public class UiCharacter : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer m_targetImg;

		private Transform m_trans;

		private void Awake()
		{
			m_trans = transform;
		}

		public void InitGraph()
		{
		}

		public void UpdatePos(Vector2Int pos)
		{
			m_trans.position = UiUtils.GetWorldPositionFromCellPosition(pos);
		}
	}
}
