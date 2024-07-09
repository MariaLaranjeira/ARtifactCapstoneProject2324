using System.IO;
using UnityEngine;

public static class GlobalGameStateManager
{
    private static string filePath = Path.Combine(Application.persistentDataPath, "gameState.json");

    [System.Serializable]
    private class GameState
    {
        public bool initialInteractionCompleted;
        public int characterSelected;
        public bool helpButton;
        public string playerChoice;
        public int currentLevel;
    }

    public static void LoadGameState()
    {
        string persistentDataPath = Application.persistentDataPath;
        Debug.Log(persistentDataPath);


        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameState gameState = JsonUtility.FromJson<GameState>(json);

            FirstStageGlobalState.initialInteractionCompleted = gameState.initialInteractionCompleted;
            FirstStageGlobalState.helpButton = gameState.helpButton;
            FirstStageGlobalState.playerChoice = gameState.playerChoice;
            FirstStageGlobalState.characterSelected = gameState.characterSelected;
            
            NavigationManager.loadLevel(gameState.currentLevel);

            Debug.Log("Game state loaded.");
        }
        else
        {
            CreateNewGameState();
        }
    }

    private static void CreateNewGameState()
    {
        FirstStageGlobalState.ResetState();
        NavigationManager.loadLevel(0);
        SaveGameState();
        Debug.Log("New game state created.");
    }

    public static void SaveGameState()
    {
        GameState gameState = new GameState
        {
            initialInteractionCompleted = FirstStageGlobalState.initialInteractionCompleted,
            helpButton = FirstStageGlobalState.helpButton,
            playerChoice = FirstStageGlobalState.playerChoice,
            characterSelected = FirstStageGlobalState.characterSelected,
            currentLevel = NavigationManager.CurrentLevel
        };
        string json = JsonUtility.ToJson(gameState, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Game state saved.");
    }

    public static void ResetGameState()
    {
        FirstStageGlobalState.ResetState();
        NavigationManager.loadLevel(0);
        SaveGameState();
    }
}
