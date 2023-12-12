using UnityEngine;

public class TrackingZone : MonoBehaviour
{
    public Vector2Int minXAndY;     //x,y 최솟값
    public Vector2Int maxXAndY;     //x,y 최댓값
    public Color mainColor = new Color(0.0f, 1.0f, 1.0f, 1.0f);     //메인 라인 컬러

    public Mesh titleMesh;      //드로우 메쉬로 활용할 타이틀 메쉬.

    [Range(0.0f, 10.0f)]
    public float titleXpos = 1.0f;      //타이틀 좌우조절

	[Range(-1.0f, 1.0f)]
	public float titleYpos = 1.0f;      //타이틀 상하조절

	[Range(0.0f, 1.0f)]
	public float titleSize = 1.0f;      //타이틀 크기조절

	private void OnDrawGizmos()
	{
		Color subColor = new Color(mainColor.r, mainColor.g, mainColor.b, 0.1f * mainColor.a);      //보조컬러
		Vector3 titlePos = new Vector3(maxXAndY.x - titleXpos, maxXAndY.y + titleYpos, 0.0f);		//타이틀 위치
		Vector3 titleScale = new Vector3(titleSize, titleSize, titleSize);                          //타이틀 크기

		Gizmos.DrawMesh(titleMesh, titlePos, transform.rotation, titleScale);                       //타이틀 메쉬 기즈모

		for (int x = minXAndY.x; x <= maxXAndY.x; x++)		//x축 최솟값이 최댓값보다 작거나 같을때까지 반복
		{
			if(x - maxXAndY.x == 0 || x- minXAndY.x == 0)	//x축 값이 최솟값, 최댓값이 같을 때 실행
			{
				Gizmos.color = mainColor;					//메인컬러 지정
			}
			else
			{
				Gizmos.color = subColor;					//서브컬러 지정
			}

			Vector3 pos1 = new Vector3(x, minXAndY.y, 0);	//세로줄 시작점
			Vector3 pos2 = new Vector3(x, maxXAndY.y, 0);	//세로줄 끝점

			Gizmos.DrawLine(pos1, pos2);					//시작에서 끝점으로 세로줄을 그림
		}

		for (int y = minXAndY.y; y <= maxXAndY.y; y++)		//Y축 최솟값이 최댓값보다 작거나 같을때까지 반복
		{
			if(y - maxXAndY.y == 0 || y - minXAndY.y == 0)	//Y축 값이 최솟값, 최댓값 같을 때 실행
			{
				Gizmos.color = mainColor;
			}
			else
			{
				Gizmos.color= subColor;
			}

			Vector3 pos1 = new Vector3(minXAndY.x, y, 0);   //가로줄 시작점
			Vector3 pos2 = new Vector3(maxXAndY.x, y, 0);   //가로줄 끝점

			Gizmos.DrawLine(pos1, pos2);					//시작에서 끝점으로 가로줄을 그림
		}
	}
}
