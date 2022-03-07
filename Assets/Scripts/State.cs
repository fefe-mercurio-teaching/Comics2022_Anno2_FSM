namespace FSM
{
    public abstract class State
    {
        public virtual void OnBegin() {}
        public virtual void OnEnd() {}
        public virtual void OnUpdate() {}
        public virtual void OnFixedUpdate() {}
    }
}