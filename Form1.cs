using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CarGame
{

   
    public partial class Form1: Form
    {

        private Timer timer;
        private Random random;
        public Form1()
        {
            InitializeComponent();
            InitializeRace();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            winnerPanel.Visible = false;
            simpleButton1.Visible = true;
        }


        private void InitializeRace() {
            timer = new Timer();
            timer.Interval = 40;
            timer.Tick += timer1_Tick;
            random = new Random();

            taxi.Image = Properties.Resources.stableTaxi;
            Ambulance.Image = Properties.Resources.stableAmbulance;
            sportCar.Image = Properties.Resources.stableSportCar;
            truck.Image = Properties.Resources.stableTruck;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int t_speed = int.Parse(taxiSpeed.Text);
            int a_speed = int.Parse(ambulanceSpeed.Text);
            int tr_speed = int.Parse(truckspeed.Text);
            int s_speed = int.Parse(sportCarSpeed.Text);


            taxi.Left += random.Next(5, t_speed);
            Ambulance.Left += random.Next(5, a_speed);
            truck.Left += random.Next(5, tr_speed);
            sportCar.Left += random.Next(5, s_speed);

            int finishLine = this.ClientSize.Width - taxi.Width - 10;


            if (taxi.Left > finishLine) {
               
                StopGif();
                timer.Stop();
                pictureBox5.Image = Properties.Resources.stableTaxi;
                winner.Text = "Taxi Won the Race!";
                winnerAndButton();

            }
            if (Ambulance.Left > finishLine)
            {
              
                StopGif();
                timer.Stop();
                pictureBox5.Image = Properties.Resources.stableAmbulance;
                winner.Text = "Ambulance Won the Race!";
                winnerAndButton();

            }
            if (truck.Left > finishLine)
            {
               
                StopGif();
                timer.Stop();
                pictureBox5.Image = Properties.Resources.stableTruck;
                winner.Text = "Truck Won the Race!";
                winnerAndButton();

            }
            if (sportCar.Left > finishLine)
            {
               
                StopGif();
                timer.Stop();
                pictureBox5.Image = Properties.Resources.stableSportCar;
                winner.Text = "Sport Car Won the Race!";
                winnerAndButton();
            }

            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            taxi.Image = Properties.Resources.taxi;
            truck.Image = Properties.Resources.tr;
            Ambulance.Image = Properties.Resources.ambulance;
            sportCar.Image = Properties.Resources.sportCar;


            taxi.Left = 10;
            sportCar.Left = 10;
            Ambulance.Left = 10;
            truck.Left = 10;

            timer.Start();
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        public void StopGif() {

                taxi.Image = Properties.Resources.stableTaxi;
                Ambulance.Image = Properties.Resources.stableAmbulance;
               sportCar.Image = Properties.Resources.stableSportCar;
                truck.Image = Properties.Resources.stableTruck;
            
        }

        public void winnerAndButton() {
            simpleButton1.Visible = false;
            winnerPanel.Visible = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            adjustPanel.Visible = false;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
