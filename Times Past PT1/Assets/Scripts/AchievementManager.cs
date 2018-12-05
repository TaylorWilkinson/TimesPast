using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour {

    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;
    public Image background;

    float delay = 5f;

    private static AchievementManager _instance;

    public static AchievementManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (AchievementManager)FindObjectOfType(typeof(AchievementManager));

                if (_instance == null)
                {
                    Debug.LogError("An instance of " + typeof(AchievementManager) +
                        " is needed in the scene, but there is none.");
                }
            }

            return _instance;
        }
    }

    public void Awake() {

        // Check if instance already exists
        if (_instance == null)
        {
            // If not, set instance to this
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // If instance already exists and it's not this:
        else if (_instance != this)
        {
            // Then destroy this. This enforces our singleton pattern.
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        background.enabled = false;
        title.enabled = false;
        desc.enabled = false;
    }


    private string[] achievementTitle = { "Doing the Most!",
                                          "Pulling Weeds",
                                          "The Red Button",
                                          "Fountain-Fascinated!"};

    private string[] achievementDesc = { "You got into the treasure room!",
                                         "Kid, you've got a promising future in horticulture.",
                                         "You're just gonna press it?! You're playing with fire!",
                                         "You thoroughly inspected both fountains. Good...job?"};
        
    public int[] unlocked;

    public void  UnlockAchievement(Achievement a) {
        StartCoroutine(DelayAchievement());

        //print("Achievement Title: " + achievementTitle[(int)a] +  ",  Achievement Description: " + achievementDesc[(int)a]);
        title.SetText(achievementTitle[(int)a]);
        desc.SetText(achievementDesc[(int)a]);

        background.enabled = true;
        title.enabled = true;
        desc.enabled = true;

        StartCoroutine(ResetAchievement());
    }

    IEnumerator DelayAchievement() {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator ResetAchievement() {
        yield return new WaitForSeconds(delay);

        background.enabled = false;
        title.enabled = false;
        desc.enabled = false;

        title.SetText("");
        desc.SetText("");
    }

    /*
    private void Update()
    {
        AchievementManager.instance.UnlockAchievement(Achievement.A1);
    }
    */
}

//enum Achievement List
public enum Achievement
{
    A1 = 0,
    A2 = 1,
    A3 = 2,
    A4 = 3
}

/*
 * Achievements:
 * 1) Getting Harriet into the treasure room in the mirror level
 * 2) Pulling the Sprout
 * 3) Pressing the red button
 * 4) Click both of the fountains in LVL1
*/
