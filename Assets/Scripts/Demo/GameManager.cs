using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum DemoGameState
{
    Setup,      // initial setup
    Intro,      // intro cutscene
    Play,       // Playing the game
    GameOver,   // End cutscene or game over
    End,        // Teardown
}

public class GameManager : Singleton<GameManager>
{
    private DemoGameState _gameState;
    public DemoGameState GameState
    { get { return _gameState; } }

    public UnityEvent<DemoGameState, DemoGameState> OnGameStateChanged = new UnityEvent<DemoGameState, DemoGameState>();


    void Start()
    {
        // initial testing of if systems work
        // LoadScene("SampleScene");
        // ChangeGameState(DemoGameState.Intro);
    }

    #region Update

    void Update()
    {
        switch (_gameState)
        {
            case DemoGameState.Setup:
                SetupUpdate();
                break;
            case DemoGameState.Intro:
                IntroUpdate();
                break;
            case DemoGameState.Play:
                PlayUpdate();
                break;
            case DemoGameState.GameOver:
                GameOverUpdate();
                break;
            case DemoGameState.End:
                EndUpdate();
                break;
            default:
                Debug.LogError("Error! Tried to run updated in an invald game state!");
                break;
        }
    }

    private void SetupUpdate()
    {
        // Do setup stuff
    }

    private void IntroUpdate()
    {
        Debug.Log("Intro Update");
    }

    private void PlayUpdate()
    {
        // Do play stuff
    }

    private void GameOverUpdate()
    {
        // Do game over stuff
    }

    private void EndUpdate()
    {
        // Do end stuff
    }

    #endregion

    public void ChangeGameState(DemoGameState targetState)
    {
        DemoGameState previousState = _gameState;
        _gameState = targetState;
        OnGameStateChanged.Invoke(previousState, _gameState);
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /* public DemoGameState GetGameState()
    {
        return _gameState;
    } */
}
