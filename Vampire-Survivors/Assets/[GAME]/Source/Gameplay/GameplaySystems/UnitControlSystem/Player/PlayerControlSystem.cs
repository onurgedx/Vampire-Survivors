using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.PlayerControlSys
{
    public class PlayerControlSystem : VSSystem
    {
        private Transform _playerTransform;
        private IProperty<float> _playerSpeed;
        private IProperty<bool> _canPlayerMove;

        PlayerInput playerInput;
        private Vector2 _touchStartPosition;
        private bool _isMove = false;


        public PlayerControlSystem(Transform a_playerTransform, IProperty<float> a_playerMovementSpeed, IProperty<bool> a_canPlayerMove)
        {
            _playerSpeed = a_playerMovementSpeed;
            _playerTransform = a_playerTransform;
            _canPlayerMove = a_canPlayerMove;
            playerInput.PlayerTouch.TouchInput.started += ctx => StartTouch(ctx);
            playerInput.PlayerTouch.TouchInput.canceled += ctx => EndTouch(ctx);
        }

        public void Init(Transform a_playerTransform, IProperty<float> a_playerSpeed)
        {
            _playerTransform = a_playerTransform;
            _playerSpeed = a_playerSpeed;
        }


        public override void Update()
        {
            base.Update();
            if (_canPlayerMove.Value && _isMove)
            {
                Vector2 direction = Vector2.ClampMagnitude(playerInput.PlayerTouch.TouchPosition.ReadValue<Vector2>() - _touchStartPosition, 1);
                Move(direction);
            }
        }


        private void Move(Vector3 a_direction)
        {
            _playerTransform.position += _playerSpeed.Value * a_direction * Time.deltaTime;
        }


        private void EndTouch(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            _isMove = false;
        }


        private void StartTouch(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            _isMove = true;
            _touchStartPosition = playerInput.PlayerTouch.TouchPosition.ReadValue<Vector2>();
        }
    }
}