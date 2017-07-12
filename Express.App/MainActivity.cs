using Android.App;
using Android.Widget;
using Android.OS;
using Express.Tools;
using Express.Tools.Responses;
using System.Linq;

namespace Express.App
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText txtId;
        private Button btnQuery;
        private ListView detailList;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            txtId = FindViewById<EditText>(Resource.Id.txtExpressId);
            detailList = FindViewById<ListView>(Resource.Id.detailList);
            btnQuery = FindViewById<Button>(Resource.Id.btnQuery);
            btnQuery.Click += BtnQuery_Click;
        }

        private async void BtnQuery_Click(object sender, System.EventArgs e)
        {
            KDNiaoHelper helper = new KDNiaoHelper();
            var ret = await helper.OrderTracesSubByJson();
            if (ret != null && ret.Shippers.Count > 0)
            {
                var exTypeInfo = ret.Shippers.FirstOrDefault();
                var orderTrace = await helper.GetOrderTracesByJson(exTypeInfo.ShipperCode, ret.LogisticCode);
                //OrderDisResponse response = System.Json.JsonValue.Load()
            }
            //var dialog = new AlertDialog.Builder(this);
            //dialog.SetMessage(ret);
            //dialog.SetNegativeButton("确定",delegate { });
            //dialog.Show();
        }
    }
}

