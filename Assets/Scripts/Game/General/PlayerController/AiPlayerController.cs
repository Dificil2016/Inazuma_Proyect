using System.Collections;
using UnityEngine;

public class AIPlayerController : PlayerController
{
    public override IEnumerator WaitForKickOffInput()
    {
        yield return new WaitForSeconds(1.5f);
    }
}