using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inazuma/Formation")]
public class FormationData : ScriptableObject
{
    public string formationName;

    public Sprite preview;

    public List<Vector2> positions = new()
    {
        new Vector2(.2f,.28f),
        new Vector2(.5f,.25f),
        new Vector2(.8f,.28f),
        new Vector2(.12f,.52f),
        new Vector2(.38f,.48f),
        new Vector2(.62f,.48f),
        new Vector2(.88f,.52f),
        new Vector2(.18f,.8f),
        new Vector2(.5f,.88f),
        new Vector2(.82f,.8f)
    };
}