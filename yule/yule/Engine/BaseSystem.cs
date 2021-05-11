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
            if (components[0].Dimensions.Intersects(components[1].Dimensions))
                components[1].Owner.GetComponent<Transform>().Colliding = true;
            else
                components[1].Owner.GetComponent<Transform>().Colliding = false;
        }

        /*public static float SweptAABB(Entity e1, Entity e2, out float normalX, out float normalY)
        {
            Box b1 = e1.GetComponent<Collider>().Dimensions;
            Box b2 = e2.GetComponent<Collider>().Dimensions;

        }*/
    }

    class DefaultSystem : BaseSystem<Component>
    {
    } //Used for all other component types.
}