using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePortal : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name=="Character") {
            if (this.gameObject.GetComponent<Locked>()==null || this.gameObject.GetComponent<Locked>().checkUnlocked(other.gameObject, true)) {
                StartCoroutine(LoadScene());
            }
            
        }
    }

    private IEnumerator LoadScene() {
        AsyncOperation loader = SceneManager.LoadSceneAsync(nextScene);
        while (!loader.isDone) {
            yield return null;
        }
    }
}
