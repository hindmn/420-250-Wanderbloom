using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Arielle
{
    public class TheChickenMovement : MonoBehaviour
    {

        [SerializeField] private float vitesse = 2f;
        [SerializeField] private float pause = 1.5f;
        [SerializeField] private Transform player;

        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private float finPause = 0f;


        void Start()
        {
            
        }


        void Update()
        {

        }
    }
}