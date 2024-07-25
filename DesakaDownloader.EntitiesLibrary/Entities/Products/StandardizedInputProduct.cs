using System.ComponentModel;

namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public class StandardizedInputProduct
    {
        /// <summary>
        /// id
        /// id produktu (musí být vyplnìn pøi následné editaci zboží)
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
        /// 1 - aktivní, 0 - neaktivní
        /// </summary>
        [DisplayName("archiv")]
        public byte Archive { get; set; }


        /// <summary>
        /// kod
        /// vaše katalogové oznaèení výrobku
        /// </summary>
        [DisplayName("kod")]
        public string Code { get; set; }


        /// <summary>
        /// kod_vyrobku
        /// kód produktu, který udává výrobce
        /// </summary>
        [DisplayName("kod_vyrobku")]
        public string ProductCode { get; set; }


        /// <summary>
        /// ean
        /// èárový kód (EAN) výrobku
        /// </summary>
        [DisplayName("ean")]
        public string EAN { get; set; }


        /// <summary>
        /// isbn
        /// ISBN - mezinárodní standardní èíslo knihy
        /// </summary>
        [DisplayName("isbn")]
        public string ISBN { get; set; }


        /// <summary>
        /// nazev
        /// pøesný název výrobku, bez pøívlastkù!
        /// </summary>
        [DisplayName("nazev")]
        public string Name { get; set; }


        /// <summary>
        /// privlastek
        /// pøívlastek názvu (napø. + zdarma, upoutávky ..)
        /// </summary>
        [DisplayName("privlastek")]
        public string Attribute { get; set; }


        /// <summary>
        /// vyrobce
        /// jméno výrobce, pokud není v databázi je automaticky pøidán
        /// </summary>
        [DisplayName("vyrobce")]
        public string Manufacturer { get; set; }


        /// <summary>
        /// cena
        /// prodejní cena bez DPH
        /// </summary>
        [DisplayName("cena")]
        public double Price { get; set; }


        /// <summary>
        /// cena_bezna
        /// bìžná informativní cena
        /// </summary>
        [DisplayName("cena_bezna")]
        public double RegularPrice { get; set; }


        /// <summary>
        /// cena_nakupni
        /// nákupní cena s DPH
        /// </summary>
        [DisplayName("cena_nakupni")]
        public double PurchasePrice { get; set; }


        /// <summary>
        /// recyklacni_poplatek
        /// recyklaèní poplatek u produktu
        /// </summary>
        [DisplayName("recyklacni_poplatek")]
        public double RecyclingFee { get; set; }


        /// <summary>
        /// dph
        /// udávejte v %, tak jak je máte uvedeny v databázi
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
        /// sleva platná od data
        /// </summary>
        [DisplayName("sleva_od")]

        public DateTime DiscountFrom { get; set; }


        /// <summary>
        /// sleva_do
        /// sleva platná do data
        /// </summary>
        [DisplayName("sleva_do")]
        public DateTime DiscountTo { get; set; }


        /// <summary>
        /// popis
        /// popis výrobku, mùžete používat i HTML tagy
        /// </summary>
        [DisplayName("popis")]
        public string Description { get; set; }


        /// <summary>
        /// popis_strucny
        /// struèný popis výrobku
        /// </summary>
        [DisplayName("popis_strucny")]
        public string BriefDescription { get; set; }


        /// <summary>
        /// kosik
        /// 1 - mùže se vložit, 0 - nemùže
        /// </summary>
        [DisplayName("kosik")]
        public byte Basket { get; set; } = 1;


        /// <summary>
        /// home
        /// 1 - zboží bude zobrazeno na úvodní stránce, 0 - nebude
        /// </summary>
        [DisplayName("home")]
        public byte HomePage { get; set; }


        /// <summary>
        /// dostupnost
        /// uvádìjte pøesnì jako je uloženo v databázi, jiné hodnoty budou pøidány a bude docházet k duplicitním záznamùm
        /// </summary>
        [DisplayName("dostupnost")]
        public string Availability { get; set; } = "-";


        /// <summary>
        /// doprava_zdarma
        /// 1 - doprava zdarma, 0 - doprava dle ceníku
        /// </summary>
        [DisplayName("doprava_zdarma")]
        public byte FreeShipping { get; set; }


        /// <summary>
        /// dodaci_doba
        /// dodací doba musí být uvádìna jako doba od pøijetí platby (v pøípadì dobírky od pøijetí objednávky) do expedice zboží.
        /// </summary>
        [DisplayName("dodaci_doba")]
        public string DeliveryTime { get; set; }


        /// <summary>
        /// dodaci_doba_auto
        /// automatická dodací doba z dostupnosti produktù
        /// </summary>
        [DisplayName("dodaci_doba_auto")]
        public string DeliveryTimeAuto { get; set; }


        /// <summary>
        /// sklad
        /// 1 - používat, 0 - nepoužívat
        /// </summary>
        [DisplayName("sklad")]
        public byte Stock { get; set; }


        /// <summary>
        /// na_sklade
        /// poèet kusù na skladì, pokud sklad používate
        /// </summary>
        [DisplayName("na_sklade")]
        public int InStock { get; set; }


        /// <summary>
        /// hmotnost
        /// hmotnost uvádìjte v kg
        /// </summary>
        [DisplayName("hmotnost")]
        public double Weight { get; set; }


        /// <summary>
        /// delka
        /// délka produktu v metrech
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
        /// po jakém množství lze odebírat produkt
        /// </summary>
        [DisplayName("odber_po")]
        public int PiecesBy { get; set; } = 1;


        /// <summary>
        /// odber_min
        /// minimální odbìr kusù produktu
        /// </summary>
        [DisplayName("odber_min")]
        public int PiecesMin { get; set; } = 1;


        /// <summary>
        /// odber_max
        /// maximální odbìr kusù produktu
        /// </summary>
        [DisplayName("odber_max")]
        public int PiecesMax { get; set; }


        /// <summary>
        /// pocet
        /// poèet na jednotku (v balení)
        /// </summary>
        [DisplayName("pocet")]
        public int QuantityPerPackage { get; set; } = 1;


        /// <summary>
        /// zaruka
        /// záruka produkt s jednotkami (hodin = "h", den = "d", mìsíc = "m", rok = "r", "bez záruky", "doživotní záruka", "uvedena na obalu", "neuvedena")
        /// </summary>
        [DisplayName("zaruka")]
        public string Warranty { get; set; } = "neuvedena";


        /// <summary>
        /// seo_titulek
        /// titulka stránky pro SEO optimalizaci
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
        /// % marže na cenu od dodavatele. Použito pouze pøi nastavení na míru.
        /// </summary>
        [DisplayName("marze_dodavatel")]
        public double SupplierMargin { get; set; }


        /// <summary>
        /// cena_dodavatel
        /// Vypne aktualizaci ceny od dodavatele. Použito pouze pøi nastavení na míru. (1 - neaktualizovat, 0 - aktualizovat)
        /// </summary>
        [DisplayName("cena_dodavatel")]
        public byte SupplierPrice { get; set; } = 1;


        /// <summary>
        /// eroticke
        /// oznaèení erotického produktu (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("eroticke")]
        public byte AdultContent { get; set; }


        /// <summary>
        /// pro_dospele
        /// oznaèení produktu pro dospìlé (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("pro_dospele")]
        public byte ForAdults { get; set; }


        /// <summary>
        /// slevovy_kupon
        /// povolení slevového kupónu v objednávce (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("slevovy_kupon")]
        public byte DiscountCoupon { get; set; } = 1;


        /// <summary>
        /// darek_objednavka
        /// povolení dárku k objednávce (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("darek_objednavka")]
        public byte OrderGift { get; set; }


        /// <summary>
        /// priorita
        /// urèuje poøadí na výpisu zboží
        /// </summary>
        [DisplayName("priorita")]
        public byte Priority { get; set; }


        /// <summary>
        /// poznamka
        /// interní poznámka u produktu
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
        /// štítky (oddìlené èárkou)
        /// </summary>
        [DisplayName("stitky")]
        public List<string> Labels { get; set; }


        /// <summary>
        /// kategorie_id
        /// id pøiøazených kategorií
        /// </summary>
        [DisplayName("kategorie_id")]
        public List<int> CategoryIds { get; set; }


        /// <summary>
        /// podobne
        /// podobné zboží (id produktu oddìlené èárkou)
        /// </summary>
        [DisplayName("podobne")]
        public List<int> SimilarProducts { get; set; }


        /// <summary>
        /// prislusenstvi
        /// pøíslušenství (id produktu oddìlené èárkou)
        /// </summary>
        [DisplayName("prislusenstvi")]
        public List<int> Accessories { get; set; }


        /// <summary>
        /// variantove
        /// variantové produkty (id produktu oddìlené èárkou)
        /// </summary>
        [DisplayName("variantove")]
        public List<int> Variants { get; set; }


        /// <summary>
        /// zdarma
        /// dárky zdarma (id produktu oddìlené èárkou)
        /// </summary>
        [DisplayName("zdarma")]
        public List<int> Free { get; set; }


        /// <summary>
        /// sluzby
        /// služby (id služby oddìlené èárkou)
        /// </summary>
        [DisplayName("sluzby")]
        public List<int> Services { get; set; }


        /// <summary>
        /// rozsirujici_obsah
        /// rozšiøující obsah (id obsahu oddìlené èárkou)
        /// </summary>
        [DisplayName("rozsirujici_obsah")]
        public List<int> ExpandingContent { get; set; }


        /// <summary>
        /// zbozicz_skryt
        /// skrytí v katalogu zbozi.cz (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("zbozicz_skryt")]
        public byte ZboziCzHideProduct { get; set; }


        /// <summary>
        /// zbozicz_productname
        /// pøesný název zboží pro katalog zbozi.cz.
        /// </summary>
        [DisplayName("zbozicz_productname")]
        public string ZboziCzProductName { get; set; }


        /// <summary>
        /// zbozicz_product
        /// název nabídky ve vyhledávání pro katalog zbozi.cz.
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
        /// cena za proklik v nabídce pro katalog zbozi.cz.
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
        /// dodateèné oznaèení nabídky
        /// </summary>
        [DisplayName("zbozicz_stitek_0")]
        public string ZboziCzLabel0 { get; set; }


        /// <summary>
        /// zbozicz_stitek_1
        /// dodateèné oznaèení nabídky
        /// </summary>
        [DisplayName("zbozicz_stitek_1")]
        public string ZboziCzLabel1 { get; set; }


        /// <summary>
        /// zbozicz_extra
        /// doplòkové informace o nabídce v katalogu zbozi.cz (free_gift, extended_warranty, voucher, ...). Více možností oddìlte èárkou.
        /// </summary>
        [DisplayName("zbozicz_extra")]
        public string ZboziCzExtra { get; set; }


        /// <summary>
        /// heurekacz_skryt
        /// skrytí v katalogu heureka.cz (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("heurekacz_skryt")]
        public byte HeurekaHide { get; set; }


        /// <summary>
        /// heurekacz_productname
        /// pøesný název zboží pro katalog heureka.cz.
        /// </summary>
        [DisplayName("heurekacz_productname")]
        public string HeurekaProductName { get; set; }


        /// <summary>
        /// heurekacz_product
        /// název nabídky ve vyhledávání pro katalog heureka.cz.
        /// </summary>
        [DisplayName("heurekacz_product")]
        public string HeurekaProduct { get; set; }


        /// <summary>
        /// heurekacz_cpc
        /// maximální cena za proklik pro katalog heureka.cz.
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
        /// skrytí v katalogu google nákupy (1 - ano, 0 - ne)
        /// </summary>
        [DisplayName("google_skryt")]
        public byte HideOnGoogle { get; set; }


        /// <summary>
        /// google_kategorie
        /// kategorie dle google nákupy
        /// </summary>
        [DisplayName("google_kategorie")]
        public string GoogleCategory { get; set; }


        /// <summary>
        /// google_stitek_0
        /// vlastní štítek pro oznaèení kampaní
        /// </summary>
        [DisplayName("google_stitek_0")]
        public string GoogleLabel0 { get; set; }


        /// <summary>
        /// google_stitek_1
        /// vlastní štítek pro oznaèení kampaní
        /// </summary>
        [DisplayName("google_stitek_1")]
        public string GoogleLabel1 { get; set; }


        /// <summary>
        /// google_stitek_2
        /// vlastní štítek pro oznaèení kampaní
        /// </summary>
        [DisplayName("google_stitek_2")]
        public string GoogleLabel2 { get; set; }


        /// <summary>
        /// google_stitek_3
        /// vlastní štítek pro oznaèení kampaní
        /// </summary>
        [DisplayName("google_stitek_3")]
        public string GoogleLabel3 { get; set; }


        /// <summary>
        /// google_stitek_4
        /// vlastní štítek pro oznaèení kampaní
        /// </summary>
        [DisplayName("google_stitek_4")]
        public string GoogleLabel4 { get; set; }


        /// <summary>
        /// glami_skryt
        /// skrytí v katalogu glami.cz (1 - ano, 0 - ne)
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
        /// Nastavení vlastní CPC pro produkt pro desktop. Hodnota se použije pokud je vyšší než základní hodnota pro kategorii. Uveïte absolutní hodnoty v CZK bez mìny.
        /// </summary>
        [DisplayName("glami_cpc")]
        public double GlamiCPC { get; set; }


        /// <summary>
        /// glami_voucher
        /// V tomto tagu pošlete ID pøiøazené ke slevovému kupónu, který jste vytvoøili v administraci pro partnery. Použijte hodnotu ze sloupce Voucher ID.
        /// </summary>
        [DisplayName("glami_voucher")]
        public int GlamiVoucher { get; set; }


        /// <summary>
        /// glami_material
        /// Uveïte typ materiálu a jeho procentuální podíl v produktu. Materiál musí být pøesnì v následujícím formátu: bavlna:60%,polyester:20%
        /// </summary>
        [DisplayName("glami_material")]
        public string GlamiMaterial { get; set; }


        /// <summary>
        /// glamisk_material
        /// Uveïte typ materiálu a jeho procentuální podíl v produktu. Materiál musí být pøesnì v následujícím formátu: bavlna:60%,polyester:20%
        /// </summary>
        [DisplayName("glamisk_material")]
        public string GlamiskMaterial { get; set; }


        /// <summary>
        /// sklad_umisteni
        /// Umístìní produktu na skladu
        /// </summary>
        [DisplayName("sklad_umisteni")]
        public string StockLocation { get; set; }


        /// <summary>
        /// sklad_minimalni
        /// Minimální množství na skladì
        /// </summary>
        [DisplayName("sklad_minimalni")]
        public int StockMinimum { get; set; }


        /// <summary>
        /// sklad_optimalni
        /// Optimální množství na skladì
        /// </summary>
        [DisplayName("sklad_optimalni")]
        public int StockOptimal { get; set; }


        /// <summary>
        /// sklad_maximalni
        /// Maximální množství na skladì
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