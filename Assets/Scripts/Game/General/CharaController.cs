using System;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    public CharaInstance charaInstance;

    internal void Setup(CharaInstance instance)
    {
        charaInstance = instance;
    }
}
