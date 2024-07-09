using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keisanki
{
    static class CalcEq
    {
        /// <summary>
        /// 変化率の計算
        /// </summary>
        /// <param name="nbefore">前</param>
        /// <param name="nafter">後</param>
        /// <returns>変化率</returns>
        public static double calcHenka(double nbefore, double nafter)
        {
            double Ratio;
            Ratio = (nafter - nbefore) / nbefore * 100;
            return Ratio;
        }

        /// <summary>
        /// 変化後の計算
        /// </summary>
        /// <param name="noriginal">基準</param>
        /// <param name="nratio">割合</param>
        /// <returns>変化後</returns>
        public static double calcHenkago(double noriginal, double nratio)
        {
            double Nchange;
            Nchange = (1+nratio/100)*noriginal;
            return Nchange;
        }

        /// <summary>
        /// 割合計算
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double calcRatio(double v1, double v2)
        {
            double R;
            R = v2 / v1 * 100;
            return R;
        }


        public static double calcWariai(double W1, double W2)
        {
            double W;
            W = W1 * W2 / 100;
            return W;
        }

        /// <summary>
        /// 波長計算
        /// </summary>
        /// <param name="WLin"></param>
        /// <returns></returns>
        public static double calcWL(double WLin)
        {
            double WLout;
            WLout= 1.239841984332003e3 / WLin;
            return WLout;
        }

        /// <summary>
        /// 周波数・周期を計算
        /// </summary>
        /// <param name="nin">f or T</param>
        /// <returns>T or f</returns>
        public static double calcFreT(double nin)
        {
            double nout;
            nout = 1 / nin;
            return nout;
        }

        /// <summary>
        /// Brillouin振動数
        /// </summary>
        /// <param name="v">v</param>
        /// <param name="n">n</param>
        /// <param name="lambda">lambda</param>
        /// <returns></returns>
        public static double calcBO(double v, double n, double lambda)
        {
            double fBO;
            fBO = 2*n*v/lambda;
            return fBO;
        }

        /// <summary>
        /// 音速計算
        /// </summary>
        /// <param name="C"></param>
        /// <param name="rho"></param>
        /// <returns></returns>
        public static double calcv(double C, double rho)
        {
            double v;
            v = (C * 1e9 / rho);
            v = Math.Pow(v, 0.5);
            return v;
        }


        /// <summary>
        /// 弾性定数計算
        /// </summary>
        /// <param name="v"></param>
        /// <param name="rho"></param>
        /// <returns></returns>
        public static double calcC(double v, double rho)
        {
            double C;
            C = rho*v*v*1e-9;
            return C;
        }

        /// <summary>
        ///  kayser to nm
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double calccm2nm(double k)
        {
            double lambda;
            lambda = (1 / k) * 1e7;
            return lambda;
        }

        /// <summary>
        ///  nm to kayser
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double calcnm2cm(double lambda)
        {
            double k;
            k = (1 / lambda) * 1e7;
            return k;
        }

        /// <summary>
        ///  Ramanシフト(1/cm)
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double calcRaman(double l1,double l2)
        {
            double Raman;
            Raman = (1/l1 - 1/l2) * 1e7;
            return Raman;
        }

    }

}
