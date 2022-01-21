using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player_CS player;
    public float respawnTime = 3;
    public int lives = 3;
    public Canvas GameOver_Canvas;

    private void Start()
    {
        GameObject.FindObjectOfType<LivesText>().LivesChange(lives);
    }
    public void PlayerDied()
    {
        this.lives--;
        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
        GameObject.FindObjectOfType<LivesText>().LivesChange(lives);
    }


    private void GameOver()
    {
        GameOver_Canvas.gameObject.SetActive(true);
        //throw new NotImplementedException();
    }

    // Update is called once per frame
    private void Respawn()
    {
        this.player.transform.localPosition = new Vector3(0, 0, 1);
        this.player.gameObject.SetActive(true);
    }
    public void Restart()
    {
        GameOver_Canvas.gameObject.SetActive(false);
        lives = 3;
        GameObject.FindObjectOfType<LivesText>().LivesChange(lives);
        this.player.transform.localPosition = new Vector3(0, 0, 1);
        this.player.gameObject.SetActive(true);
    }

}
