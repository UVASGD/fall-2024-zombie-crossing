using UnityEngine;
using ZombieCrossing.Character.Runtime;
using ZombieCrossing.CommandPattern.Runtime;
using ZombieCrossing.Input.Runtime;

namespace ZombieCrossing.Player.Runtime
{
    /// <summary>
    /// Handles the player movement.
    /// </summary>
    public class PlayerCommandMoveHandler: MonoBehaviour
    {
        [SerializeField]
        private InputEventChannel inputEventChannel;
        
        [SerializeField]
        private BaseCharacterController characterController;

        [SerializeField]
        private float speed;
        
        [SerializeField, Range(0f, 1f)]
        private float friction;

        [SerializeField] 
        private Transform referenceAxis;
        
        private Vector3 direction; 
        
        private void OnEnable()
        {
            inputEventChannel.OnMove += HandleOnMove;
        }
        
        private void OnDisable()
        {
            inputEventChannel.OnMove -= HandleOnMove;
        }

        private void HandleOnMove(Vector2 value)
        {
            direction = new Vector3(value.x, 0, value.y);
        }

        private void FixedUpdate()
        {
            var rotation = Quaternion.Euler(0, referenceAxis.eulerAngles.y, 0);
            CommandInvoker.Execute(new CharacterCommandMove(characterController, direction * speed, rotation, friction)); 
        }
    }
}