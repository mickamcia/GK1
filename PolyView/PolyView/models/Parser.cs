using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolyView.models
{
    public static class Parser
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
                if (parts.Length == 0) continue;
                switch (parts[0])
                {
                    case "v":
                        model.vertices.Add(new Vector4((float)Convert.ToDouble(parts[1]), (float)Convert.ToDouble(parts[2]), (float)Convert.ToDouble(parts[3]), 1));
                        break;
                    case "vn":
                        model.normals.Add(new Vector3((float)Convert.ToDouble(parts[1]), (float)Convert.ToDouble(parts[2]), (float)Convert.ToDouble(parts[3])));
                        break;
                    case "f":
                        var p = new Polygon();
                        for(int i = 0; i < (parts.Length - 1) / 2; i++)
                        {
                            p.vertices.Add(new Vertex(model.vertices[Convert.ToInt32(parts[2 * i + 1]) - 1], model.normals[Convert.ToInt32(parts[2 * i + 2]) - 1]));
                        }
                        p.Finish();
                        model.polygons.Add(p);
                        break;
                    default:
                        break;
                }
            }
            return model;
        }
    }
}
