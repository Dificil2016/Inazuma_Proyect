using UnityEngine;

public class KickOffState : MatchState
{
    public KickOffState(MatchStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.StartCoroutine(KickOffRoutine());
    }

    private System.Collections.IEnumerator KickOffRoutine()
    {
        Debug.Log("KickOff");

        yield return new WaitForSeconds(3);

        stateMachine.ChangeState(stateMachine.PlayGameState);
    }
}

public class PlayGameState : MatchState
{
    public PlayGameState(MatchStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Empieza el juego");
    }
}

public class AnimState : MatchState
{
    public AnimState(MatchStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Duelo");
    }
}

public class DuelState : MatchState
{
    public DuelState(MatchStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Duelo");
    }
}

public class GoalState : MatchState
{
    public GoalState(MatchStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Duelo");
    }
}

public class EndGameState : MatchState
{
    public EndGameState(MatchStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Duelo");
    }
}