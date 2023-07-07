using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    bool canSpawn = false;
    bool ballInstance = false;
    float minX = -7.5f;
    float maxX = 7.5f;
    float minY = 3;
    float maxY = 4;

    public void setCanSpawn(bool value)
    {
        canSpawn = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        canSpawnToggleDisplay(this.canSpawn);
    }

    public void canSpawnToggleDisplay(bool canSpawn) {
        if (canSpawn)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.green;
        }
        else {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
        }
    }

    /**
     * Spawner movement limited by clamped values
     */
    void SpawnerMovement() {
        UnityEngine.Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(mousePosition.y, minY, maxY);
        this.transform.position = new UnityEngine.Vector3(clampedX, clampedY, 0);
    }
    // Update is called once per frame
    void Update()
    {
        SpawnerMovement();

        if (canSpawn && Input.GetButton("Fire1"))
        {
            if (!ballInstance) {
                ball = Instantiate(ball, transform);
                ball.name = "Ball";
                ball.transform.parent = null;
                ballInstance = true;
            }
            else
            {
                ball.gameObject.SetActive(true);
                ball.transform.position = this.transform.position;
                ball.GetComponent<Rigidbody2D>().mass = Random.Range(0.5f, 3f);
            }
            canSpawn = false;
            canSpawnToggleDisplay(canSpawn);
        }
    }
}
