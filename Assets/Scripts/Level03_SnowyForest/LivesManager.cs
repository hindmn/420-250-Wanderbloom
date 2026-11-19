using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{

    [SerializeField] private int maxLives = 3;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Tilemap iceTile;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    //Réutilise l'écran de victoire en changeant juste son contenu (le titre, message)
    [SerializeField] private ScreenVictory gameOver;
    [SerializeField] private AudioSource backgroundAudio;

    private int lives;
    private Vector2 startPos;
    //Propriété en lecture seulement : sert à lire le nb de vies sans modifier.
    public int Lives => lives;

    private void OnEnable()
    {
        ChickenActions.PlayerIsTouched += PlayerTouched;
    }

    private void OnDisable()
    {
        ChickenActions.PlayerIsTouched -= PlayerTouched;
    }

    private void Start()
    {
        lives = maxLives;
        startPos = player.position;
        HeartChanges();
    }

    private void PlayerTouched()
    {
        //Si le joueur est sur la glace, l'animal poulet ne peut pas le toucher
        if (PlayerIsOnIce()) { return; }

        //Si le Chicken touche le Player une 4eme fois, le jeu est terminé.
        if (lives <= 0)
        {
            GameOver();
            return;
        }

        //À chaque fois que le joueur se fait toucher par un poulet, il perd 1 vie = 1 coeur.
        lives--;
        HeartChanges();
        Respawn();
    }

    private void HeartChanges()
    {
        //Parcours les 3 essaies
        for (int i = 0; i < hearts.Length; i++)
        {
            //Si [i] est plus petit que le nombre de vies (3), le coeur est plein
            if (i < lives)
            {
                hearts[i].sprite = fullHeart;
            } //Si non le coeur est vide
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    private bool PlayerIsOnIce()
    {
        //WorldToCell convertit la position du joueur, qui est en unités, en case de la grille
        Vector3Int tile = iceTile.WorldToCell(player.position);
        //HasTile vérifie s'il y a une tuile de glace sur cette case
        return iceTile.HasTile(tile);
    }
    private void Respawn()
    {//Après chaque essaie, le joueur revient à sa position et vitesse de départ (vitesse = 0)
        player.position = startPos;
        player.linearVelocity = Vector2.zero;
    }
    private void GameOver()
    {//Lorsque le jeu est terminé, le son de fond d'écran arrête et l'écran de gameOver s'apparaît
        backgroundAudio.Stop();
        gameOver.ShowScreen();
    }
}
