using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private InputAction openMenu;
    [SerializeField] private GameObject menuPanel;
    //[SerializeField] private Slider mouseSensibilitySlider;
    [SerializeField] private bool isMenuOpen;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;
        //mouseSensibilitySlider.onValueChanged.AddListener(delegate {OnValueChangeRunTime(mouseSensibilitySlider.value);});
    }

    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;
        //mouseSensibilitySlider.onValueChanged.RemoveListener(delegate {OnValueChangeRunTime(mouseSensibilitySlider.value);});
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        // Code to open the menu goes here
        //Debug.Log("Open Menu called pressing P");
        isMenuOpen = !isMenuOpen; // Toggle the menu state
        menuPanel.SetActive(isMenuOpen);
        if (isMenuOpen)
        {
            GetComponent<PlayerInput>().enabled = false; // Disable player input when menu is open
            InputSystem.actions.FindActionMap("Player").Disable();
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Make the cursor visible
        }
        else
        {
            GetComponent<PlayerInput>().enabled = true; // Enable player input when menu is closed
            InputSystem.actions.FindActionMap("Player").Enable();
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
            Cursor.visible = false; // Hide the cursor
        }
    }

    //private void OnValueChangeRunTime(float value)
    //{
    //    Debug.Log("MenuInput value changed " + value);
    //}
}
