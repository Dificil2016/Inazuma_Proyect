using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Hissatsu", menuName = "Scriptable Object/Hissatsu Data")]
public class HissatsuData : ScriptableObject
{
    //=========================================================
    // DATA
    //=========================================================

    [Header("Data")]

    [Tooltip("Nombre localizado de la técnica.")]
    public LocalizedString hissatsuName;

    [Tooltip("Descripción localizada de la técnica.")]
    public LocalizedString description;

    [Tooltip("Tipo de hissatsu.")]
    public HissatsuType type;

    [Tooltip("Elemento de la técnica.")]
    public Element element;

    [Tooltip("Sistema de progresión de nivel de la técnica.")]
    public HissatsuLevelType levelType;

    [Space]

    [Header("Battle")]

    [Tooltip("Coste de puntos necesario para utilizar la técnica.")]
    public int cost;

    [Tooltip("Poder base de la técnica.")]
    public int power;

    [Tooltip("Probabilidad de cometer falta al utilizarla.")]
    [Range(0, 100)] public int foulRisk = 0;

    [Space]

    [Header("Passive Effect")]

    [Tooltip("Efecto pasivo asociado a la técnica.")]
    public PassiveEffect passiveEffect;

    //=========================================================
    // DATA
    //=========================================================

    [Space]

    [Header("Presentation")]
    public HissatsuPresentation presentation;

}

[System.Serializable]
public class HissatsuPresentation
{
    [Tooltip("Rótulo que aparece al ejecutar la técnica.")]
    public Sprite titleBanner;

    [Tooltip("Animación reproducida cuando la técnica tiene éxito.")]
    public GameObject successAnimation;

    [Tooltip("Animación reproducida cuando la técnica falla.")]
    public GameObject failAnimation;

    [Tooltip("Sonido al comenzar la técnica.")]
    public AudioClip startSFX;
}

public enum HissatsuType
{
    Talent,
    Shot,
    Dribble,
    Defense,
    Catch
}

public enum HissatsuLevelType
{
    None,
    Shin,
    G,
    N
}