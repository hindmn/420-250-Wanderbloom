using UnityEngine;
using UnityEngine.InputSystem;


namespace Arielle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        
        [SerializeField] private float vitesse = 3f;
        [SerializeField] private InputAction deplacement;
        private Rigidbody2D rigidb;
        private Vector2 direction;
        

        
        private void Awake()
        {
            rigidb = GetComponent<Rigidbody2D>();

        }

        private void OnEnable()
        {
            deplacement.Enable();
        }

        private void OnDisable()
        {
            deplacement.Disable();
        }


        private void Update()
        {
            direction = deplacement.ReadValue<Vector2>().normalized;
            

        }

        private void FixedUpdate()
        {
            rigidb.linearVelocity = direction * vitesse;
        }


    }
}



