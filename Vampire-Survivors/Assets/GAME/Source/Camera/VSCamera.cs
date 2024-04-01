
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.CameraSystems
{
    public class VSCamera : ICamera
    {
        private Camera _camera;
        public IProperty<Vector3> CameraPosition => _cameraPosition;
        private Property<Vector3> _cameraPosition { get; set; }
        private IProperty<Vector3> _followPosition { get; set; }

        public VSCamera(Camera a_camera)
        {
            _cameraPosition = new Property<Vector3>(Vector3.zero);
            _camera = a_camera;
        }


        public void Init(IProperty<Vector3> a_followPosition)
        {
            _followPosition = a_followPosition;
        }


        public void Update()
        {
            if (_followPosition != null)
            {
                UpdateCameraPosition();
            }
        }


        private void UpdateCameraPosition()
        {
            Vector3 destionationPosition = Vector3.Lerp(_cameraPosition.Value, _followPosition.Value, Time.deltaTime * 5);
            destionationPosition.z = -10;
            _cameraPosition.SetValue(destionationPosition);
        }

        public Vector3 Position()
        {
            return _cameraPosition.Value;
        }
    }
}