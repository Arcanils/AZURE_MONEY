using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class CameraManager 
	{
		public enum ECameraMode
		{
			Free,
			Follow,
			MoveTo,
		}

		private ECameraMode m_currentMode;
		private Camera m_cam;
		private Transform m_camTrans;

		private static CameraManager m_instance;

		public CameraManager(Camera cam)
		{
			m_instance = this;
			m_cam = cam;
			m_camTrans = m_cam.transform;
		}

		public IEnumerator MoveToPosEnum(Vector2Int position)
		{
			yield break;
		}

		public IEnumerator FollowCharacterEnum()
		{
			yield break;
		}

		public static void FollowThisChar(BaseCharacter character)
		{
			m_instance._FollowThisChar(character);
		}

		public void _FollowThisChar(BaseCharacter character)
		{
			m_camTrans.SetParent(character.UiComponent.UiTrans, false);
			m_camTrans.localPosition = new Vector3(0f,0f,-10f);
		}
	}
}
