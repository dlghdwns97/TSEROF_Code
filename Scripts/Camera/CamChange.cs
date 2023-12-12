using Cinemachine;
using UnityEngine;

public class CamChange : MonoBehaviour
{
	static CinemachineVirtualCamera cam1;
	static CinemachineVirtualCamera cam2;
	static CinemachineVirtualCamera cam3;
	static CinemachineVirtualCamera cam4;

    public CinemachineVirtualCamera[] cams = new CinemachineVirtualCamera[4] { cam1, cam2, cam3, cam4 };

	public void SetCamPoint(int index)
    {
        for(int i = 0; i < cams.Length; i++)
        {
            cams[i].enabled = i == index;
        }
    }

	public void CamReset()
	{
        //cam1.enabled = true;
    }
}
