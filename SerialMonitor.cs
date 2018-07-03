using Newtonsoft.Json;
using SerialReader.Class.Configuration;
using SerialReader.Class.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialReader
{
    public partial class SerialMonitor : Form
    {
        static HttpClient client = new HttpClient();

        public SerialMonitor()
        {
            client.BaseAddress = new Uri("http://localhost:50272");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
            DefaultSerialPort.serialPort.Open();
            DefaultSerialPort.serialPort.DataReceived += DataRecievedHandler;
        }

        private async void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
       {

            string json = DefaultSerialPort.serialPort.ReadLine();

            richTextBox1.Invoke(new Action(() => richTextBox1.Text = richTextBox1.Text + json));

            //API Passing parameters here
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await CreateLog("Api/Logger/Log", json);

 
        }

        static async Task<string> GetLogs(string path)
        {
            string product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }
            return product;
        }
        static async Task<Uri> CreateLog(string path, string json)
        {
            var model = JsonConvert.DeserializeObject<Logs>(json);
            model.datetime = LogFunction.ConvertToUnixTime();

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(
                path, content);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public class Logs {
            public string deviceID { get; set; }
            public string values { get; set; }
            public int datetime { get; set; }
        }




    }
}
