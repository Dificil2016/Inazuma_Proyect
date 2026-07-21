using UnityEngine;

public class MatchFieldSide : MonoBehaviour
{
    [Header("Jugadores de campo")]
    public Transform topLeft;
    public Transform topRight;
    public Transform bottomLeft;
    public Transform bottomRight;

    [Header("Portero")]
    public Transform goalkeeperSpawn;
    public Transform rivalGoalKeeper;

    [Header("Saque inicial")]
    public Transform kickOffPointA;
    public Transform kickOffPointB;
}