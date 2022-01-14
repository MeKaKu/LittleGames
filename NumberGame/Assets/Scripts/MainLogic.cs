using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    public int n = 5;
    public int m = 5;
    public int Dec = 20;
    int lowX = -225;
    int lowY = -180;
    int w = 90;
    int [] dx = new int[4]{0,0,-1,1};
    int [] dy = new int[4]{-1,1,0,0};
    int [][] v = new int[10][];
    public BlockController blockController;
    BlockController[][]  blocks = new BlockController[10][];
    int curV = 1;
    struct Node{
        public int x,y;
    }
    private void Start() {
        curV = 1;
        for(int i=0;i<n;i++){
            v[i] = new int [m];
            blocks[i] = new BlockController [m];
            for(int j=0;j<m;j++){
                v[i][j]=0;
                blocks[i][j] = Instantiate<BlockController>(blockController,transform);
                //print(blocks[i][j].name);
                //position
                //blocks[i][j].transform.position = new Vector3(lowX+i*w,lowY+j*w,0);
                //print(blocks[i][j].transform.position);
                blocks[i][j].GetComponent<RectTransform>().anchoredPosition = new Vector3(lowX+i*w,lowY+j*w,0);
                //print(blocks[i][j].GetComponent<RectTransform>().anchoredPosition);
                //color,num
                int num = GetNumber();
                print(num);
                blocks[i][j].num = num;
                blocks[i][j].transform.GetChild(0).gameObject.GetComponent<Text>().text =  "";
                blocks[i][j].GetComponent<Image>().color = new Color(1 - 1.0f*num/Dec/2,1 - 1.0f*num/Dec,1 - 1.0f*num/Dec,1);
            }
        }
    }
    void ck(int x,int y){

    }
    void bfs(int x,int y){
        Queue<Node> q = new Queue<Node>();
        Node node = new Node();
        node.x = x;
        node.y = y;
        int num = blocks[x][y].num;
        q.Enqueue(node);
        while(q.Count>0){
            node = q.Peek();
            x = node.x;
            y = node.y;
            for(int i=0;i<4;i++){
                int _x = x+dx[i];
                int _y = y+dy[i];
                if(ing(x,y)&&v[x][y]!=curV&&blocks[x][y].num==num){
                    v[x][y] = curV;
                    node.x = _x;
                    node.y = _y;
                }
            }
        }
        

    }
    int GetNumber(){
        int num = Mathf.FloorToInt(Time.time * Dec);
        num += Random.Range(0,100);
        num %= 6;
        num+=6;
        num%=6;
        num++;
        return num;
    }
    bool ing(int x,int y){
        return x>=0&&y>=0&&x<n&&y<m;
    }
}
