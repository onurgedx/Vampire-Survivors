using UnityEngine;
namespace VampireSurvivors.CameraSystems
{

    public class CameraSceneEntry : SceneEntry
    {
        public static readonly string SceneName = "Camera";


        [SerializeField] private VSCameraBehavior _vsCameraBehavior;
        [SerializeField] private Camera _camera;
        public VSCamera VSCamera { get; private set; }
                

        public override void Load()
        {
            VSCamera = new VSCamera(_camera);
            _vsCameraBehavior.Init(VSCamera);
        }

        public override void Unload()
        {
            
        }

        private void Update()
        {
            VSCamera.Update();
        }
    }
}