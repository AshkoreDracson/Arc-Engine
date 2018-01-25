using ArcEngine;

namespace ArcEngineTest
{
    public class CameraScript : GlobalScript
    {
        private GameObject go;
        private Camera camera;

        private GameObject meshGo;
        private MeshRenderer renderer;

        public override void Start()
        {
            go = new GameObject();
            camera = go.AddComponent<Camera>();
            camera.ClearColor = Color.Lerp(Color.Black, Color.Cyan, 0.25f);

            Mesh m = new Mesh(new []
            {
                new Vertex(new Vector4(-0.25f, 0.25f, 0.5f, 1-0f), Color.Orange),
                new Vertex(new Vector4( 0.0f, -0.25f, 0.5f, 1-0f), Color.Orange),
                new Vertex(new Vector4( 0.25f, 0.25f, 0.5f, 1-0f), Color.Orange)
            });

            meshGo = new GameObject();
            renderer = meshGo.AddComponent<MeshRenderer>();
            renderer.Mesh = m;
        }
    }
}