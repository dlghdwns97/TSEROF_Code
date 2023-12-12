using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private Transform camTargetTr;        //ī�޶� ������ Ÿ���� Ʈ������ ����

	private TrackingZone trackingZone;  //Ʈ��ŷ�� ��ũ��Ʈ ���� ����
	private Vector2 minRange;           //���� ���� �ּڰ�
    private Vector2 maxRange;           //���� ���� �ִ�

    [Range(0.0f, 2.0f)]
    public float distX = 1.0f;          //Ÿ�ٰ��� x�� �Ÿ�

	[Range(0.0f, 2.0f)]
	public float distY = 1.0f;          //Ÿ�ٰ��� Y�� �Ÿ�

	[Range(1.0f, 10.0f)]
	public float smoothX = 5.0f;        //X�� ������ �ε巯�� ����

	[Range(1.0f, 10.0f)]
	public float smoothY = 5.0f;        //Y�� ������ �ε巯�� ����

    

	
	private void Awake()
    {
        camTargetTr = GameObject.FindWithTag("CameraTarget").transform;                     //ī�޶� Ÿ���� Ʈ������ ���� ����
        trackingZone = GameObject.Find("Gizmo_TrackingZone").GetComponent<TrackingZone>();  //TrackingZone ����
        minRange = trackingZone.minXAndY;       //�ּڰ��� Ʈ��ŷ �� ��ũ��Ʈ�� �ּڰ� ����
        maxRange = trackingZone.maxXAndY;       //�ִ񰪿� Ʈ��ŷ �� ��ũ��Ʈ�� �ִ� ����
    }

    bool CheckDistanceX()
    {
        return Mathf.Abs(transform.position.x - camTargetTr.position.x) > distX;            //X�� Ÿ�ٰ��� �Ÿ��� disX �Ÿ����� �Ѿ�� ���� ��ȯ
    }

	bool CheckDistanceY()
	{
		return Mathf.Abs(transform.position.y - camTargetTr.position.y) > distY;            //Y�� Ÿ�ٰ��� �Ÿ��� disY �Ÿ����� �Ѿ�� ���� ��ȯ
	}

    void CamerTracking()
    {
        float camPosX = transform.position.x;       //ī�޶��� x������
        float camPosY = transform.position.y;       //ī�޶��� y������

        if(CheckDistanceX())
        {
            camPosX = Mathf.Lerp(transform.position.x, camTargetTr.position.x, smoothX * Time.deltaTime);       //Ÿ�� x�� ����
        }

        if(CheckDistanceY())
        {
			camPosY = Mathf.Lerp(transform.position.y, camTargetTr.position.y, smoothY * Time.deltaTime);       //Ÿ�� y�� ����
		}

        camPosX = Mathf.Clamp(camPosX, minRange.x, maxRange.x);         //ī�޶� x�� ���� �������� ���� ����
        camPosY = Mathf.Clamp(camPosY, minRange.y, maxRange.y);         //ī�޶� y�� ���� �������� ���� ����

        transform.position = new Vector3(camPosX, camPosY, transform.position.z);   //ī�޶� �������� ����
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        CamerTracking();

	}
}
