using System;
using Runtime.Enums;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Runtime.Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        #region Self Variables
        
        #region Serialized Variables

        [SerializeField] private UIEventSubscriptionType type;
        [SerializeField] private Button button;

        #endregion

        #region Private Variables

        private UIManager _manager;
        

        #endregion

        #endregion

        private void Awake()
        { 
            GetReferences();
        }

        private void GetReferences()
        {
            _manager = FindObjectOfType<UIManager>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionType.OnPlay:
                    button.onClick.AddListener(()=>_manager.Play());
                    break;
                
                case UIEventSubscriptionType.OnNextLevel:
                    button.onClick.AddListener((()=>_manager.NextLevel()));
                    break;
                
                case UIEventSubscriptionType.OnRestartLevel:
                    button.onClick.AddListener((()=>_manager.RestartLevel()));
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UnSubscribeEvents()
        {
            button.onClick.RemoveAllListeners();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}