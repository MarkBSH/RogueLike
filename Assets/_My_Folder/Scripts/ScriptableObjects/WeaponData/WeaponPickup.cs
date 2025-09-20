using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private MainWeaponInventory mainWeaponInventory;
    [SerializeField] public MainWeaponData mainWeaponData;
    [SerializeField] private GameObject buttonUI;
    private bool buttonSpawned = false;
    private GameObject go;
    private bool keyDown;

    void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        mainWeaponInventory = FindObjectOfType<MainWeaponInventory>();
    }

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));

        RB2D = GetComponent<Rigidbody2D>();
        RB2D.AddForce(new Vector2(Random.Range(-2, 2), Random.Range(-2, 2)), ForceMode2D.Impulse);
    }

    void Update()
    {
        keyDown = Input.GetKey(KeyCode.E);
    }

    void OnTriggerStay2D()
    {
        if (!buttonSpawned)
        {
            go = Instantiate(buttonUI, transform.position, Quaternion.identity, transform);
            buttonSpawned = true;
        }

        if (keyDown)
        {
            mainWeaponInventory.AddItem(mainWeaponData);
            Destroy(go);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D()
    {
        Destroy(go);
        buttonSpawned = false;
    }
}
