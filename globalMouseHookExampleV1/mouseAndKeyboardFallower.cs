using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace globalMouseHookExampleV1
{
    public partial class mouseAndKeyboardFallower : Form
    {
        public mouseAndKeyboardFallower()
        {
            InitializeComponent();
            //Gma.System.MouseKeyHook ile çalışıyor burası

            //manage nuget packages üzerinden eklenebiliyor
            //method oluşturmaya gerek yok
            //MouseDown, KeyDown, KeyPress, Move falan hepsi var değiştirilip kullanılabilir.

            //single click veriyor
            Hook.GlobalEvents().MouseDown += async (sender, e) =>
            {
                this.Text = ($"Mouse {e.Button} Down");
                richTextBox2.Text = richTextBox2.Text+e.Button+"\n";
            };
            //double click veriyor
            Hook.GlobalEvents().MouseDoubleClick += async (sender, e) =>
            {
                this.Text = ($"Mouse {e.Button} button double clicked.");
                richTextBox2.Text = richTextBox2.Text + e.Button + "\n";
            };
            Hook.GlobalEvents().KeyDown += async (sender, e) =>
            {
                this.Text = ($"klavyedeki {e.KeyCode} tuşuna basılıyor.");

                if (Convert.ToString(e.KeyCode) == "Return")
                {
                    richTextBox1.Text = richTextBox1.Text + "\n";
                }
                else if (Convert.ToString(e.KeyCode) == "Space")
                {
                    richTextBox1.Text = richTextBox1.Text + " ";

                }
                else
                {
                    richTextBox1.Text = richTextBox1.Text + e.KeyCode;
                }

            };
            //klavyeden basılan tuşu veriyor.
            Hook.GlobalEvents().KeyUp += async (sender, e) =>
            {
                this.Text = ($"klavyedeki {e.KeyCode} tuşuna basıldı.");
            };
        }
    }
}
