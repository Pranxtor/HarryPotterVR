using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.XR;

public class Test : MonoBehaviour
{
    public InputActionReference trigger;
    public InputActionReference select;
    public InputActionReference selectController;

  

    // Start is called before the first frame update
    void Start()
    {
       trigger.action.performed += HandleTriggerChange;
       select.action.performed += HandleSelectChange;

       
       
       selectController.action.performed += HandleSelectSChange;
    }

    void HandleTriggerChange(InputAction.CallbackContext obj){
        var controller = InputSystem.AddDevice<MyDevice>();


        using (StateEvent.From(controller, out var eventPtr))
        {
            controller.trigger.WriteValueIntoEvent(1.0f, eventPtr);
            InputSystem.QueueEvent(eventPtr);
        }
         Debug.Log("test trigger");
    }

    void HandleSelectChange(InputAction.CallbackContext obj){
        Debug.Log("test select");
        selectController.action.Enable();
        Debug.Log("test select");
    }

    void HandleSelectSChange(InputAction.CallbackContext obj){
        Debug.Log("test sdsdsddsdsds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
