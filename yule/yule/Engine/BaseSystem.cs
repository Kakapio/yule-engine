using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace yule.Engine
{
    /// <summary>
    /// Used to ensure that all instances of certain component types are updated at once.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseSystem<T> where T : Component
    {
        private static List<T> components = new List<T>();

        public static void Register(T component)
        {
            components.Add(component);
        }

        public static void Update(GameTime gameTime)
        {
            foreach (T component in components)
            {
                component.Update(gameTime);
            }
        }
    }

    class TransformSystem : BaseSystem<Transform>
    {
    }

    class SpriteSystem : BaseSystem<Sprite>
    {
    }

    //Separate as update method must be overridden but it must also remain static.
    class ColliderSystem
    {
        private static List<Collider> components = new List<Collider>();

        public static void Register(Collider component)
        {
            components.Add(component);
        }

        public static void Update(GameTime gameTime)
        {
        }

        public static float SweptAABB(Entity e1, Entity e2, out float normalX, out float normalY)
        {
            Point pos1 = e1.GetComponent<Collider>().Dimensions.Location;
            Point pos2 = e2.GetComponent<Collider>().Dimensions.Location;
            Rectangle size1 = e1.GetComponent<Collider>().Dimensions;
            Rectangle size2 = e2.GetComponent<Collider>().Dimensions;
            Vector2 v1 = e1.GetComponent<Transform>().Velocity;
            Vector2 v2 = e2.GetComponent<Transform>().Velocity;

            float xInvEntry, yInvEntry;
            float xInvExit, yInvExit;

            if (v1.X > 0.0f)
            {
                xInvEntry = pos2.X - (pos1.X + size1.Width);
                xInvExit = (pos2.X + size2.Width) - pos1.X;
            }
            else
            {
                xInvEntry = (pos2.X + size2.Width) - pos1.X;
                xInvExit = pos2.X - (pos1.X + size1.Width);
            }

            if (v1.Y > 0.0f)
            {
                yInvEntry = (pos2.Y + size2.Height) - pos1.Y;
                yInvExit = (pos2.Y + size2.Height) - pos1.Y;
            }
            else
            {
                yInvEntry = (pos2.Y + size2.Height) - pos1.Y;
                yInvExit = pos2.Y - (pos1.Y + size1.Height);
            }

            float xEntry = 0, yEntry = 0;
            float xExit = 0, yExit = 0;

            if (v1.Y == 0.0f)
            {
                xEntry = float.NegativeInfinity;
                yExit = float.PositiveInfinity;
            }
            else
            {
                yEntry = yInvEntry / v1.Y;
                yExit = yInvExit / v1.Y;
            }

            float entryTime = MathF.Max(xEntry, yEntry);
            float exitTime = MathF.Min(xExit, yExit);

            if (entryTime > exitTime || xEntry < 0.0f && yEntry < 0.0f || xEntry > 1.0f || yEntry > 1.0f)
            {
                normalX = 0.0f;
                normalY = 0.0f;
                return 1.0f;
            }
            else // if there was a collision 
            {
                // calculate normal of collided surface
                if (xEntry > yEntry)
                {
                    if (xInvEntry < 0.0f)
                    {
                        normalX = 1.0f;
                        normalY = 0.0f;
                    }
                    else
                    {
                        normalX = -1.0f;
                        normalY = 0.0f;
                    }
                }
                else
                {
                    if (yInvEntry < 0.0f)
                    {
                        normalX = 0.0f;
                        normalY = 1.0f;
                    }
                    else
                    {
                        normalX = 0.0f;
                        normalY = -1.0f;
                    }
                }
            }

            return entryTime;
        }
    }

    class DefaultSystem : BaseSystem<Component>
    {
    } //Used for all other component types.
}