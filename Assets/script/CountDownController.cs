using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int countDownTime;
    public Text countDownDisplay;

   
    private void Start()
    {
        
        Global.GlobalVariables.isMoving = false;
        StartCoroutine(CountDownToStart());
        
    }

    IEnumerator CountDownToStart()
    {
        // TO DO : voir pouquoi cette boucle ne fonctionne pas
       
       /* while(countDownTime > 0)
        {
            countDownDisplay.text = countDownDisplay.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }*/

        //décompte 
        countDownDisplay.text = "3";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "2";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "1";
        yield return new WaitForSeconds(1f);
        countDownDisplay.text = "GO !";

        yield return new WaitForSeconds(1f);
        //on cache le texte du décompte
        countDownDisplay.gameObject.SetActive(false);
        //on passe la variable isMoving à true pour pouvoir dans PlayerMouvement donner dees mouvements au Player
        Global.GlobalVariables.isMoving = true;
        
    }
}
