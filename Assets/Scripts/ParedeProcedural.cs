using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParedeProcedural : MonoBehaviour
{
   public GameObject block;
   public int width = 10;
   public int height = 6;
  
   void Start()
   {
       for (int y=0; y<height; ++y)
       {
           for (int x=0; x<width; ++x)
           {
               Instantiate(block, new Vector3(x,y,10), Quaternion.identity);
           }
       }       
   }
}
