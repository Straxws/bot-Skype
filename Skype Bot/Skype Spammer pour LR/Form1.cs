using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;
using System.Threading;
using System.IO;
using AxSKYPE4COMLib;


namespace Skype_Spammer_pour_LR
{
    public partial class Form1 : Form
    {
        private static Skype skype = new Skype();
        
        public Form1()
        {
            InitializeComponent();
            ToolTip toolTip1 = new ToolTip(); // InfoBulle au passage de la souris
            toolTip1.SetToolTip(this.button1, "Permet d'envoyer un message général pour toute sa liste d'amis");
            toolTip1.SetToolTip(this.button2, "Permet de demander l'accès à votre compte Skype");
            toolTip1.SetToolTip(this.button3, "Permet d'envoyer un message à un destinataire particulier");
            toolTip1.SetToolTip(this.button4, "Information sur l'auteur");
            toolTip1.SetToolTip(this.groupBox1, "Changer son status Skype");
            
        }

        private void button2_Click(object sender, EventArgs e) // Lier le tool avec son compte Skype
        {
            skype.Attach(10, true);
            MessageBox.Show("Veuillez autorisé l'accès sur Skype");
        }

        private void button1_Click(object sender, EventArgs e) // Envoyer un message à toute sa liste d'amis
        {
            foreach (SKYPE4COMLib.User a in skype.Friends)
            {             
                skype.SendMessage(a.Handle, richTextBox1.Text);              
            }
        }

        private void button3_Click(object sender, EventArgs e) // Envoyer un message à une personne en particulier
        {
            progressBar1.Value = 0;
            skype.SendMessage(textBox1.Text, richTextBox1.Text);
            progressBar1.Value = 100;
            MessageBox.Show("Message en cours d'envoie");
        }
               
        private void checkBox1_CheckedChanged(object sender, EventArgs e) // En ligne
        {
            axSkype1.CurrentUserStatus = SKYPE4COMLib.TUserStatus.cusOnline
               ;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) // Absent
        {
            axSkype1.CurrentUserStatus = SKYPE4COMLib.TUserStatus.cusAway
                ;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) // Ne pas déranger
        {
            axSkype1.CurrentUserStatus = SKYPE4COMLib.TUserStatus.cusDoNotDisturb
                ;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) // Invisible
        {
            axSkype1.CurrentUserStatus = SKYPE4COMLib.TUserStatus.cusInvisible
                ;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) // Déconecté
        {
            axSkype1.CurrentUserStatus = SKYPE4COMLib.TUserStatus.cusOffline
                ;
        }

        private void button4_Click_1(object sender, EventArgs e) // Informations
        {
            MessageBox.Show("Bot Skype by Strawxs");
        }

        private void button5_Click(object sender, EventArgs e) // Vider l'editeur de texte
        {
            richTextBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e) // Appeller quelqu'un 
        {
            skype.PlaceCall(textBox2.Text);
        }     
        private void button7_Click_1(object sender, EventArgs e) // Modifier son humeur
        {
            skype.CurrentUserProfile.MoodText = textBox3.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }       
}
