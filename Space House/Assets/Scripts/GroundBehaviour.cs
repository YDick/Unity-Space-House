using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class GroundBehaviour : MonoBehaviour
{
    public List<GroundType> GroundTypes = new List<GroundType>();
    public FirstPersonController FPC;
    public string currentGround;

    void Start()
    {
        setGroundType(GroundTypes[0]);
    }

    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Metal")
            setGroundType(GroundTypes[1]);
        else
            setGroundType(GroundTypes[0]);
        
    }

    public void setGroundType(GroundType ground)
    {
        if (currentGround != ground.name)
        {
            FPC.m_FootstepSounds = ground.footstepsounds;
            currentGround = ground.name;
        }
    }

    [System.Serializable]
    public class GroundType
    {
        public string name;
        //u need at least 2 footstep sounds
        public AudioClip[] footstepsounds;

        // public float walkspeed;
        // public float runspeed;

    }

}
