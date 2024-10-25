using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed = 0.3f;
    public float rotSpeed = 2.0f;
    public float wheelRotSpeed = 6.0f;
    GameObject tower, rearWheels, frontWheels;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tower = GameObject.Find("tower");
        rearWheels = GameObject.Find("rearWheels");    
        frontWheels = GameObject.Find("frontWheels");        
    }

    // Update is called once per frame
    void Update()
    {
        KeyControl();   
    }

    void KeyControl()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed);
            rearWheels.transform.Rotate(wheelRotSpeed, 0, 0);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed);
            rearWheels.transform.Rotate(-wheelRotSpeed, 0, 0);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotSpeed, 0);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotSpeed, 0);
        }

        if(Input.GetKey(KeyCode.A))
        {
            tower.transform.Rotate(0, -rotSpeed, 0);
        }

        if(Input.GetKey(KeyCode.D))
        {
            tower.transform.Rotate(0, rotSpeed, 0);
        }

    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.name == "Explosive")  
            GetComponent<Rigidbody>().AddForce(0, 500, 0);  
    }
}
