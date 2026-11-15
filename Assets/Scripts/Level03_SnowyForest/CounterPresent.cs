using TMPro;
using UnityEngine;

public class CounterPresent : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    private int count;

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
        counterText.text = "Cadeaux : " + count;
    }
    public int Count => count;
    void Start()
    {
        TextUpdate();
    }
}
