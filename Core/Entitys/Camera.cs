using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace EndlessRunner.Core.Entitys
{
    public class Camera
    {
        protected float _zoom; // Camera Zoom
        public Matrix _transform; // Matrix Transform
        public Vector2 _pos; // Camera Position
        protected float _rotation; // Camera Rotation

        public Camera(float x, float y, float zoom, Viewport viewport)
        {
            _zoom = zoom;
            _rotation = 0.0f;
            _pos = new Vector2(viewport.Width / _zoom, viewport.Height / _zoom);
            Move(new Vector2(x,y));
        }// Sets and gets zoom

        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        // Get set position
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        // Auxiliary function to move the camera
        public void Move(Vector2 amount)
        {
            _pos += amount;
        }

        public Matrix GetTransform(GraphicsDevice graphicsDevice)
        {
            _transform =
              Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                         Matrix.CreateRotationZ(_rotation) *
                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * (1 / Zoom), graphicsDevice.Viewport.Height * (1 / Zoom), 0));
            return _transform;
        }
    }
}