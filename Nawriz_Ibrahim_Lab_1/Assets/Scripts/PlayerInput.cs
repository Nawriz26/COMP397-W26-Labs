using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputAction move;
    
    void Start()
    {
        move = new InputSystem.actions.findAction("Player/Move");
    }

    void Update()
    {
        Vector 2 readMove = move.ReadValue<Vector2>();

        Debug.Log("Player Move Input: " + readMove);
    }
}
