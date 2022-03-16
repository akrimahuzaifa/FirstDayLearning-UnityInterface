using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] float resetDelay;
    bool dead = false;

    [SerializeField] AudioSource deadthSound;

    public GameObject gamerOverUI;

    private void Update()
    {
        if (gameObject.transform.position.y < -5 && !dead)
        {
            Die();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }


    void Die()
    {
        deadthSound.Play();
        //Invoke(nameof(ResetLevel), resetDelay);
        //StartCoroutine(ResetLevel(resetDelay));
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            dead = true;
            gamerOverUI.SetActive(true);
            Time.timeScale = 0;
        }


    }

/*    public IEnumerator ResetLevel(float resetTime)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return new WaitForSeconds(resetTime);
        //SceneManager.LoadScene("Level01");
    }*/

/*    //Working with Ivoke but not smooth using Coroutine
    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
