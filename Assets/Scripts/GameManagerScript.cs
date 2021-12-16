using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameManagerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button Level1;
    public Button Level2;
    public Text textPlay;

    public void Start()
    {
        Level1.gameObject.SetActive(false);
        Level2.gameObject.SetActive(false);
    }

    public void ZmienScene(int numerSceny)
    {
        SceneManager.LoadScene(numerSceny);
    }

    public void OpuscGre()
    {
        Application.Quit();
    }

    public void PokazPoziom()
    {
        Level1.gameObject.SetActive(true);
        Level2.gameObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textPlay.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textPlay.color = Color.white;
    }
}
