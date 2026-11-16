
using UnityEngine;

public class DiamondCounter : MonoBehaviour
{
    public int diamondsCollected = 0;
    public int diamondsRequired = 8;

    public void AddDiamond()
    {
        diamondsCollected++;

        Debug.Log("Diamants : " + diamondsCollected + "/" + diamondsRequired);
    }
}
