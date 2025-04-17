using System;
using Cinemachine;
using UnityEngine;

namespace Runtime.Extensions
{
    [ExecuteInEditMode]
    [SaveDuringPlay]
    [AddComponentMenu("Cinemachine/Lock Cinemachine Axis")]
    public class LockCinemachineAxis : CinemachineExtension
    {
        private enum CinemachineLockAxis
        {
            X,
            Y,
            Z
        }

        [SerializeField] private CinemachineLockAxis LockAxis;
        
        [Tooltip("Lock the Cinemachine Virtual Camera's X Axis position with this spesific value")]
        public float ClampValue = 0;
        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            switch (LockAxis)
            {
                case CinemachineLockAxis.X:
                    if (stage == CinemachineCore.Stage.Body)
                    {
                        var pos = state.RawPosition;
                        pos.x = ClampValue;
                        state.RawPosition = pos;
                    }
                    break;
                case CinemachineLockAxis.Y:
                    if (stage == CinemachineCore.Stage.Body)
                    {
                        var pos = state.RawPosition;
                        pos.y = ClampValue;
                        state.RawPosition = pos;
                    }
                    break;
                case CinemachineLockAxis.Z:
                    if (stage == CinemachineCore.Stage.Body)
                    {
                        var pos = state.RawPosition;
                        pos.z = ClampValue;
                        state.RawPosition = pos;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
    }
}