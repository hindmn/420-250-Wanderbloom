using UnityEngine;
using UnityEngine.InputSystem;


namespace Arielle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementA : MonoBehaviour
    {
        [SerializeField] private Vector2 limiteMin = new Vector2(-10f, -5f);
        [SerializeField] private Vector2 limiteMax = new Vector2(10f, 5f);

        [SerializeField] private float vitesse = 4f;
        [SerializeField] private InputAction deplacement;
        [SerializeField] private InputAction bond;
        private Rigidbody2D rigidb;
        private Vector2 direction;
        

        
        private void Awake()
        {
            rigidb = GetComponent<Rigidbody2D>();

        }

        private void OnEnable()
        {
            deplacement.Enable();
            bond.Enable();
        }

        private void OnDisable()
        {
            deplacement.Disable();
            bond.Disable();
        }


        private void Update()
        {
            direction = deplacement.ReadValue<Vector2>().normalized;
            

        }

        private void FixedUpdate()
        {
            rigidb.linearVelocity = direction * vitesse;
            rigidb.position = Limites.Limiter(rigidb.position, limiteMin, limiteMax);
        }


    }
}



