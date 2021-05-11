using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace yule.Engine
{
    //Inspired by code from Spool @ https://community.monogame.net/t/simple-2d-camera/9135
    
    public class Camera
    {
        public float Zoom { get; private set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; private set; }
        public Rectangle VisibleArea { get; private set; }
        public Matrix ViewMatrix { get; private set; }

        private Matrix inverseViewMatrix;
        private GraphicsDevice graphicsDevice;
        private float currentMouseWheelValue, previousMouseWheelValue;

        public Camera(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            Bounds = graphicsDevice.Viewport.Bounds;
            Zoom = 1f;
            Position = Vector2.Zero;
        }
        
        /// <summary>
        /// Recalculate camera matrix based on current position/scale.
        /// </summary>
        public void Update()
        {
            Bounds = graphicsDevice.Viewport.Bounds;
            UpdateMatrix();

            Vector2 cameraMovement = Vector2.Zero;
            int moveSpeed;

            if (Zoom > .8f)
                moveSpeed = 15;
            else if (Zoom < .8f && Zoom >= .6f)
                moveSpeed = 20;
            else if (Zoom < .6f && Zoom > .35f)
                moveSpeed = 25;
            else if (Zoom <= .35f)
                moveSpeed = 30;
            else
                moveSpeed = 10;

            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Up))
                cameraMovement.Y = -moveSpeed;

            if (keyboard.IsKeyDown(Keys.Down))
                cameraMovement.Y = moveSpeed;

            if (keyboard.IsKeyDown(Keys.Left))
                cameraMovement.X = -moveSpeed;

            if (keyboard.IsKeyDown(Keys.Right))
                cameraMovement.X = moveSpeed;

            previousMouseWheelValue = currentMouseWheelValue;
            currentMouseWheelValue = Mouse.GetState().ScrollWheelValue;

            if (currentMouseWheelValue > previousMouseWheelValue)
                AdjustZoom(0.05f);
            else if (currentMouseWheelValue < previousMouseWheelValue)
                AdjustZoom(-0.05f);

            MoveCamera(cameraMovement);
        }

        /// <summary>
        /// Get the position of the mouse as pixel-coordinates in the world.
        /// </summary>
        /// <returns></returns>
        public Vector2 MouseToWorldPosition()
        {
            Point mousePosition = Mouse.GetState().Position;
            return Vector2.Transform(new Vector2(mousePosition.X, mousePosition.Y), inverseViewMatrix);
        }

        /// <summary>
        /// Convert our view matrix from view space -> world space to update our visible area.
        /// </summary>
        private void UpdateVisibleArea()
        {
            inverseViewMatrix = Matrix.Invert(ViewMatrix);

            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), inverseViewMatrix);
            
            var min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
            VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }
        
        /// <summary>
        /// Create a matrix with our desired position and scale for rendering usage.
        /// </summary>
        private void UpdateMatrix()
        {
            ViewMatrix = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                        Matrix.CreateScale(Zoom) *
                        Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
            
            UpdateVisibleArea();
        }
        
        /// <summary>
        /// Change the camera's position by an amount.
        /// </summary>
        /// <param name="movePosition"></param>
        public void MoveCamera(Vector2 movePosition)
        {
            Vector2 newPosition = Position + movePosition;
            Position = newPosition;
        }
        
        /// <summary>
        /// Modify the zoom by an amount. Value is clamped.
        /// </summary>
        /// <param name="zoomAmount"></param>
        public void AdjustZoom(float zoomAmount)
        {
            Zoom += zoomAmount;
            Math.Clamp(Zoom, 0.35f, 2f);
        }
    }
}