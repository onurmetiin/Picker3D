using DG.Tweening;
using Runtime.Data.ValueObjects;
using TMPro;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMeshController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private new Renderer renderer;
        [SerializeField] private TextMeshPro scaleText;
        [SerializeField] private ParticleSystem confetti;

        #endregion

        #region Private Variables

        [SerializeField] private PlayerMeshData _data;

        #endregion
        #endregion

        internal void SetData(PlayerMeshData data)
        {
            _data = data;
        }

        internal void ScaleUpPlayer()
        {
            renderer.gameObject.transform.DOScaleX(_data.ScaleCounter,1f)
                .SetEase(Ease.Flash);
        }

        internal void ShowUpText()
        {
            scaleText.DOFade(1, 0)
                .SetEase(Ease.Flash)
                .OnComplete(() =>
                {
                    scaleText.DOFade(0, 0.3f).SetDelay(.35f);
                    scaleText.rectTransform.DOAnchorPosY(1f, .65f).SetEase(Ease.Linear);
                });
        }
        
        internal void PlayConfetti()
        {
            confetti.Play();
            // confetti.Emit(new ParticleSystem.EmitParams()
            // {
            //     position = transform.position,
            //     rotation = transform.eulerAngles,
            //     velocity = Vector3.zero
            // });
        }

        internal void OnReset()
        {
            renderer.gameObject.transform.DOScaleX(1, 1)
                .SetEase(Ease.Linear);
        }
    }
}