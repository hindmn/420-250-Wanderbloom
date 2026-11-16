
using UnityEngine;

public class FinalRoomGate : MonoBehaviour
{
    private DiamondCounter diamondCounter;
    private BoxCollider2D gateCollider;

    void Start()
    {
        diamondCounter = FindFirstObjectByType<DiamondCounter>();
        gateCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (diamondCounter != null && gateCollider != null)
        {
            if (diamondCounter.HasEnoughDiamonds())
            {
                gateCollider.enabled = false;
            }
        }
    }
}
