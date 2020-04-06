using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathfx;
    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathfx.SetActive(true);
        Invoke("loadingscene", levelLoadDelay);
    }
    private void loadingscene()
    {
        SceneManager.LoadScene(1);
    }
    void StartDeathSequence()
    {
        SendMessage("ApplyDamage", "Movement stopped");
    }
}
