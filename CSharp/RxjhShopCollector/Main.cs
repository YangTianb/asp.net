using DataAccesss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RxjhShopCollector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Start() {
            Collecter coll = new Collecter();

            var list =  coll.MoinList();
            foreach (var temp in list)
            {
                coll.GetData(temp.Bytes);
            }
            
            BindLowData();
        }

        private void BindMoin() {
            Collecter coll = new Collecter();

            var list = coll.MoinList();
            this.dg_Moin.DataSource = list;
   
        }

        private void BindLowData() {
            Collecter coll = new Collecter();
            dg_LowData.DataSource= coll.GetLowData();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Start();
            BindMoin();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowUpdateTime();
            timer1.Interval = 1 * 1000 * 60 * 3;
            Start();
            BindMoin();
           
        }

        private void ShowUpdateTime() {
            lblLastTime.Text = DateTime.Now.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var _name = txtName.Text.Trim();
            var _addValue = txtAddValue.Text.Trim();
            var _price = txtPrice.Text.Trim();
            var _bytes = txtBytes.Text.Trim();
            CommodConfig config = new CommodConfig()
            {
                AddValue =_addValue,
                Bytes = _bytes,
                 Name= _name
            };

            Collecter coll = new Collecter();
            coll.AddCommodConfig(config);
            Start();
            BindMoin();
            ShowUpdateTime();
        }
    }
}
