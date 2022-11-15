using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolyMesh
{
    internal class Parser
    {
        public static Model ParseModel(string path)
        {
            Model model = new();
            const Int32 BufferSize = 128;
            using var fileStream = File.OpenRead(path);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            String? line;
            string[] separators = { " ", "//", "/" };
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                switch (parts[0])
                {
                    case "v":
                        model.vertices.Add(new Vector3((float)Convert.ToDouble(parts[1]) * MainWindowForm.scale + MainWindowForm.size / 2, (float)Convert.ToDouble(parts[2]) * MainWindowForm.scale + MainWindowForm.size / 2, (float)Convert.ToDouble(parts[3]) * MainWindowForm.scale + MainWindowForm.size / 2));
                        break;
                    case "vn":
                        model.normals.Add(new Vector3((float)Convert.ToDouble(parts[1]), (float)Convert.ToDouble(parts[2]), (float)Convert.ToDouble(parts[3])));
                        break;
                    case "f":
                        if (parts.Length == 7)
                        {
                            model.triangles.Add(new Triangle(model.vertices[Convert.ToInt32(parts[1]) - 1], model.vertices[Convert.ToInt32(parts[3]) - 1], model.vertices[Convert.ToInt32(parts[5]) - 1], model.normals[Convert.ToInt32(parts[2]) - 1], model.normals[Convert.ToInt32(parts[4]) - 1], model.normals[Convert.ToInt32(parts[6]) - 1]));
                        }
                        if (parts.Length == 10)
                        {
                            model.triangles.Add(new Triangle(model.vertices[Convert.ToInt32(parts[1]) - 1], model.vertices[Convert.ToInt32(parts[4]) - 1], model.vertices[Convert.ToInt32(parts[7]) - 1], model.normals[Convert.ToInt32(parts[3]) - 1], model.normals[Convert.ToInt32(parts[6]) - 1], model.normals[Convert.ToInt32(parts[9]) - 1]));
                        }
                        break;
                    default:
                        break;
                }
            }
            return model;
        }
    }
}
