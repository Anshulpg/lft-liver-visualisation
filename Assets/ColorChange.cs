using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] material;
    Renderer rend;
    //private string input;
    private int[] input;
    public bool changed=false;
 //
    public GameObject sphere;
    private Vector3 scaleChange, positionChange;
    private int last_multiplier=0;
    void Start(){ }


    /*
        Assumption:
        4 factor in range - 
        10-150
        0-1000
        40-900
        99-25000

        current formula : taking avg after scaling down
    */
    public double calculateFactor(){
        int []start=new int[4]{10,0,40,99};
        int []end=new int[4]{150,1000,900,25000};
        double sum=0.0;
        for(int i=0;i<4;i++){
            sum+=((input[i]-start[i])*100.0)/(end[i]-start[i]);
        }
        sum/=4.0;
        // sum can be max 100 min 0 as of now
        return sum;


    }
    void Update(){
        if(changed){
            changed=false;
            // for(int i=0;i<4;i++){
            //     Debug.Log(input[i]);
            // }
            //int factor=int.Parse(input);
            scaleChange = new Vector3(2f, 2f, 0f);
            double factor=calculateFactor();
            Debug.Log(factor);
            sphere.transform.localScale -= scaleChange*last_multiplier;
            rend=GetComponent<Renderer>();
            rend.enabled=true;
            last_multiplier=(int)factor;
            sphere.transform.localScale += scaleChange*last_multiplier;
            //Debug.Log(sphere.transform.localScale);
            // if(factor<25){
                
            //     rend.sharedMaterial=material[0];
            //     //rend.material.Lerp(material[0], material[1], (float)factor/25);
                
            // }
            // if(factor<25){ 
            //     rend.sharedMaterial=material[0];

            // }
            // else if(factor>=25 && factor<50) {
                
            //     rend.sharedMaterial=material[1]; 
            // }
            // else if(factor>=50 && factor<75) {
              
            //     rend.sharedMaterial=material[2]; 
            // }
            // else {
                
            //     rend.sharedMaterial=material[3];  
            // }
            if(factor<=10){
                rend.sharedMaterial=material[0];
            }

            else if(factor<=40 && factor>10) {
                
                rend.sharedMaterial=material[1];
                rend.material.Lerp(material[0], material[1], (float)(factor-10)/30);
            }
            else if(factor>40 && factor<=70) {
              
                rend.sharedMaterial=material[2];
                rend.material.Lerp(material[1], material[2], (float)(factor-40)/30);
            }
            else {
                
                 rend.sharedMaterial=material[3];
                rend.material.Lerp(material[2], material[3], (float)(factor-70)/30);
                
            }
        }
          // 
        //
        //scaleChange = new Vector3(-0.001f, -0.001f, -0.001f);
        //positionChange = new Vector3(0.0f, -0.0005f, 0.00f);
        // sphere.transform.localScale += scaleChange;
        //sphere.transform.position += positionChange;

        
    }
   
    void OnCollisionEnter (Collision col){
        rend.sharedMaterial=material[1];
    }
    public int[] converter(string s){
        string temp="";
        int [] ans=new int[4];
        int j=0;
        for(int i=0;i<s.Length;i++){
            if(s[i]!=','){
                temp+=s[i];
            }
            else{
                ans[j++]=int.Parse(temp);
                temp="";
            }
        }
        if(j<4){
            ans[j++]=int.Parse(temp);
        }
        return ans;
    }
    public void ReadStringInput(string s){
        //int[] myArray = Array.ConvertAll<string, int>(value.Split(','), Convert.ToInt32);
        //input=s;
        changed=true;
        int[] arr=converter(s);
        
        input=arr;
        //Debug.Log(input);
    }
    
}
