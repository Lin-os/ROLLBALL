using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public void Scene()
    {

        Application.Quit();
        Debug.Log("앱종료");//앱이 종료되는지 안되는지 확인
    }
}
