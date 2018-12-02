using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour, IActionOnClick {
    [SerializeField]
    public GameObject objectInOtherTime;

    [SerializeField]
    public GameObject requiredCharacter;

    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    // Use this for initialization
    public void OnObjectClick()
    {
        //determine active character
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 0)
        {
            harrietActive = true;
            basilActive = false;
        }
        else if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 1)
        {
            basilActive = true;
            harrietActive = false;
        }


        //destroy object if the active character is, well, active
        if ((requiredCharacter.name == "Harriet") && (harrietActive == true))
        {
            StartCoroutine(DestroyGameObjects());
        }
        else if ((requiredCharacter.name == "Basil") && (basilActive == true))
        {
            if (this.gameObject.name == "Grass_g_01") {
                //play grass pulling sound
                this.GetComponent<AudioScript>().PlaySound();
            } else if (this.gameObject.name == "Tapestry Kah") {
                //play grass pulling sound
                this.GetComponent<AudioScript>().PlaySound();
            }

            StartCoroutine(DestroyGameObjects());
        }
    }

    IEnumerator DestroyGameObjects() {
        if (this.gameObject.name == "Grass_g_01") {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        } else if (this.gameObject.name == "Tapestry Kah") {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }


        yield return new WaitForSeconds(1.50f);
        //print(gameObject);

        Destroy(gameObject);
        DestroyOtherObject(objectInOtherTime);
    }

    private void DestroyOtherObject(GameObject go)
    {
        if (objectInOtherTime != null)
        {
            Destroy(go);
            //gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}
