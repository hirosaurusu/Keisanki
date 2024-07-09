using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keisanki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 変化率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHenka_Click(object sender, EventArgs e)
        {
            double nbefore;
            double nafter;
            if(double.TryParse(txtHenkaBefore.Text, out nbefore) && double.TryParse(txtHenkaAfter.Text, out nafter))
            {
                txtHenkaRatio.Text = CalcEq.calcHenka(nbefore, nafter).ToString();
            }
            else
            {
                txtHenkaRatio.Text = "Error";
            }
        }
        /// <summary>
        /// Brillouin振動数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBO_Click(object sender, EventArgs e)
        {
            double v;
            double n;
            double lambda;
            if(double.TryParse(txtBOv.Text, out v) && double.TryParse(txtBOn.Text, out n) && double.TryParse(txtWL.Text, out lambda))
            {
                txtfBO.Text = CalcEq.calcBO(v, n, lambda).ToString();
            }
            else
            {
                txtfBO.Text = "Error";
            }
        }


        /// <summary>
        /// Enterで変化率計算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHenkaBefore_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnHenka.PerformClick();
            }
        }

        /// <summary>
        /// Enterで変化率計算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHenkaAfter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnHenka.PerformClick();
            }
        }

        /// <summary>
        /// 波長計算ev→nm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWLev_Click(object sender, EventArgs e)
        {
            double WLin;
            double coef=1;
            double WLout;
            if(double.TryParse(txtWLevIn.Text, out WLin))
            {
                if(comboBox1.SelectedIndex==0)
                {
                    coef = 1;
                }
                else if(comboBox1.SelectedIndex==1)
                {
                    coef = 10;
                }
                else if(comboBox1.SelectedIndex==2)
                {
                    coef = 0.001;
                }
                WLout = CalcEq.calcWL(WLin);
                WLout = WLout * coef;
                txtWLevOut.Text = WLout.ToString();
            }
            else
            {
                txtWLevOut.Text = "Error";
            }
        }

        /// <summary>
        /// 波長タブのコンボボックスの初期値設定(デフォルト:nm)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        /// <summary>
        /// 波長nm→eVの実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWLnm_Click(object sender, EventArgs e)
        {
            double WLin;
            double coef=1;
            double WLout;
            if(double.TryParse(txtWLnmIn.Text, out WLin))
            {
                if(comboBox2.SelectedIndex==0)
                {
                    coef = 1;
                }
                else if(comboBox2.SelectedIndex==1)
                {
                    coef = 10;
                }
                else if(comboBox2.SelectedIndex==2)
                {
                    coef = 0.001;
                }
                WLout = CalcEq.calcWL(WLin);
                WLout = WLout * coef;
                txtWLnmOut.Text = WLout.ToString();
            }
            else
            {
                txtWLnmOut.Text = "Error";
            }
        }
        /// <summary>
        /// Enterで波長nm→eVの実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWLevIn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnWLev.PerformClick();
            }
        }
        /// <summary>
        /// Enterで波長eV→nmの実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWLnmIn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnWLnm.PerformClick();
            }
        }

        /// <summary>
        /// ピーク生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeak_Click(object sender, EventArgs e)
        {
            //変換後
            StringBuilder sb = new StringBuilder();

            //改行コードごとに分割する
            string[] InputStrRow = richTextBox1.Text.Split('\n');

            for (int i=0; i < InputStrRow.Length ; i++)
            {
                if(InputStrRow[i] == "")
                {
                    break;
                }
                sb.Append(InputStrRow[i]);
                sb.Append("  ");
                sb.AppendLine(txtPeakMin.Text);

                sb.Append(InputStrRow[i]);
                sb.Append("  ");
                sb.AppendLine(txtPeakMax.Text);

                sb.Append(InputStrRow[i]);
                sb.Append("  ");
                sb.AppendLine(txtPeakMin.Text);
            }

            richTextBox2.Text = sb.ToString();

        }

        private void btnFT1_Click(object sender, EventArgs e)
        {
            double f;
            double T;
            double fcoef=1e9;
            double Tcoef=1e12;

            //fの桁数
            if (comboBox3.SelectedIndex == 0)//GHz
            {
                fcoef = 1e9;
            }
            else if (comboBox3.SelectedIndex == 1)//MHz
            {
                fcoef = 1e6;
            }
            else if (comboBox3.SelectedIndex == 2)//THz
            {
                fcoef = 1e12;
            }
            else if (comboBox3.SelectedIndex == 3)//kHz
            {
                fcoef = 1e3;
            }
            else if(comboBox3.SelectedIndex==4)//Hz
            {
                fcoef = 1;
            }
            //Tの桁数
            if (comboBox4.SelectedIndex == 0)//ps
            {
                Tcoef = 1e12;
            }
            else if (comboBox4.SelectedIndex == 1)//ns
            {
                Tcoef = 1e9;
            }
            else if (comboBox4.SelectedIndex == 2)//us
            {
                Tcoef = 1e6;
            }
            else if (comboBox4.SelectedIndex == 3)//ms
            {
                Tcoef = 1e3;
            }
            else if (comboBox4.SelectedIndex == 4)//s
            {
                Tcoef = 1;
            }

            if (double.TryParse(txtFT1.Text, out f))
            {
                //calc f to T
                f = f*fcoef;
                T = CalcEq.calcFreT(f);
                T = T * Tcoef;
                txtFT2.Text = T.ToString();
            }
        }

        private void btnFT2_Click(object sender, EventArgs e)
        {
            double f;
            double T;
            double fcoef = 1e9;
            double Tcoef = 1e12;

            //fの桁数
            if (comboBox3.SelectedIndex == 0)//GHz
            {
                fcoef = 1e-9;
            }
            else if (comboBox3.SelectedIndex == 1)//MHz
            {
                fcoef = 1e-6;
            }
            else if (comboBox3.SelectedIndex == 2)//THz
            {
                fcoef = 1e-12;
            }
            else if (comboBox3.SelectedIndex == 3)//kHz
            {
                fcoef = 1e-3;
            }
            else if (comboBox3.SelectedIndex == 4)//Hz
            {
                fcoef = 1;
            }
            //Tの桁数
            if (comboBox4.SelectedIndex == 0)//ps
            {
                Tcoef = 1e-12;
            }
            else if (comboBox4.SelectedIndex == 1)//ns
            {
                Tcoef = 1e-9;
            }
            else if (comboBox4.SelectedIndex == 2)//us
            {
                Tcoef = 1e-6;
            }
            else if (comboBox4.SelectedIndex == 3)//ms
            {
                Tcoef = 1e-3;
            }
            else if (comboBox4.SelectedIndex == 4)//s
            {
                Tcoef = 1;
            }

            if (double.TryParse(txtFT2.Text, out T))
            {
                //calc f to T
                T = T * Tcoef;
                f = CalcEq.calcFreT(T);
                f = f * fcoef;
                txtFT1.Text = f.ToString();
            }
        }

        private void txtFT1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnFT1.PerformClick();
            }
        }

        private void txtFT2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnFT2.PerformClick();
            }
        }

        private void btnHenka2_Click_1(object sender, EventArgs e)
        {
            double noriginal;
            double nratio;
            if (double.TryParse(txtHenka1.Text, out noriginal) && double.TryParse(txtHenka2.Text, out nratio))
            {
                txtHenka3.Text = CalcEq.calcHenkago(noriginal, nratio).ToString();
            }
            else
            {
                txtHenka3.Text = "Error";
            }
        }

        private void txtHenka2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnHenka2.PerformClick();
            }
        }

        private void btnv_Click(object sender, EventArgs e)
        {
            double C;
            double rho;
            if (double.TryParse(txtC.Text, out C) && double.TryParse(txtrho.Text, out rho))
            {
                txtv.Text = CalcEq.calcv(C, rho).ToString();
                if (checkBoxv.Checked == true)
                {
                    txtBOv.Text = txtv.Text;
                }
            }
            else
            {
                txtv.Text = "Error";
            }
        }

        private void txtC_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnv.PerformClick();
            }
        }

        private void txtrho_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnv.PerformClick();
            }
        }

        private void txtBOv_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnBO.PerformClick();
            }
        }

        private void txtBOn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnBO.PerformClick();
            }
        }

        private void txtWL_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnBO.PerformClick();
            }
        }

        private void txtHenka1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnHenka2.PerformClick();
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            double rho;
            double v;
            if (double.TryParse(txtv.Text, out v) && double.TryParse(txtrho.Text, out rho))
            {
                txtC.Text = CalcEq.calcC(v, rho).ToString();
                if (checkBoxv.Checked == true)
                {
                    txtBOv.Text = txtv.Text;
                }
            }
            else
            {
                txtC.Text = "Error";
            }
        }

        private void txtv_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnC.PerformClick();
            }
        }

        private void btncm2nm_Click(object sender, EventArgs e)
        {
            double k;
            if (double.TryParse(txtcm.Text, out k))
            {
                txtnm.Text = CalcEq.calccm2nm(k).ToString();
            }
            else
            {
                txtnm.Text = "Error";
            }
        }

        private void txtcm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btncm2nm.PerformClick();
            }
        }

        private void btnnm2cm_Click(object sender, EventArgs e)
        {
            double lambda;
            if(double.TryParse(txtnm.Text, out lambda))
            {
                txtcm.Text = CalcEq.calcnm2cm(lambda).ToString();
            }
            else
            {
                txtnm.Text = "Error";
            }
        }

        private void txtnm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnnm2cm.PerformClick();
            }
        }

        private void btnRaman_Click(object sender, EventArgs e)
        {
            double l1;
            double l2;
            if( double.TryParse(txtReiki.Text, out l1) && double.TryParse(txtshift.Text, out l2) )
            {
                txtRaman.Text = CalcEq.calcRaman(l1, l2).ToString();
            }
            else
            {
                txtRaman.Text = "Error";
            }
        }

        private void txtReiki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRaman.PerformClick();
            }
        }

        private void txtshift_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnRaman.PerformClick();
            }
        }

        private void btnRatio_Click(object sender, EventArgs e)
        {
            double R1, R2;
            if( double.TryParse(txtRatio1.Text, out R1) && double.TryParse(txtRatio2.Text, out R2))
            {
                txtRatio.Text = CalcEq.calcRatio(R1, R2).ToString();
            }
            else
            {
                txtRatio.Text = "Error";
            }
        }

        private void txtRatio2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRatio.PerformClick();
            }
        }

        private void txtRatio1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnRatio.PerformClick();
            }
        }

        private void btnWariai_Click(object sender, EventArgs e)
        {
            double W1, W2;
            if ( double.TryParse(txtWariai1.Text, out W1) && double.TryParse(txtWariai2.Text, out W2))
            {
                txtWariai3.Text = CalcEq.calcWariai(W1, W2).ToString();
            }
            else
            {
                txtWariai3.Text = "Error";
            }
        }

        private void txtWariai1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                btnWariai.PerformClick();
            }
        }

        private void txtWariai2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnWariai.PerformClick();
            }
        }
    }
}
