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
using net.zemberek.yapi;
using net.zemberek.yapi.kok;

namespace net.zemberek.tr.yapi.kok
{
    public class YumusamaNk : HarfDizisiIslemi
    {
        
    private HarfDizisi NK;
    private Alfabe alfabe;


    public YumusamaNk(Alfabe alfabe) {
        this.alfabe = alfabe;
        NK = new HarfDizisi("nk", alfabe);
    }

    public void uygula(HarfDizisi dizi) {
        if (dizi.aradanKiyasla(dizi.Length - 2, NK))
            dizi.harfDegistir(dizi.Length - 1, alfabe.harf('g'));
    }
    }
}
