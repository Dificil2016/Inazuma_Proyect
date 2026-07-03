using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Player", menuName = "Scriptable Object/Player Data")]
public class PlayerData : ScriptableObject
{
    //================================================================
    // DATA
    //================================================================

    [Header("Data")]

    [Tooltip("Nombre del jugador."), SerializeField]
    public LocalizedString playerName;

    [Tooltip("Apodo o sobrenombre del jugador."), SerializeField]
    public LocalizedString nickname;

    [Tooltip("Posición principal del jugador.")]
    public PlayerPosition position;

    [Tooltip("Elemento al que pertenece el jugador.")]
    public Element element;
    [Tooltip("Género del jugador.")]
    public Gender gender;
    [Tooltip("Año escolar o edad del jugador.")]
    public SchoolYear schoolYear;
    [Tooltip("Saga original del jugador.")]
    public Season originalSeason;

    [Space]

    [Header("Stats")]


    [Range(1, 200)] public int shooting = 50;
    [Range(1, 200)] public int dribbling = 50;
    [Range(1, 200)] public int defense = 50;
    [Range(1, 200)] public int physique = 50;
    [Range(1, 200)] public int technique = 50;
    [Range(1, 200)] public int speed = 50;
    [Range(1, 200)] public int stamina = 50;
    [Range(1, 200)] public int luck = 50;

    //================================================================
    // VISUAL
    //================================================================

    [Header("Visual")]

    [Tooltip("Imagen utilizada en menús y HUD.")]
    public Sprite portrait;

    [Tooltip("Modelo 3D de la cabeza del jugador.")]
    public GameObject headModel;

    [Tooltip("Tipo de cuerpo utilizado por el jugador.")]
    public BodyType bodyType;
}

public enum PlayerPosition
{
    Goalkeeper,
    Defender,
    Midfielder,
    Forward
}

public enum Element
{
    Neutral,
    Fire,
    Mountain,
    Air,
    Forest
}

public enum SchoolYear
{
    unknown,
    young,
    first,
    second,
    third,
    adult
}

public enum Season
{
    none,
    OG1,
    OG2,
    OG3,
    GO,
    GOCS,
    GOGLX,
    ARES,
    ORION,
    VR
}

public enum Gender
{
    unknown,
    male,
    female
}

public enum BodyType
{
    StandardMale,
    StandardFemale,
    Small,
    Large,
    Tall,
    Fat,
    Strong,
    Muscular
}