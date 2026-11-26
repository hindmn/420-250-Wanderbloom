using UnityEngine;
using UnityEngine.InputSystem;

namespace Arielle
{
    public class ArPause : MonoBehaviour
    {
        [SerializeField] private GameObject panneauPause;

        [Header("Touches")]
        [SerializeField] private InputAction pause;
        [SerializeField] private InputAction reprendre;

        private bool enPause = false;

        private void OnEnable()
        {
            pause.Enable();
            reprendre.Enable();
        }

        private void OnDisable()
        {
            pause.Disable();
            reprendre.Disable();
        }

        private void Start()
        {
            panneauPause.SetActive(false);
        }

        private void Update()
        {
            // Pause (seulement if le jeu est en train de tourner)
            if (!enPause && pause.WasPressedThisFrame() && Time.timeScale > 0f)
            {
                enPause = true;
                Time.timeScale = 0f;
                panneauPause.SetActive(true);
            }
            // Reprendre
            else if (enPause && reprendre.WasPressedThisFrame())
            {
                enPause = false;
                Time.timeScale = 1f;
                panneauPause.SetActive(false);
            }
        }
    }
}