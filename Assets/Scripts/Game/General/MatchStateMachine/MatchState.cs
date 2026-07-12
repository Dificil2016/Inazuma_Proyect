public abstract class MatchState
{
    protected MatchStateMachine stateMachine;

    protected MatchState(MatchStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}