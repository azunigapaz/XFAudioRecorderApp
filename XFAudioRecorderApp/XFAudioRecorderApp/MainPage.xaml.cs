using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.AudioRecorder;
using Xamarin.Essentials;

namespace XFAudioRecorderApp
{
    public partial class MainPage : ContentPage
    {
        private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.RequestAsync<Permissions.Microphone>();

            if (status != PermissionStatus.Granted)
                return;

            if (audioRecorderService.IsRecording)
            {
                await audioRecorderService.StopRecording();
                audioPlayer.Play(audioRecorderService.GetAudioFilePath());
            }
            else
            {
                await audioRecorderService.StartRecording();
            }
            
        }
    }
}
