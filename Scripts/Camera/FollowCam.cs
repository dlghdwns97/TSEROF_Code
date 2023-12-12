using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private Transform camTargetTr;        //카메라가 추적할 타겟의 트랜스폼 정보

	private TrackingZone trackingZone;  //트랙킹존 스크립트 담을 변수
	private Vector2 minRange;           //추적 범위 최솟값
    private Vector2 maxRange;           //추적 범위 최댓값

    [Range(0.0f, 2.0f)]
    public float distX = 1.0f;          //타겟과의 x축 거리

	[Range(0.0f, 2.0f)]
	public float distY = 1.0f;          //타겟과의 Y축 거리

	[Range(1.0f, 10.0f)]
	public float smoothX = 5.0f;        //X축 추적시 부드러움 정도

	[Range(1.0f, 10.0f)]
	public float smoothY = 5.0f;        //Y축 추적시 부드러움 정도

    

	
	private void Awake()
    {
        camTargetTr = GameObject.FindWithTag("CameraTarget").transform;                     //카메라 타겟의 트랜스폼 정보 저장
        trackingZone = GameObject.Find("Gizmo_TrackingZone").GetComponent<TrackingZone>();  //TrackingZone 저장
        minRange = trackingZone.minXAndY;       //최솟값에 트랙킹 존 스크립트의 최솟값 저장
        maxRange = trackingZone.maxXAndY;       //최댓값에 트랙킹 존 스크립트의 최댓값 저장
    }

    bool CheckDistanceX()
    {
        return Mathf.Abs(transform.position.x - camTargetTr.position.x) > distX;            //X축 타겟과의 거리가 disX 거리값을 넘어서면 참을 반환
    }

	bool CheckDistanceY()
	{
		return Mathf.Abs(transform.position.y - camTargetTr.position.y) > distY;            //Y축 타겟과의 거리가 disY 거리값을 넘어서면 참을 반환
	}

    void CamerTracking()
    {
        float camPosX = transform.position.x;       //카메라의 x포지션
        float camPosY = transform.position.y;       //카메라의 y포지션

        if(CheckDistanceX())
        {
            camPosX = Mathf.Lerp(transform.position.x, camTargetTr.position.x, smoothX * Time.deltaTime);       //타겟 x축 추적
        }

        if(CheckDistanceY())
        {
			camPosY = Mathf.Lerp(transform.position.y, camTargetTr.position.y, smoothY * Time.deltaTime);       //타겟 y축 추적
		}

        camPosX = Mathf.Clamp(camPosX, minRange.x, maxRange.x);         //카메라 x축 설정 범위내로 추적 제한
        camPosY = Mathf.Clamp(camPosY, minRange.y, maxRange.y);         //카메라 y축 설정 범위내로 추적 제한

        transform.position = new Vector3(camPosX, camPosY, transform.position.z);   //카메라 포지션을 갱신
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        CamerTracking();

	}
}
