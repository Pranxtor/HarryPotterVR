using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

public struct MyDeviceState : IInputStateTypeInfo{
    public FourCC format => new FourCC('M','Y','D','V');
    [InputControl(name = "trigger", layout = "Button", bit = 0)]
    
    public int buttons;
    public short x;
    public short y;

}


[InputControlLayout(displayName = "My Device", stateType = typeof(MyDeviceState))]
public class MyDevice : InputDevice
{
    [InputControl(displayName = "trigger")]
    public ButtonControl trigger { get; private set; }
    
    /*[InputControl(displayName = "axis")]
    public AxisControl axis { get; private set; }*/

    // Register the device.
    static MyDevice()
    {
        // In case you want instance of your device to automatically be created
        // when specific hardware is detected by the Unity runtime, you have to
        // add one or more "device matchers" (InputDeviceMatcher) for the layout.
        // These matchers are compared to an InputDeviceDescription received from
        // the Unity runtime when a device is connected. You can add them either
        // using InputSystem.RegisterLayoutMatcher() or by directly specifying a
        // matcher when registering the layout.
        InputSystem.RegisterLayout<MyDevice>(
            // For the sake of demonstration, let's assume your device is a HID
            // and you want to match by PID and VID.
            matches: new InputDeviceMatcher()
                .WithInterface("My Device")
                .WithCapability("PID", 1234)
                .WithCapability("VID", 5678));
    }
    private static void Initialize() {
        InputSystem.AddDevice<MyDevice>();
    }


    protected override void FinishSetup()
    {
        base.FinishSetup();
        trigger = GetChildControl<ButtonControl>("trigger");
        //axis = GetChildControl<AxisControl>("axis");
    }
}
