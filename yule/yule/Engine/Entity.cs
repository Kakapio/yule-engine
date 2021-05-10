using System.Collections.Generic;
using Microsoft.Xna.Framework;
using yule.Engine;

namespace yule.Engine
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
        /// Used to add components to our entity and set their parameters.
        /// </summary>
        public virtual void Initialize() {}
    }
}