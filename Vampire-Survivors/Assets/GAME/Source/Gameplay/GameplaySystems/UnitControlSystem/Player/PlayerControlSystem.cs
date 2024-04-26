using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.PlayerControlSys
{
    /// <summary> 
    /// Analyze the player inputs and controls the player movements
    /// </summary>
    public class PlayerControlSystem : VSSystem
    {
        public IProperty<Vector3> Position => _playerPosition;
        private Property<Vector3> _playerPosition { get; set; }

        public IProperty<Vector3> Direction => _playerDirection;
        private Property<Vector3> _playerDirection { get; set; }

        private Transform _playerTransform;
        private IProperty<float> _playerSpeed; 

        private PlayerInput _playerInput;
        private Vector2 _touchStartPosition;
        private bool _isMove = false;
        private bool _canMove = false;

        public PlayerControlSystem( )
        { 
            _playerInput = new();
            _playerInput.Enable();
            _playerPosition = new Property<Vector3>(Vector3.zero);
            _playerDirection = new Property<Vector3>(Vector3.up);
            _playerInput.PlayerTouch.TouchInput.started += ctx => TouchStarted(ctx);
            _playerInput.PlayerTouch.TouchInput.canceled += ctx => TouchEnded(ctx);
        }


        public void Init(Transform a_playerTransform, IProperty<float> a_playerSpeed)
        {
            _canMove = true;
            _playerSpeed = a_playerSpeed;
            _playerTransform = a_playerTransform;
            _playerPosition.SetValue(_playerTransform.position);
        }


        public override void Update()
        {
            if (_canMove  && _isMove)
            {
                Vector3 direction = Vector2.ClampMagnitude(_playerInput.PlayerTouch.TouchPosition.ReadValue<Vector2>() - _touchStartPosition, 1);
                Move(direction);
            }
        }


        private void Move(Vector3 a_direction)
        {
            _playerTransform.position += _playerSpeed.Value * a_direction * Time.deltaTime;
            _playerPosition.SetValue(_playerTransform.position);
            if (a_direction != Vector3.zero)
            {
                _playerDirection.SetValue(a_direction);
            }
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