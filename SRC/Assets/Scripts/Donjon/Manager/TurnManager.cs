using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Donjon
{
	public class TurnManager
	{
        private float m_turnDuration = 0.2f;
        private CharacterManager m_characterManager;
        private Queue<BaseController> m_baseCharacterQueue;
        private IEnumerator m_currentRoutine;

        public TurnManager(CharacterManager characterManager)
        {
            m_characterManager = characterManager;
            Init();
        }

        public void ManualUpdate()
        {
            m_currentRoutine.MoveNext();
        }

        private void Init()
        {
            m_baseCharacterQueue = new Queue<BaseController>();
            var controllers = m_characterManager.GetCharacterControllerList().OrderBy(item => item.GetCharacterSpeed()).ToArray();
            foreach (var controller in controllers)
            {
                m_baseCharacterQueue.Enqueue(controller);
            }

            m_currentRoutine = TurnEnum();
        }

        private IEnumerator TurnEnum()
        {
            var isPlayerTurn = false;
            while (true)
            {
                var currentController = GetNextCharacter();

                if (currentController == null)
                {
                    yield return null;
                    continue;
                }

                currentController.Think();
                currentController.Execute();
                m_baseCharacterQueue.Enqueue(currentController);

                for (float t = 0f; t < m_turnDuration; t += Time.deltaTime)
                {
                    yield return null;
                }
            }
        }

        private BaseController GetNextCharacter()
        {
            return m_baseCharacterQueue.Count != 0 ? m_baseCharacterQueue.Dequeue() : null;
        }


	}
}

