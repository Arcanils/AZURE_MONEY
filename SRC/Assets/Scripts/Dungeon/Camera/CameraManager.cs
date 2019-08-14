using Dungeon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
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
        private float m_depthCam;

		private static CameraManager m_instance;

        public static Camera MainCam { get { return m_instance.m_cam; } }
        public static float DepthCam { get { return m_instance.m_depthCam; } }

        public CameraManager(Camera cam, float depthCam)
		{
			m_instance = this;
			m_cam = cam;
			m_camTrans = m_cam.transform;
            m_depthCam = depthCam;
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
