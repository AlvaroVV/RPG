using UnityEngine;
using System.Collections;

public class MainMenuSceneTest : MonoBehaviour {

    public enum Menu
    {
        MainMenu,
        NewGame,
        Continue
    }

    public Menu currentMenu;

    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        if (currentMenu == Menu.MainMenu)
        {
            SaveLoadManager.Load();
            GUILayout.Box("Last Fantasy");
            GUILayout.Space(10);

            if (GUILayout.Button("New Game"))
            {
                SaveLoadManager.NewSlot();
                currentMenu = Menu.NewGame;
            }

            if (GUILayout.Button("Continue"))
            {
                currentMenu = Menu.Continue;
            }

            if (GUILayout.Button("Quit"))
            {
                Application.Quit();
            }
        }

        else if (currentMenu == Menu.NewGame)
        {
            GUILayout.Label("Your Name");
            GameSlotInfo.currentGameSlot.gameSlotName = GUILayout.TextField(GameSlotInfo.currentGameSlot.gameSlotName, 20);

            if (GUILayout.Button("Create"))
            {             
                Application.LoadLevel(1);
            }

            GUILayout.Space(10);
            if (GUILayout.Button("Cancel"))
            {
                currentMenu = Menu.MainMenu;
            }

        }

        else if (currentMenu == Menu.Continue)
        {

            GUILayout.Box("Select Save File");
            GUILayout.Space(10);

            for(int i = 0; i< SaveLoadManager.gamesSlots.gameSlotsInfo.Length; i++)
            {
                if (GUILayout.Button("GameSlot_" + SaveLoadManager.gamesSlots.gameSlotsInfo[i].gameSlotName))
                {
                    GameSlotInfo.currentGameSlot = SaveLoadManager.gamesSlots.gameSlotsInfo[i];
                    //Move on to game...
                    Application.LoadLevel(1);
                }

            }

            GUILayout.Space(10);
            if (GUILayout.Button("Cancel"))
            {
                currentMenu = Menu.MainMenu;
            }

        }

        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();

    }
}
