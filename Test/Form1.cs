using mohamedothman.Compiler;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Test
{
	public partial class Form1 : Form
	{
        public string a;
		public Form1()
		{
			InitializeComponent();
		}
		string Txt = "";
		

		

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            a = File.ReadAllText(ofd.FileName);
            richTextBox1.Text = a;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            LexicalAnalyzer analyzer = new LexicalAnalyzer(a);
            const int col1 = -15;
            const int col2 = -15;
            const int col3 = -15;
            const int col4 = -15;
            const int col5 = -15;
            var tokens = analyzer.Tokenize();
            var res = $"{"Lexeme",col1}{"|",col2}{"Family",col3}{"|",col4}{"Type",col5}\r\n";
            res += $"{analyzer.GetRepeatedString("-", Math.Abs(col1 + col2 + col3 + col4 + col5))}\r\n";
            foreach (var tok in tokens)
            {
                res += $"{tok.Lexeme,col1}{"|",col2}{tok.Type?.Families?.First()?.Name ?? "Unknown",col3}{"|",col4}{tok.Type?.Name ?? "Unknown",col5}{"|",col4}\r\n -------------------------------------------------------------------------- \r\n";
            }
            richTextBox1.Text = res;
            Txt = res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllText(sfd.FileName, Txt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
