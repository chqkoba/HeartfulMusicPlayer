using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Wave;

using Microsoft.Win32;


namespace HeartfulMusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /*public void testshokika_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog File0;
        }*/
        //ファイルのクラス型変数の宣言と初期化
        private OpenFileDialog File0 = new OpenFileDialog();
        public void buttonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (File0.ShowDialog() == true)
            {
                var outputDevice = new WasapiOut();
                var audioFile = new AudioFileReader(File0.FileName);

                outputDevice.Init(audioFile);
                MessageBox.Show("Loaded.");
            }
            else
            {
                MessageBox.Show("Not Loaded.");

            }
        }
        private void buttonPlaySound_Click(object sender, RoutedEventArgs e)
        {
            playSoundTestWASAPI(File0.FileName);

            
        }
        //private OpenFileDialog openFile() { return new OpenFileDialog(); }
        private void playSoundTestWASAPI(string filename)
        {
            var outputDevice = new WasapiOut();
            var audioFile = new AudioFileReader(filename);

            outputDevice.Init(audioFile);
            outputDevice.Play();
            
        }

        
    }
}