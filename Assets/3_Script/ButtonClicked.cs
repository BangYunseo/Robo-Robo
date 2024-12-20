using UnityEngine;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour {

    public Image myImage;
    public GameObject _target;
    public string _functionName = "Regame";

	// Use this for initialization
	void Start () {
        if(myImage == null){
            Debug.LogError("Image component is not assigned.");
        }
    }
	
    
	public void OnButtonClick(){
        if(_target != null){
            _target.SendMessage(_functionName, SendMessageOptions.DontRequireReceiver);
        }
    }
    /*
    void Update()
    {

        if( Input.GetMouseButtonDown(0))
        {
            if(_thisObjBtn.HitTest(Input.mousePosition))
            {

                if (_target != null)
                {
                    _target.SendMessage(_functionName, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
    */
}
