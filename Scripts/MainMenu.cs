using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int indexPlay;
    [SerializeField] int indexReturn;
    [SerializeField] int indexHowTo;

    public void OpenScene()
    {
        SceneManager.LoadScene(indexPlay);
    }

    public void ExitGame()
    {

        Application.Quit();

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(indexReturn);
    }

    public void OpenHowToPlay()
    {
        SceneManager.LoadScene(indexHowTo);
    }

}
