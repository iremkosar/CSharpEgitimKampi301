using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            //Toplam Lokasyon Sayısı
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price).ToString()+ "₺";
            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();
            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();
            var milanoGuideId = db.Location.Where(x => x.City == "Milano").Select(y => y.GuideId).FirstOrDefault();
            lblMilanoGuideName.Text = db.Guide.Where(x => x.GuideId == milanoGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();
            var MaxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == MaxPrice).Select(y => y.City).FirstOrDefault().ToString();
            var guideIdByNameYemlihanKursun = db.Guide.Where(x => x.GuideName == "Yemlihan" && x.GuideSurname == "Kurşun").Select(y=> y.GuideId).FirstOrDefault();
            lblYemlihanKursunLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameYemlihanKursun).Count().ToString();




        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
