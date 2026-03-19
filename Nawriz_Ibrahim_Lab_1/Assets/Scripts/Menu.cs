using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private const string GAME_SCENE_NAME = "SampleScene";
    private const string SAVE_FILE_NAME = "Menu";

    [SerializeField] private Button playBtn;
    [SerializeField] private Button saveBtn;
    [SerializeField] private Button loadBtn;

    private void Start()
    {
        playBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(GAME_SCENE_NAME);
        });

        saveBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.gameData.fileName = SAVE_FILE_NAME;
            SaveLoadSystem.Instance.gameData.sceneName = GAME_SCENE_NAME;
            SaveLoadSystem.Instance.SaveGame();
        });

        loadBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.LoadGame(SAVE_FILE_NAME);
        });
    }
}
