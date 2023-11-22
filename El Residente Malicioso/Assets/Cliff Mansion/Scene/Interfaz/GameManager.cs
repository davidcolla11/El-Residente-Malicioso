using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{

    public void inicioJuego()
    {
        SceneManager.LoadScene("Scene", LoadSceneMode.Single);
    }
    
    
    public void finJuego()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Single);
    }

    public void cerrarJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
