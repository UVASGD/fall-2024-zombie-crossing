using UnityEngine;
using ZombieCrossing.Input.Runtime;

namespace ZombieCrossing.InputPointer.Runtime
{
    public class FollowPointer: MonoBehaviour
    {
        [SerializeField] private Camera referenceCamera;
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private Transform origin;
        [SerializeField] private float maxDistanceFromOrigin;
        [SerializeField] private LayerMask includeLayers;
        
        private Vector2 pointerPosition;

        private void OnEnable()
        {
            inputHandler.OnPointerPosition += HandlePointerPosition;
        }

        private void HandlePointerPosition(Vector2 position)
        {
            pointerPosition = position;
        }
        
        private void Update()
        {
            var ray = referenceCamera.ScreenPointToRay(pointerPosition);
            if (!Physics.Raycast(ray, out var pointerWorldPosition, Mathf.Infinity, includeLayers)) return;
            var direction = pointerWorldPosition.point - origin.position;
            
            if (direction.sqrMagnitude > maxDistanceFromOrigin * maxDistanceFromOrigin)
            {
                pointerPosition = referenceCamera.WorldToScreenPoint(origin.position + direction.normalized * maxDistanceFromOrigin);
            }
            
            ray = referenceCamera.ScreenPointToRay(pointerPosition);
            if (!Physics.Raycast(ray, out var resolvedPointerWorldPosition, Mathf.Infinity, includeLayers)) return;
            
            transform.position = resolvedPointerWorldPosition.point;
        }
    }
}