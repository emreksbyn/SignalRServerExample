using Microsoft.AspNetCore.SignalR.Client;

namespace DesktopClient
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        public Form1()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/messagehub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }


        private async void btnConnection_Click(object sender, EventArgs e)
        {
            connection.On<string>("receiveMessage", (messages) =>
            {
                this.Invoke((Action)(() =>
                {
                    var _messages = $"{richtxtMessages}";
                    messages = _messages;
                }));
            });

            try
            {
                await connection.StartAsync();
                btnConnection.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessageAsync",txtMessage.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}