using NAudio.Wave;
using System.Net.Sockets;

namespace Nhom21.AudioConnector.Client
{
    public partial class Form1 : Form
    {
        private bool _isConnected = false;
        private TcpClient _client;
        private NetworkStream _stream;
        
        // Audio components
        private WaveInEvent _waveIn;
        private WaveOutEvent _waveOut;
        private BufferedWaveProvider _waveProvider;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                // Connect
                try
                {
                    string ip = txtServerIP.Text; // Use the property .Text, not .Text()
                    _client = new TcpClient();
                    Log("Connecting to generic server...");
                    lblStatus.Text = "Connecting...";
                    lblStatus.ForeColor = Color.Yellow;
                    
                    await _client.ConnectAsync(ip, 8888);
                    
                    _stream = _client.GetStream();
                    _isConnected = true;
                    
                    // Audio Setup
                    StartAudio();

                    // Start Listening
                    _ = ReceiveAudioAsync();

                    btnConnect.Text = "DISCONNECT";
                    btnConnect.BackColor = Color.FromArgb(200, 50, 50); // Red
                    lblStatus.Text = "CONNECTED (LIVE)";
                    lblStatus.ForeColor = Color.Lime;
                    txtServerIP.Enabled = false;
                    Log("Connected successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}");
                    Log($"Error: {ex.Message}");
                    lblStatus.Text = "Connection Failed";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                // Disconnect
                Disconnect();
            }
        }

        private void StartAudio()
        {
            // RECORDING (Mic -> Server)
            _waveIn = new WaveInEvent();
            _waveIn.DeviceNumber = 0; 
            _waveIn.WaveFormat = new WaveFormat(16000, 16, 1); // 16kHz, 16-bit, Mono
            _waveIn.BufferMilliseconds = 20; // Low latency
            _waveIn.DataAvailable += WaveIn_DataAvailable;
            
            try 
            {
                _waveIn.StartRecording();
                Log("Microphone started.");
            } 
            catch (Exception ex)
            {
                Log($"Mic Error: {ex.Message}");
            }

            // PLAYBACK (Server -> Speaker)
            _waveOut = new WaveOutEvent();
            _waveProvider = new BufferedWaveProvider(new WaveFormat(16000, 16, 1));
            _waveProvider.DiscardOnBufferOverflow = true; // Prevent lag buildup
            _waveOut.Init(_waveProvider);
            _waveOut.Play();
        }

        private async void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // Calculate Volume for Visualizer
            UpdateVisualizer(e.Buffer, e.BytesRecorded);

            if (_isConnected && _stream != null)
            {
                try
                {
                    // Send audio bytes to server
                    await _stream.WriteAsync(e.Buffer, 0, e.BytesRecorded);
                }
                catch
                {
                    Disconnect();
                }
            }
        }

        private void UpdateVisualizer(byte[] buffer, int length)
        {
            if (length == 0) return;

            // Simple RMS calculation for visualization
            double sum = 0;
            for (int i = 0; i < length; i += 2)
            {
                short sample = BitConverter.ToInt16(buffer, i);
                sum += (sample * sample);
            }
            double rms = Math.Sqrt(sum / (length / 2));
            int volume = (int)(rms / 100); // Scale down
            if (volume > 100) volume = 100;

            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => pbVolume.Value = volume));
            }
            else
            {
                pbVolume.Value = volume;
            }
        }

        private async Task ReceiveAudioAsync()
        {
            byte[] buffer = new byte[8192];
            try
            {
                while (_isConnected && _client.Connected)
                {
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    // Add received bytes to playback buffer
                    _waveProvider.AddSamples(buffer, 0, bytesRead);
                }
            }
            catch
            {
                // Disconnected
            }
            finally
            {
                Disconnect();
            }
        }

        private void Disconnect()
        {
            _isConnected = false;
            
            // Clean up Audio
            _waveIn?.StopRecording();
            _waveIn?.Dispose();
            _waveIn = null;

            _waveOut?.Stop();
            _waveOut?.Dispose();
            _waveOut = null;

            // Clean up Network
            _client?.Close();
            _stream = null;

            // UI Update
            if (InvokeRequired)
            {
                Invoke(new Action(() => {
                    btnConnect.Text = "CONNECT";
                    btnConnect.BackColor = Color.FromArgb(0, 122, 204); // Blue
                    lblStatus.Text = "Disconnected";
                    lblStatus.ForeColor = Color.Gray;
                    txtServerIP.Enabled = true;
                    pbVolume.Value = 0;
                    Log("Disconnected.");
                }));
            }
            else
            {
                btnConnect.Text = "CONNECT";
                btnConnect.BackColor = Color.FromArgb(0, 122, 204);
                lblStatus.Text = "Disconnected";
                lblStatus.ForeColor = Color.Gray;
                txtServerIP.Enabled = true;
                pbVolume.Value = 0;
                Log("Disconnected.");
            }
        }

        private void Log(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => {
                    txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\n");
                    txtLog.ScrollToCaret();
                }));
            }
            else
            {
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\n");
                txtLog.ScrollToCaret();
            }
        }
    }
}
