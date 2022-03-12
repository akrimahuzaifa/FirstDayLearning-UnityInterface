using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] float resetDelay = 1.3f;
    bool dead = false;

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
        //Invoke(nameof(ResetLevel), resetDelay);
        StartCoroutine(ResetLevel(resetDelay));
        dead = true;
    }

    public IEnumerator ResetLevel(float resetTime)
    {
        SceneManager.LoadScene("testin");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return new WaitForSeconds(resetTime);
    }

    //Working with Ivoke but not smooth using Coroutine
/*    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
