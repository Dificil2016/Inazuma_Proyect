using System.Collections;
using UnityEngine;

public class MatchGameManager : MonoBehaviour
{
    public static MatchGameManager Instance { get; private set; }

    [Header("Controllers")]
    public PlayerController player1;
    public PlayerController player2;

    [Header("Managers")]
    public MatchAnimManager animManager;
    public MatchStateMachine stateMachine;

    [Header("Fields")]
    public MatchFieldSide playerField;
    public MatchFieldSide enemyField;

    [Header("MatchData")]
    public PlayerController CurrentPossessionPlayer { get; private set; }
    [SerializeField] private bool playerStarts = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        stateMachine.Initialize();
    }

    public IEnumerator SetupKickOff()
    {
        player1.SetTeam(GameDataManager.Instance.playerTeam);
        player2.SetTeam(GameDataManager.Instance.enemyTeam);

        CurrentPossessionPlayer = playerStarts ? player1 : player2;

        yield return player1.SetupCharas(playerField, playerStarts);

        yield return player2.SetupCharas(enemyField, !playerStarts);
    }
}