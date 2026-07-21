using System.Collections;
using UnityEngine;

public class HumanPlayerController : PlayerController
{
    private bool kickOffConfirmed;

    public override IEnumerator WaitForKickOffInput()
    {
        kickOffConfirmed = false;

        yield return new WaitUntil(() => kickOffConfirmed);
    }

    public void ConfirmKickOff()
    {
        kickOffConfirmed = true;
    }
}