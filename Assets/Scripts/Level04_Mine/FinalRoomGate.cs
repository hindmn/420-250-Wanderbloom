using UnityEngine;
using TMPro;

public class FinalRoomGate : MonoBehaviour
{
    public GameObject gatePanel;
    public TextMeshProUGUI gateText;
    public GameObject roomDarkness;

    private BoxCollider2D gateCollider;
    private DiamondCounter diamondCounter;

    void Start()
    {
        gateCollider = GetComponent<BoxCollider2D>();
        diamondCounter = FindFirstObjectByType<DiamondCounter>();
    }

    void Update()
    {
        if (diamondCounter == null)
            return;

        if (diamondCounter.HasEnoughDiamonds())
        {
            if (gateCollider != null)
                gateCollider.enabled = false;

            if (gatePanel != null)
                gatePanel.SetActive(false);

            if (roomDarkness != null)
                roomDarkness.SetActive(false);
        }
        else
        {
            if (gateText != null)
                gateText.text = diamondCounter.diamondsCollected + "/10";
        }
    }
}