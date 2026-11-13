using UnityEngine;
using UnityEngine.InputSystem;


namespace Arielle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        
        [SerializeField] private float vitesse = 4f;
        private Rigidbody2D rigidb;
        private Vector2 direction;
        

        
        private void Awake()
        {
            rigidb = GetComponent<Rigidbody2D>();

            
        }

       
        private void Update()
        {
            direction = Vector2.zero;
            var clavier = Keyboard.current;
            if (clavier == null) return;
        }

        private void FixedUpdate()
        {
            rigidb.linearVelocity = direction * vitesse;
        }


    }
}



/*
 * using UnityEngine;
using UnityEngine.InputSystem;

namespace Arielle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ArPlayerMovement : MonoBehaviour
    {
        [SerializeField] private float vitesse = 4f;

        private Rigidbody2D rb;
        private Vector2 direction;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            direction = Vector2.zero;
            var clavier = Keyboard.current;
            if (clavier == null) return;

            if (clavier.wKey.isPressed || clavier.upArrowKey.isPressed)    direction.y += 1;
            if (clavier.sKey.isPressed || clavier.downArrowKey.isPressed)  direction.y -= 1;
            if (clavier.dKey.isPressed || clavier.rightArrowKey.isPressed) direction.x += 1;
            if (clavier.aKey.isPressed || clavier.leftArrowKey.isPressed)  direction.x -= 1;

            direction = direction.normalized;
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = direction * vitesse;
        }
    }
}
 */