using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityGamingServicesUseCases
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        public string sceneName;
        public Object readmeFile;

        void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        void OnDestroy()
        {
            var button = GetComponent<Button>();
            button.onClick.RemoveListener(OnButtonClick);
        }

        void OnButtonClick()
        {
            LoadScene();
            SelectReadmeFileOnProjectWindow();
        }
        
        void LoadScene()
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        
        void SelectReadmeFileOnProjectWindow()
        {
#if UNITY_EDITOR
            if (!(readmeFile is null))
            {
                Selection.objects = new Object[] {readmeFile};   
            }
#endif
        }
    }
}
