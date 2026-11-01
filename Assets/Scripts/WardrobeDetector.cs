using UnityEngine;

public class WardrobeDetector : MonoBehaviour
{
    public GameObject target;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            GameObject.FindGameObjectWithTag("MainManager").GetComponent<StoryManager>().Progress();
            StartCoroutine(GameObject.FindGameObjectWithTag("MainManager").GetComponent<StoryManager>().UpdateObjective("Good job!"));

            //Better said:
            // - Find the StoryManager using GameObject.GetComponent<*component*>()
            // - Trigger the Progress() method inside
            // - Update the objective using UpdateObjective Coroutine (be careful, coroutines are started in a special way, viz. other stages!) in void of Stage2
            // - Inside the StoryManager add in Stage3 void
            // - Wire up Stage3 void on the story manager for it to say "hello stage 3" to console


            // yeahhhh.....................................................................
            //I definetly know what am doing...............................................\
            //- Fish
            
        }
    }
}
