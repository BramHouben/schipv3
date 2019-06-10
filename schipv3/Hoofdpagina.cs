using schipv3.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schipv3
{
    public partial class Hoofdpagina : Form
    {
        private Schip schip = new Schip();
        public Hoofdpagina()
        {
            InitializeComponent();
            BtnToevoegenContainer.Enabled = false;
        }

        private void BtnSchip_Click(object sender, EventArgs e)
        {
            int lengte = (int)NudLengte.Value;
            int breedte = (int)NudBreedte.Value;
            schip = new Schip(lengte, breedte);
            // dan kan de gebruiker niet weer een schip ondertussen toevoegen
            BtnSchip.Enabled = false;
            BtnToevoegenContainer.Enabled = true;
            schip.MaakRijen();
        }

        private void BtnToevoegenContainer_Click(object sender, EventArgs e)
        {
            string Soort = LbSoort.Text;
            int Gewicht = (int)NUDcontainer.Value;
            Classes.Container container = new Classes.Container(Soort, Gewicht);
            schip.ToevoegenContainer(container);
            LbContainers.Text = container.ToString();
        }
        public void Indelen()
        {
            schip.SoorterenLijstenOpGewicht();
            schip.PlaatsenGekoeld();
            schip.PlaatsenNormaal();
            schip.PlaatsenWaardevol();
            schip.PlaatsenMidden();
        }
        private void BtnIndelen_Click(object sender, EventArgs e)
        {
            Indelen();
            LbContainers.DataSource = schip.Rijen;
        }

        private void BtnWegvaren_Click(object sender, EventArgs e)
        {
            if (schip.OverMinimaalGewicht() == true)
            {
                MessageBox.Show("Je mag wegvaren");
            }
            else
            {
                MessageBox.Show("Het schip is met de huidige lading niet zwaar genoeg!");
            }
        }

        private void LbContainers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Rij test = LbContainers.SelectedItem as Rij;

            foreach (var item in test.Stapel)
            {
                listBox1.Items.Add(item).ToString();
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Stapel test2 = listBox1.SelectedItem as Stapel;
            foreach (Classes.Container item in test2.Containers)
            {
                listBox2.Items.Add(item).ToString();
            }
        }

        private void Btnmaakveelcontainers_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Aantalcontainers.Value; i++)
            {
                Classes.Container container = new Classes.Container("Normaal", 30000);
                schip.ToevoegenContainer(container);
            }
       
        }
    }
}
