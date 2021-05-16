namespace yule.Engine
{
    /// <summary>
    /// Describes a piece of logic with initialization and update methods.
    /// </summary>
    public abstract class Component : BaseComponent
    {
        protected Component()
        {
            DefaultSystem.Register(this);
        }
    }
}