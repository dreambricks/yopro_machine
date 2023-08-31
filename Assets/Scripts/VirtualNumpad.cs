using System.Runtime.InteropServices;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualNumpad : MonoBehaviour, ISelectHandler
{

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    private const byte VK_F9 = 0x78;
    private const uint KEYEVENTF_KEYDOWN = 0x0000;
    private const uint KEYEVENTF_KEYUP = 0x0002;

    public void OnSelect(BaseEventData eventData)
    {
        SimulateF9KeyPress();
    }

    public void SimulateF9KeyPress()
    {
        // Simula pressionar a tecla F9 (KeyDown)
        keybd_event(VK_F9, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);

        // Simula liberar a tecla F9 (KeyUp)
        keybd_event(VK_F9, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }
}
