using System;
using UnityEngine;
using UnityEngine.Localization;
using static UnityEngine.Rendering.HableCurve;

[CreateAssetMenu(fileName = "New Uniform", menuName = "Scriptable Object/Uniform Data")]
public class UniformData : ScriptableObject
{
    [Header("General")]

    [Tooltip("Clave del nombre localizado.")]
    public LocalizedString nameKey;

    [Tooltip("Icono utilizado en los menús.")]
    public Sprite icon;

    [Space]
    [Header("Field Player")]

    public UniformSet fieldKit;

    [Header("Goalkeeper")]

    public UniformSet goalkeeperKit;

    // Devuelve los modelos correspondientes al tipo de cuerpo indicado.
    public BodyUniform GetBodyUniform(bool goalkeeper, BodyType bodyType)
    {
        UniformSet kit = goalkeeper ? goalkeeperKit : fieldKit;

        int index = (int)bodyType;

        if (index < 0 || index >= kit.bodyModels.values.Length)
            return null;

        return kit.bodyModels.values[index];
    }

    // Devuelve las texturas del uniforme local o visitante.
    public UniformTextures GetTextures(bool goalkeeper, bool homeKit)
    {
        UniformSet kit = goalkeeper ? goalkeeperKit : fieldKit;

        return homeKit ? kit.homeTextures : kit.awayTextures;
    }
}

[Serializable]
public class UniformSet
{
    [Tooltip("Modelos para cada tipo de cuerpo.")]
    public BodyUniformTable bodyModels;

    [Space]

    [Tooltip("Texturas del uniforme local.")]
    public UniformTextures homeTextures;

    [Tooltip("Texturas del uniforme visitante.")]
    public UniformTextures awayTextures;
}

[Serializable]
public class BodyUniform
{
    public BodyType bodyType;

    [Tooltip("Modelo del uniforme.")]
    public GameObject uniformModel;

    [Tooltip("Modelo del cuerpo.")]
    public GameObject bodyModel;

    [Tooltip("Modelo de las botas.")]
    public GameObject bootsModel;
}

[Serializable]
public class BodyUniformTable
{
    public BodyUniform[] values = new BodyUniform[Enum.GetValues(typeof(BodyType)).Length];
}

[Serializable]
public class UniformTextures
{
    [Tooltip("Textura de la camiseta.")]
    public Texture2D shirt;

    [Tooltip("Textura del pantalón.")]
    public Texture2D shorts;
}