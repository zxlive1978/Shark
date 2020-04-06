using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class color_collection_tech
    {
        //float[] cl1 = new float[] { 255, 0, 0 };
        float[] cl2 = new float[] { 0, 0, 255 };
        float[] cl3 = new float[] { 255, 0, 255 };
        float[] cl4 = new float[] { 255, 0, 0 };
        //float[] cl5 = new float[] { 220, 20, 60 };
        //float[] cl6 = new float[] { 255, 99, 71 };
        float[] cl7 = new float[] { 255, 255, 0 };
        //float[] cl8 = new float[] { 255, 255, 255 };
        //float[] cl9 = new float[] { 128, 128, 0 };
        //float[] cl10 = new float[] { 85, 107, 47 };
        float[] cl11 = new float[] { 0, 255, 0 };
        //float[] cl12 = new float[] { 0, 128, 0 };
        //float[] cl13 = new float[] { 46, 139, 87 };
        //float[] cl14 = new float[] { 47, 79, 79 };
        float[] cl15 = new float[] { 0, 255, 255 };
        //float[] cl16 = new float[] { 25, 25, 112 };
        float[] cl17 = new float[] { 255, 165, 0 };
        //float[] cl18 = new float[] { 0, 0, 255 };
        //float[] cl19 = new float[] { 75, 0, 130 };
        //float[] cl20 = new float[] { 255, 228, 196 };
        //float[] cl21 = new float[] { 255, 20, 147 };
        //float[] cl22 = new float[] { 255, 215, 0 };
        //float[] cl23 = new float[] { 139, 69, 19 };
        float[] cl24 = new float[] { 210, 105, 30 };
        float[] cl25 = new float[] { 127, 255, 212 };
        float[] cl26 = new float[] { 0, 250, 154 };
        //float[] cl28 = new float[] { 107, 142, 35 };

        public List<float[]> colors_collect_tech = new List<float[]>();
        public List<int> colors_select = new List<int>();
        public List<int> colors_select_backup = new List<int>();
        

        public color_collection_tech(){
            
            //colors_collect_tech.Add(cl1);
            colors_collect_tech.Add(cl2);
            colors_collect_tech.Add(cl3);
            colors_collect_tech.Add(cl4);
            //colors_collect_tech.Add(cl5);
            //colors_collect_tech.Add(cl6);
            colors_collect_tech.Add(cl7);
            //colors_collect_tech.Add(cl8);
            //colors_collect_tech.Add(cl9);
            //colors_collect_tech.Add(cl10);
            colors_collect_tech.Add(cl11);
            //colors_collect_tech.Add(cl12);
            //colors_collect_tech.Add(cl13);
            //colors_collect_tech.Add(cl14);
            colors_collect_tech.Add(cl15);
            //colors_collect_tech.Add(cl16);
            colors_collect_tech.Add(cl17);
            //colors_collect_tech.Add(cl18);
            //colors_collect_tech.Add(cl19);
            //colors_collect_tech.Add(cl20);
            //colors_collect_tech.Add(cl21);
            //colors_collect_tech.Add(cl22);
            //colors_collect_tech.Add(cl23);
            colors_collect_tech.Add(cl24);
            colors_collect_tech.Add(cl25);
            colors_collect_tech.Add(cl26);
            //colors_collect_tech.Add(cl28);
            for (int i = 0; i < colors_collect_tech.Count; i++) {
                colors_collect_tech[i][0] = (float)(colors_collect_tech[i][0] / 256f);
                colors_collect_tech[i][1] = (float)(colors_collect_tech[i][1] / 256f);
                colors_collect_tech[i][2] = (float)(colors_collect_tech[i][2] / 256f);
            }
            
            
        }

        public void color_copy(){
            colors_collect_tech.Capacity = 0;
            //colors_collect_tech.Add(cl1);
            colors_collect_tech.Add(cl2);
            colors_collect_tech.Add(cl3);
            colors_collect_tech.Add(cl4);
            //colors_collect_tech.Add(cl5);
            //colors_collect_tech.Add(cl6);
            colors_collect_tech.Add(cl7);
            //colors_collect_tech.Add(cl8);
            //colors_collect_tech.Add(cl9);
            //colors_collect_tech.Add(cl10);
            colors_collect_tech.Add(cl11);
            //colors_collect_tech.Add(cl12);
            //colors_collect_tech.Add(cl13);
            //colors_collect_tech.Add(cl14);
            colors_collect_tech.Add(cl15);
            //colors_collect_tech.Add(cl16);
            colors_collect_tech.Add(cl17);
            //colors_collect_tech.Add(cl18);
            //colors_collect_tech.Add(cl19);
            //colors_collect_tech.Add(cl20);
            //colors_collect_tech.Add(cl21);
            //colors_collect_tech.Add(cl22);
            //colors_collect_tech.Add(cl23);
            colors_collect_tech.Add(cl24);
            colors_collect_tech.Add(cl25);
            colors_collect_tech.Add(cl26);
            //colors_collect_tech.Add(cl28);
            //for (int i = 0; i < colors_collect_tech.Count; i++)
            //{
            //    colors_collect_tech[i][0] = (float)(colors_collect_tech[i][0] / 256f);
            //    colors_collect_tech[i][1] = (float)(colors_collect_tech[i][1] / 256f);
            //    colors_collect_tech[i][2] = (float)(colors_collect_tech[i][2] / 256f);
            //}
        
        }
    }
}
