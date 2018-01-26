using ArcEngine;
using OpenTK.Graphics;

namespace ArcEngineTest
{
    public class CameraScript : GlobalScript
    {
        private GameObject go;
        private Camera camera;

        private GameObject meshGo;
        private MeshRenderer renderer;

        private float lookAnglesx, lookAnglesy;

        public override void Start()
        {
            go = new GameObject();
            camera = go.AddComponent<Camera>();
            camera.ClearColor = Color.Lerp(Color.Black, Color.Cyan, 0.25f);
            camera.Transform.Position = -Vector3.forward * 2f;

            meshGo = new GameObject();
            renderer = meshGo.AddComponent<MeshRenderer>();
            renderer.Mesh = PrimitiveMeshes.Cube;
        }

        public override void Update()
        {
            DoMouse();
            DoMovement();
            meshGo.Transform.EulerAngles += new Vector3(1f, 0, 0) * Time.deltaTime;
        }

        private void DoMouse()
        {
            lookAnglesx += (Input.IsKey(Keys.Right) ? 1f : 0f) * Time.deltaTime;
            lookAnglesx += (Input.IsKey(Keys.Left) ? -1f : 0f) * Time.deltaTime;
            lookAnglesy += (Input.IsKey(Keys.Up) ? 1f : 0f) * Time.deltaTime;
            lookAnglesy += (Input.IsKey(Keys.Down) ? -1f : 0f) * Time.deltaTime;

            camera.Transform.EulerAngles = new Vector3(0, -lookAnglesx, -lookAnglesy);
        }

        private void DoMovement()
        {
            if (Input.IsKey(Keys.Z))
                camera.Transform.Position += camera.Transform.forward * Time.deltaTime * 2;
            if (Input.IsKey(Keys.S))
                camera.Transform.Position += camera.Transform.back * Time.deltaTime * 2;
            if (Input.IsKey(Keys.Q))
                camera.Transform.Position += -camera.Transform.left * Time.deltaTime * 2;
            if (Input.IsKey(Keys.D))
                camera.Transform.Position += -camera.Transform.right * Time.deltaTime * 2;
        }
    }
}