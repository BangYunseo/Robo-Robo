using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	// Player's basic properties
	
	public float _speed; 
	public float _hp; 
	public TextMesh _HpVal; 
	public GameObject _hpBar; 
    public Animator _rabbit; 
	
	// For Game Result
	public bool _gameWin; // Check bool for win
    public bool _playerLive = true; // bool for player's live
	public GameObject _uiResult; // Result UI obejct
	public Text _resultText; // Result UI's Text for win or lose
	
	public BoxCollider _attackChkCol; // Boxcollider for on/off when player attack 
	
	private float _damTimer; // Timer for damage state check
	public GameObject _DamEffect; // Effect for damage state
    public GameObject _DamText; // Text Mesh for damage's value
	
	private float _timerForAttack;
    private float _timerForAttackSnd;
    private bool _attackChkbool;

	// Use this for initialization
	void Start () 
	{
		//atakState = _rabbit.StringToHash("0_idle"); 
		if(GetComponent<AudioSource>() != null) GetComponent<AudioSource>().Play();
        if(_rabbit != null) 
		{
			_rabbit.speed = 2.0f;
		}
		else
		{
			_rabbit = gameObject.GetComponentInChildren<Animator>();
			_rabbit.speed = 2.0f;
		}


        if(_uiResult!=null)
        {
            _resultText = _uiResult.transform.Find("3_Result_Text").gameObject.GetComponent<Text>();
        }
			
	}
	
	// Update is called once per frame
	void Update () {
		if(_playerLive)
		{
	        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
	        {
	            float _verticalPos = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
	            float _horizonPos = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
	
	            transform.position += new Vector3(-1 * _horizonPos, 0, -1 * _verticalPos);
	            transform.forward = (new Vector3(-1 * _horizonPos, 0, -1 * _verticalPos));
	            if(_rabbit != null) _rabbit.SetBool("runChk", true);
	        }
	        else
	        {
	            if(_rabbit != null)_rabbit.SetBool("runChk", false);
	        }

			if((_rabbit != null))
			{
                if (Input.GetButtonDown("Fire1") && !_rabbit.GetCurrentAnimatorStateInfo(0).IsName("1_attack"))
                {
                    _rabbit.SetBool("attackChk", true);
                    if (_attackChkCol != null)
                    {
                        _attackChkCol.enabled = true;
                    }
                    _attackChkbool = true;
                }
                else
                {
                    if (_attackChkCol != null) _attackChkCol.enabled = false;
                }

                if (_rabbit.GetBool("damageChk"))
                {
                    if (_rabbit.GetCurrentAnimatorStateInfo(0).IsName("3_damage"))
                    {
                        if (_rabbit.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.0f) _rabbit.SetBool("damageChk", false);
                    }
                }
		    }
        }
	}
	
	void Damaged(float _dam)
	{
		_hp -= _dam;
        if(!_rabbit.GetCurrentAnimatorStateInfo(0).IsName("3_damage")) _rabbit.SetBool("damageChk", true);
		if(_DamEffect != null) Instantiate(_DamEffect,new Vector3(transform.position.x, 1.0f, transform.position.z),Quaternion.identity);
        if(_DamText != null) Instantiate(_DamText, new Vector3(transform.position.x, 1.2f, transform.position.z + 0.2f), Quaternion.identity);
        
		if(_hp >0)
		{
			if(_hpBar != null) _hpBar.transform.localScale = new Vector3 (_hp * 0.01f, 1, 1);
			if(_HpVal != null) _HpVal.text = _hp.ToString();
		}
		else if(_hp <= 0)
		{
			if(_hpBar != null) _hpBar.transform.localScale = new Vector3 (0, 1, 1);
			_playerLive = false;
			if(_HpVal != null) _HpVal.text = "0";
			_gameWin = false;
			GameOver();
		}
	}
	
	public void GameOver()
	{
		//game over
        if (_gameWin)
        {
            if(_resultText != null) _resultText.text = "WIN";
        }
        else
        {
            if(_resultText != null)_resultText.text = "LOSE";
        }
        
        //
		Time.timeScale = 0.0f;
		if(_uiResult != null) _uiResult.SetActive(true);
		
	}

    void Regame()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("1_play");
    }
}
