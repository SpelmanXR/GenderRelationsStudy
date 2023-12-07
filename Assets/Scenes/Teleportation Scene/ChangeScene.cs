using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class ChangeScene : MonoBehaviour
    {
        public XRController xrController;
        public Canvas vrCanvas;
        public Button continiousButton;
        public Button teleportationButton;

        private bool isTeleporting = false;

        private void Start()
        {
            vrCanvas.enabled = true;

            continiousButton.onClick.AddListener(OnContinuousButtonClik);
            teleportationButton.onClick.AddListener(OnTeleportationButtonClick);
        }

        private void Update()
        {
            float pressThreshold = 0.1f;
            if (isTeleporting && !IsButtonPressed(xrController.inputDevice, xrController.selectUsage, pressThreshold))
            {
                vrCanvas.enabled = true; // Re-enable the canvas after teleportation
                isTeleporting = false;
            }
        }

        private bool IsButtonPressed(InputDevice inputDevice, InputHelpers.Button button, float threshold)
        {
            bool isPressed;
            InputHelpers.IsPressed(inputDevice, button, out isPressed, threshold);
            return isPressed;
        }

        public void OnContinuousButtonClik()
        {
            vrCanvas.enabled = false;
        }

        public void OnTeleportationButtonClick()
        {
            StartCoroutine(TeleportationCorutine());
        }

        private IEnumerator TeleportationCorutine()
        {
            SceneManager.LoadScene("TeleportationScene");

            isTeleporting = true;

            yield return null;
        }
    }
}
