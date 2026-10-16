using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Game.UI.Button {
    public enum DeviceState
    {
        None,Mouse, Keybord, Pad
    }

    public class InputDeviceManager : StaticObject.StaticObject<InputDeviceManager>
    {
        public DeviceState DeviceState { get; private set; } = DeviceState.None;

        private InputDevice CurrentDevice;

        private InputDevice lastDevice;

        public event Action<DeviceState> OnDeviceStateChanged;

        protected override void OnEnableObject() {

            InputSystem.onDeviceChange += OnDeviceChange;
        }

        protected override void OnDisableObject()
        {
            InputSystem.onDeviceChange -= OnDeviceChange;
        }

        private void OnDeviceChange(InputDevice device,InputDeviceChange ce)
        {
            if (device == null)
                return; 

            if (CurrentDevice == device)
            {
                return;
            }

            CurrentDevice = device;

            // マウス・キーボード・ゲームパッドの入力を記録

            if (device is Mouse)
            {
                SetDevice(DeviceState.Mouse);
                lastDevice = device;

                Debug.Log(device.deviceId);
            }
            else if (device is Keyboard)
            {
                SetDevice(DeviceState.Keybord);
                lastDevice = device;
            }
            else if (device is Gamepad)
            {
                SetDevice(DeviceState.Mouse);
                lastDevice = device;
            }
            //Debug.Log($"操作中の Device: {device.displayName}");
        }

        void SetDevice(DeviceState device)
        {
            DeviceState = device;
            OnDeviceStateChanged?.Invoke(DeviceState);
        }

    }
}


