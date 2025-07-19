/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections;
using SkyForge.Extension;

namespace BonesOfDragonfall
{
    public class SceneService : BaseSceneService
    {
        public const string BOOTSTRAP_SCENE = "Bootstrap";
        public const string MAIN_MENU_SCENE = "MainMenu";
        public const string GAMEPLAY_SCENE = "Gameplay";
        
        public IEnumerator LoadMainMenu(MainMenuEnterParams mainMenuEnterParams)
        {
            yield return LoadScene(BOOTSTRAP_SCENE);
            yield return LoadScene(MAIN_MENU_SCENE, mainMenuEnterParams);
        }

        public IEnumerator LoadGameplay(GameplayEnterParams gameplayEnterParams)
        {
            yield return LoadScene(BOOTSTRAP_SCENE);
            yield return LoadScene(GAMEPLAY_SCENE, gameplayEnterParams);
        }
    }
}