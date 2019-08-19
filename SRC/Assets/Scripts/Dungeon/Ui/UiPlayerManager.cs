using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dungeon
{
	public class UiPlayerManager
	{
		[SerializeField]
		private UiFillBar m_currentHPBar;
		[SerializeField]
		private UiFillBar m_currentMPBar;



		[SerializeField]
		private Button m_invotoryButton;
		[SerializeField]
		private Button m_waitButton;
		[SerializeField]
		private Button[] m_skillButtons;


		private const string c_displayBarTxtFormat = "{0} / {1}";

		public void UpdateHP(float newValue, float maxValue)
		{
			var percValue = Mathf.Clamp01(newValue / maxValue);
			m_currentHPBar.UpdateValue(string.Format(c_displayBarTxtFormat, (int)newValue, (int)maxValue), 
				percValue);
		}

		public void UpdateMP(float newValue, float maxValue)
		{
			var percValue = Mathf.Clamp01(newValue / maxValue);
			m_currentHPBar.UpdateValue(string.Format(c_displayBarTxtFormat, (int)newValue, (int)maxValue),
				percValue);
		}
	}
}