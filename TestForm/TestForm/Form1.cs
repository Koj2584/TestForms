using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Color barvaPozadi = Color.White;
        Font font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
        
        bool poprve = true;
        Form ukoncit = null;
        Form novaHra = null;
        Form nastaveni = null;
        Form uloz = null;
        Form nacteniHry = null;
        private void button4_Click(object sender, EventArgs e)
        {
            ukoncit = new Form();
            ukoncit.AutoScaleDimensions = new SizeF(9F, 20F);
            ukoncit.AutoScaleMode = AutoScaleMode.Font;
            ukoncit.ClientSize = new Size(479, 202);
            ukoncit.StartPosition = FormStartPosition.CenterScreen;

            Label napis = new Label();
            napis.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            napis.Location = new Point(12, 9);
            napis.Size = new Size(455, 128);
            napis.TabIndex = 0;
            napis.Text = "Opravdu chcete ukončit hru?";
            napis.TextAlign = ContentAlignment.MiddleCenter;
            ukoncit.Controls.Add(napis);

            Button btn = new Button();
            btn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            btn.Location = new Point(353, 140);
            btn.Size = new Size(114, 50);
            btn.TabIndex = 1;
            btn.Text = "Ok";
            btn.DialogResult = DialogResult.OK;
            btn.UseVisualStyleBackColor = true;
            poprve = true;
            btn.MouseEnter += Btn_MouseEnter;
            ukoncit.Controls.Add(btn);

            Button btn2 = new Button();
            btn2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            btn2.Location = new Point(16, 140);
            btn2.Size = new Size(114, 50);
            btn2.TabIndex = 2;
            btn2.Text = "Zrušit";
            btn2.DialogResult = DialogResult.Cancel;
            btn2.UseVisualStyleBackColor = true;
            ukoncit.Controls.Add(btn2);
            UpdateForms();
            if (ukoncit.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            if (poprve)
            {
                poprve = false;
                Point p = ((Button)sender).Location;
                ((Button)sender).Location = new Point(p.X - ((Button)sender).Width, p.Y);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            novaHra = new Form();
            novaHra.AutoScaleDimensions = new SizeF(9F, 20F);
            novaHra.AutoScaleMode = AutoScaleMode.Font;
            novaHra.ClientSize = new Size(471, 166);
            novaHra.StartPosition = FormStartPosition.CenterScreen;
            novaHra.Text = "Nová hra";

            Label text = new Label();
            text.AutoSize = true;
            text.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            text.Location = new Point(46, 62);
            text.Size = new Size(113, 22);
            text.TabIndex = 0;
            text.Text = "Zadej jméno:";
            novaHra.Controls.Add(text);

            TextBox jmeno = new TextBox();
            jmeno.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            jmeno.Location = new Point(165, 58);
            jmeno.Size = new Size(197, 30);
            jmeno.TabIndex = 1;
            novaHra.Controls.Add(jmeno);

            Button btn = new Button();
            btn.Location = new Point(371, 122);
            btn.Size = new Size(88, 32);
            btn.TabIndex = 2;
            btn.Text = "Založit";
            btn.UseVisualStyleBackColor = true;
            btn.Click += Btn_Click;
            btn.DialogResult = DialogResult.OK;
            novaHra.Controls.Add(btn);

            UpdateForms();
            novaHra.ShowDialog();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            uloz = new Form(); 
            UpdateForms();
            uloz.Show();
            string jmeno = "";
            foreach(Control c in novaHra.Controls)
            {
                if(c.GetType() == typeof(TextBox))
                {
                    jmeno = ((TextBox)c).Text;
                }
            }

            StreamWriter sw = new StreamWriter("hra.txt",true);
            sw.WriteLine(jmeno);
            sw.WriteLine(DateTime.Now);
            sw.Close();
            uloz.Close();
            MessageBox.Show("Vaše jméno bylo zaznamenáno");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            nastaveni = new Form();
            nastaveni.AutoScaleDimensions = new SizeF(9F, 20F);
            nastaveni.AutoScaleMode = AutoScaleMode.Font;
            nastaveni.ClientSize = new Size(471, 166);
            nastaveni.StartPosition = FormStartPosition.CenterScreen;
            nastaveni.Text = "Nastavení";

            Button btn = new Button();
            btn.Location = new Point(316, 122);
            btn.Size = new Size(143, 32);
            btn.TabIndex = 2;
            btn.Text = "Uložit nastavení";
            btn.UseVisualStyleBackColor = true;
            btn.Click += Btn_Click1;
            nastaveni.Controls.Add(btn);

            Button btn2 = new Button();
            btn2.Location = new Point(12, 122);
            btn2.Size = new Size(143, 32);
            btn2.TabIndex = 2;
            btn2.Text = "Zpět do menu";
            btn2.UseVisualStyleBackColor = true;
            nastaveni.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Location = new Point(26, 42);
            btn3.Size = new Size(112, 34);
            btn3.TabIndex = 2;
            btn3.Text = "Barva pozadí";
            btn3.Click += Btn3_Click;
            btn3.UseVisualStyleBackColor = true;
            nastaveni.Controls.Add(btn3);

            Button btn4 = new Button();
            btn4.Location = new Point(176, 42);
            btn4.Size = new Size(112, 34);
            btn4.TabIndex = 2;
            btn4.Text = "Font";
            btn4.Click += Btn4_Click;
            btn4.UseVisualStyleBackColor = true;
            nastaveni.Controls.Add(btn4);

            CheckBox chk = new CheckBox();
            chk.AutoSize = true;
            chk.Location = new Point(328, 48);
            chk.Size = new Size(108, 24);
            chk.TabIndex = 4;
            chk.Text = "Fullscreen";
            chk.CheckedChanged += Chk_CheckedChanged;
            chk.UseVisualStyleBackColor = true;
            nastaveni.Controls.Add(chk);
            UpdateForms();
            nastaveni.Show();
        }
        bool fullscreen = false;
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            fullscreen = ((CheckBox)sender).Checked;
        }

        private void Btn_Click1(object sender, EventArgs e)
        {
            UpdateForms();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                font = fd.Font;
            }

        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                barvaPozadi = cd.Color;
            }
        }

        void UpdateForms()
        {
            if (ukoncit != null)
            {
                ukoncit.BackColor = barvaPozadi;
                ukoncit.Font = font;
                if (fullscreen)
                    ukoncit.WindowState = FormWindowState.Maximized;
            }
            if (novaHra != null)
            { 
                novaHra.BackColor = barvaPozadi;
                novaHra.Font = font;
                if (fullscreen)
                    novaHra.WindowState = FormWindowState.Maximized;
            }
            if (nastaveni != null)
            {
                nastaveni.BackColor = barvaPozadi;
                nastaveni.Font = font;
                if (fullscreen)
                    nastaveni.WindowState = FormWindowState.Maximized;
            }
            if (uloz != null)
            {
                uloz.BackColor = barvaPozadi;
                uloz.Font = font;
                if (fullscreen)
                    uloz.WindowState = FormWindowState.Maximized;
            }
            if (nacteniHry != null)
            {
                nacteniHry.BackColor = barvaPozadi;
                nacteniHry.Font = font;
                if (fullscreen)
                    nacteniHry.WindowState = FormWindowState.Maximized;
            }
            this.BackColor = barvaPozadi;
            this.Font = font;
            if (fullscreen)
                this.WindowState = FormWindowState.Maximized;
        }
        List<Form> list = new List<Form>();
        private void button2_Click(object sender, EventArgs e)
        {
            nacteniHry = new Form();
            nacteniHry.AutoScaleDimensions = new SizeF(9F, 20F);
            nacteniHry.AutoScaleMode = AutoScaleMode.Font;
            nacteniHry.ClientSize = new Size(471, 166);
            nacteniHry.StartPosition = FormStartPosition.CenterScreen;
            nacteniHry.Text = "Načíst hru";

            Button btn = new Button();
            btn.Location = new Point(190, 120);
            btn.Size = new Size(90, 34);
            btn.TabIndex = 0;
            btn.Text = "Vybrat";
            btn.Click += Btn_Click2;
            btn.UseVisualStyleBackColor = true;
            nacteniHry.Controls.Add(btn);

            Label lbl = new Label();
            lbl.Location = new Point(12, 13);
            lbl.Size = new Size(447, 80);
            lbl.TabIndex = 1;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            nacteniHry.Controls.Add(lbl);

            
            StreamReader sr = new StreamReader("hra.txt");
            while (!sr.EndOfStream)
            {
                string jmeno = sr.ReadLine();
                string datum = sr.ReadLine();

                lbl.Text = "Jmeno: "+jmeno+"\nDatum: "+datum;
                list.Add(nacteniHry);
            }
            sr.Close();
            foreach (Form form in list)
            {
                form.Show();
            }
        }

        private void Btn_Click2(object sender, EventArgs e)
        {
            foreach (Form form in list)
            {
                form.Close();
            }
        }
    }
}
