 
namespace VampireSurvivors.CameraSystems
{
    public class VSCameraBehavior : VSBehavior
    {

        private ICamera _vsCamera;

        public void Init(ICamera a_vsCamera)
        {
            _vsCamera =  a_vsCamera;
        }


        private void LateUpdate()
        {
            transform.position = _vsCamera.Position();
        }
    }
}