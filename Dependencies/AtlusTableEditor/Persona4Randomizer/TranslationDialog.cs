using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlusRandomizer
{
    public partial class TranslationDialog : Form
    {
        public ResultValue Result { get; set; }

        public TranslationDialog()
        {
            InitializeComponent();
            lbl_TranslateHelp.Text = "Runs MSG.TBL text through\nGoogle Translate several times.\nThere is a limit to how many\ntranslations allowed per IP.";
        }

        public class ResultValue
        {
            public TranslationDialog mParent;

            public ResultValue(TranslationDialog parent)
            {
                mParent = parent;
            }

            public List<Tuple<string, string>> sTranslationLanguages => new List<Tuple<string, string>> {
            new Tuple<string, string>(mParent.textBox_Translate1.Text, mParent.textBox_Translate2.Text),
            new Tuple<string, string>(mParent.textBox_Translate3.Text, mParent.textBox_Translate4.Text)
            };
        }

        private void btn_Translate_Click(object sender, EventArgs e)
        {
            Result = new ResultValue(this);
        }
    }
}
