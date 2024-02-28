using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource sfx;
    public bool IsPause = false;
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive )
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            sfx.Play();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!IsPause)
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
                IsPause = true;
                logic.backgroundScore.Stop();
                logic.pauseSound.Play();
            }
            else
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                IsPause = false;
                logic.backgroundScore.Play();
            }

            
        }
        if (Input.GetKeyDown(KeyCode.R) && birdIsAlive)
        {
            Time.timeScale = 1;
            logic.pauseScreen.SetActive(false);
            logic.backgroundScore.Play();
        }
        if (transform.position.y < -17 || transform.position.y >17)
        {
            logic.gameOver();
            //logic.restartGame();//
            birdIsAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        logic.dies();
        birdIsAlive = false;
    }
    


}
