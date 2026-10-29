using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asser")]
    [SerializeField] private InputActionAsset playercontrols;

    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string movement = "Movement";
    [SerializeField] private string rotation = "Rotation";
    //[SerializeField] private string jump = "Jump";
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string interact = "Interact";

    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction interactAction;

    public Vector2 MovementInput { get; private set; }

    public Vector2 RotationInput { get; private set; }

    //public bool JumpTriggered { get; private set; }

    public bool SprintTriggered { get; private set; }

    public bool InteractionTriggered { get; private set; }

    private void Awake()
    {
        InputActionMap mapReference = playercontrols.FindActionMap(actionMapName);

        movementAction = mapReference.FindAction(movement);
        rotationAction = mapReference.FindAction(rotation);
        //jumpAction = mapReference.FindAction(jump);
        sprintAction = mapReference.FindAction(sprint);
        interactAction = mapReference.FindAction(interact);

        SubscribeActionValuesToInputEvents();
    }

    private void SubscribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;

        //jumpAction.performed += inputInfo => JumpTriggered = true;
        //jumpAction.canceled += inputInfo => JumpTriggered = false;

        sprintAction.performed += inputInfo => SprintTriggered = true;
        sprintAction.canceled += inputInfo => SprintTriggered = false;

        interactAction.performed += inputInfo => InteractionTriggered = true;
        interactAction.canceled += inputInfo => InteractionTriggered = false;
    }

    private void OnEnable()
    {
        playercontrols.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playercontrols.FindActionMap(actionMapName).Disable();  
    }
}
