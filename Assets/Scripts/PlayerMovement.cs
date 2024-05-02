using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody rig;
    public Transform mainCamera;
    public float _speed;

    [Space]

    [Header("Keys")]
    public AudioSource _audioSource_pick; 
    public Text _keyText;
    public int _keys;

    [Space]

    [Header("Win")]
    public Transform _door;
    public Transform _TargetPos;
    public Win _win;
    public GameObject _restartTxt;

    [Space]

    [Header("Lose && Timer")]
    public Timer _timer;
    public AudioSource _audioSource_lose;


    private Vector3 currentVelocity;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("key"))
        {
            _audioSource_pick.Play();
            Destroy(collision.gameObject);
            _keys++;
            _keyText.text = ("Keys: ") + _keys + ("/5");

            if (_keys == 5)
            {
                StartCoroutine(_openDoor());
            }
                
        }
        if (collision.transform.CompareTag("LastObj"))
        {
            _TheEnd();
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    { 
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 
            mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void FixedUpdate()
    {

        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;

      //  camF.y = 0;
      //  camR.y = 0;

        Vector3 movingVector;

        movingVector = Vector3.ClampMagnitude(camF.normalized * Input.GetAxis("Vertical") * _speed 
            + camR.normalized * Input.GetAxis("Horizontal") * _speed, _speed);
       
        rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);


        rig.angularVelocity = Vector3.zero;
    }

    IEnumerator _openDoor()
    {
        while(_door.position != _TargetPos.position)
        {
            _door.position = Vector3.SmoothDamp(_door.position, _TargetPos.position, ref currentVelocity, 0.5f);
            yield return null;
        }
    }
    public void _lose(Text _timerText)
    {
        _keyText.text = "LOSE";
        _timerText.text = "LOSE";
        _audioSource_lose.Play();
        StartCoroutine(WaitForRestart());
    }

    private IEnumerator WaitForRestart()
    {
        yield return new WaitForSeconds(1.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void _TheEnd()
    {
        _timer.isRunning = false;
        _timer.timerText.text = "Congratulations";
        _keyText.text = "Win";
        _win._wining(_restartTxt);
    }
}
