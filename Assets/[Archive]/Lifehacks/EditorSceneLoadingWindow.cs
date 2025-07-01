#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Game.Editor
{
    public class EditorSceneLoadingWindow
    {
        private const string ScenePath = "Assets/Scenes/";
            
        private static void OpenScene(string sceneName)
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                EditorSceneManager.OpenScene(ScenePath + sceneName);
        }

        [MenuItem("Custom tools/Open Sample Scene")]
        public static void OpenSampleScene()
        {
            OpenScene("SampleScene.unity");
        }
        
        [MenuItem("Custom tools/Open Test Scene")]
        public static void OpenTestScene()
        {
            OpenScene("TestScene.unity");
        }
    }
}
#endif