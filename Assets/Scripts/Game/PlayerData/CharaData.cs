using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Inazuma/Character")]
public class CharaData : ScriptableObject
{
    [Header("General")]

    public string characterName;

    public string characterNickname;

    [Tooltip("sprite de la cabeza entera")]
    public Sprite backPortrait;
    [Tooltip("sprite de la cabeza con solo los elementos que quedan por delante del uniforme")]
    public Sprite frontPortrait;

    public PlayerPosition position;

    public Element element;

    public Gender gender;

    public BodyType bodyType;

    public SchoolYear age;

    [Header("Base Stats (Lv99)")]

    public int maxPT;

    public int maxPE;

    [Space]

    public Stats stats;
}