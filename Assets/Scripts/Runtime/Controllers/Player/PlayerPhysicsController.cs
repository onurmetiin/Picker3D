using System;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;

        #endregion

        #region Private Variables

        private readonly string _stageArea = "StageArea";
        private readonly string _finish = "FinishArea";
        private readonly string _miniGameArea = "MiniGameArea";

        #endregion
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(tag: _stageArea))
            {
                manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                
                //Stage Area Pool/Ball Kontrol 
            }

            if (other.CompareTag(tag: _finish))
            {
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onFinishAreaEntered?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                return;
            }

            if (other.CompareTag(tag: _miniGameArea))
            {
                //Mini Game Mechanics
            }
        }

        public void OnReset()
        {
            
        }
    }
}