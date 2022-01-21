using UnityEngine;
using UnityEngine.UI;

public class Button_CS : MonoBehaviour
{
    public enum Type { Quit, Restart };
    public Button button;
    public Type type;// = Type.Quit;
    private GameObject playerObj;
    private void Awake()
    {
        if (type == Type.Quit)
        {
            button.onClick.AddListener(OnAplicationQuit);
        }
        else if (type == Type.Restart)
        {
            button.onClick.AddListener(OnAplicationRestart);
        }
        playerObj = GameObject.FindWithTag("Player");
    }
    public void OnAplicationQuit()
    {
        Application.Quit();
    }
    public void OnAplicationRestart() 
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids) 
        {
            Destroy(asteroid);
        }
        //Instantiate(playerObj, GameObject.FindObjectOfType<Camera>().transform);
        //Player.gameObject.transform.position = GameObject.FindObjectOfType<Camera>().transform.position;
        //GameObject Player = GameObject.FindWithTag("Player");

       GameObject.FindObjectOfType<GameManager>().Restart();
        
        //playerObj.SetActive(true); 
    }

}
