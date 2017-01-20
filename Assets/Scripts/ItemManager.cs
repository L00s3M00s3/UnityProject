using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    public GameObject powerup, extralife, speedUp, fireUp;
    int pownum = 3;
    int livesnum = 5;
	int Speednum = 5;
	int Firenum = 5;

    GameObject[] power_array, lives = null, speed_array, fire_array;

	// Use this for initialization
	void Awake () {
        power_array = new GameObject[pownum];
        lives = new GameObject[livesnum];
		speed_array = new GameObject[Speednum];
		fire_array = new GameObject[Firenum];


        for(int i = 0; i < pownum; i++)
        {
            power_array[i] = Instantiate(powerup) as GameObject;
            power_array[i].SetActive(false);
        }
        for (int i = 0; i < livesnum; i++)
        {
            lives[i] = Instantiate(extralife) as GameObject;
            lives[i].SetActive(false);
        }
		for (int i = 0; i < Speednum; i++)
		{
			speed_array[i] = Instantiate(speedUp) as GameObject;
			speed_array[i].SetActive(false);
		}
		for (int i = 0; i < Firenum; i++)
		{
			fire_array[i] = Instantiate(fireUp) as GameObject;
			fire_array[i].SetActive(false);
		}

    }
	
	public void Activatepower(Transform _transform)
    {
        for(int i = 0; i < pownum; i++)
        {
            if (power_array[i].activeSelf == false)
            {
                power_array[i].SetActive(true);
                power_array[i].transform.position = _transform.position;
                break;
            }
        }
    }
    public void ActivateLife(Transform _transform)
    {
        for(int i = 0; i < livesnum; i++)
        {
            if (lives[i].activeSelf == false)
            {
                lives[i].SetActive(true);
                lives[i].transform.position = _transform.position;
                break;
            }
        }
    }

	public void ActivateSpeedUp(Transform _transform)
	{
		for(int i = 0; i < Speednum; i++)
		{
			if (speed_array[i].activeSelf == false)
			{
				speed_array[i].SetActive(true);
				speed_array[i].transform.position = _transform.position;
				break;
			}
		}
	}

	public void ActivateFireUp(Transform _transform)
	{
		for(int i = 0; i < Firenum; i++)
		{
			if (speed_array[i].activeSelf == false)
			{
				fire_array[i].SetActive(true);
				fire_array[i].transform.position = _transform.position;
				break;
			}
		}
	}
}

