using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlackHoleMovement : MonoBehaviour
{
    public GameObject Explosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControlObject = GameObject.FindWithTag("GameController");
        if (gameControlObject != null)
            gameController = gameControlObject.GetComponent<GameController>();
        if (gameControlObject == null)
            Debug.Log("Sorry ,Couldn't find object");
    }

    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(Explosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
            gameController.addScore(scoreValue);
        }

        

        
    }



}
