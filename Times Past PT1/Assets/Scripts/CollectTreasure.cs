using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreasure : MonoBehaviour {
    //character check
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;
    GameObject harriet, basil;

    //gem elements
    public GameObject gemPrefab;

    GameObject gemScoreCounter;

    GameObject[] gemArray;

    public int randomGemTotal;

    Vector3 randomGemPosition;

    // Use this for initialization
    public void Start() {
        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");

        gemScoreCounter = GameObject.Find("GemScore");
        gemArray = GameObject.FindGameObjectsWithTag("Gem");
        randomGemTotal = Random.Range(1, 4);
    }
	
	// Update is called once per frame
	void Update () {
        //determine active character
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 0) {
            harrietActive = true;
            basilActive = false;
        } else if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 1) {
            basilActive = true;
            harrietActive = false;
        }


        //print("This random gemtotal: " + this.randomGemTotal);
        //print("Score: " + gemScoreCounter.GetComponent<GemCounter>().score + ", randomGemTotal: " + randomGemTotal);

        //ON CLICK, COLLECT RANDOM GEMS
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f)) {
                if (hit.transform != null) {
                    //print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                    //print(this.transform.position);

                    if (hit.transform.gameObject == this.transform.gameObject) {
                        //if harriet is active, collect gems
                        if (harrietActive == true)
                        {
                            //print("urn clicked");
                            for (int i = 0; i < randomGemTotal; i++) {
                                /*randomGemPosition = new Vector3(Random.Range((this.transform.position.x - 0.5f), (this.transform.position.x + 0.5f)),
                                                                2.0f,
                                                                Random.Range((this.transform.position.z - 0.5f), (this.transform.position.z + 0.5f)));*/
                                randomGemPosition = new Vector3(Random.Range((this.transform.position.x - 0.5f), (this.transform.position.x + 0.5f)),
                                                                Random.Range((this.transform.localPosition.y + 1.5f), (this.transform.localPosition.y + 2.5f)),
                                                                Random.Range((this.transform.position.z - 0.5f), (this.transform.position.z + 0.5f)));
                                Instantiate(gemPrefab, randomGemPosition, transform.rotation);
                            }

                            //add score
                            gemScoreCounter.GetComponent<GemCounter>().score += this.randomGemTotal;
                            StartCoroutine(gemScoreCounter.GetComponent<GemCounter>().showGemScore());

                            //make gems disappear
                            StartCoroutine(MakeGemsDisappear(GameObject.FindGameObjectsWithTag("Gem")));

                            this.GetComponent<DialogueOnClick>().enabled = false;
                            this.GetComponent<CollectTreasure>().enabled = false;
                        }
                        else if (basilActive == true)
                        {
                            //play sound
                            this.GetComponent<AudioScript>().PlayAlternateSound();
                        }
                    }
                }
            }
        }
    }

    IEnumerator MakeGemsDisappear(GameObject[] go) {
        //play sound
        this.GetComponent<AudioScript>().PlaySound();

        yield return new WaitForSeconds(2f);

        for (var i = 0; i < go.Length; i++)
        {
            Destroy(go[i]);
        }
    }
}
