using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apresentacao
{
    public class GerarEan13
    {
        public string Criar_EAN(string sCodigo)
        {


            string sParte = "";
            string sPais = "00";
            string sEmpresa = "";


            int[] vSequen = new int[] { 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 };
            int[] vResult = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int iDigito, iSoma, iMultiplo = 0;

            sParte = sPais + sEmpresa + sCodigo.PadLeft(10, '0');

            for (int i = 0; i < sParte.Length; i++)
            {
                vResult[i] = vSequen[i] * (Convert.ToInt16(sParte[i]) - 48);
            }

            iSoma = vResult.Sum();

            if (iSoma % 10 != 0 && iSoma > 10)
                iMultiplo = ((iSoma / 10) + 1);
            else
                if (iSoma < 10)
                    iMultiplo = 1;
                else
                    iMultiplo = iSoma / 10;

            iDigito = (iMultiplo * 10) - iSoma;

            return sParte + iDigito.ToString();
        }
    }
}
