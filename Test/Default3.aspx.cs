using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemcachedProviders.Cache;

[Serializable]
public class UU {
    public string name = "";
    
    public  UU(string _name) {
        this.name = _name;
    }
}


public partial class Test_Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       string cacheKey = "myname";
       string cacheValue = "Nelson";

       UU u1 = new UU("nelson");

       DistCache.Add("U1", u1);



        //object objCache = DistCache.Get(cacheKey);
        
        // 寫入快取資料 (預設過期時間)
        DistCache.Add(cacheKey, cacheValue);
        // 快取 60 秒
        DistCache.Add(cacheKey, cacheValue, 60 * 1000);
        
        // 快取至今天結束
        DistCache.Add(cacheKey, cacheValue, DateTime.Today.AddDays(1) - DateTime.Now);



        
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         //string cacheKey = "myname";
        //object objCache = DistCache.Get(cacheKey);
        //Label1.Text = objCache.ToString();


        UU u1 =(UU) DistCache.Get("U1");
        Label1.Text = u1.name;


    }
}