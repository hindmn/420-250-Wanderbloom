using TMPro;
using UnityEngine;

public class CounterPresent : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    private int count;
    [SerializeField] private int total = 15;
    [SerializeField] private ScreenVictory screenVictory;


    private void OnEnable()
    {
        Present.Collected += AddPresent;
    }

    private void OnDisable()
    {
        Present.Collected -= AddPresent;
    }

    //Utiliser >= plutôt que == pour éviter des problèmes de logique si le compteur dépasse le total
    private void AddPresent()
    {
        count++;
        TextUpdate();
        if (count >= total) { screenVictory.ShowScreen(); }
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
