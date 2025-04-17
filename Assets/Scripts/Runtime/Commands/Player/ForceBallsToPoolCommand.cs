using System.Linq;
using DG.Tweening;
using Runtime.Data.ValueObjects;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Commands.Player
{
    public class ForceBallsToPoolCommand
    {
        private PlayerManager _manager;
        private PlayerForceData _forceData;
        public ForceBallsToPoolCommand(PlayerManager manager, PlayerForceData forceData)
        {
            _manager = manager;
            _forceData = forceData;
        }

        internal void Execute()
        {
            var transformManager = _manager.transform;
            var positionManager = transformManager.position;
            var forcePos = new Vector3(positionManager.x, positionManager.y + 1, positionManager.z+1);

            var collider = Physics.OverlapSphere(forcePos, 1.35f);
            
            var collectableColliderList = collider.Where(col => col.CompareTag("Collectable")).ToList();

            foreach (var col in collectableColliderList)
            {
                if(col.GetComponent<Rigidbody>() == null) continue;
                var rb = col.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0,_forceData.ForceParameters.y, _forceData.ForceParameters.z), ForceMode.Impulse);
            }
            collectableColliderList.Clear();
        }
    }
}