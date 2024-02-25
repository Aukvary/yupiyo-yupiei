using UnityEngine;
using UnityEngine.SceneManagement;

class GameReloader : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    private void Update()
    {
        if(Input.GetKeyUp(_key))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}