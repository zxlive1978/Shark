using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{

    //'Windows XP style
    //        '   ActiveBorder, RGB=(212,208,200); LightGray, RGB=(211,211,211); ActiveBorder, RGB=(212,208,200)
    //        '   ActiveCaption, RGB=(0,84,227); RoyalBlue, RGB=(65,105,225); ActiveCaption, RGB=(0,84,227)
    //        '   ActiveCaptionText, RGB=(255,255,255); Transparent, RGB=(255,255,255); ActiveCaptionText, RGB=(255,255,255)
    //        '   AppWorkspace, RGB=(128,128,128); Gray, RGB=(128,128,128); AppWorkspace, RGB=(128,128,128)
    //        '   Control, RGB=(236,233,216); AntiqueWhite, RGB=(250,235,215); Control, RGB=(236,233,216)
    //        '   ControlDark, RGB=(172,168,153); DarkGray, RGB=(169,169,169); ControlDark, RGB=(172,168,153)
    //        '   ControlDarkDark, RGB=(113,111,100); DimGray, RGB=(105,105,105); ControlDarkDark, RGB=(113,111,100)
    //        '   ControlLight, RGB=(241,239,226); Beige, RGB=(245,245,220); ControlLight, RGB=(241,239,226)
    //        '   ControlLightLight, RGB=(255,255,255); Transparent, RGB=(255,255,255); ActiveCaptionText, RGB=(255,255,255)
    //        '   ControlText, RGB=(0,0,0); Black, RGB=(0,0,0); ControlText, RGB=(0,0,0)
    //        '   Desktop, RGB=(0,78,152); Teal, RGB=(0,128,128); Desktop, RGB=(0,78,152)
    //        '   GrayText, RGB=(172,168,153); DarkGray, RGB=(169,169,169); ControlDark, RGB=(172,168,153)
    //        '   Highlight, RGB=(49,106,197); RoyalBlue, RGB=(65,105,225); Highlight, RGB=(49,106,197)
    //        '   HighlightText, RGB=(255,255,255); Transparent, RGB=(255,255,255); ActiveCaptionText, RGB=(255,255,255)
    //        '   HotTrack, RGB=(0,0,128); Navy, RGB=(0,0,128); HotTrack, RGB=(0,0,128)
    //        '   InactiveBorder, RGB=(212,208,200); LightGray, RGB=(211,211,211); ActiveBorder, RGB=(212,208,200)
    //        '   InactiveCaption, RGB=(122,150,223); CornflowerBlue, RGB=(100,149,237); InactiveCaption, RGB=(122,150,223)
    //        '   InactiveCaptionText, RGB=(216,228,248); Lavender, RGB=(230,230,250); InactiveCaptionText, RGB=(216,228,248)
    //        '   Info, RGB=(255,255,225); LightYellow, RGB=(255,255,224); Info, RGB=(255,255,225)
    //        '   InfoText, RGB=(0,0,0); Black, RGB=(0,0,0); ControlText, RGB=(0,0,0)
    //        '   Menu, RGB=(255,255,255); Transparent, RGB=(255,255,255); ActiveCaptionText, RGB=(255,255,255)
    //        '   MenuText, RGB=(0,0,0); Black, RGB=(0,0,0); ControlText, RGB=(0,0,0)
    //        '   ScrollBar, RGB=(212,208,200); LightGray, RGB=(211,211,211); ActiveBorder, RGB=(212,208,200)
    //        '   Window, RGB=(255,255,255); Transparent, RGB=(255,255,255); ActiveCaptionText, RGB=(255,255,255)
    //        '   WindowFrame, RGB=(0,0,0); Black, RGB=(0,0,0); ControlText, RGB=(0,0,0)
    //        '   WindowText, RGB=(0,0,0); Black, RGB=(0,0,0); ControlText, RGB=(0,0,0)
    //        '   Transparent, RGB=(255,255,255); Transparent, RGB=(255,255,255); ActiveCaptionText, RGB=(255,255,255)
    //        '   Black, RGB=(0,0,0); Black, RGB=(0,0,0); ControlText, RGB=(0,0,0)
    //        '   Gray, RGB=(128,128,128); Gray, RGB=(128,128,128); AppWorkspace, RGB=(128,128,128)
    //        '   Navy, RGB=(0,0,128); Navy, RGB=(0,0,128); HotTrack, RGB=(0,0,128)
    //        '   White, RGB=(255,255,255); Transparent, RGB=(255,255,255); ActiveCaptionText, RGB=(255,255,255)
    //        '   ButtonFace, RGB=(236,233,216); AntiqueWhite, RGB=(250,235,215); Control, RGB=(236,233,216)
    //        '   ButtonHighlight, RGB=(255,255,255); Transparent, RGB=(255,255,255); ActiveCaptionText, RGB=(255,255,255)
    //        '   ButtonShadow, RGB=(172,168,153); DarkGray, RGB=(169,169,169); ControlDark, RGB=(172,168,153)
    //        '   GradientActiveCaption, RGB=(61,149,255); DodgerBlue, RGB=(30,144,255); GradientActiveCaption, RGB=(61,149,255)
    //        '   GradientInactiveCaption, RGB=(157,185,235); LightSteelBlue, RGB=(176,196,222); GradientInactiveCaption, RGB=(157,185,235)
    //        '   MenuBar, RGB=(236,233,216); AntiqueWhite, RGB=(250,235,215); Control, RGB=(236,233,216)
    //        '   MenuHighlight, RGB=(49,106,197); RoyalBlue, RGB=(65,105,225); Highlight, RGB=(49,106,197)
    //        '
    public class color_collection
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

        public List<float[]> colors_collect = new List<float[]>();
        public List<int> colors_select = new List<int>();
        public List<int> colors_select_backup = new List<int>();
        

        public color_collection(){
            
            //colors_collect.Add(cl1);
            colors_collect.Add(cl2);
            colors_collect.Add(cl3);
            colors_collect.Add(cl4);
            //colors_collect.Add(cl5);
            //colors_collect.Add(cl6);
            colors_collect.Add(cl7);
            //colors_collect.Add(cl8);
            //colors_collect.Add(cl9);
            //colors_collect.Add(cl10);
            colors_collect.Add(cl11);
            //colors_collect.Add(cl12);
            //colors_collect.Add(cl13);
            //colors_collect.Add(cl14);
            colors_collect.Add(cl15);
            //colors_collect.Add(cl16);
            colors_collect.Add(cl17);
            //colors_collect.Add(cl18);
            //colors_collect.Add(cl19);
            //colors_collect.Add(cl20);
            //colors_collect.Add(cl21);
            //colors_collect.Add(cl22);
            //colors_collect.Add(cl23);
            colors_collect.Add(cl24);
            colors_collect.Add(cl25);
            colors_collect.Add(cl26);
            //colors_collect.Add(cl28);
            for (int i = 0; i < colors_collect.Count; i++) {
                colors_collect[i][0] = (float)(colors_collect[i][0] / 256f);
                colors_collect[i][1] = (float)(colors_collect[i][1] / 256f);
                colors_collect[i][2] = (float)(colors_collect[i][2] / 256f);
            }
            
            
        }

        public void color_copy(){
            colors_collect.Capacity = 0;
            //colors_collect.Add(cl1);
            colors_collect.Add(cl2);
            colors_collect.Add(cl3);
            colors_collect.Add(cl4);
            //colors_collect.Add(cl5);
            //colors_collect.Add(cl6);
            colors_collect.Add(cl7);
            //colors_collect.Add(cl8);
            //colors_collect.Add(cl9);
            //colors_collect.Add(cl10);
            colors_collect.Add(cl11);
            //colors_collect.Add(cl12);
            //colors_collect.Add(cl13);
            //colors_collect.Add(cl14);
            colors_collect.Add(cl15);
            //colors_collect.Add(cl16);
            colors_collect.Add(cl17);
            //colors_collect.Add(cl18);
            //colors_collect.Add(cl19);
            //colors_collect.Add(cl20);
            //colors_collect.Add(cl21);
            //colors_collect.Add(cl22);
            //colors_collect.Add(cl23);
            colors_collect.Add(cl24);
            colors_collect.Add(cl25);
            colors_collect.Add(cl26);
            //colors_collect.Add(cl28);
            //for (int i = 0; i < colors_collect.Count; i++)
            //{
            //    colors_collect[i][0] = (float)(colors_collect[i][0] / 256f);
            //    colors_collect[i][1] = (float)(colors_collect[i][1] / 256f);
            //    colors_collect[i][2] = (float)(colors_collect[i][2] / 256f);
            //}
        
        }
    }
}
