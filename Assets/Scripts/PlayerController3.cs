using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI 네임스페이스
using UnityEngine.SceneManagement;
public class PlayerController3 : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public AudioSource audioSource; //사운드
    public AudioSource winSource; //아이템 다 먹을 시 사운드
    public Text itemText; //아이템 먹을 시 표시할 텍스트
    public Text winText; //아이템 다 먹을 시(클리어) 표시할 텍스트
    public float JumpPower;
    private bool Jumping;

    private int item = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        item = 0;
        SetItemText();
        //audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        Jumping = false;//점프 중인지 판단 할 수 있도록 bool값 생성(초기화)
    }

    void Update()//키 입력
    {
        if (Input.GetKeyDown(KeyCode.Space))//스페이스 키 누르면 점프
        {
            if (!Jumping)//바닥에 있으면 점프
            {
                Jumping = true;
                rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
            else
            {
                return;//공중에 떠있는 상태이면 점프하지 못하도록 리턴
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //바닥에 닿으면
        if (collision.gameObject.CompareTag("Floor"))//바닥에 닿으면
        {
            Jumping = false; //점프가 가능한 상태로 만듦
        }
    }

    // Update is called once per frame
    void FixedUpdate() //물리적 제어를 위해 Update 함수 대신 FixedUpdate 함수를 사용
                       //Update는 게임의 로직을 제어하고 FixedUpdate는 물리적 충돌을 제어
    {
        float h = Input.GetAxis("Horizontal");//Horizontal로 입력된 키보드 값을 가져온다.  Horizontal : 수평 
        float v = Input.GetAxis("Vertical"); //Vertical로 입력된 키보드 값을 가져온다.     Vertical : 수직 
        //Input클래스 : 사용자로부터 받은 입력을 처리
        //GetAxis("Horizontal"); -> -1 ~ 0 ~ 1 값 리턴
        //GetAxis("Vertical"); -> -1 ~1 값 리턴
        Vector3 moveVertor = new Vector3(h, 0f, v); //Rigidbody 컴포넌트에 객체의 이동을 위해 전달할 값은 Vector3 객체 형태로 전달 -> Vector3객체는 x, y, z 값을 담고 있는 자료구조 역할을 한다.(수평 이동 백터)

        rb.AddForce(moveVertor * speed); // Rigidbody 컴포넌트에서 제공하는 AddForce 함수를 통해 사용자로부터 입력 받은 값을 객체로 전달한다.
    }

    //Trigger Collider 충돌 발생 시
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        other.gameObject.SetActive(false);


        //Item을 더하고, UI에 표시
        item++; //Item값에 1 더해줌
        SetItemText();

        //아이템을 6개 이상 먹으면
        if (item >= 6)
        {
            winText.enabled = true;
            winSource.Play();//사운드 실행(승리사운드)

        }

        if (other.gameObject.CompareTag("item"))//"item이라는 오브젝트에 닿으면"
        {
            audioSource.Play();//사운드 실행(아이템사운드)
        }
    }


    //현재 Item값을 UI에 표시
    void SetItemText()
    {
        itemText.text = "Item : " + item.ToString();
    }
}
