using UnityEngine;

public class TrackingZone : MonoBehaviour
{
    public Vector2Int minXAndY;     //x,y �ּڰ�
    public Vector2Int maxXAndY;     //x,y �ִ�
    public Color mainColor = new Color(0.0f, 1.0f, 1.0f, 1.0f);     //���� ���� �÷�

    public Mesh titleMesh;      //��ο� �޽��� Ȱ���� Ÿ��Ʋ �޽�.

    [Range(0.0f, 10.0f)]
    public float titleXpos = 1.0f;      //Ÿ��Ʋ �¿�����

	[Range(-1.0f, 1.0f)]
	public float titleYpos = 1.0f;      //Ÿ��Ʋ ��������

	[Range(0.0f, 1.0f)]
	public float titleSize = 1.0f;      //Ÿ��Ʋ ũ������

	private void OnDrawGizmos()
	{
		Color subColor = new Color(mainColor.r, mainColor.g, mainColor.b, 0.1f * mainColor.a);      //�����÷�
		Vector3 titlePos = new Vector3(maxXAndY.x - titleXpos, maxXAndY.y + titleYpos, 0.0f);		//Ÿ��Ʋ ��ġ
		Vector3 titleScale = new Vector3(titleSize, titleSize, titleSize);                          //Ÿ��Ʋ ũ��

		Gizmos.DrawMesh(titleMesh, titlePos, transform.rotation, titleScale);                       //Ÿ��Ʋ �޽� �����

		for (int x = minXAndY.x; x <= maxXAndY.x; x++)		//x�� �ּڰ��� �ִ񰪺��� �۰ų� ���������� �ݺ�
		{
			if(x - maxXAndY.x == 0 || x- minXAndY.x == 0)	//x�� ���� �ּڰ�, �ִ��� ���� �� ����
			{
				Gizmos.color = mainColor;					//�����÷� ����
			}
			else
			{
				Gizmos.color = subColor;					//�����÷� ����
			}

			Vector3 pos1 = new Vector3(x, minXAndY.y, 0);	//������ ������
			Vector3 pos2 = new Vector3(x, maxXAndY.y, 0);	//������ ����

			Gizmos.DrawLine(pos1, pos2);					//���ۿ��� �������� �������� �׸�
		}

		for (int y = minXAndY.y; y <= maxXAndY.y; y++)		//Y�� �ּڰ��� �ִ񰪺��� �۰ų� ���������� �ݺ�
		{
			if(y - maxXAndY.y == 0 || y - minXAndY.y == 0)	//Y�� ���� �ּڰ�, �ִ� ���� �� ����
			{
				Gizmos.color = mainColor;
			}
			else
			{
				Gizmos.color= subColor;
			}

			Vector3 pos1 = new Vector3(minXAndY.x, y, 0);   //������ ������
			Vector3 pos2 = new Vector3(maxXAndY.x, y, 0);   //������ ����

			Gizmos.DrawLine(pos1, pos2);					//���ۿ��� �������� �������� �׸�
		}
	}
}
