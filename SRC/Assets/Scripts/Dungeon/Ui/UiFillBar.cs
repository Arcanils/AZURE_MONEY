using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dungeon
{
	public sealed class UiFillBar : MonoBehaviour
	{
		[SerializeField]
		private Image m_bgImg;
		[SerializeField]
		private Image m_fillImg;
		[SerializeField]
		private Text m_text;

		public void InitFillBar(
			Color bgColor, Color fillColor, 
			Sprite bgDefaultImg = null, Sprite fillDefaultImg = null,
			string defaultTxt = null)
		{
			m_bgImg.sprite = bgDefaultImg;
			m_bgImg.color = bgColor;
			m_fillImg.sprite = fillDefaultImg;
			m_fillImg.color = fillColor;
			m_text.text = defaultTxt;
		}

		public void UpdateValue(string text, float percFill)
		{
			m_text.text = text;
			m_fillImg.fillAmount = percFill;
		}
	}
}