using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoxPlaySfx : MonoBehaviour
{
    AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        sfx = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            sfx.Play();
            StartCoroutine(growAndSrink());
        }
    }

    IEnumerator growAndSrink() {
        this.gameObject.transform.localScale += new Vector3(1, 1, 0);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.transform.localScale -= new Vector3(1, 1, 0);
    }


}
