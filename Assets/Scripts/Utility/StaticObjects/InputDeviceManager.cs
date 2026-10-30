
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace Assets.Scripts.StaticObject
{
    public enum DeviceState
    {
        None,
        Gamepad,
        KeyboardMouse
    }

    public class InputDeviceManager:StaticObject.StaticObject<InputDeviceManager>
    {
        public DeviceState CurrentState { get; private set; } = DeviceState.None;

        public event Action<DeviceState> OnDeviceStateChanged;

      
        protected override void OnEnableObject()
        {
            InputSystem.onEvent += OnInputEvent;
        }

        protected override void OnDisableObject()
        {
            InputSystem.onEvent -= OnInputEvent;
        }

        private void OnInputEvent(InputEventPtr eventPtr,InputDevice device)
        {
            if (device == null)
                return;

            // 状態イベント以外は無視
            if (!eventPtr.IsA<StateEvent>() &&
                !eventPtr.IsA<DeltaStateEvent>())
                return;

            // キーボード・マウス・ゲームパッドだけを対象にする
            DeviceState newState;

            if (device is Keyboard || device is Mouse)
            {
                newState = DeviceState.KeyboardMouse;
            }
            else if (device is Gamepad)
            {
                newState = DeviceState.Gamepad;
            }
            else
            {
                return;
            }

            // 同じグループなら通知しない
            if (CurrentState == newState)
                return;

            CurrentState = newState;
            OnDeviceStateChanged?.Invoke(CurrentState);
        }

        public void SetState(DeviceState state)
        {
            CurrentState = state;
        }
    }
}
