using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace ArcEngine
{
    public static class Shader
    {
        public static int CompileShader(ShaderType type, string path)
        {
            var shader = GL.CreateShader(type);
            var src = File.ReadAllText(path);
            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);
            return shader;
        }
        public static int CreateProgram()
        {
            var program = GL.CreateProgram();
            var shaders = new List<int>
            {
                CompileShader(ShaderType.VertexShader, ".\\Data\\Shaders\\vertexShaderTriangle.c"),
                CompileShader(ShaderType.FragmentShader, ".\\Data\\Shaders\\fragmentShader.c")
            };

            foreach (var shader in shaders)
                GL.AttachShader(program, shader);

            GL.LinkProgram(program);
            foreach (var shader in shaders)
            {
                GL.DetachShader(program, shader);
                GL.DeleteShader(shader);
            }
            return program;
        }
    }
}