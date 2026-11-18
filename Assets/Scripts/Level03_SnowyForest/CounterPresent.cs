using TMPro;
using UnityEngine;

public class CounterPresent : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    private int count;
    [SerializeField] private int total = 15;

    private void OnEnable()
    {
        Present.Collected += AddPresent;
    }

    private void OnDisable()
    {
        Present.Collected -= AddPresent;
    }

    private void AddPresent()
    {
        count++;
        TextUpdate();
    }
    private void TextUpdate()
    {
        counterText.text = count + " / " + total;
    }
    public int Count => count;
    public int TotalPresents => total;
    void Start()
    {
        TextUpdate();
    }
}
