using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.PlayerControlSys
{
    public class PlayerControlSystem : VSSystem
    {
        private Transform _playerTransform;
        private IProperty<float> _playerSpeed;
        private IProperty<bool> _canPlayerMove;

        PlayerInput _playerInput;
        private Vector2 _touchStartPosition;
        private bool _isMove = false;
        private bool _canMove = false;

        public PlayerControlSystem(IProperty<bool> a_canPlayerMove)
        {
            _canPlayerMove = a_canPlayerMove;
            _playerInput = new();
            _playerInput.Enable();

            _playerInput.PlayerTouch.TouchInput.started += ctx => TouchStarted(ctx);
            _playerInput.PlayerTouch.TouchInput.canceled += ctx => TouchEnded(ctx);
        }


        public void Init(Transform a_playerTransform, IProperty<float> a_playerSpeed)
        {
            _canMove = true;
            _playerSpeed = a_playerSpeed;
            _playerTransform = a_playerTransform;
        }


        public override void Update()
        {
            base.Update();
            if (_canMove && _canPlayerMove.Value && _isMove)
            { 
                Vector3 direction = Vector2.ClampMagnitude(_playerInput.PlayerTouch.TouchPosition.ReadValue<Vector2>() - _touchStartPosition, 1);
                Move(direction);
            }
        }


        private void Move(Vector3 a_direction)
        {
            _playerTransform.position += _playerSpeed.Value * a_direction * Time.deltaTime;
        }


        private void TouchStarted(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            _isMove = true;
            _touchStartPosition = _playerInput.PlayerTouch.TouchPosition.ReadValue<Vector2>();
        }

        private void TouchEnded(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            _isMove = false;
        }
    }
}