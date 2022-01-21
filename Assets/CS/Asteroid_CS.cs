using UnityEngine;
using UnityEngine.UI;

public class Asteroid_CS : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D Rigidbody2D;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;
    public PointsUI_CS PointsUI;
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

        SpriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        this.transform.localScale = Vector3.one * this.size;
        Rigidbody2D.mass = this.size;

    }
    public void SetTrajectory(Vector2 Dir) 
    {
        Rigidbody2D.AddForce(Dir * this.speed);
        Destroy(gameObject, this.maxLifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((this.size * 0.5f) >= this.minSize) 
            {
                CreateSplit();
                CreateSplit();
            }
            GameObject.FindObjectOfType<PointsUI_CS>().addPoint();
            //GameObject.Find("Text").GetComponent<PointsUI_CS>().addPoint();
            //PointsUI.addPoint();
            Destroy(this.gameObject);
        }
       
    }
    private void CreateSplit() 
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid_CS half = Instantiate(this, position,this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized);
    }

}
