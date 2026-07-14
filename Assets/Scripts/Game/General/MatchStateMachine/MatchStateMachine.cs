using UnityEngine;

public class MatchStateMachine : MonoBehaviour
{
    private MatchState currentState;

    public KickOffState KickOffState { get; private set; }
    public PlayGameState PlayGameState { get; private set; }
    public DuelState DuelState { get; private set; }
    public AnimState AnimState { get; private set; }
    public GoalState GoalState { get; private set; }
    public EndGameState EndGameState { get; private set; }

    internal void Initialize()
    {
        KickOffState = new KickOffState(this);
        PlayGameState = new PlayGameState(this);
        DuelState = new DuelState(this);
        AnimState = new AnimState(this);
        GoalState = new GoalState(this);
        EndGameState = new EndGameState(this);

        ChangeState(KickOffState);
    }

    private void Update()
    {
        currentState?.Update();
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    public void ChangeState(MatchState newState, object context = null)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }

    public T GetState<T>() where T : MatchState
    {
        return currentState as T;
    }

    //-------------------------------------------------------------------
    //API PUBLICA
    //-------------------------------------------------------------------

    public void BeginDuel()
    {
        ChangeState(DuelState);
    }

    public void FinishDuel()
    {
        ChangeState(PlayGameState);
    }

    public void BeginAnimation()
    {
        ChangeState(AnimState);
    }

    public void FinishAnimation()
    {
        ChangeState(PlayGameState);
    }

    public void GoalScored()
    {
        ChangeState(GoalState);
    }

    public void FinishGoal()
    {
        ChangeState(KickOffState);
    }

    public void EndMatch()
    {
        ChangeState(EndGameState);
    }
}