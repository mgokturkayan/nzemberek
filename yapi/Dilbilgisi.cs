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
using net.zemberek.yapi.ek;
using net.zemberek.yapi.kok;
using net.zemberek.islemler.cozumleme;
using net.zemberek.bilgi.kokler;

namespace net.zemberek.yapi
{
    public interface DilBilgisi
    {
        /**
 * Dile ozel alfabe nesnesini dondurur.
 * @return alfabe.
 */
        Alfabe alfabe();

        /**
         * Dile ozgu ek oynetici nesnesini dondurur.
         * @return ekyonetici
         */
        EkYonetici ekler();

        /**
         * Kok bilgilerine ve kok secicilere erisimi saglayan
         * dile ozel Sozluk nesnesini dondurur.
         * @return sozluk
         */
        Sozluk kokler();

        /**
         * Dile ozgu kok ozel durumu bilgilerini tasiyan nesneyi dondurur.
         * @return ozeldurumbilgisi
         */
        KokOzelDurumBilgisi kokOzelDurumlari();

        /**
         * eger varsa dile ozgu hece bulma nesnesi.
         * @return hecebulma nesnesi
         */
        HeceBulucu heceBulucu();

        /**
         * dile ozgu cozumleme yardimcisi nesnesi. bu nesne cozumleme sirasinda kullanilan
         * cesitli on ve art isleme, cep mekanizmalarini tasir.
         * @return cozumleme yardimcisi
         */
        CozumlemeYardimcisi cozumlemeYardimcisi();
    }
}
