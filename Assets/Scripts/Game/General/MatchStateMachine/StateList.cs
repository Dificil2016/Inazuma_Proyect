using System.Collections;
using UnityEngine;

public class KickOffState : MatchState
{
    public KickOffState(MatchStateMachine machine) : base(machine)
    {

    }

    public override void Enter()
    {
        MatchGameManager.Instance.StartCoroutine(KickOffRoutine());
    }

    IEnumerator KickOffRoutine()
    {
        // Preparar jugadores
        yield return MatchGameManager.Instance.SetupKickOff();

        // Animación inicial
        yield return MatchGameManager.Instance.animManager.PlayKickOffAnimation();

        // Esperar al input del jugador que inicia
        //yield return MatchGameManager.Instance.CurrentPossessionPlayer.WaitForKickOffInput();

        // Comienza el partido
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

    public override void Update()
    {
        MatchGameManager.Instance.player1.UpdateAllCharas();

        MatchGameManager.Instance.player2.UpdateAllCharas();

        MatchGameManager.Instance.ballController.BallPlayUpdate();
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