using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptsScene
{
    public class SwitchingScene : MonoBehaviour
    {
        public void OpenMenu(GameObject menu)
        {
            menu.SetActive(true);

        }

        public void CloseMenu(GameObject menu)
        {
            menu.SetActive(false);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void StartGame(int indexScene) => SceneManager.LoadScene(indexScene);

    }
}
