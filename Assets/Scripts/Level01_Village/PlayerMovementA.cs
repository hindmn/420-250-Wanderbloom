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

        [SerializeField] private float vitesseBond = 12f;
        [SerializeField] private float dureeBond = 0.15f;
        [SerializeField] private float delaiBond = 1f;

        [SerializeField] private AudioClip sonBond;

        private Rigidbody2D rigidb;
        private Vector2 direction;

        private float finBond = 0f;
        private float prochainBond = 0f;
        private Vector2 directionBond;

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
            if(bond.WasPressedThisFrame() && Time.time >= prochainBond && direction != Vector2.zero)
            {
                directionBond = direction;
                finBond = Time.time + dureeBond;
                prochainBond = Time.time + delaiBond;
                GetComponent<AudioSource>().PlayOneShot(sonBond);
            }
            

        }

        private void FixedUpdate()
        {
            //rigidb.linearVelocity = direction * vitesse;
            if (Time.time < finBond)
                rigidb.linearVelocity = directionBond * vitesseBond;
            else
                rigidb.linearVelocity = direction * vitesse;

            rigidb.position = Limites.Limiter(rigidb.position, limiteMin, limiteMax);
        }


    }
}



