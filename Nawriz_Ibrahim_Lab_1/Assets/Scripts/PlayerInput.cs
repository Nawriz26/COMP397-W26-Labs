using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputAction move;
    
    void Start()
    {
        move = new InputSystem.actions.FindAction("Player/Move");
    }

    void Update()
    {
        Vector2 readMove = move.ReadValue<Vector2>();

        Debug.Log("Player Move Input: " + readMove);
    }
}
