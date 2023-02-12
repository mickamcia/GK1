using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyView
{
    public enum CameraOption
    {
        Center = 0,
        Stationary = 1,
        Moving = 2,
    }
    public enum ShadingType
    {
        Constant = 0,
        Phong = 1,
        Gouraud = 2,
    }
    public static class Settings
    {
        public static int frameCount = 0;
        public static float fieldOfView = (float)(90 * Math.PI / 180);
        public static float nearPlaneDist = 10;
        public static float farPlaneDist = 2000;
        public const int BitmapWidth = 800;
        public const int BitmapHeight = 800;
        public static CameraOption cameraOption = CameraOption.Center;
        public static ShadingType shadingType = ShadingType.Constant;

        public static float ReflectorAngle = 0f;
        public static bool LightOnMovingObject = false;
        public static bool LightOnStationaryObject = false;
        public static bool LightingDaylight = false;
        public static bool LightingFog = false;
        public static bool Shivering = false;
    }
}
