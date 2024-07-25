using System.ComponentModel;

namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public class StandardizedInputProduct
    {
        /// <summary>
        /// id
        /// id produktu (mus� b�t vypln�n p�i n�sledn� editaci zbo��)
        /// </summary>
        [DisplayName("id")]
        public int Id { get; set; }


        /// <summary>
        /// zobrazit
        /// 1 - zobrazovat, 0 - nezobrazovat
        /// </summary>
        [DisplayName("zobrazit")]
        public byte Display { get; set; } = 1;


        /// <summary>
        /// archiv
        /// 1 - aktivn�, 0 - neaktivn�
        /// </summary>
        [DisplayName("archiv")]
        public byte Archive { get; set; }


        /// <summary>
        /// kod
        /// va�e katalogov� ozna�en� v�robku
        /// </summary>
        [DisplayName("kod")]
        public string Code { get; set; }


        /// <summary>
        /// kod_vyrobku
        /// k�d produktu, kter� ud�v� v�robce
        /// </summary>
        [DisplayName("kod_vyrobku")]
        public string ProductCode { get; set; }


        /// <summary>
        /// ean
        /// ��rov� k�d (EAN) v�robku
        /// </summary>
        [DisplayName("ean")]
        public string EAN { get; set; }


        /// <summary>
        /// isbn
        /// ISBN - mezin�rodn� standardn� ��slo knihy
        /// </summary>
        [DisplayName("isbn")]
        public string ISBN { get; set; }


        /// <summary>
        /// nazev
        /// p�esn� n�zev v�robku, bez p��vlastk�!
        /// </summary>
        [DisplayName("nazev")]
        public string Name { get; set; }


        /// <summary>
        /// privlastek
        /// p��vlastek n�zvu (nap�. + zdarma, upout�vky ..)
        /// </summary>
        [DisplayName("privlastek")]
        public string Attribute { get; set; }


        /// <summary>
        /// vyrobce
        /// jm�no v�robce, pokud nen� v datab�zi je automaticky p�id�n
        /// </summary>
        [DisplayName("vyrobce")]
        public string Manufacturer { get; set; }


        /// <summary>
        /// cena
        /// prodejn� cena bez DPH
        /// </summary>
        [DisplayName("cena")]
        public double Price { get; set; }


        /// <summary>
        /// cena_bezna
        /// b�n� informativn� cena
        /// </summary>
        [DisplayName("cena_bezna")]
        public double RegularPrice { get; set; }


        /// <summary>
        /// cena_nakupni
        /// n�kupn� cena s DPH
        /// </summary>
        [DisplayName("cena_nakupni")]
        public double PurchasePrice { get; set; }


        /// <summary>
        /// recyklacni_poplatek
        /// recykla�n� poplatek u produktu
        /// </summary>
        [DisplayName("recyklacni_poplatek")]
        public double RecyclingFee { get; set; }


        /// <summary>
        /// dph
        /// ud�vejte v %, tak jak je m�te uvedeny v datab�zi
        /// </summary>
        [DisplayName("dph")]
        public double VAT { get; set; }


        /// <summary>
        /// sleva
        /// sleva v %
        /// </summary>
        [DisplayName("sleva")]
        public double Discount { get; set; }


        /// <summary>
        /// sleva_od
        /// sleva platn� od data
        /// </summary>
        [DisplayName("sleva_od")]

        public DateTime DiscountFrom { get; set; }


        /// <summary>
        /// sleva_do
        /// sleva platn� do data
        /// </summary>
        [DisplayName("sleva_do")]
        public DateTime DiscountTo { get; set; }


        /// <summary>
        /// popis
        /// popis v�robku, m��ete pou��vat i HTML tagy
        /// </summary>
        [DisplayName("popis")]
        public string Description { get; set; }


        /// <summary>
        /// popis_strucny
        /// stru�n� popis v�robku
        /// </summary>
        [DisplayName("popis_strucny")]
        public string BriefDescription { get; set; }


        /// <summary>
        /// kosik
        /// 1 - m��e se vlo�it, 0 - nem��e
        /// </summary>
        [DisplayName("kosik")]
        public byte Basket { get; set; } = 1;


        /// <summary>
        /// home
        /// 1 - zbo�� bude zobrazeno na �vodn� str�nce, 0 - nebude
        /// </summary>
        [DisplayName("home")]
        public byte HomePage { get; set; }


        /// <summary>
        /// dostupnost
        /// uv�d�jte p�esn� jako je ulo�eno v datab�zi, jin� hodnoty budou p�id�ny a bude doch�zet k duplicitn�m z�znam�m
        /// </summary>
        [DisplayName("dostupnost")]
        public string Availability { get; set; } = "-";


        /// <summary>
        /// doprava_zdarma
        /// 1 - doprava zdarma, 0 - doprava dle cen�ku
        /// </summary>
        [DisplayName("doprava_zdarma")]
        public byte FreeShipping { get; set; }


        /// <summary>
        /// dodaci_doba
        /// dodac� doba mus� b�t uv�d�na jako doba od p�ijet� platby (v p��pad� dob�rky od p�ijet� objedn�vky) do expedice zbo��.
        /// </summary>
        [DisplayName("dodaci_doba")]
        public string DeliveryTime { get; set; }


        /// <summary>
        /// dodaci_doba_auto
        /// automatick� dodac� doba z dostupnosti produkt�
        /// </summary>
        [DisplayName("dodaci_doba_auto")]
        public string DeliveryTimeAuto { get; set; }


        /// <summary>
        /// sklad
        /// 1 - pou��vat, 0 - nepou��vat
        /// </summary>
        [DisplayName("sklad")]
        public byte Stock { get; set; }


        /// <summary>
        /// na_sklade
        /// po�et kus� na sklad�, pokud sklad pou��vate
        /// </summary>
        [DisplayName("na_sklade")]
        public int InStock { get; set; }


        /// <summary>
        /// hmotnost
        /// hmotnost uv�d�jte v kg
        /// </summary>
        [DisplayName("hmotnost")]
        public double Weight { get; set; }


        /// <summary>
        /// delka
        /// d�lka produktu v metrech
        /// </summary>
        [DisplayName("delka")]
        public double Length { get; set; }


        /// <summary>
        /// jednotka
        /// jednotka produktu
        /// </summary>
        [DisplayName("jednotka")]
        public string Unit { get; set; } = "ks";


        /// <summary>
        /// odber_po
        /// po jak�m mno�stv� lze odeb�rat produkt
        /// </summary>
        [DisplayName("odber_po")]
        public int PiecesBy { get; set; } = 1;


        /// <summary>
        /// odber_min
        /// minim�ln� odb�r kus� produktu
        /// </summary>
        [DisplayName("odber_min")]
        public int PiecesMin { get; set; } = 1;


        /// <summary>
        /// odber_max
        /// maxim�ln� odb�r kus� produktu
        /// </summary>
        [DisplayName("odber_max")]
        public int PiecesMax { get; set; }


        /// <summary>
        /// pocet
        /// po�et na jednotku (v balen�)
        /// </summary>
        [DisplayName("pocet")]
        public int QuantityPerPackage { get; set; } = 1;


        /// <summary>
        /// zaruka
        /// z�ruka produkt s jednotkami (hodin = "h", den = "d", m�s�c = "m", rok = "r", "bez z�ruky", "do�ivotn� z�ruka", "uvedena na obalu", "neuvedena")
        /// </summary>
        [DisplayName("zaruka")]
        public string Warranty { get; set; } = "neuvedena";


        /// <summary>
        /// seo_titulek
        /// titulka str�nky pro SEO optimalizaci
        /// </summary>
        [DisplayName("seo_titulek")]
        public string SeoTitle { get; set; }


        /// <summary>
        /// seo_popis
        /// popis produktu pro SEO optimalizaci
        /// </summary>
        [DisplayName("seo_popis")]
        public string SeoDescription { get; set; }


        /// <summary>
        /// marze_dodavatel
        /// % mar�e na cenu od dodavatele. Pou�ito pouze p�i nastaven� na m�ru.
        /// </summary>
        [DisplayName("marze_dodavatel")]
        public double SupplierMargin { get; set; }


        /// <summary>
        /// cena_dodavatel
        /// Vypne aktualizaci ceny od dodavatele. Pou�ito pouze p�i nastaven� na m�ru. (1 - neaktualizovat, 0 - aktualizovat)
        /// </summary>
        [DisplayName("cena_dodavatel")]
        public byte SupplierPrice { get; set; } = 1;


        /// <summary>
        /// eroticke
        /// ozna�en� erotick�ho produktu (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("eroticke")]
        public byte AdultContent { get; set; }


        /// <summary>
        /// pro_dospele
        /// ozna�en� produktu pro dosp�l� (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("pro_dospele")]
        public byte ForAdults { get; set; }


        /// <summary>
        /// slevovy_kupon
        /// povolen� slevov�ho kup�nu v objedn�vce (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("slevovy_kupon")]
        public byte DiscountCoupon { get; set; } = 1;


        /// <summary>
        /// darek_objednavka
        /// povolen� d�rku k objedn�vce (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("darek_objednavka")]
        public byte OrderGift { get; set; }


        /// <summary>
        /// priorita
        /// ur�uje po�ad� na v�pisu zbo��
        /// </summary>
        [DisplayName("priorita")]
        public byte Priority { get; set; }


        /// <summary>
        /// poznamka
        /// intern� pozn�mka u produktu
        /// </summary>
        [DisplayName("poznamka")]
        public string Note { get; set; }


        /// <summary>
        /// dodavatel_id
        /// ID dodavatele
        /// </summary>
        [DisplayName("dodavatel_id")]
        public int SupplierId { get; set; }


        /// <summary>
        /// dodavatel_kod
        /// Kod dodavatele
        /// </summary>
        [DisplayName("dodavatel_kod")]
        public string SupplierCode { get; set; }


        /// <summary>
        /// stitky
        /// �t�tky (odd�len� ��rkou)
        /// </summary>
        [DisplayName("stitky")]
        public List<string> Labels { get; set; }


        /// <summary>
        /// kategorie_id
        /// id p�i�azen�ch kategori�
        /// </summary>
        [DisplayName("kategorie_id")]
        public List<int> CategoryIds { get; set; }


        /// <summary>
        /// podobne
        /// podobn� zbo�� (id produktu odd�len� ��rkou)
        /// </summary>
        [DisplayName("podobne")]
        public List<int> SimilarProducts { get; set; }


        /// <summary>
        /// prislusenstvi
        /// p��slu�enstv� (id produktu odd�len� ��rkou)
        /// </summary>
        [DisplayName("prislusenstvi")]
        public List<int> Accessories { get; set; }


        /// <summary>
        /// variantove
        /// variantov� produkty (id produktu odd�len� ��rkou)
        /// </summary>
        [DisplayName("variantove")]
        public List<int> Variants { get; set; }


        /// <summary>
        /// zdarma
        /// d�rky zdarma (id produktu odd�len� ��rkou)
        /// </summary>
        [DisplayName("zdarma")]
        public List<int> Free { get; set; }


        /// <summary>
        /// sluzby
        /// slu�by (id slu�by odd�len� ��rkou)
        /// </summary>
        [DisplayName("sluzby")]
        public List<int> Services { get; set; }


        /// <summary>
        /// rozsirujici_obsah
        /// roz�i�uj�c� obsah (id obsahu odd�len� ��rkou)
        /// </summary>
        [DisplayName("rozsirujici_obsah")]
        public List<int> ExpandingContent { get; set; }


        /// <summary>
        /// zbozicz_skryt
        /// skryt� v katalogu zbozi.cz (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("zbozicz_skryt")]
        public byte ZboziCzHideProduct { get; set; }


        /// <summary>
        /// zbozicz_productname
        /// p�esn� n�zev zbo�� pro katalog zbozi.cz.
        /// </summary>
        [DisplayName("zbozicz_productname")]
        public string ZboziCzProductName { get; set; }


        /// <summary>
        /// zbozicz_product
        /// n�zev nab�dky ve vyhled�v�n� pro katalog zbozi.cz.
        /// </summary>
        [DisplayName("zbozicz_product")]
        public string ZboziCzProduct { get; set; }


        /// <summary>
        /// zbozicz_cpc
        /// cena za proklik v detailu pro katalog zbozi.cz.
        /// </summary>
        [DisplayName("zbozicz_cpc")]
        public double ZboziCzCPC { get; set; }


        /// <summary>
        /// zbozicz_cpc_search
        /// cena za proklik v nab�dce pro katalog zbozi.cz.
        /// </summary>
        [DisplayName("zbozicz_cpc_search")]
        public double ZboziCzCPCSearch { get; set; }


        /// <summary>
        /// zbozicz_kategorie
        /// kategorie dle katalogu zbozi.cz.
        /// </summary>
        [DisplayName("zbozicz_kategorie")]
        public string ZboziCzCategory { get; set; }


        /// <summary>
        /// zbozicz_stitek_0
        /// dodate�n� ozna�en� nab�dky
        /// </summary>
        [DisplayName("zbozicz_stitek_0")]
        public string ZboziCzLabel0 { get; set; }


        /// <summary>
        /// zbozicz_stitek_1
        /// dodate�n� ozna�en� nab�dky
        /// </summary>
        [DisplayName("zbozicz_stitek_1")]
        public string ZboziCzLabel1 { get; set; }


        /// <summary>
        /// zbozicz_extra
        /// dopl�kov� informace o nab�dce v katalogu zbozi.cz (free_gift, extended_warranty, voucher, ...). V�ce mo�nost� odd�lte ��rkou.
        /// </summary>
        [DisplayName("zbozicz_extra")]
        public string ZboziCzExtra { get; set; }


        /// <summary>
        /// heurekacz_skryt
        /// skryt� v katalogu heureka.cz (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("heurekacz_skryt")]
        public byte HeurekaHide { get; set; }


        /// <summary>
        /// heurekacz_productname
        /// p�esn� n�zev zbo�� pro katalog heureka.cz.
        /// </summary>
        [DisplayName("heurekacz_productname")]
        public string HeurekaProductName { get; set; }


        /// <summary>
        /// heurekacz_product
        /// n�zev nab�dky ve vyhled�v�n� pro katalog heureka.cz.
        /// </summary>
        [DisplayName("heurekacz_product")]
        public string HeurekaProduct { get; set; }


        /// <summary>
        /// heurekacz_cpc
        /// maxim�ln� cena za proklik pro katalog heureka.cz.
        /// </summary>
        [DisplayName("heurekacz_cpc")]
        public double HeurekaCPC { get; set; }


        /// <summary>
        /// heurekacz_kategorie
        /// kategorie dle heureka.cz.
        /// </summary>
        [DisplayName("heurekacz_kategorie")]
        public string HeurekaCategory { get; set; }


        /// <summary>
        /// google_skryt
        /// skryt� v katalogu google n�kupy (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("google_skryt")]
        public byte HideOnGoogle { get; set; }


        /// <summary>
        /// google_kategorie
        /// kategorie dle google n�kupy
        /// </summary>
        [DisplayName("google_kategorie")]
        public string GoogleCategory { get; set; }


        /// <summary>
        /// google_stitek_0
        /// vlastn� �t�tek pro ozna�en� kampan�
        /// </summary>
        [DisplayName("google_stitek_0")]
        public string GoogleLabel0 { get; set; }


        /// <summary>
        /// google_stitek_1
        /// vlastn� �t�tek pro ozna�en� kampan�
        /// </summary>
        [DisplayName("google_stitek_1")]
        public string GoogleLabel1 { get; set; }


        /// <summary>
        /// google_stitek_2
        /// vlastn� �t�tek pro ozna�en� kampan�
        /// </summary>
        [DisplayName("google_stitek_2")]
        public string GoogleLabel2 { get; set; }


        /// <summary>
        /// google_stitek_3
        /// vlastn� �t�tek pro ozna�en� kampan�
        /// </summary>
        [DisplayName("google_stitek_3")]
        public string GoogleLabel3 { get; set; }


        /// <summary>
        /// google_stitek_4
        /// vlastn� �t�tek pro ozna�en� kampan�
        /// </summary>
        [DisplayName("google_stitek_4")]
        public string GoogleLabel4 { get; set; }


        /// <summary>
        /// glami_skryt
        /// skryt� v katalogu glami.cz (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("glami_skryt")]
        public byte GlamiHide { get; set; }


        /// <summary>
        /// glami_kategorie
        /// kategorie dle glami.cz
        /// </summary>
        [DisplayName("glami_kategorie")]
        public string GlamiCategory { get; set; }


        /// <summary>
        /// glami_cpc
        /// Nastaven� vlastn� CPC pro produkt pro desktop. Hodnota se pou�ije pokud je vy��� ne� z�kladn� hodnota pro kategorii. Uve�te absolutn� hodnoty v CZK bez m�ny.
        /// </summary>
        [DisplayName("glami_cpc")]
        public double GlamiCPC { get; set; }


        /// <summary>
        /// glami_voucher
        /// V tomto tagu po�lete ID p�i�azen� ke slevov�mu kup�nu, kter� jste vytvo�ili v administraci pro partnery. Pou�ijte hodnotu ze sloupce Voucher ID.
        /// </summary>
        [DisplayName("glami_voucher")]
        public int GlamiVoucher { get; set; }


        /// <summary>
        /// glami_material
        /// Uve�te typ materi�lu a jeho procentu�ln� pod�l v produktu. Materi�l mus� b�t p�esn� v n�sleduj�c�m form�tu: bavlna:60%,polyester:20%
        /// </summary>
        [DisplayName("glami_material")]
        public string GlamiMaterial { get; set; }


        /// <summary>
        /// glamisk_material
        /// Uve�te typ materi�lu a jeho procentu�ln� pod�l v produktu. Materi�l mus� b�t p�esn� v n�sleduj�c�m form�tu: bavlna:60%,polyester:20%
        /// </summary>
        [DisplayName("glamisk_material")]
        public string GlamiskMaterial { get; set; }


        /// <summary>
        /// sklad_umisteni
        /// Um�st�n� produktu na skladu
        /// </summary>
        [DisplayName("sklad_umisteni")]
        public string StockLocation { get; set; }


        /// <summary>
        /// sklad_minimalni
        /// Minim�ln� mno�stv� na sklad�
        /// </summary>
        [DisplayName("sklad_minimalni")]
        public int StockMinimum { get; set; }


        /// <summary>
        /// sklad_optimalni
        /// Optim�ln� mno�stv� na sklad�
        /// </summary>
        [DisplayName("sklad_optimalni")]
        public int StockOptimal { get; set; }


        /// <summary>
        /// sklad_maximalni
        /// Maxim�ln� mno�stv� na sklad�
        /// </summary>
        [DisplayName("sklad_maximalni")]
        public int StockMaximum { get; set; }
        [DisplayName("varianta_id")]
        public int VariantID { get; set; }
        [DisplayName("varianta_stejne")]
        public byte VariantSame { get; set; }
        [DisplayName("varianta_produkt")]
        public string VariantProduct { get; set; }
        [DisplayName("varianta3_nazev")]
        public string Variant3Name { get; set; }
        [DisplayName("varianta2_nazev")]
        public string Variant2Name { get; set; }
        [DisplayName("varianta1_nazev")]
        public string Variant1Name { get; set; }
        [DisplayName("varianta1_hodnota")]
        public string Variant1Value { get; set; }
        [DisplayName("varianta2_hodnota")]
        public string Variant2Value { get; set; }
        [DisplayName("varianta3_hodnota")]
        public string Variant3Value { get; set; }





        /// <summary>
        /// cena_s
        /// </summary>
        [DisplayName("cena_s")]
        public double PriceReal { get; set; }

    }
}