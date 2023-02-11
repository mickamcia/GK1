using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolyView
{
    public static class CameraGeometry
    {
        public static Matrix4x4 GetMatrix4x4(Scene scene)
        {
            if(Settings.cameraOption == CameraOption.Center)
            {
                return Matrix4x4.CreateLookAt(new Vector3(1000, 1000, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 1));
            }
            if (Settings.cameraOption == CameraOption.Stationary)
            {
                var m = scene.movingModels[0];
                var pos = Vector4.Transform(new Vector4(0, 0, 0, 1), m.modelMatrix);
                return Matrix4x4.CreateLookAt(new Vector3(1000, 1000, -300), new Vector3(pos.X, pos.Y, pos.Z), new Vector3(0, 0, 1));
            }
            if (Settings.cameraOption == CameraOption.Moving)
            {
                var m = scene.movingModels[0];
                var pos = Vector4.Transform(new Vector4(0, 2, -4, 1), m.modelMatrix);
                var target = Vector4.Transform(new Vector4(0, 0, 0, 1), m.modelMatrix);
                return Matrix4x4.CreateLookAt(new Vector3(pos.X, pos.Y, pos.Z), new Vector3(target.X, target.Y, target.Z), new Vector3(0, 0, 1));
            }
            return Matrix4x4.Identity;
        }
        public static Vector3 GetCameraPosition(Scene scene)
        {
            if (Settings.cameraOption == CameraOption.Center)
            {
                return new Vector3(1000, 1000, -300);
            }
            if (Settings.cameraOption == CameraOption.Stationary)
            {
                var m = scene.movingModels[0];
                var pos = Vector4.Transform(new Vector4(0, 0, 0, 1), m.modelMatrix);
                return new Vector3(pos.X, pos.Y, pos.Z);
            }
            if (Settings.cameraOption == CameraOption.Moving)
            {
                var m = scene.movingModels[0];
                var pos = Vector4.Transform(new Vector4(0, 2, -4, 1), m.modelMatrix);
                return new Vector3(pos.X, pos.Y, pos.Z);
            }
            return new Vector3(0, 0, 0);
        }
    }
}
