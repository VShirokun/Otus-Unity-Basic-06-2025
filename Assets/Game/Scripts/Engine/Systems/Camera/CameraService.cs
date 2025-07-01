using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Game.Engine
{
    internal sealed class CameraService : MonoBehaviour, ICameraService
    {
        [Serializable]
        private struct CameraInfo
        {
            public CameraType type;
            public CinemachineVirtualCamera camera;
        }

        [SerializeField]
        private List<CameraInfo> cameras;
        
        public CinemachineVirtualCamera GetCamera(CameraType type)
        {
            for (int i = 0, count = this.cameras.Count; i < count; i++)
            {
                CameraInfo info = this.cameras[i];
                if (info.type == type)
                {
                    return info.camera;
                }
            }

            throw new Exception($"Camera of type {type} is not found!");
        }

        public bool TryGetCamera(CameraType type, out CinemachineVirtualCamera camera)
        {
            for (int i = 0, count = this.cameras.Count; i < count; i++)
            {
                CameraInfo info = this.cameras[i];
                if (info.type == type)
                {
                    camera = info.camera; 
                    return true;
                }
            }

            camera = default;
            return false;
        }
    }
}