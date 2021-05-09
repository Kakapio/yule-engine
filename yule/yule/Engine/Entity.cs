using System.Collections.Generic;
using Microsoft.Xna.Framework;
using yule.Engine;

namespace yule.ECS
{
    /// <summary>
    /// Describes an object composed of several components.
    /// </summary>
    public class Entity
    {
        protected readonly List<Component> Components = new List<Component>();

        public Entity()
        {
            AddComponent(new Transform());
        }
        
        /// <summary>
        /// Finds and returns a type of component on the entity. Null otherwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : Component
        {
            foreach (var comp in Components)
            {
                if (comp.GetType() == typeof(T))
                    return (T)comp;
            }

            return default(T);
        }

        /// <summary>
        /// Add a component to the entity and initialize it.
        /// </summary>
        /// <param name="comp"></param>
        public void AddComponent(Component comp)
        {
            Components.Add(comp);
            comp.Owner = this;
            comp.Initialize();
        }
        
        /// <summary>
        /// Can be overridden to add initialization logic.
        /// </summary>
        public virtual void Initialize() {}

        /// <summary>
        /// Provides basic update logic. Avoid overriding, use components instead.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            foreach (var comp in Components)
            {
                comp.Update(gameTime);
            }
        }
    }
}