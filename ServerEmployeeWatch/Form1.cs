using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net.Http;
using System.Security.Policy;

namespace ServerEmployeeWatch
{
	public partial class MainForm : Form
	{
		private Dictionary<string, Client> clients = new Dictionary<string, Client>();
		private HttpListener listener;
		public MainForm()
		{
			InitializeComponent();
			StartHttpServer();
		}

		private void StartHttpServer()
		{
			listener = new HttpListener();
			listener.Prefixes.Add("http://+:1212/");
			listener.Start();

			Task.Run(() => ListenLoop());
		}

		private async Task ListenLoop()
		{
			while (listener.IsListening)
			{
				var context = await listener.GetContextAsync();
				string url = context.Request.Url.AbsolutePath.ToLower();

				if (url == "/report")
					HandleReport(context);
				else if (url == "/screenshot")
					HandleScreenshot(context);
				else
					context.Response.StatusCode = 404;

				context.Response.Close();
			}
		}

		private void HandleReport(HttpListenerContext context)
		{
			using (StreamReader reader = new StreamReader(context.Request.InputStream))
			{
				string data = reader.ReadToEnd();
				var info = ParseClientInfo(data);

				// Обновление UI
				Invoke(new Action(() =>
				{
					if (!clients.ContainsKey(info.Mac))
					{
						clients[info.Mac] = info;
						listBoxClients.Items.Add(info.Mac); // ключ = MAC
					}
					else
					{
						clients[info.Mac].Update(info);
					}

					context.Response.StatusCode = 200;
				}));
			}
		}

		private void HandleScreenshot(HttpListenerContext context)
		{
			string mac = context.Request.QueryString["mac"].ToLower();
			using (MemoryStream ms = new MemoryStream())
			{
				context.Request.InputStream.CopyTo(ms);
				clients[mac].ScreenshotBytes = ms.ToArray();

				Invoke(new Action(() =>
				{
					if (listBoxClients.SelectedItem?.ToString() == mac)
						pictureBoxScreen.Image = Image.FromStream(new MemoryStream(clients[mac].ScreenshotBytes));

					context.Response.StatusCode = 200;
				}));
			}
		}

		private Client ParseClientInfo(string raw)
		{
			var info = new Client();
			foreach (var part in raw.Split(';'))
			{
				var kv = part.Split('=');
				if (kv.Length != 2) continue;
				switch (kv[0].ToLower())
				{
					case "user": info.Username = kv[1]; break;
					case "pc": info.ComputerName = kv[1]; break;
					case "mac": info.Mac = kv[1]; break;
					case "time": info.LastSeen = kv[1]; break;
					case "ip": info.IP = kv[1]; break;
				}
			}
			return info;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private async void buttonSendScreen_Click(object sender, EventArgs e)
		{
			if (listBoxClients.SelectedItem == null)
			{
				MessageBox.Show("Выберите клиента из списка.");
				return;
			}

			string mac = listBoxClients.SelectedItem.ToString();

			if (!clients.TryGetValue(mac, out Client info))
			{
				MessageBox.Show("Клиент не найден.");
				return;
			}

			string clientIp = info.IP; // должен быть установлен ранее в HandleReport
			string url = $"http://{clientIp}:9090/capture";
			using (var client = new HttpClient())
			{
				client.Timeout = TimeSpan.FromSeconds(30);

				try
				{
					HttpResponseMessage response = await client.GetAsync(url);

					if (response.IsSuccessStatusCode)
					{
						MessageBox.Show("Запрос на скриншот отправлен.");
					}
					else
					{
						MessageBox.Show($"Ошибка: {response.StatusCode}");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка при отправке запроса: {ex.Message}");
				}
			}
		}


		private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
		{
			string mac = listBoxClients.SelectedItem.ToString();
			var client = clients[mac];

			labelInfo.Text = $"User: {client.Username}\nPC: {client.ComputerName}\nTime: {client.LastSeen}";

			if (client.ScreenshotBytes != null)
			{
				pictureBoxScreen.Image = Image.FromStream(new MemoryStream(client.ScreenshotBytes));
			}
		}
	}
}
