﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arduino
{
    public partial class ArduinoIHM : Form
    {
        public ArduinoIHM()
        {
            InitializeComponent();

        }

        private void tratarBotoes(object sender, EventArgs e)
        {
            Button generico = (Button)sender;

            if (generico.Text == "Ligar")
            {
                generico.Text = "Desligar";
                ArduinoBLL.ligaDispositivo(generico.Tag.ToString());
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            }
            else
            {
                generico.Text = "Ligar";
                ArduinoBLL.desligaDispositivo(generico.Tag.ToString());
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ArduinoBLL.setDisplay(0);
            textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            button1.Text = "Ligar";
            button2.Text = "Ligar";
            button3.Text = "Ligar";
            button4.Text = "Ligar";
            button5.Text = "Ligar";
            button6.Text = "Ligar";
            button7.Text = "Ligar";
            button8.Text = "Ligar";
        }

        private async void btnAlarme_Click(object sender, EventArgs e)
        {

            for (int j = 0; j < 5; j++)
            {

                for (int i = 1; i <= 8; i++)
                {
                    string buttonName = "button" + i.ToString();


                    Button button = (Button)this.Controls.Find(buttonName, true).FirstOrDefault();

                    if (button != null)
                    {

                        if (button.Text == "Desligar")
                        {
                            ArduinoBLL.desligaDispositivo(button.Tag.ToString());
                            //button.BackColor = Color.Red;
                        }
                        else if (button.Text == "Ligar")
                        {
                            ArduinoBLL.ligaDispositivo(button.Tag.ToString());
                            //button.BackColor = Color.Green;
                        }
                    }
                }


                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());




                for (int i = 1; i <= 8; i++)
                {
                    string buttonName = "button" + i.ToString();
                    Button button = (Button)this.Controls.Find(buttonName, true).FirstOrDefault();
                    if (button != null)
                    {

                        button.Text = (button.Text == "Ligar") ? "Desligar" : "Ligar";
                    }
                }


                await Task.Delay(2000);
            }
        }

        private async void btnSequencial_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 8; i++)
            {
                string buttonName = "button" + i.ToString();
                Button button = (Button)this.Controls.Find(buttonName, true).FirstOrDefault();

                if (button != null)
                {
                    
                    if (button.Text == "Ligar")
                    {
                        button.Text = "Desligar";
                        ArduinoBLL.ligaDispositivo(button.Tag.ToString());
                    }
                    else
                    {
                        button.Text = "Ligar";
                        ArduinoBLL.desligaDispositivo(button.Tag.ToString());
                    }

                    
                    textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                }

                
                await Task.Delay(2000);
            }
        }

    }

}



