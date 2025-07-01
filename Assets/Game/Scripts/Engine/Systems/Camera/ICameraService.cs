using Cinemachine;

namespace Game.Engine
{
    public interface ICameraService
    {
        CinemachineVirtualCamera GetCamera(CameraType type);
        
        bool TryGetCamera(CameraType cameraType, out CinemachineVirtualCamera camera);
    }
}