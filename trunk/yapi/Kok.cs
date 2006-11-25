using System;
using net.zemberek.yapi.ek;
using net.zemberek.yapi.kok;

namespace net.zemberek.yapi
{
	public class Kok
	{
		virtual public KelimeTipi Tip
		{
			set
			{
				this.tip_Renamed_Field = value;
			}
			
		}
		virtual public System.String Icerik
		{
			set
			{
				this.icerik_Renamed_Field = value;
			}
			
		}
		virtual public int Indeks
		{
			get
			{
				return indeks;
			}
			
			set
			{
				this.indeks = value;
			}
			
		}
		virtual public int Frekans
		{
			get
			{
				return frekans;
			}
			
			set
			{
				this.frekans = value;
			}
			
		}
		virtual public System.String Asil
		{
			set
			{
				this.asil_Renamed_Field = value;
			}
			
		}
		virtual public char KisaltmaSonSeslisi
		{
			get
			{
				return kisaltmaSonSeslisi;
			}
			
			set
			{
				this.kisaltmaSonSeslisi = value;
			}
			
		}
		
		private static readonly KokOzelDurumu[] BOS_OZEL_DURUM_DIZISI = new KokOzelDurumu[0];
		
		private int indeks;
		// Eger bir kok icinde alfabe disi karakter barindiriyorsa (nokta, tire gibi) orjinal hali bu
		// String icinde yer alir. Aksi halde null.
		private System.String asil_Renamed_Field;
		// bazi kisaltmalara ek eklenebilmesi icin kisaltmanin asil halinin son seslisine ihtiyac duyulur.
		private char kisaltmaSonSeslisi;
		// Kok'un ozel karakterlerden tmeizlenmis hali. Genel olarak kok icerigi olarak bu String kullanilir.
		private System.String icerik_Renamed_Field;
		private KelimeTipi tip_Renamed_Field;
		//performans ve kaynak tuketimini nedeniyle icin ozel durumlari Set yerine diziye koyduk.
		private KokOzelDurumu[] ozelDurumlar = BOS_OZEL_DURUM_DIZISI;
		
		private int frekans;
		
		public virtual bool ozelDurumVarmi()
		{
			return ozelDurumlar.Length > 0;
		}
		
		public virtual KokOzelDurumu[] ozelDurumDizisi()
		{
			return ozelDurumlar;
		}
		
		public virtual bool ozelDurumIceriyormu(KokOzelDurumTipi tip)
		{
			//UPGRADE_ISSUE: The following fragment of code could not be parsed and was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1156'"
			foreach(KokOzelDurumu oz in ozelDurumlar)
			{
				if (oz.indeks() == tip.indeks())
					return true;
			}
			return false;
		}
		
		/// <summary> koke ozel durum ekler. burada dizi kullaniminda kaynak konusunda cimrilik ettigimizden
		/// her yeni ozel durum icin dizi boyutunu bir buyuttuk. ayrica tekrar olmamasini da sagliyoruz.
		/// Normalde bu islem Set icin cok daha kolay bir yapida olabilirdi set.add() ancak Set'in kaynak tuketimi
		/// diziden daha fazla.
		/// 
		/// </summary>
		/// <param name="ozelDurum">
		/// </param>
		public virtual void  ozelDurumEkle(KokOzelDurumu ozelDurum)
		{
			if (ozelDurumlar.Length == 0)
			{
				ozelDurumlar = new KokOzelDurumu[1];
				ozelDurumlar[0] = ozelDurum;
			}
			else
			{
				if (ozelDurumIceriyormu(ozelDurum.tip()))
					return ;
				KokOzelDurumu[] yeni = new KokOzelDurumu[ozelDurumlar.Length + 1];
				for (int i = 0; i < ozelDurumlar.Length; i++)
				{
					yeni[i] = ozelDurumlar[i];
				}
				yeni[ozelDurumlar.Length] = ozelDurum;
				this.ozelDurumlar = yeni;
			}
		}
		
		/// <summary> sadece ilk acilista kullanilan bir metod
		/// 
		/// </summary>
		/// <param name="tip">
		/// </param>
		public virtual void  ozelDurumCikar(KokOzelDurumTipi tip)
		{
			if (!ozelDurumIceriyormu(tip))
				return ;
			KokOzelDurumu[] yeni = new KokOzelDurumu[ozelDurumlar.Length - 1];
			int j = 0;
			foreach(KokOzelDurumu oz in ozelDurumlar)
			{
				if (!oz.tip().Equals(tip))
					yeni[j++] = oz;
			}
			this.ozelDurumlar = yeni;
		}
		
		public Kok(System.String icerik)
		{
			this.icerik_Renamed_Field = icerik;
		}
		
		public Kok(System.String icerik, KelimeTipi tip)
		{
			this.icerik_Renamed_Field = icerik;
			this.tip_Renamed_Field = tip;
		}
		
		public override System.String ToString()
		{
			System.String strOzel = "";
			foreach(KokOzelDurumu ozelDurum in ozelDurumlar)
			{
				if (ozelDurum != null)
					strOzel += (ozelDurum.kisaAd() + " ");
			}
			return icerik_Renamed_Field + " " + tip_Renamed_Field + " " + strOzel;
		}
		
		public virtual HarfDizisi ozelDurumUygula(Alfabe alfabe, Ek ek)
		{
			HarfDizisi dizi = new HarfDizisi(this.icerik_Renamed_Field, alfabe);
			foreach(KokOzelDurumu ozelDurum in ozelDurumlar)
			{
				if (ozelDurum.yapiBozucumu() && ozelDurum.olusabilirMi(ek))
					ozelDurum.uygula(dizi);
				if (!ozelDurum.olusabilirMi(ek) && ozelDurum.ekKisitlayiciMi())
					return null;
			}
			return dizi;
		}
		
		public virtual bool yapiBozucuOzelDurumVarmi()
		{
			if (ozelDurumlar.Length == 0)
				return false;
			foreach(KokOzelDurumu ozelDurum in ozelDurumlar)
			{
				if (ozelDurum.yapiBozucumu())
					return true;
			}
			return false;
		}
		
		public KelimeTipi tip()
		{
			return tip_Renamed_Field;
		}
		
		public System.String icerik()
		{
			return icerik_Renamed_Field;
		}
		
		public  override bool Equals(System.Object o)
		{
			if (this == o)
				return true;
			if (o == null || GetType() != o.GetType())
				return false;
			
			Kok kok = (Kok) o;
			
			if (icerik_Renamed_Field != null?!icerik_Renamed_Field.Equals(kok.icerik_Renamed_Field):kok.icerik_Renamed_Field != null)
				return false;
			if (ozelDurumlar != null?!ozelDurumlar.Equals(kok.ozelDurumlar):kok.ozelDurumlar != null)
				return false;
			if (tip_Renamed_Field != null?!tip_Renamed_Field.Equals(kok.tip_Renamed_Field):kok.tip_Renamed_Field != null)
				return false;
			
			return true;
		}
		
		public override int GetHashCode()
		{
			int result;
			result = (icerik_Renamed_Field != null?icerik_Renamed_Field.GetHashCode():0);
			result = 29 * result + (tip_Renamed_Field != null?tip_Renamed_Field.GetHashCode():0);
			result = 29 * result + (ozelDurumlar != null?ozelDurumlar.GetHashCode():0);
			return result;
		}
		
		public virtual System.String asil()
		{
			return asil_Renamed_Field;
		}
	}
}