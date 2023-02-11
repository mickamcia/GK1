using PolyView.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PolyView
{
    public class Scene
    {
        //public const string path = @"C:..\\..\\..\\models\\cube.txt";
        public const string pathCar = @"C:..\\..\\..\\models\\car.txt";
        public const string pathPlane = @"C:..\\..\\..\\models\\plane.txt";
        public List<Model> movingModels;
        public List<Model> stationaryModels;
        public List<LightSource> lights;
        public Matrix4x4 projectionMatrix;
        public Matrix4x4 viewMatrix;
        public ZBuffer zBuffer;

        public Scene()
        {
            lights = new List<LightSource>();
            movingModels = new List<Model>();
            stationaryModels = new List<Model>();
            zBuffer = new ZBuffer();
            PrepareScene();
            CalculateAnimation();
            CalculateFrame();
        }
        public void PrepareScene()
        {
            for(int i = 0; i < 12; i++)
            {
                var temp = Parser.ParseModel(pathCar);
                temp.modelMatrixTranslation = Matrix4x4.CreateTranslation(new Vector3(800, 0, 0));
                temp.modelMatrixScale = Matrix4x4.CreateScale(50);
                temp.modelMatrixRotation = Matrix4x4.CreateRotationZ((float)Math.PI * i / 12 * 2);
                movingModels.Add(temp);
            }
            var plane = Parser.ParseModel(pathPlane);
            plane.modelMatrixTranslation = Matrix4x4.CreateTranslation(new Vector3(0, 0, 0));
            plane.modelMatrixScale = Matrix4x4.CreateScale(1000);
            plane.modelMatrixRotation = Matrix4x4.CreateRotationX((float)Math.PI / 2);
            plane.modelMatrix = plane.modelMatrixScale * plane.modelMatrixTranslation * plane.modelMatrixRotation;
            stationaryModels.Add(plane);
        }
        public void CalculateAnimation()
        {
            foreach (var m in movingModels)
            {
                m.modelMatrix = m.modelMatrixScale * Matrix4x4.CreateRotationX(-(float)Math.PI / 2) * m.modelMatrixTranslation * m.modelMatrixRotation * Matrix4x4.CreateRotationZ((float)Settings.frameCount / 100);
            }
        }
        public void CalculateFrame()
        {
            viewMatrix = CameraGeometry.GetMatrix4x4(this);
            projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(Settings.fieldOfView,
                (float)Settings.BitmapWidth / Settings.BitmapHeight, Settings.nearPlaneDist,
                Settings.farPlaneDist);
            var cam = CameraGeometry.GetCameraPosition(this);
            foreach (var m in movingModels)
            {
                foreach (var p in m.polygons)
                {
                    foreach(var v in p.vertices)
                    {
                        v.scene_pos = Vector4.Transform(v.model_pos, m.modelMatrix);
                        v.view_pos = Vector4.Transform(Vector4.Transform(v.scene_pos, viewMatrix), projectionMatrix);
                        v.view_pos = Vector4.Divide(v.view_pos, v.view_pos.W);
                        float x = (float)((v.view_pos.X + 1) * (Settings.BitmapWidth / 2.0));
                        float y = (float)((v.view_pos.Y + 1) * (Settings.BitmapHeight / 2.0));
                        float z = (float)((v.view_pos.Z) * (Settings.farPlaneDist - Settings.nearPlaneDist) + Settings.nearPlaneDist);
                        v.view_pos = new Vector4(x, y, z, 1);
                        
                        v.scene_norm = Vector3.TransformNormal(v.model_norm, m.modelMatrix);
                        v.view_norm = new Vector3(cam.X - v.scene_norm.X,
                            cam.Y - v.scene_norm.Y,
                            cam.Z - v.scene_norm.Z);

                    }
                    p.UpdateAETP();
                }
            }
            foreach (var m in stationaryModels)
            {
                foreach (var p in m.polygons)
                {
                    foreach (var v in p.vertices)
                    {
                        v.scene_pos = Vector4.Transform(v.model_pos, m.modelMatrix);
                        v.view_pos = Vector4.Transform(Vector4.Transform(v.scene_pos, viewMatrix), projectionMatrix);
                        v.view_pos = Vector4.Divide(v.view_pos, v.view_pos.W);
                        float x = (float)((v.view_pos.X + 1) * (Settings.BitmapWidth / 2.0));
                        float y = (float)((v.view_pos.Y + 1) * (Settings.BitmapHeight / 2.0));
                        float z = (float)((v.view_pos.Z) * (Settings.farPlaneDist - Settings.nearPlaneDist) + Settings.nearPlaneDist);
                        v.view_pos = new Vector4(x, y, z, 1);

                        v.scene_norm = Vector3.TransformNormal(v.model_norm, m.modelMatrix);
                        v.view_norm = new Vector3(cam.X - v.scene_norm.X,
                            cam.Y - v.scene_norm.Y,
                            cam.Z - v.scene_norm.Z);
                    }
                    p.UpdateAETP();
                }
            }
        }
    }
}
