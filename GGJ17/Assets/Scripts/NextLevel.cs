
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public string pathname;

    public void ChangeScene()
    {
        SceneManager.LoadScene(pathname);
    }
}
