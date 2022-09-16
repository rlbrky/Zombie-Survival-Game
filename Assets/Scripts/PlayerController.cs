using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float DashDistance;
    [SerializeField] private float stamina;
    [SerializeField] private float staminaRegen;
    [SerializeField] private float staminaDep;
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;

    [SerializeField] private Rigidbody rb;
    private Vector3 inputs = Vector3.zero;
    public float radius = 3f;   //Objeyle etkile�ime ge�ebilmek i�in i�inde bulunmam�z gereken mesafe.

    //Yerden e�ya alma ve kap� a�ma vs gibi i�lemler i�in de�i�kenlerimiz.
    private bool interactionAvailable = false;
    public bool InteractionAvailable { get { return interactionAvailable; } set { interactionAvailable = value; } }
    Interactable interactableThing;
    public Interactable InteractableThing
    {
        set { interactableThing = value; }
    }
    //A�l�k eklenmedi
    [SerializeField] private int hungerMeter;
    //K�r�k bacak debuff � eklenmedi
    private bool BrokenLeg;


    public Healthbar healthBar;
    public Staminabar staminaBar;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
        staminaBar.SetMaxStamina(stamina);
    }

    // Update is called once per frame
    void Update()
    {
       /* inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal"); 
        inputs.z = Input.GetAxis("Vertical"); 
        if(inputs != Vector3.zero)
        {
            transform.forward = inputs;
        }*/

        //Dash ayarlar�
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3(
                (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag+1)) / -Time.deltaTime)));
            rb.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
        #region Hareket
        if (Input.GetKey(KeyCode.W))
        {
            //HATALI
            transform.position += Camera.main.transform.forward * speed *Time.deltaTime;
            //Rotasyonunu kameran�n bakt��� y�ne g�re ayarla ? Quaternion ?
        }
        if (Input.GetKey(KeyCode.S))
        {
            //HATALI
            transform.position -= Camera.main.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Camera.main.transform.right*speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Camera.main.transform.right*speed * Time.deltaTime;
        }

        //Ge�ici fonksiyon sil
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }

        #region Ko�ma Ayarlar�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina >= 0)
            {
                speed = runningSpeed;
                stamina -= staminaDep*Time.deltaTime;
                staminaBar.SetStamina(stamina);
            }
        }
        else
        {
            if (stamina <= 100)
            {
                speed = walkingSpeed;
                stamina += staminaRegen * Time.deltaTime;
                staminaBar.SetStamina(stamina);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkingSpeed;
        }
        #endregion
        #endregion

        #region Interaction
        if (interactionAvailable && Input.GetKeyDown(KeyCode.E)) //E tu�una bast���mda menzildeysem obje ile etkile�ime ge�ilecek.
        {
            interactableThing.Interact();
        }
        #endregion
    }

    //Hasar alma i�lemleri
    void TakeDamage(int damage)
    {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);
    }

    //G�rselle�tirmek i�in.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}