using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreasure : MonoBehaviour {
    public GameObject gemPrefab;

    GameObject gemScoreCounter;

    GameObject[] gemArray;

    public int randomGemTotal;

    Vector3 randomGemPosition;

    // Use this for initialization
    public void Start() {
        gemScoreCounter = GameObject.Find("GemScore");

        gemArray = GameObject.FindGameObjectsWithTag("Gem");

        randomGemTotal = Random.Range(1, 4);
    }
	
	// Update is called once per frame
	void Update () {
        //print("This random gemtotal: " + this.randomGemTotal);
        //print("Score: " + gemScoreCounter.GetComponent<GemCounter>().score + ", randomGemTotal: " + randomGemTotal);

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f)) {
                if (hit.transform != null) {
                    //print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                    //print(this.transform.position);

                    if (hit.transform.gameObject == this.transform.gameObject) {
                        //print("urn clicked");
                        for (int i = 0; i < randomGemTotal; i++)
                        {
                            randomGemPosition = new Vector3(Random.Range((this.transform.position.x - 1f), (this.transform.position.x + 1f)), 2.0f, Random.Range((this.transform.position.z - 1f), (this.transform.position.z + 1f)));
                            Instantiate(gemPrefab, randomGemPosition, transform.rotation);
                        }

                        gemScoreCounter.GetComponent<GemCounter>().score += this.randomGemTotal;

                        StartCoroutine(MakeGemsDisappear(GameObject.FindGameObjectsWithTag("Gem")));

                        this.GetComponent<DialogueOnClick>().enabled = false;
                        this.GetComponent<CollectTreasure>().enabled = false;
                    }
                }
            }
        }
    }

    IEnumerator MakeGemsDisappear(GameObject[] go) {
        yield return new WaitForSeconds(2f);

        for (var i = 0; i < go.Length; i++)
        {
            Destroy(go[i]);
        }
    }
}
