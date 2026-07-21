using UnityEngine;
using UnityEngine.InputSystem;

public class HumanPlayerInput : MonoBehaviour
{
    [SerializeField]
    private HumanPlayerController controller;

    public void OnPass(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        controller.ConfirmKickOff();
    }
}