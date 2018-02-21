using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPlayer : Photon.MonoBehaviour {

    

    public Transform playerGlobal;
    public Transform playerLocal;

    PhotonView photonView;
    private GameObject spawnedCameraRig;
    private GameObject spawnedSphere;
    
    // Use this for initialization
    void Start () {

        photonView = GetComponent<PhotonView>();

        if (photonView.isMine)
        {
            //Instantiates the sphere. 
            spawnedSphere = (GameObject)Instantiate(Resources.Load("Sphere"), new Vector3(0f, 0f, 0f), Quaternion.identity);

            //Instantiates the camera rigs here that combines the avatar with the rig. 
            spawnedCameraRig = (GameObject)Instantiate(Resources.Load("[CameraRig]"), new Vector3(0f, 0f, 0f), Quaternion.identity);
            playerGlobal = GameObject.Find("Player1(Clone)").transform;
            playerLocal = playerGlobal.Find("[CameraRig]/Camera (head)/Camera (eye)");



            if(playerLocal == null)
            {
                playerLocal = playerGlobal.Find("Camera (eye)");
            }
            //Parent camera to this
            this.transform.SetParent(playerLocal);
            this.transform.localPosition = Vector3.zero;

            
        }
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
