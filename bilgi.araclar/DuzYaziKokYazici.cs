/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The Original Code is Zemberek Do�al Dil ��leme K�t�phanesi.
 *
 * The Initial Developer of the Original Code is
 * Ahmet A. Ak�n, Mehmet D. Ak�n.
 * Portions created by the Initial Developer are Copyright (C) 2006
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *   Mert Derman
 *   Tankut Tekeli
 * ***** END LICENSE BLOCK ***** */

/*
 * Created on 06.Nis.2004
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using net.zemberek.yapi;
using net.zemberek.yapi.kok;
using log4net;



namespace net.zemberek.bilgi.araclar
{
    /**
     * Verilen bir s�zl���n d�zyaz� olarak yaz�lmas�n� sa�lar.
     * @author MDA
     */
    public class DuzYaziKokYazici : KokYazici
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        StreamWriter writer;

        public DuzYaziKokYazici(String dosyaAdi)
        {
            Stream fos = new FileStream(dosyaAdi, FileMode.Create);
            writer = new StreamWriter(fos);
        }

        #region KokYazici Members

        public void yaz(List<Kok> kokler) 
        {
            writer.Write("#-------------------------\n");
            writer.Write("# TSPELL DUZ METIN SOZLUK \n");
            writer.Write("#-------------------------\n");
            writer.Write("#v0.1\n");
            foreach (Kok kok in kokler) 
            {
                writer.Write(getDuzMetinSozlukForm(kok));
                writer.Write(writer.NewLine);
            }
            writer.Close();
        }

        #endregion

        private String getDuzMetinSozlukForm(Kok kok)
        {

        //icerik olarak icerigin varsa asil halini yoksa normal kok icerigini al.
        String icerik = kok.icerik();
        if (kok.asil() != null)
            icerik = kok.asil();

        StringBuilder res = new StringBuilder(icerik);
        res.Append(" ");
        // Tipi ekleyelim.
        if (kok.tip() == KelimeTipi.YOK) 
        {
            logger.Warn("tipsiz kok:" + kok);
            return res.ToString();
        }

        res.Append(kok.tip().ToString());
        res.Append(" ");
        res.Append(getOzellikString(kok.ozelDurumDizisi()));
        return res.ToString();
    }

        private String getOzellikString(KokOzelDurumu[] ozelDurumlar) 
        {
            String oz = "";
            foreach (KokOzelDurumu ozelDurum in ozelDurumlar) 
            {
                oz = oz + ozelDurum.kisaAd() + " ";
            }
            return oz;
        }

    }
}





