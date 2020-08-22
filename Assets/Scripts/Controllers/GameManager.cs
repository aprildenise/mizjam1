using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }
    public CanvasGroup victory;
    public CanvasGroup loose;
    public TextMeshProUGUI damagePercentage;

    public bool isPaused { get; private set; }
    private int numCollapsingStructures;

    private float currentWeightedDamage; // Showed to the player and used to determine gameover.
    private float currentDamage;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void UpdateDamageText()
    {
        damagePercentage.text = "Destruction:" + (int)currentWeightedDamage + "%";
        CheckForLose();
    }

    public void AddDamage(float damage)
    {
        currentDamage += damage;
        currentWeightedDamage = currentDamage / numCollapsingStructures;
        UpdateDamageText();
    }

    public void AddCollapsingStructure()
    {
        numCollapsingStructures++;
    }

    public void ShowVictory()
    {
        isPaused = true;
        victory.gameObject.SetActive(true);
    }

    public void HideVictory()
    {
        isPaused = false;
        victory.gameObject.SetActive(false);
    }

    public void CheckForLose()
    {
        if (currentWeightedDamage >= 100)
        {
            ShowLoose();
        }
    }

    public void ShowLoose()
    {
        isPaused = true;
        loose.gameObject.SetActive(true);
    }

    public void HideLoose()
    {
        isPaused = false;
        loose.gameObject.SetActive(false);
    }

    public void RestartCurrentScene()
    {
        GoToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
