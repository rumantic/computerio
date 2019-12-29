using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour {
	public bool killEnemies = false;
	public bool killAnything = false;

	void OnTriggerEnter2D(Collider2D other){
		var player = other.GetComponent<Player> ();
        Debug.Log("KillPlayerOnTouch begin");
        Debug.Log("killEnemies = " + killEnemies);
        Debug.Log("killAnything = " + killAnything);
        Debug.Log(gameObject.name);
        Debug.Log("gameObject.transform.position.x = " + gameObject.transform.position.x);
        Debug.Log("gameObject.transform.position.y = " + gameObject.transform.position.y);
        Debug.Log("^^^^");
        Debug.Log("player.transform.position.x = " + player.transform.position.x);
        Debug.Log("player.transform.position.y = " + player.transform.position.y);
        Debug.Log("user ^^^^");


        if (killAnything)
			other.gameObject.SetActive (false);
		
		else if (player != null) {
            if (player.isPlaying) {
                Debug.Log("KillPlayerOnTouch is player");
                LevelManager.Instance.KillPlayer();
            }
        } else if (killEnemies && other.gameObject.GetComponent (typeof(ICanTakeDamage)))
			other.gameObject.SetActive (false);
		}


}
