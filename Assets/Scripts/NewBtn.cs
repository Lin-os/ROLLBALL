using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Scene 전환 할 수 있는 코드 사용할 수 있음

public class NewBtn : MonoBehaviour
{
    // Start is called before the first frame update
 public void Scene()
    {

        SceneManager.LoadScene(1);
    }
}
