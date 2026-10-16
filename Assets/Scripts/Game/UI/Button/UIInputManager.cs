using UnityEngine;

namespace Assets.Scripts.Game.UI.Button
{
    public class UIInputManager : MonoBehaviour
    {

        private InputDeviceManager inputDevice;

        private void OnEnable()
        {
            //inputDevice.OnDeviceStateChanged += UseDevice;
        }
        private void OnDisable()
        {
            //inputDevice.OnDeviceStateChanged -= UseDevice;
        }

        void UseDevice()
        {

        }
    }

}
