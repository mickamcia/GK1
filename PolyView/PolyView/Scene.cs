﻿using PolyView.models;
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
            var ls0 = new LightSource();
            ls0.model_pos = new Vector4(10, 0, 10, 1);
            ls0.type = LightSource.LightType.DayLight;
            lights.Add(ls0);

            var ls1 = new LightSource();
            ls1.scene_pos = new Vector4(700, 900, -50, 1);
            ls1.type = LightSource.LightType.PointLight;
            lights.Add(ls1);

            var ls2 = new LightSource();
            ls2.scene_pos = new Vector4(10, 0, 10, 1);
            ls2.type = LightSource.LightType.SpotLight;
            ls2.direction = new Vector3(100, 100, 0);
            lights.Add(ls2);
            var r = new Random();
            for (int i = 0; i < 12; i++)
            {
                var temp = Parser.ParseModel(pathCar);
                temp.color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
                temp.modelMatrixTranslation = Matrix4x4.CreateTranslation(new Vector3(800, 0, 0));
                temp.modelMatrixScale = Matrix4x4.CreateScale(100);
                temp.modelMatrixRotation = Matrix4x4.CreateRotationZ((float)Math.PI * i / 12 * 2);
                temp.modelNormalRotation = temp.modelMatrixRotation;
                movingModels.Add(temp);
            }
            var plane = Parser.ParseModel(pathPlane);
            plane.color = Color.Green;
            plane.modelMatrixTranslation = Matrix4x4.CreateTranslation(new Vector3(0, 0, 0));
            plane.modelMatrixScale = Matrix4x4.CreateScale(1000);
            plane.modelMatrixRotation = Matrix4x4.CreateRotationX(-(float)Math.PI / 2);
            plane.modelMatrix = plane.modelMatrixScale * plane.modelMatrixTranslation * plane.modelMatrixRotation;
            plane.modelNormalRotation = plane.modelMatrixRotation;
            stationaryModels.Add(plane);
        }
        public void CalculateAnimation()
        {
            lights[0].scene_pos = new Vector4((float)Math.Sin((float)Settings.frameCount / 10) * 600, (float)Math.Cos((float)Settings.frameCount / 10) * 600, -400, 1);//Lighting.GetLightVector((float)(Settings.frameCount / 100));
            foreach (var m in movingModels)
            {
                m.modelMatrix = m.modelMatrixScale * Matrix4x4.CreateRotationX(-(float)Math.PI / 2) * m.modelMatrixTranslation * m.modelMatrixRotation * Matrix4x4.CreateRotationZ((float)Settings.frameCount / 100);
                m.modelNormalRotation = Matrix4x4.CreateRotationX(-(float)Math.PI / 2) * m.modelMatrixRotation * Matrix4x4.CreateRotationZ((float)Settings.frameCount / 100);

                if (Settings.Shivering)
                {
                    m.modelMatrix *= Matrix4x4.CreateTranslation(new Vector3(10 * (float)Math.Sin(Settings.frameCount), 10 * (float)Math.Cos(Settings.frameCount), 0));
                }
            }
            lights[1].scene_pos = Vector4.Transform(new Vector4(0, 0, 0, 1), movingModels[5].modelMatrix);
            lights[1].scene_pos.Z += -300;
            lights[2].scene_pos = Vector4.Transform(new Vector4(0, 0, 2, 1), movingModels[0].modelMatrix);
            var temp = Vector4.Transform(new Vector4(0, 0, 0, 1), movingModels[0].modelMatrix);
            //temp = Vector4.Transform(temp, Matrix4x4.CreateRotationZ((float)Settings.ReflectorVarValue / 15));
            lights[2].scene_pos.Z += -100;
            lights[2].direction = new Vector3(temp.X - lights[2].scene_pos.X, temp.Y - lights[2].scene_pos.Y, temp.Z - lights[2].scene_pos.Z);
            var v = Vector4.Transform(lights[2].direction, Matrix4x4.CreateRotationZ((float)(Settings.ReflectorVarValue / 30 - Math.PI/2)));
            lights[2].direction = new Vector3(v.X, v.Y, v.Z);

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
                        
                        v.scene_norm = Vector3.TransformNormal(v.model_norm, m.modelNormalRotation);
                        
                        //v.view_norm = new Vector3(cam.X - v.scene_norm.X, cam.Y - v.scene_norm.Y, cam.Z - v.scene_norm.Z);

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

                        v.scene_norm = Vector3.TransformNormal(v.model_norm, m.modelNormalRotation);

                        //v.view_norm = Vector3.TransformNormal(modelMatrixRotation);
                        //v.view_norm = new Vector3(cam.X - v.scene_norm.X, cam.Y - v.scene_norm.Y, cam.Z - v.scene_norm.Z);
                    }
                    p.UpdateAETP();
                }
            }
        }
    }
}
