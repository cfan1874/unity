using UnityEngine;
using System.Collections;
/// <summary>
/// 敌人生成器
/// </summary>
public class EnemyGenerator : MonoBehaviour {
    //生成的位置
    public Transform spawnPos;
    //敌人集合
    public GameObject[] enemyArray;
    //一次生成的数量
    public int num=4;
    //生成时间
    public float waitTime = 2f;
    // Use this for initialization
    void Awake()
    {
        StartCoroutine(GenerateWait());
    }
    void OnDestroy()
    {
        StopCoroutine(GenerateWait());
    }
	// Update is called once per frame
	void Update () {

	}
    IEnumerator GenerateWait()
    {
        //最初的等待时间
        yield return new WaitForSeconds(2);
        while (true)
        {
            for (int i = 0; i < num; i++)
            {
                Generate();
            }
            //两次生成的等待时间
            yield return new WaitForSeconds(waitTime);
        }
    }
    //生成
    private void Generate()
    {
        //随机生成敌人
        GameObject go = enemyArray[Random.Range(0, enemyArray.Length)];
        //位置
        Vector2 p = new Vector2(Random.Range(spawnPos.position.x - 6, spawnPos.position.x + 6), spawnPos.position.y);
        //方向（默认）
        Quaternion q = Quaternion.identity;
        Instantiate(go, p, q);
    }
}
