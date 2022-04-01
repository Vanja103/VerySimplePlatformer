using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_controller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    //компоненты которые нужны для движения
    Rigidbody rb;
    Transform transf;
    //слишком умные вещи
    float vertical;
    float horizontal;
    float jumpForce = 10f;
    static int coins = 0;

    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transf = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
       vertical = Input.GetAxis("Vertical");
       horizontal = Input.GetAxis("Horizontal");
     

       //движение влево вправо прямо и назад
       rb.AddRelativeForce(0,0, vertical * 10f);
       transf.Rotate(0,horizontal,0);
       //прыжок для игрока
       if(Input.GetKeyDown("space") && isGrounded == true){
           print("нажат");
           rb.drag = 2;
           rb.angularDrag = 2;
           rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
       }
    }

    void OnCollisionEnter(Collision col){
          //ДЕНЬГИ!!!!!!
       if(col.gameObject.tag == "Coin"){
           coins = coins + 1;
           coinText.text = coins + "Coins";
           Destroy(col.gameObject);
       }
        //прыжок сиквел
        if(col.gameObject.tag == "Dirt"){
             isGrounded = true;
             
        }
    }

    void OnCollisionExit(Collision col){
        
        if(col.gameObject.tag == "Dirt"){
            isGrounded = false;
        }
    }
}
