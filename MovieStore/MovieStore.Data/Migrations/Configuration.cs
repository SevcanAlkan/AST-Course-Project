namespace MovieStore.Data.Migrations
{
    using MovieStore.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            try
            {
                #region Languages

                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ab", Name = "Abkhaz", NativeName = "аҧсуа" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "aa", Name = "Afar", NativeName = "Afaraf" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "af", Name = "Afrikaans", NativeName = "Afrikaans" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ak", Name = "Akan", NativeName = "Akan" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sq", Name = "Albanian", NativeName = "Shqip" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "am", Name = "Amharic", NativeName = "አማርኛ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ar", Name = "Arabic", NativeName = "العربية" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "an", Name = "Aragonese", NativeName = "Aragonés" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "hy", Name = "Armenian", NativeName = "Հայերեն" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "as", Name = "Assamese", NativeName = "অসমীয়া" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "av", Name = "Avaric", NativeName = "авар мацӀ, магӀарул мацӀ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ae", Name = "Aymara", NativeName = "aymar aru" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "az", Name = "Azerbaijani", NativeName = "azərbaycan dili" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "bm", Name = "Bambara", NativeName = "bamanankan" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ba", Name = "Bashkir", NativeName = "башҡорт теле" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "eu", Name = "Basque", NativeName = "euskara, euskera" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "be", Name = "Belarusian", NativeName = "Беларуская" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "bn", Name = "Bengali", NativeName = "বাংলা" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "bh", Name = "Bihari", NativeName = "भोजपुरी" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "bi", Name = "Bislama", NativeName = "Bislama" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "bs", Name = "Bosnian", NativeName = "bosanski jezik" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "br", Name = "Breton", NativeName = "brezhoneg" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "bg", Name = "Bulgarian", NativeName = "български език" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "my", Name = "Burmese", NativeName = "аဗမာစာ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ca", Name = "Catalan; Valencian", NativeName = "Català" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ch", Name = "Chamorro", NativeName = "Chamoru" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ce", Name = "Chechen", NativeName = "нохчийн мотт" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ny", Name = "Chichewa; Chewa; Nyanja", NativeName = "chiCheŵa, chinyanja" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "zh", Name = "Chinese", NativeName = "中文 (Zhōngwén), 汉语, 漢語" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "cv", Name = "Chuvash", NativeName = "чӑваш чӗлхи" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "kw", Name = "Cornish", NativeName = "Kernewek" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "co", Name = "Corsican", NativeName = "corsu, lingua corsa" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "cr", Name = "Cree", NativeName = "ᓀᐦᐃᔭᐍᐏᐣ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "hr", Name = "Croatian", NativeName = "hrvatski" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "cs", Name = "Czech", NativeName = "česky, čeština" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "da", Name = "da", NativeName = "dansk" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "dv", Name = "Divehi; Dhivehi; Maldivian", NativeName = "ދިވެހި" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "nl", Name = "Dutch", NativeName = "Nederlands, Vlaams" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "en", Name = "English", NativeName = "English" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "eo", Name = "Esperanto", NativeName = "Esperanto" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "et", Name = "Estonian", NativeName = "eesti, eesti keel" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ee", Name = "Ewe", NativeName = "Eʋegbe" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "fo", Name = "Faroese", NativeName = "føroyskt" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "fj", Name = "Fijian", NativeName = "vosa Vakaviti" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "fi", Name = "Finnish", NativeName = "suomi, suomen kieli" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "fr", Name = "French", NativeName = "français, langue française" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ff", Name = "Fula; Fulah; Pulaar; Pular", NativeName = "Fulfulde, Pulaar, Pular" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "gl", Name = "Galician", NativeName = "Galego" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ka", Name = "Georgian", NativeName = "ქართული" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "de", Name = "German", NativeName = "Deutsch" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "el", Name = "Greek", NativeName = "Ελληνικά" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "gn", Name = "Guaraní", NativeName = "Avañeẽ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "gu", Name = "Gujarati", NativeName = "ગુજરાતી" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ht", Name = "Haitian; Haitian Creole", NativeName = "Kreyòl ayisyen" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ha", Name = "Hausa", NativeName = "Hausa, هَوُسَ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "he", Name = "Hebrew (modern)", NativeName = "עברית" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "hz", Name = "Herero", NativeName = "Otjiherero" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "hi", Name = "Hindi", NativeName = "हिन्दी, हिंदी" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ho", Name = "Hiri Motu", NativeName = "Hiri Motu" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "hu", Name = "Hungarian", NativeName = "Magyar" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ia", Name = "Interlingua", NativeName = "Interlingua" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "id", Name = "Indonesian", NativeName = "Bahasa Indonesia" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ie", Name = "Interlingue", NativeName = "Originally called Occidental; then Interlingue after WWII" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ga", Name = "Irish", NativeName = "Gaeilge" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ig", Name = "Igbo", NativeName = "Asụsụ Igbo" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ik", Name = "Inupiaq", NativeName = "Iñupiaq, Iñupiatun" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "io", Name = "Ido", NativeName = "Ido" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "is", Name = "Icelandic", NativeName = "Íslenska" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "it", Name = "Italian", NativeName = "Italiano" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "iu", Name = "Inuktitut", NativeName = "ᐃᓄᒃᑎᑐᑦ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ja", Name = "Japanese", NativeName = "日本語 (にほんご／にっぽんご" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "jv", Name = "Javanese", NativeName = "basa Jawa" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "kl", Name = "Kalaallisut, Greenlandic", NativeName = "kalaallisut, kalaallit oqaasii" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "kn", Name = "Kannada", NativeName = "ಕನ್ನಡ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "kr", Name = "Kanuri", NativeName = "Kanuri" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ks", Name = "Kashmiri", NativeName = "कश्मीरी, كشميري" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "kk", Name = "Kazakh", NativeName = "Қазақ тілі" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "km", Name = "Khmer", NativeName = "ភាសាខ្មែរ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ki", Name = "Kikuyu, Gikuyu", NativeName = "Gĩkũyũ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "rw", Name = "Kinyarwanda", NativeName = "Ikinyarwanda" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ky", Name = "Kirghiz, Kyrgyz", NativeName = "кыргыз тили" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "kv", Name = "Komi", NativeName = "коми кыв" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "kg", Name = "Kongo", NativeName = "KiKongo" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ko", Name = "Korean", NativeName = "한국어 (韓國語), 조선말 (朝鮮語)" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "kj", Name = "Kwanyama, Kuanyama", NativeName = "Kuanyama" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "la", Name = "Latin", NativeName = "latine, lingua latina" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "lb", Name = "Luxembourgish, Letzeburgesch", NativeName = "Lëtzebuergesch" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "lg", Name = "Luganda", NativeName = "Luganda" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "li", Name = "Limburgish, Limburgan, Limburger", NativeName = "Limburgs" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ln", Name = "Lingala", NativeName = "Lingála" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "lo", Name = "Lao", NativeName = "ພາສາລາວ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "lt", Name = "Lithuanian", NativeName = "lietuvių kalba" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "lu", Name = "Luba-Katanga", NativeName = "" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "lv", Name = "Latvian", NativeName = "latviešu valoda" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "gv", Name = "Manx", NativeName = "Gaelg, Gailck" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "mk", Name = "Macedonian", NativeName = "македонски јазик" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "mg", Name = "Malagasy", NativeName = "Malagasy fiteny" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ms", Name = "Malay", NativeName = "bahasa Melayu, بهاس ملايو" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ml", Name = "Malayalam", NativeName = "മലയാളം" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "mt", Name = "Maltese", NativeName = "Malti" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "mi", Name = "Māori", NativeName = "te reo Māori" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "mr", Name = "Marathi (Marāṭhī)", NativeName = "मराठी" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "mh", Name = "Marshallese", NativeName = "Kajin M̧ajeļ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "mn", Name = "Mongolian", NativeName = "монгол" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "na", Name = "Nauru", NativeName = "Ekakairũ Naoero" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "nv", Name = "Navajo, Navaho", NativeName = "Diné bizaad, Dinékʼehǰí" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "nb", Name = "Norwegian Bokmål", NativeName = "Norsk bokmål" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "nd", Name = "North Ndebele", NativeName = "isiNdebele" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ne", Name = "Nepali", NativeName = "नेपाली" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ng", Name = "Ndonga", NativeName = "Owambo" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "nn", Name = "Norwegian Nynorsk", NativeName = "Norsk nynorsk" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "no", Name = "Norwegian", NativeName = "Norsk" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ii", Name = "Nuosu", NativeName = "Nuosuhxop" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "nr", Name = "South Ndebele", NativeName = "isiNdebele" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "oc", Name = "Occitan", NativeName = "Occitan" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "oj", Name = "Ojibwe, Ojibwa", NativeName = "ᐊᓂᔑᓈᐯᒧᐎᓐ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "cu", Name = "Old Church Slavonic, Church Slavic, Church Slavonic, Old Bulgarian, Old Slavonic", NativeName = "ѩзыкъ словѣньскъ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "om", Name = "Oromo", NativeName = "Afaan Oromoo" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "or", Name = "Oriya", NativeName = "ଓଡ଼ିଆ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "os", Name = "Ossetian, Ossetic", NativeName = "ирон æвзаг" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "pa", Name = "Panjabi, Punjabi", NativeName = "ਪੰਜਾਬੀ, پنجابی" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "pi", Name = "Pāli", NativeName = "पाऴि" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "fa", Name = "Persian", NativeName = "فارسی" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "pl", Name = "Polish", NativeName = "polski" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ps", Name = "Pashto, Pushto", NativeName = "پښتو" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "pt", Name = "Portuguese", NativeName = "Português" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "qu", Name = "Quechua", NativeName = "Runa Simi, Kichwa" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "rm", Name = "Romansh", NativeName = "rumantsch grischun" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "rn", Name = "Kirundi", NativeName = "kiRundi" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ro", Name = "Romanian, Moldavian, Moldovan", NativeName = "română" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ru", Name = "Russian", NativeName = "русский язык" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sa", Name = "Sanskrit (Saṁskṛta)", NativeName = "संस्कृतम्" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sc", Name = "Sardinian", NativeName = "sardu" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sd", Name = "Sindhi", NativeName = "सिन्धी, سنڌي، سندھی" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "se", Name = "Northern Sami", NativeName = "Davvisámegiella" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sm", Name = "Samoan", NativeName = "gagana faa Samoa" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sg", Name = "Sango", NativeName = "yângâ tî sängö" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sr", Name = "Serbian", NativeName = "српски језик" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "gd", Name = "Scottish Gaelic; Gaelic", NativeName = "Gàidhlig" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sn", Name = "Shona", NativeName = "chiShona" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "si", Name = "Sinhala, Sinhalese", NativeName = "සිංහල" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sk", Name = "Slovak", NativeName = "slovenčina" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sl", Name = "Slovene", NativeName = "slovenščina" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "so", Name = "Somali", NativeName = "Soomaaliga, af Soomaali" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "st", Name = "Southern Sotho", NativeName = "Sesotho" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "es", Name = "Spanish", NativeName = "español, castellano" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "su", Name = "Sundanese", NativeName = "Basa Sunda" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sw", Name = "Swahili", NativeName = "Kiswahili" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ss", Name = "Swati", NativeName = "SiSwati" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "sv", Name = "Swedish", NativeName = "svenska" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ta", Name = "Tamil", NativeName = "தமிழ்" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "te", Name = "Telugu", NativeName = "తెలుగు" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "tg", Name = "Tajik", NativeName = "тоҷикӣ, toğikī, تاجیکی" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "th", Name = "Thai", NativeName = "ไทย" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ti", Name = "Tigrinya", NativeName = "ትግርኛ" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "bo", Name = "Tibetan Standard, Tibetan, Central", NativeName = "བོད་ཡིག" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "tk", Name = "Turkmen", NativeName = "Türkmen, Түркмен" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "tl", Name = "Tagalog", NativeName = "Wikang Tagalog, ᜏᜒᜃᜅ᜔ ᜆᜄᜎᜓᜄ᜔" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "tn", Name = "Tswana", NativeName = "Setswana" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "to", Name = "Tonga (Tonga Islands)", NativeName = "faka Tonga" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "tr", Name = "Turkish", NativeName = "Türkçe" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ts", Name = "Tsonga", NativeName = "Xitsonga" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "tt", Name = "Tatar", NativeName = "татарча, tatarça, تاتارچا" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "tw", Name = "Twi", NativeName = "Twi" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ty", Name = "Tahitian", NativeName = "Reo Tahiti" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ug", Name = "Uighur, Uyghur", NativeName = "Uyƣurqə, ئۇيغۇرچە" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "uk", Name = "Ukrainian", NativeName = "українська" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ur", Name = "Urdu", NativeName = "اردو" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "uz", Name = "Uzbek", NativeName = "zbek, Ўзбек, أۇزبېك" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "ve", Name = "Venda", NativeName = "Tshivenḓa" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "vi", Name = "Vietnamese", NativeName = "Tiếng Việt" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "vo", Name = "Volapük", NativeName = "Volapük" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "wa", Name = "Walloon", NativeName = "Walon" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "cy", Name = "Welsh", NativeName = "Cymraeg" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "wo", Name = "Wolof", NativeName = "Wollof" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "fy", Name = "Western Frisian", NativeName = "Frysk" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "xh", Name = "Xhosa", NativeName = "isiXhosa" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "yi", Name = "Yiddish", NativeName = "ייִדיש" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "yo", Name = "Yoruba", NativeName = "Yorùbá" });
                context.Languages.AddOrUpdate(p => p.Code, new Language() { Id = Guid.NewGuid(), Code = "za", Name = "Zhuang, Chuang", NativeName = "Saɯ cueŋƅ, Saw cuengh" });

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}