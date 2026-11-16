
using UnityEngine;
using TMPro;

public class DiamondCounter : MonoBehaviour
{
    public int diamondsCollected = 0;
    public int diamondsRequired = 10;
    public TextMeshProUGUI diamondText;

    void Start()
    {
        UpdateDisplay();
    }

    public void AddDiamond()
    {
        diamondsCollected++;
        UpdateDisplay();

        Debug.Log("Diamants : " + diamondsCollected + "/" + diamondsRequired);
    }

    public bool HasEnoughDiamonds()
    {
        return diamondsCollected >= diamondsRequired;
    }

    private void UpdateDisplay()
    {
        if (diamondText != null)
        {
            diamondText.text = diamondsCollected + "/" + diamondsRequired;
        }
    }
}
