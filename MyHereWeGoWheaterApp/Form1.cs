using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHereWeGoWheaterApp
{
    public partial class Form1 : Form
    {
        private Size _flpSize = new Size(800, 600);
        private HttpClient _httpClient = new HttpClient(); // this comment is made in the develop-branch

        private bool btest = true; // this is for testing how to merge correct between branches
        private int i = 1;


        public Form1()
        {
            InitializeComponent();
        }
        // ///////////////

        private void ClearDynamicInsertedControls()
        {
            this.Controls.Remove((Control)this._flp);
        }

        private void ShowWeatherForecast_7days(string location)
        {
            this.ClearDynamicInsertedControls();
            int x = 20;
            int y = 90;
            int num = 80;
            this.Text = "Weersvoorspelling voor 7 dagen";
            try
            {
                HttpResponseMessage result1 = this._httpClient.GetAsync("https://weather.api.here.com/weather/1.0/report.json?app_id=VjXo59SzFVv1SseP8Dxi&app_code=WUutcvuv5eTkLeaVyrd5uQ&language=nl-NL&product=forecast_7days&name=" + location).GetAwaiter().GetResult();                
                if (result1.StatusCode.ToString() == "OK")
                {
                    string result2 = result1.Content.ReadAsStringAsync().Result;

                    JArray jarray = (JArray)((JObject)((JObject)JObject.Parse(result2).GetValue("forecasts")).GetValue("forecastLocation")).GetValue("forecast");
                    this._flp = new FlowLayoutPanel();
                    this._flp.Location = new Point(x, y);
                    this._flp.Size = this._flpSize;
                    this._flp.AutoScroll = true;
                    foreach (JObject jobject in jarray)
                    {
                        DateTime dateTime = DateTime.Parse(jobject.GetValue("utcTime").ToString(), (IFormatProvider)null);
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Name = "mypicturebox";
                        pictureBox.Load(jobject.GetValue("iconLink").ToString());
                        pictureBox.Location = new Point(x, y);
                        this._flp.Controls.Add((Control)pictureBox);
                        Label label = new Label();
                        label.Name = "mylabel";
                        label.Location = new Point(x + 100, y + 5);
                        label.Size = new Size(600, 90);
                        label.Text = jobject.GetValue("weekday").ToString() + " (" + dateTime.ToString("dd-MMM-yyyy") + ") - " + jobject.GetValue("daySegment").ToString() + Environment.NewLine + "    " + jobject.GetValue("description")?.ToString() + " " + jobject.GetValue("beaufortDescription")?.ToString() + "   [ " + jobject.GetValue("temperature")?.ToString() + "°C ]" + Environment.NewLine + "    Regenkans: " + jobject.GetValue("precipitationProbability")?.ToString() + "% - GevoelsTemp: " + jobject.GetValue("comfort").ToString() + " °C";
                        this._flp.Controls.Add((Control)label);
                        y += num;
                    }
                    this.Controls.Add((Control)this._flp);
                }
                else
                    this.ShowWeatherForecast_7days_simple(location);
            }
            catch (Exception ex)
            {
                Label label = new Label();
                label.Location = new Point(x + 100, y + 5);
                label.Size = new Size(600, 400);
                label.Text = "Probleem: " + ex.ToString();
                this.Controls.Add((Control)label);
            }
        }

        private void ShowWeatherForecast_7days_simple(string location)
        {
            this.ClearDynamicInsertedControls();
            int x = 20;
            int y = 80;
            int num = 60;
            this.Text = "Weersvoorspelling 7 dagen (eenvoudig)";
            try
            {
                HttpResponseMessage result1 = this._httpClient.GetAsync("https://weather.api.here.com/weather/1.0/report.json?app_id=VjXo59SzFVv1SseP8Dxi&app_code=WUutcvuv5eTkLeaVyrd5uQ&language=nl-NL&product=forecast_7days_simple&name=" + location).GetAwaiter().GetResult();
                string result2 = result1.Content.ReadAsStringAsync().Result;
                if (result1.StatusCode.ToString() == "OK")
                {
                    JArray jarray = (JArray)((JObject)((JObject)JObject.Parse(result2).GetValue("dailyForecasts")).GetValue("forecastLocation")).GetValue("forecast");
                    this._flp = new FlowLayoutPanel();
                    this._flp.Location = new Point(x, y);
                    this._flp.Size = this._flp.Size = this._flpSize;
                    this._flp.AutoScroll = true;
                    foreach (JObject jobject in jarray)
                    {
                        DateTime dateTime = DateTime.Parse(jobject.GetValue("utcTime").ToString(), (IFormatProvider)null);
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Name = "mypicturebox";
                        pictureBox.Load(jobject.GetValue("iconLink").ToString());
                        pictureBox.Location = new Point(x, y);
                        this._flp.Controls.Add((Control)pictureBox);
                        Label label = new Label();
                        label.Name = "mylabel";
                        label.Location = new Point(x + 100, y + 5);
                        label.Size = new Size(600, 60);
                        label.Text = jobject.GetValue("weekday").ToString() + " (" + dateTime.ToString("dd-MMM-yyyy") + ")" + Environment.NewLine + "    " + jobject.GetValue("description")?.ToString() + " " + jobject.GetValue("beaufortDescription")?.ToString() + "   [ " + jobject.GetValue("lowTemperature")?.ToString() + "°C - " + jobject.GetValue("highTemperature")?.ToString() + "°C ]" + Environment.NewLine + "    Regenkans: " + jobject.GetValue("precipitationProbability")?.ToString() + "% - GevoelsTemp: " + jobject.GetValue("comfort").ToString() + " °C";
                        this._flp.Controls.Add((Control)label);
                        y += num;
                    }
                    this.Controls.Add((Control)this._flp);
                }
                else
                {
                    Label label = new Label();
                    label.Location = new Point(x + 100, y + 5);
                    label.Size = new Size(600, 400);
                    label.Text = "Probleem: " + result1.StatusCode.ToString() + Environment.NewLine + result2;
                    this.Controls.Add((Control)label);
                }
            }
            catch (Exception ex)
            {
                Label label = new Label();
                label.Location = new Point(x + 100, y + 5);
                label.Size = new Size(600, 400);
                label.Text = "Probleem: " + ex.ToString();
                this.Controls.Add((Control)label);
            }
        }

        // ///////////////

        private void Form1_Shown(object sender, EventArgs e)
        {
            btnHechtel_Click(sender, e);
        }

        // ////////////////

        private void ResetColorAllButtons()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.ForeColor = Color.DarkGray;
            }
        }

        private void btnHechtel_Click(object sender, EventArgs e)
        {
            this.ShowWeatherForecast_7days("Hechtel");
            ResetColorAllButtons();
            this.btnHechtel.ForeColor = Color.Blue;
        }
      
        private void btnAntwerpen_Click(object sender, EventArgs e)
        {
            this.ShowWeatherForecast_7days("Antwerpen");
            ResetColorAllButtons();
            this.btnAntwerpen.ForeColor = Color.Blue;
        }

        private void btnOostende_Click(object sender, EventArgs e)
        {
            this.ShowWeatherForecast_7days("Oostende");
            ResetColorAllButtons();
            this.btnOostende.ForeColor = Color.Blue;
        }

    }
}
