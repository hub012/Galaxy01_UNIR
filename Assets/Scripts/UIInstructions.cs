using UnityEngine;


    public class UIInstructions: MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            GameManager.Instance.ChangeScene(sceneName);
        }
    }
