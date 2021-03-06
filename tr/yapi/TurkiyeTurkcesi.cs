﻿/* ***** BEGIN LICENSE BLOCK *****
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
 * The Original Code is Zemberek Doğal Dil İşleme Kütüphanesi.
 *
 * The Initial Developer of the Original Code is
 * Ahmet A. Akın, Mehmet D. Akın.
 * Portions created by the Initial Developer are Copyright (C) 2006
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *   Mert Derman
 *   Tankut Tekeli
 * ***** END LICENSE BLOCK ***** */

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using net.zemberek.yapi;
using net.zemberek.tr.yapi.kok;
using net.zemberek.tr.yapi.ek;
using net.zemberek.tr.islemler;
using net.zemberek.yapi.ek;

namespace net.zemberek.tr.yapi
{
    public class TurkiyeTurkcesi : DilAyarlari
    {
        public CultureInfo locale()
        {
            return new CultureInfo("tr");
        }

        public Type alfabeSinifi() 
        {
            return typeof(Alfabe);
        }

        public Type ekYoneticiSinifi() 
        {
            return typeof(TemelEkYonetici);
        }

        public Type heceBulucuSinifi() 
        {
            return typeof(TurkceHeceBulucu);
        }

        public Type kokOzelDurumBilgisiSinifi() 
        {
            return typeof(TurkceKokOzelDurumBilgisi);
        }

        public Type cozumlemeYardimcisiSinifi() 
        {
            return typeof(TurkceCozumlemeYardimcisi);
        }

        public EkUretici ekUretici(Alfabe alfabe) 
        {
            return new EkUreticiTr(alfabe);
        }

        public EkOzelDurumUretici ekOzelDurumUretici(Alfabe alfabe) 
        {
            return new TurkceEkOzelDurumUretici(alfabe);
        }

        public String[] duzYaziKokDosyalari() 
        {
            return new String[]{
                    "kaynaklar/tr/bilgi/duzyazi-kilavuz.txt",
                    "kaynaklar/tr/bilgi/kisaltmalar.txt",
                    "kaynaklar/tr/bilgi/bilisim.txt",
                    "kaynaklar/tr/bilgi/kisi-adlari.txt"};
        }

        public IDictionary<String, KelimeTipi> kokTipiAdlari() 
        {
            IDictionary<String, KelimeTipi> tipMap = new Dictionary<String,KelimeTipi>();
            tipMap.Add("IS", KelimeTipi.ISIM);
            tipMap.Add("FI", KelimeTipi.FIIL);
            tipMap.Add("SI", KelimeTipi.SIFAT);
            tipMap.Add("SA", KelimeTipi.SAYI);
            tipMap.Add("YA", KelimeTipi.YANKI);
            tipMap.Add("ZA", KelimeTipi.ZAMIR);
            tipMap.Add("SO", KelimeTipi.SORU);
            tipMap.Add("IM", KelimeTipi.IMEK);
            tipMap.Add("ZAMAN", KelimeTipi.ZAMAN);
            tipMap.Add("HATALI", KelimeTipi.HATALI);
            tipMap.Add("EDAT", KelimeTipi.EDAT);
            tipMap.Add("BAGLAC", KelimeTipi.BAGLAC);
            tipMap.Add("OZ", KelimeTipi.OZEL);
            tipMap.Add("UN", KelimeTipi.UNLEM);
            tipMap.Add("KI", KelimeTipi.KISALTMA);
            return tipMap;
        }

        public IDictionary<KelimeTipi, String> baslangiEkAdlari() 
        {
            IDictionary<KelimeTipi, String> baslangicEkAdlari = new Dictionary<KelimeTipi,String>();
            baslangicEkAdlari.Add(KelimeTipi.ISIM, TurkceEkAdlari.ISIM_KOK);
            baslangicEkAdlari.Add(KelimeTipi.SIFAT, TurkceEkAdlari.ISIM_KOK);
            baslangicEkAdlari.Add(KelimeTipi.FIIL, TurkceEkAdlari.FIIL_KOK);
            baslangicEkAdlari.Add(KelimeTipi.ZAMAN, TurkceEkAdlari.ZAMAN_KOK);
            baslangicEkAdlari.Add(KelimeTipi.ZAMIR, TurkceEkAdlari.ZAMIR_KOK);
            baslangicEkAdlari.Add(KelimeTipi.SAYI, TurkceEkAdlari.SAYI_KOK);
            baslangicEkAdlari.Add(KelimeTipi.SORU, TurkceEkAdlari.SORU_KOK);
            baslangicEkAdlari.Add(KelimeTipi.UNLEM, TurkceEkAdlari.UNLEM_KOK);
            baslangicEkAdlari.Add(KelimeTipi.EDAT, TurkceEkAdlari.EDAT_KOK);
            baslangicEkAdlari.Add(KelimeTipi.BAGLAC, TurkceEkAdlari.BAGLAC_KOK);
            baslangicEkAdlari.Add(KelimeTipi.OZEL, TurkceEkAdlari.OZEL_KOK);
            baslangicEkAdlari.Add(KelimeTipi.IMEK, TurkceEkAdlari.IMEK_KOK);
            baslangicEkAdlari.Add(KelimeTipi.YANKI, TurkceEkAdlari.YANKI_KOK);
            baslangicEkAdlari.Add(KelimeTipi.KISALTMA, TurkceEkAdlari.ISIM_KOK);
            return baslangicEkAdlari;
        }

        public String ad() 
        {
            return "TURKIYE TURKCESI";
        }
    }
}
