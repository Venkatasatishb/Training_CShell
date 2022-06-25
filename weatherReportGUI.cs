// Weather Report GUI

using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
          

class WeatherReportGUI
{
    static void Main(string[] args)
    {
        // PrepareGUI p = new PrepareGUI();
        Application.Run(new PrepareGUI());
    }
}

class PrepareGUI : Form
{
    Label temperatureLabel;
    TextBox cityNameTextBox;
    public PrepareGUI()
    {
        // this.Name = "WeatherReportGUI";
        // this.Text = "WeatherReportGUI";
        this.Size = new Size(400, 250);
        // this.StartPosition = FormStartPosition.CenterScreen;

        Label cityNameLabel = new Label();
        cityNameLabel.Text = "Enter City Name: ";
        cityNameLabel.Size = new Size(100, 30);
        cityNameLabel.Location = new Point(30,30);

        cityNameTextBox = new TextBox();
        cityNameTextBox.Size = new Size(200,30);
        cityNameTextBox.Location = new Point(130,30);

        Button checkTemperatureButton = new Button();
        checkTemperatureButton.Text = "Check temperture";
        checkTemperatureButton.Size = new Size(150, 30);
        checkTemperatureButton.Location = new Point((this.Width - 150)/2,90);
        checkTemperatureButton.Click += new System.EventHandler(this.MyButtonClick);

        temperatureLabel = new Label();
        temperatureLabel.Text = "";
        temperatureLabel.Size = new Size(350, 40);
        temperatureLabel.Location = new Point(35,150);



        this.Controls.Add(checkTemperatureButton);
        this.Controls.Add(cityNameLabel);
        this.Controls.Add(cityNameTextBox);
        this.Controls.Add(temperatureLabel);
    }
    private void MyButtonClick(object source, EventArgs e) 
    {
        string cityName = cityNameTextBox.Text;

        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&units=metric&appid=201ac1b1456985494f5e9f7c1c258d45"));
        HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

        StreamReader reader = new StreamReader(WebResp.GetResponseStream());
        string jsonString = reader.ReadToEnd();
        JObject json = JObject.Parse(jsonString);
        JObject main = JObject.Parse(json["main"].ToString());
        temperatureLabel.Text = "The temperature in " + cityName + " is " + main["temp"].ToString() + " degrees celsius.";
        cityNameTextBox.Text = "";
    }
}


